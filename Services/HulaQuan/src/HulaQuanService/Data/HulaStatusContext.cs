using HulaQuanService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Data
{
    public class HulaStatusContext : DbContext
    {
        public HulaStatusContext(DbContextOptions<HulaStatusContext> options)
            : base(options)
        { }

        public DbSet<HulaStatus> HulaStatusSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HulaStatus>().ToTable("HulaStatus");
        }
    }
}
