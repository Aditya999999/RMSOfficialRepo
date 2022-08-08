using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        virtual public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string CustomerName { get; set; }

        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdatedBy { get; set; }

        virtual public DateTime UpdatedDate { get; set; }

        #region Navigation to Collections

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; set; }

        #endregion
    }
}
