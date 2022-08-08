using Restaurant.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Areas.Demos.ViewModels
{
    public class PaymentTypeViewModel : PaymentType
    {
        [Display(Name = "Payment ID")]
        [Required]
        public override int PaymentTypeId
        { 
            get { return base.PaymentTypeId; }
            set { base.PaymentTypeId = value; }
        }

        [Display(Name = "Payment Type Name")]
        [Required]
        public override string PaymentTypeName
        {
            get { return base.PaymentTypeName; }
            set { base.PaymentTypeName = value; }
        }

        [Display(Name = "{0} has placed the Order ")]
        [Required]
        public override int CustomerId
        {
            get { return base.CustomerId; }
            set { base.CustomerId = value; }
        }
        [Display(Name = "Price of the Ordered Item")]
        [Required]
        public override int OrderId
        {
            get { return base.OrderId; }
            set { base.OrderId = value; }
        }

        [Display(Name = "Price of the Ordered Item")]
        [Required]
        public override int ItemId
        {
            get { return base.ItemId; }
            set { base.ItemId = value; }
        }


        [Display(Name = "Enter Customer's Mobile Number")]
        [Required]
        public override string MobileNumber
        {
            get { return base.MobileNumber; }
            set { base.MobileNumber = value; }
        }
        [Display(Name = "Total amount to be paid")]
        [Required]
        public override decimal AmountPaid
        {
            get { return base.AmountPaid; }
            set { base.AmountPaid = value; }
        }
        [Display(Name = "Discount")]

        public override int OrderDetailId
        {
            get { return base.OrderDetailId; }
            set { base.OrderDetailId = value; }
        }

    }
}
