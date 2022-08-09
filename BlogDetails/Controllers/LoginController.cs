using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogDetails.Models;
using BlogDetailsBAL.Repository;
using BlogDetailsBAL.Services;
using BlogDetailsDAL;

namespace BlogDetails.Controllers
{
    public class LoginController : Controller
    {
        private IAuthentication _authentication;
        private ILogin _login;

        public LoginController()
        {
            _authentication = new AuthenticationDetails();
            _login = new LoginRepository();
        }
        // GET: Login
        public ActionResult Index()
        {
            LoginViewModel loginView = new LoginViewModel();
            ViewBag.ErrorMsg = "";
            return View(loginView);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                string password = _authentication.EncryptString(loginView.Password);
                List<tblLoginDetail> loginDetails = new List<tblLoginDetail>();
                loginDetails = _login.FindBy(a => a.Email_Id == loginView.EmailId && a.Password == password).ToList();
                if (loginDetails.Count > 0)
                {
                    LoginViewModel login = new LoginViewModel(loginDetails[0]);
                    Session["LoginDetails"] = login; 
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    ViewBag.ErrorMsg = "Username and password is invalid";
                }
            }
            return View(loginView);
        }

        public ActionResult Register()
        {
            tblLoginDetail loginDetail = new tblLoginDetail();
            ViewBag.Error = "";
            return View(loginDetail);
        }

        [HttpPost]
        public ActionResult Register(tblLoginDetail loginDetail)
        {
            try
            {
                List<tblLoginDetail> loginlist = new List<tblLoginDetail>();
                 loginlist = _login.FindBy(a => a.Email_Id == loginDetail.Email_Id).ToList();
                if (loginlist.Count > 0)
                {
                    ViewBag.Error = "This Email Id is Already Exists";
                }
                else
                {
                    loginDetail.Password = _authentication.EncryptString(loginDetail.Password);
                    _login.Add(loginDetail);
                    _login.Save();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return View();
        }

        public ActionResult Logout()
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();

            Session["LoginDetails"] = null;
            Session.Abandon();

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Request.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }
    }
}