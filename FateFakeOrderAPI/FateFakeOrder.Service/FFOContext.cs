using FateFakeOrder.Data;
using FateFakeOrder.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FateFakeOrder.Service
{
    public class FFOContext : DbContext
    {
        public FFOContext()
        {

        }
        public FFOContext(DbContextOptions<FFOContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=.;User ID=.;Password=.;");
            }
        }

        public DbSet<Master> Masters { get; set; }
        public DbSet<Servant> Servants { get; set; }
        public DbSet<Familiar> Familiars { get; set; }
        public DbSet<User> FFOUsers { get; set; }


    }
}
