using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class ProductColor
    {
        [Key] public int ProductColorId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "نام رنگ")]
        [MaxLength(50, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string ProductColorName { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "کد رنگ")]
        [MaxLength(50, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        public string ProductColorCode { get; set; }

        #region Relation

        public List<ProductPrice> ProductPrices { get; set; }

        #endregion
    }
}