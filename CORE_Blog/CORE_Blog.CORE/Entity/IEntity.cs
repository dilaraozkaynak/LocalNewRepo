using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_Blog.CORE.Entity
{
    public interface IEntity<T>
    {
         T ID { get; set; }
    }
}
