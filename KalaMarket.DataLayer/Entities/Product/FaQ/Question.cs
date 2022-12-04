using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KalaMarket.DataLayer.Entities.Product.FaQ
{
    public class Question
    {
        [Key] public int QuestionId { get; set; }

        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        [Display(Name = "متن سوال")]
        [MaxLength(500, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [MinLength(3, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        public string QuestionDescription { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Relation

        [ForeignKey("ProductId")] public Product Product { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }

        #endregion
    }
}