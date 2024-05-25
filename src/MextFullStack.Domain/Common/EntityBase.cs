using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MextFullStack.Domain.Common
{
    public class EntityBase<TKey>
    {
       // public Guid Id { get; set; }

        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string CreatedByUserId { get; set; }

        public string? ModifiedByUserId { get; set; }
    }
}