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
    public class ProductPrice
    {
        [Key] public int ProductPriceId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "قیمت محصول")]
        public int MainPrice { get; set; }

        [Display(Name = "قیمت تخفیف خورده")] public int SpacialPrice { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "تعداد محصول")]
        public int Count { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "حداکثر خرید کاربر")]
        public int MaxOrderCount { get; set; }

        public int productColorId { get; set; }
        public int ProductGarrantyId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDateDiscount { get; set; }

        #region Relation

        [ForeignKey("productColorId")]
        public ProductColor ProductColor { get; set; }

        [ForeignKey("ProductGarrantyId")]
        public ProductGarranty ProductGarranty { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}