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
    public class Review
    {
        [Key] public int ReviewId { get; set; }

        [Display(Name = "توضیحات محصول")]
        [MaxLength(15000, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(10, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string ReviewDescription { get; set; }

        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(1000, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "نقاط ضعف")]
        public string ReviewMegative { get; set; }

        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(1000, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "نقاط قوت")]
        public string ReviewPositive { get; set; }

        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(10000, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "عنوان مقاله")]
        public string ArticleTitle { get; set; }

        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [Display(Name = "توضیحات مقاله")]
        public string ArticleDescription { get; set; }

        public int ProductId { get; set; }

        #region Relation

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}