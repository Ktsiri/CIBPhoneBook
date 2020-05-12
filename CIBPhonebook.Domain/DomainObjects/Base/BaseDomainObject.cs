using System;
namespace CIBPhonebook.Domain.DomainObjects.Base
{
    public abstract class BaseDomainObject<TIdentity> : DomainObject
    {
        public BaseDomainObject()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
        public TIdentity Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
