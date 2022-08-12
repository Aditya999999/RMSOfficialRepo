using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]                                         // Suppress the information about the FK Collection to the API.
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]                                 // Suppress the information about the FK Collection to the API.
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [JsonIgnore]                                 // Suppress the information about the FK Collection to the API.
        public ICollection<PaymentType> PaymentTypes { get; set; }

        #endregion
    }
}
