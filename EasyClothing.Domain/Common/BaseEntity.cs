using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
