using System;
using CIBPhonebook.Domain.EF.Providers;
using Microsoft.EntityFrameworkCore;

namespace CIBPhonebook.Domain.EF.Extensions
{
    public static class ConfigurationExtention
    {
        public static ModelBuilder ApplyConfiguration(this ModelBuilder modelBuilder,
            IModelBuilderConfiguration modelBuilderConfiguration)
        {
            modelBuilderConfiguration.Configure(modelBuilder);

            return modelBuilder;
        }
    }
}
