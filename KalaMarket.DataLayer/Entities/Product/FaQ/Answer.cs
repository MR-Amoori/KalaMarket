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
    public class Answer
    {
        [Key] public int AnswerId { get; set; }

        [MinLength(10, ErrorMessage = "* وارد کردن کمتر از {0} کاراکتر مجاز نیست")]
        [MaxLength(1000, ErrorMessage = "* وارد کردن بیش از {0} کاراکتر مجاز نیست")]
        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "* وارد کردن {0} اجباری است")]
        public string AnswerDescription { get; set; }

        public DateTime AnswerDate { get; set; }
        public int QuestionId { get; set; }

        #region Relation

        [ForeignKey("QuestionId")] public Question Question { get; set; }

        #endregion
    }
}