using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectASP.Models
{
    public class Shipment
    {

        [Key]
        public int ShipmentId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int SoldItemsId { get; set; }

        [Required]
        public DateTime ShipmentDate { get; set; }

       
        public string  ShipementDetails { get; set; }


    }
}