using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities
{
    public class MainSlider
    {
        [Key] public int SliderId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "لینک اسلایدر")]
        [MaxLength(500, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        public string SliderLink { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "آلت اسلایدر")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        public string SliderAlt { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان اسلایدر")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        public string SliderTitle { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "مرتب سازی")]
        [MaxLength(100, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        public int SliderSort { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "تصویر اسلایدر")]
        public string SliderImage { get; set; }

        [Display(Name = "نمایش")] public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}