using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class PropertyValue
    {
        [Key] public int PropertyValueId { get; set; }

        [MinLength(5, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "مقدار خصوصیت")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string PropertyValueText { get; set; }

        public int ProductId { get; set; }

        #region Relation

        [ForeignKey("ProductId")] public Product Product { get; set; }

        #endregion
    }
}