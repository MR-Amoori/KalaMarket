using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class Tag
    {
        [Key] public int TagId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "برچسب")]
        [MaxLength(15, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string TagName { get; set; }
    }
}