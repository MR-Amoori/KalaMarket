using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class ProductGarranty
    {
        [Key] public int ProductGarrantyId { get; set; }

        [MinLength(5, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(150, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "نام گارانتی")]
        public string ProductGarrantyName { get; set; }

        public bool IsDeleted { get; set; }

        #region Relation

        public List<ProductPrice> ProductPrices { get; set; }


        #endregion
    }
}