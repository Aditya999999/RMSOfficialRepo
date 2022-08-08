using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    [Table(name: "Menus")]
    public class Menu
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int MenuId { get; set; }

        [Required]
        [StringLength(100)]
        virtual public string MenuName { get; set; }
        virtual public string CreatedBy { get; set; }

        virtual public DateTime CreatedDate { get; set; }

        virtual public string UpdatedBy { get; set; }

        virtual public DateTime UpdatedDate { get; set; }

        #region Navigation Properties to the Item Category

        public ICollection<ItemCategory> ItemCategories { get; set; }

        #endregion
    }
}