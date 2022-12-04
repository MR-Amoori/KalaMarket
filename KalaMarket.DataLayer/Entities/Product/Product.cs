﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Product
{
    public class Product
    {
        [Key] public int ProductId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان فارسی")]
        [MaxLength(500, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string ProductFaTitle { get; set; }

        [MaxLength(500, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string ProductWnTitle { get; set; }

        [Display(Name = "تعداد فروش")]
        public int ProductSell { get; set; }

        [Display(Name = "امتیاز محصول")]
        public byte ProductStar { get; set; }

        [Display(Name = "برچسب های محصول")]
        public List<Tag> Tags { get; set; }
       
        [Display(Name = "تصویر محصول")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "تاریخ ایجاد")]
        public DateTime ProductCreatDate { get; set; }

        [Display(Name = "وزن محصول")]
        public int ProductWith { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "اصل بودن کالا")]
        public bool IsOriginal { get; set; }
        public bool IsDeleted { get; set; }
    }
}