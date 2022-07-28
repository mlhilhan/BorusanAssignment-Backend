using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SiparisApi.Models;

namespace SiparisApi.Data
{
    public class SiparisDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.; Initial Catalog=Siparis; Integrated Security=SSPI");
            }

        }

        public DbSet<Siparis> Siparis { get; set; }
    }
}
