using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreEFCF_DropDownDemo.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string ProductName { get; set; }

        [Column(TypeName = "NUMERIC(9,2)")]
        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
