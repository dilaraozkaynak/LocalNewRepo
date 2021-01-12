using CORE_Blog.CORE.Map;
using CORE_Blog.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_Blog.MODEL.Maps
{
    public class CommentMap : CoreMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.Property(x => x.CommentText).HasMaxLength(255).IsRequired(true);


            base.Configure(builder);
        }
    }
}
