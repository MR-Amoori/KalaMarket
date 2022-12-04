using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class Brand
    {
        [Key] public int BrandId { get; set; }

        [MinLength(5, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(50, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "عنوان برند")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string BrandName { get; set; }

        #region Relation

        public List<Product> Products { get; set; }

        #endregion
    }
}