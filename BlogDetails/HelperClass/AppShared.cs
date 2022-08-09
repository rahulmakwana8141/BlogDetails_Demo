using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogDetails.Models;

namespace BlogDetails.HelperClass
{
    public static class AppShared
    {
        public static LoginViewModel GetUserDetails()
        {
            LoginViewModel loginView = new LoginViewModel();
            try
            {
                if (HttpContext.Current.Session["LoginDetails"] != null)
                {
                    loginView = HttpContext.Current.Session["LoginDetails"] as LoginViewModel;
                    if (loginView.UserId <= 0)
                    {
                        if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                        {
                            HttpContext.Current.Response.Redirect("~/Login/Logout");
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/Login/Logout");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            return loginView;
        }
    }
}