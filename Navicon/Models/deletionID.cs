using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Navicon.Models
{
    public class deletionID
    {
        [Required]
        [StringLength(400)]
        [RegularExpression("^(\\d+(,\\d+)*)?$", ErrorMessage = "Please insert valid customers IDs separated by commas")]
        public string DescriptionIDs { get; set; }
    }
}