using System;
using System.Collections.Generic;

#nullable disable

namespace BrandoAppWebAPI.Models
{
    public partial class AddToCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}
