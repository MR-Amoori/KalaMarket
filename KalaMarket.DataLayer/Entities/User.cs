using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KalaMarket.DataLayer.Entities.Product.FaQ;

namespace KalaMarket.DataLayer.Entities
{
   public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserAccount { get; set; }
        public string UserName { get; set; }
        public string UserFamily { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Email { get; set; }

        #region Relation

        public List<Question> Questions { get; set; }

        public List<Comment> Comments { get; set; }

        #endregion
    }
}
