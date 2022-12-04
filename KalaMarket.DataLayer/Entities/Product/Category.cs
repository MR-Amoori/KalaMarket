using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان دسته بندی")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string CategoryName { get; set; }

        #region Relation

        public List<Product> Products { get; set; }

        #endregion
    }
}