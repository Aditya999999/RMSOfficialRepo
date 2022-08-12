using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant.Web.Models
{
    [Table(name: "Payments")]
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int PaymentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string PaymentTypeName { get; set; }

        #region Navigation to the order details
        
        virtual public int OrderDetailId { get; set; }
        [JsonIgnore]                                       // Suppress the information about the FK Object to the API.
        [ForeignKey(nameof(PaymentType.OrderDetailId))]

        virtual public OrderDetail OrderDetail { get; set; }

        #endregion


        #region Navigation Properties to the Customer Model 
        virtual public int CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PaymentType.CustomerId))]

        public Customer Customer { get; set; }


        #endregion

        #region Navigation properties to the Item Name
        [Display(Name ="Order Date")]
        virtual public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(PaymentType.OrderId))]
        virtual public Order Order { get; set; }

        [Required]
        virtual public int ItemId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(PaymentType.ItemId))]
        virtual public Item Item { get; set; }

        #endregion

        [Required]
        [StringLength(10)]
        virtual public string MobileNumber { get; set; }

        [Required]
        virtual public decimal AmountPaid { get; set; }


    }
}