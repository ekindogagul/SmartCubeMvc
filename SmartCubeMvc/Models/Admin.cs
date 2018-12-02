using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCubeMvc.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}