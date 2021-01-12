using CORE_Blog.CORE.Map;
using CORE_Blog.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_Blog.MODEL.Maps
{
    public class CategoryMap : CoreMap<Category>
    {
        // override yazıp boşluk bıraktıktan sonra ezilebilecek metotlardan hangisi kullanılacaksa seçilip Enter tuşuna basılır.
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);

            // Silmiyoruz
            base.Configure(builder);
        }
    }
}
