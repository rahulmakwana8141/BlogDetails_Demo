using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using BlogDetailsBAL.Repository;
using BlogDetailsBAL.Services;
using BlogDetailsDAL;
using BlogDetails.Models;
using BlogDetails.HelperClass;

namespace BlogDetails.Controllers
{
    public class BlogController : Controller
    {
        private IBlog _blog;
        public BlogController()
        {
            _blog = new BlogRepository();
        }
        // GET: Blog
        public ActionResult Index()
        {
            LoginViewModel loginView = AppShared.GetUserDetails();
            List<tblBlogDetail> blogDetails = new List<tblBlogDetail>();
            blogDetails = _blog.GetAll().Where(a => a.IsDeleted == false).ToList();
            return View(blogDetails);
        }
        [HttpGet]
        public ActionResult BlogInsertUpate(string id)
        {
            LoginViewModel loginView = AppShared.GetUserDetails();
            tblBlogDetail tblBlog = new tblBlogDetail();
            if (string.IsNullOrEmpty(id) == false)
            {
                int BlogId = Convert.ToInt32(id);
                if (BlogId > 0)
                {
                    tblBlog = _blog.FindBy(a => a.BlogId == BlogId).FirstOrDefault();
                }
            }
            else
            {
                tblBlog.CreatedBy = 0;
                tblBlog.CreatedOn = DateTime.Now;
            }
            return View(tblBlog);
        }

        [HttpPost]
        public ActionResult BlogInsertUpate(BlogViewModel blogView)
        {
            if (ModelState.IsValid)
            {
                tblBlogDetail blogDetail = new tblBlogDetail();
                try
                {
                    blogDetail.BlogId = blogView.Id;
                    blogDetail.Title = blogView.title;
                    blogDetail.Author = blogView.Author;
                    blogDetail.Description = blogView.description;
                    blogDetail.IsDeleted = false;

                    if (blogDetail.BlogId > 0)
                    {
                        blogDetail.ModifyBy = 1;
                        blogDetail.ModifyOn = DateTime.Now;
                        blogDetail.CreatedBy = blogView.CreatedBy;
                        blogDetail.CreatedOn = blogView.CreatedOn;
                        _blog.Edit(blogDetail);
                        _blog.Save();
                    }
                    else
                    {
                        blogDetail.CreatedBy = 1;
                        blogDetail.CreatedOn = DateTime.Now;
                        _blog.Add(blogDetail);
                        _blog.Save();
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }

            }
            else
            {
                return View(blogView);
            }
            return RedirectToAction("Index");
        }

        public ActionResult BlogDelete(int id)
        {
            tblBlogDetail blogDetail = new tblBlogDetail();
            try
            {
                blogDetail = _blog.FindBy(a => a.BlogId == id).FirstOrDefault();
                blogDetail.IsDeleted = true;
                _blog.Edit(blogDetail);
                _blog.Save();

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}