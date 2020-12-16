using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjectASP.Models
{
    public class SoldItems
    {


        [Key]
        public int SoldItemsId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int SoldItemsQuantity { get; set; }

        [Required]
        public int SoldItemsPrice { get; set; }



    }
}