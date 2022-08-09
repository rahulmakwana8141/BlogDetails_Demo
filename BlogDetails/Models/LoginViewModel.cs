using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BlogDetailsDAL;

namespace BlogDetails.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public LoginViewModel(tblLoginDetail loginDetail)
        {
            UserId = loginDetail.UserId;
            EmailId = loginDetail.Email_Id;
            Username = loginDetail.Username;
        }
        public int UserId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Password { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
    }
}