using CORE_Blog.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_Blog.MODEL.Entities
{
    public class Category : CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
