using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant.Web.Models
{
    [Table(name: "OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int OrderDetailId { get; set; }

        #region Navigation properties to the Item Modal

        [Required]
        virtual public int ItemId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(OrderDetail.ItemId))]
        public virtual Item Item { get; set; }

        #endregion

        virtual public decimal Discount { get; set; }
       
        virtual public decimal Quantity { get; set; }

        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdatedBy { get; set; }

        virtual public DateTime UpdatedDate { get; set; }

        #region Navigation to the Order Modal
        [Required]
        virtual public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        #endregion
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaymentType> PaymentTypes { get; set; }

        #region Navigation properites to the Customer Modal
        [Required]
        virtual public int CustomerId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(OrderDetail.CustomerId))]
        public virtual Customer Customer { get; set; }

        #endregion
    }
}