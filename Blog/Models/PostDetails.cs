﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostDetails
    {
        public Post Post { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}