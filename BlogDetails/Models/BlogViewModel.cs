using System;

namespace BlogDetails.Models
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
            title = string.Empty;
            description = string.Empty;
            Author = string.Empty;
            CreatedBy = 0;
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string Author { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}