using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    public class FriendInvitation
    {
        [Key]
        public Guid FriendInvitationID { get; set; }
        [Required]
        [EmailAddress]
        public string Recipient { get; set; }
        [EmailAddress]
        public string Sender { get; set; }
        public bool Status { get; set; }


    }
}
