using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Home
    {
        public ICollection<Post> Posts { get; set; }

        public Post Post { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}