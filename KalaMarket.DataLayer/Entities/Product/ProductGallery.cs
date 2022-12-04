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
    public class ProductGallery
    {
        [Key] public int ProductGalleryId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "تصویر محصول")]
        public string ImageName { get; set; }

        [MinLength(5, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(50, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "آلت تصویر")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string ImageAlt { get; set; }

        public int ProductId { get; set; }

        #region Relation

        [ForeignKey("ProductId")] public Product Product { get; set; }

        #endregion
    }
}