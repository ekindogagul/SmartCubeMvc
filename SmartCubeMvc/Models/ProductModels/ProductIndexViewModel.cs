using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCubeMvc.Models.ProductModels
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Users> Users { get; set; }
    }
}