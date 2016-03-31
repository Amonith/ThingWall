using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public string AuthorID { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreateDate { get; set; }
        public virtual User Owner { get; set; }
    }
}
