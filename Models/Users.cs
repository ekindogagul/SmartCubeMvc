namespace SmartCubeMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public partial class Users
    {
        public int ID { get; set; }

        public string username { get; set; }

        public string password { get; set; }
    }

    public class UsersDBContext : DbContext
    {
        public System.Data.Entity.DbSet<SmartCubeMvc.Models.Users> Users { get; set; }
    }
}
