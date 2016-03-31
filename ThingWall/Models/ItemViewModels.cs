using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ThingWall.Data.Model;

namespace ThingWall.Models
{
    public class ItemViewModels
    {
        public int ItemID { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreateDate { get; set; }
    }

    public class CreateViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}