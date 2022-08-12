using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant.Web.Models
{
    [Table(name: "Orders")]
    public class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int OrderId { get; set; }

        virtual public System.DateTime OrderDate { get; set; } = DateTime.Now;



        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdatedBy { get; set; }

        virtual public DateTime UpdatedDate { get; set; }

        virtual public ICollection<OrderDetail> OrderDetails { get; set; }

        #region Navigation Properties to the Customer Model 

        [Required]
        virtual public int CustomerId { get; set; }
        [JsonIgnore]                                       // Suppress the information about the FK Object to the API.
        [ForeignKey(nameof(Order.CustomerId))]
        
        public Customer Customer { get; set; }

        #endregion

        #region Navigation Properties to the Item Model 
        [Required]

        virtual public int ItemId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(Order.ItemId))]

        public Item Item { get; set; }

        #endregion


    }

}