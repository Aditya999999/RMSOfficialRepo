using Restaurant.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Areas.Demos.ViewModels
{
    public class ItemCategoryViewModel : ItemCategory
    {
        [Display(Name = "Item Category Name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} can have a maximum of {1} characters")]

        public override string ItemCategoryName
        {
            get { return base.ItemCategoryName; }
            set { base.ItemCategoryName = value; }
        }
        [Display(Name = "Is Available?")]

        public override bool IsAvailable
        {
            get => base.IsAvailable;
            set => base.IsAvailable = value;
        }
        [Display(Name = "Who have created this {0}?")]

        public override string CreatedBy
        {
            get => base.CreatedBy;
            set => base.CreatedBy = value;
        }
        [Display(Name = "When {0} was created?")]

        public override System.DateTime CreatedDate
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

        public override System.DateTime UpdatedDate
        {
            get => base.UpdatedDate;
            set => base.UpdatedDate = value;
        }
        [Display(Name = "Available Items in this Category")]
        public override string ItemsAvailable
        {
            get => base.ItemsAvailable;
            set => base.ItemsAvailable = value;
        }
    }
}