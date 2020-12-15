using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        [Required]
        public string CustomerName { get; set; }


        [Required]
        public string CustomerPassword { get; set; }


        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public int CustomerPhone { get; set; }
        [Required]
        public string CustomerAddress { get; set; }


        public virtual ICollection<Order> Orders { get; set; }


       

    }

    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext() : base("DBConnectionString") { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }



}