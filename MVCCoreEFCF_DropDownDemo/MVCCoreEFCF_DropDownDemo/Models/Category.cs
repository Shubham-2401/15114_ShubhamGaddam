using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreEFCF_DropDownDemo.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
