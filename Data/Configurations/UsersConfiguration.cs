using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeFlow.Models;

namespace OfficeFlow.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users> 
    {
        public void Configure(EntityTypeBuilder<Users> builder )
        {
            builder.HasOne(u => u.)
        }
    }
}