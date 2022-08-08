using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(PaymentType.OrderDetailId))]

        virtual public OrderDetail OrderDetail { get; set; }

        #endregion


        #region Navigation Properties to the Customer Model 
        virtual public int CustomerId { get; set; }

        [ForeignKey(nameof(PaymentType.CustomerId))]

        public Customer Customer { get; set; }


        #endregion

        #region Navigation properties to the Item Name

        virtual public int OrderId { get; set; }
        [ForeignKey(nameof(PaymentType.OrderId))]

        [Required]
        virtual public int ItemId { get; set; }
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