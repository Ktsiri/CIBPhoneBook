using System;
using System.Collections.Generic;
using CIBPhonebook.Common.Helpers;
using CIBPhonebook.Domain.EF.Providers;
using Microsoft.EntityFrameworkCore;
using CIBPhonebook.Domain.EF.Extensions;

namespace CIBPhonebook.Domain.EF.DomainContexts
{
    public class DomainContext : DbContext
    {
        private IList<IModelBuilderConfiguration> IModelBuilderConfigurations = new List<IModelBuilderConfiguration>();

        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            var types = ReflectionHelper.GetTypes<IModelBuilderConfiguration>();

            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is IModelBuilderConfiguration def)
                {
                    IModelBuilderConfigurations.Add(def);
                }
            }

            foreach (var item in IModelBuilderConfigurations)
            {
                modelBuilder.ApplyConfiguration(item);
            }
        }

    }
}
