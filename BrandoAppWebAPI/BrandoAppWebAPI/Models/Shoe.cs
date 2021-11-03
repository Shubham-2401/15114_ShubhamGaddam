using System;
using System.Collections.Generic;

#nullable disable

namespace BrandoAppWebAPI.Models
{
    public partial class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string Img { get; set; }
    }
}
