using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class PropertyName
    {
        [Key] public int PropertyNameId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان خصوصیت")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {1} کاراکتر مجاز نیست")]
        [MinLength(2, ErrorMessage = "* وارد کردن کمتر از {1} کاراکتر مجاز نیست")]
        public string PropertyNameTitle { get; set; }

        #region Relation

        public List<PropertyNameToCategory> PropertyNameToCategories { get; set; }

        #endregion
    }
}