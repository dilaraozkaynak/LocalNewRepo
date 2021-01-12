﻿using CORE_Blog.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_Blog.MODEL.Entities
{
    public class Post : CoreEntity
    {
        public string Title  { get; set; }
        public string PostDetail { get; set; }
        public string Tags { get; set; }
        public string ImagePath { get; set; }
        public string ViewCount { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}