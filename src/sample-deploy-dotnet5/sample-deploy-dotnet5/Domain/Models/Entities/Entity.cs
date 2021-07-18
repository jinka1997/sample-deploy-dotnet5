using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; private set; }
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedAt { get; protected set; } = null;
        [Timestamp]
        public byte[] TimeStamp { get; set; }


        protected static string GetNewGuid() => Guid.NewGuid().ToString("N");
    }
}
