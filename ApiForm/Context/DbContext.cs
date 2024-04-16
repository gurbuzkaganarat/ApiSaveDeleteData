using ApiForm.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ApiForm.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Player> Player { get; set; }
        public DbSet<Meta> Meta { get; set; }
        public DbSet<Root> Root { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Niutari\\SQLEXPRESS; Database=PlayerDbb; User ID=SA;  Password=123; TrustServerCertificate=True") ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
