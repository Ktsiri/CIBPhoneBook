using System;
using Microsoft.EntityFrameworkCore;

namespace CIBPhonebook.Domain.EF.Providers
{
    public interface IModelBuilderConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
