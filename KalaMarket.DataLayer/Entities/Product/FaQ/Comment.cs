using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KalaMarket.DataLayer.Entities.Product.FaQ
{
    public class Comment
    {
        [Key] public int CommentId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "عنوان نظر")]
        [MaxLength(200, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(4, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string CommentTitle { get; set; }

        [MinLength(10, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(500, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "توضیحات نظر")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string CommentDescription { get; set; }

        public int CommentLike { get; set; }
        public int CommentDislike { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public byte ReComment { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }

        #region Relation

        [ForeignKey("ProductId")] public Product Product { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }

        #endregion
    }
}