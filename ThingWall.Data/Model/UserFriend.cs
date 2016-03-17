using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    public class UserFriend
    {
        public Guid UserFriendID { get; set; }
        [Required]
        [EmailAddress]
        public string User1 { get; set; }
        [Required]
        [EmailAddress]
        public string User2 { get; set; }
    }
}
