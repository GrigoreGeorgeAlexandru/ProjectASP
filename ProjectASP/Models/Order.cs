using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using ProjectASP.Models;

namespace ProjectASP.Controllers
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        
       
        [Required]
        public int SoldItemsId { get; set; }
       
       

        public string OrderDetails { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }


        public virtual Customer Customer { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        public virtual Shipment Shipment { get; set; }

        public virtual SoldItems Items { get; set; }


    }
    public class OrderDBContext : DbContext
    {
        public OrderDBContext() : base("DBConnectionString") { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<SoldItems> SoldItems { get; set; }
    }




}