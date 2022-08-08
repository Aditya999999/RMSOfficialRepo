using Restaurant.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Areas.Demos.ViewModels
{
    public class ItemViewModel
        : Item
    {
        [Display(Name = "Item ID")]
        [Required]

        override public int ItemId
        {
            get
            {
                return base.ItemId;
            }
            set
            {
                base.ItemId = value;
            }
        }
        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(150, ErrorMessage = "{0} can have a maximum of {1} characters")]

        public override string ItemName
        {
            get => base.ItemName;
            set => base.ItemName = value;
        }
        [Display(Name = "Item Type")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(1, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(20, ErrorMessage = "{0} can have a maximum of {1} characters")]

        public override string ItemType
        {
            get => base.ItemType;
            set => base.ItemType = value;
        }
        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(10, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(350, ErrorMessage = "{0} can have a maximum of {1} characters")]

        public override string ItemDescription
        {
            get => base.ItemDescription;
            set => base.ItemDescription = value;
        }
        [Display(Name = "Is Available?")]
        [Required]
        public override bool IsAvailable
        {
            get => base.IsAvailable;
            set => base.IsAvailable = value;
        }
        [Display(Name = "Item's Price")]
        [Required]
        public override decimal? Price
        {
            get => base.Price;
            set => base.Price = value;
        }
        [Display(Name = "Who have created this {0}?")]

        public override string CreatedBy
        {
            get => base.CreatedBy;
            set => base.CreatedBy = value;
        }
        [Display(Name = "When {0} was created?")]

        public override DateTime CreatedDate
        {
            get => base.CreatedDate;
            set => base.CreatedDate = value;
        }
        [Display(Name = "Who have updated this {0}?")]

        public override string UpdatedBy
        {
            get => base.UpdatedBy;
            set => base.UpdatedBy = value;
        }
        [Display(Name = "When {0} was updated?")]

        public override DateTime UpdatedDate
        {
            get => base.UpdatedDate;
            set => base.UpdatedDate = value;
        }
        [Display(Name = "Item Category")]
        [Required]
        public override int ItemCategoryId
        {
            get => base.ItemCategoryId;
            set => base.ItemCategoryId = value;
        }

    }
}