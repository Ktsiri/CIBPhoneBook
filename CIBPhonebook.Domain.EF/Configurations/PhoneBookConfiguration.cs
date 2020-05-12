using System;
using CIBPhonebook.Domain.DomainObjects;
using CIBPhonebook.Domain.EF.Configurations.Base;
using Microsoft.EntityFrameworkCore;

namespace CIBPhonebook.Domain.EF.Configurations
{
    public class PhoneBookConfiguration : BaseConfiguration<PhoneBook, Guid>
    {
        public override void Configure(ModelBuilder modelBuilder)
        {
            base.Configure(modelBuilder);

            EntityBuilder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            EntityBuilder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            EntityBuilder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
