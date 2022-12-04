using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان دسته بندی فارسی")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string categoriFaTitle { get; set; }


        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان دسته بندی انگلیسی")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string categoriEnTitle { get; set; }

        public int SubCategory { get; set; }

        public bool IsDeleted { get; set; }

        #region Relation

        public List<Product> Products { get; set; }

        public List<PropertyNameToCategory> PropertyNameToCategories { get; set; }

        [ForeignKey("SubCategory")]
        public Category Category1 { get; set; }

        #endregion
    }
}