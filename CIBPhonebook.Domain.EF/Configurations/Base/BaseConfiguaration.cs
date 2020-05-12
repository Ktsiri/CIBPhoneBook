using System;
using CIBPhonebook.Domain.DomainObjects.Base;
using CIBPhonebook.Domain.EF.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIBPhonebook.Domain.EF.Configurations.Base
{
    public abstract class BaseConfiguration<TEntity, TIdentity> : IModelBuilderConfiguration
        where TEntity : BaseDomainObject<TIdentity>
    {
        protected EntityTypeBuilder<TEntity> EntityBuilder { get; private set; }

        public virtual void Configure(ModelBuilder modelBuilder)
        {
            EntityBuilder = modelBuilder.Entity<TEntity>();

            EntityBuilder.HasKey(c => c.Id);

            EntityBuilder.Property(x => x.CreatedDate)
                .IsRequired();

            EntityBuilder.Property(x => x.ModifiedDate)
                .IsRequired(false);
        }
    }
}
