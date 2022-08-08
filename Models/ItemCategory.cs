using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    [Table(name: "ItemCategories")]
    public class ItemCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int ItemCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        virtual public string ItemCategoryName { get; set; }

        [Required]
        [DefaultValue(true)]
        virtual public bool IsAvailable { get; set; }

        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdatedBy { get; set; }

        virtual public DateTime UpdatedDate { get; set; }
        virtual public string ItemsAvailable { get; set; }

        #region Navigation Properties to the Item Model
        virtual public int MenuId { get; set; }

        [ForeignKey(nameof(ItemCategory.MenuId))]

        public Menu Menu { get; set; }

        public ICollection<Item> Items { get; set; }

        #endregion

    }
}