using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
