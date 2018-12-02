using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SmartCubeMvc.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SmartCubeMvc.Context
{
    public class SmartCubeContext : DbContext
    {
        public SmartCubeContext()
       : base("SmartCubeContext"){ //databasein adini kisaltmak icin
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
    }
   
}