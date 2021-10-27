using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZlorpShack.Data.Award;

namespace ZlorpShack.Model
{
    public class AwardCreate
    {
        [Required]
        [MinLength(5, ErrorMessage ="Please enter a name that is at least 5 characters")]
        [MaxLength(50, ErrorMessage ="There are too many characters in this field (Max = 50)")]
        public string AwardName { get; set; }

        [Required]
        public Tiers AwardTier { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Please enter a description that is at least 10 characters")]
        [MaxLength(200, ErrorMessage ="There are too many characters in this field (Max = 200)")]
        public string AwardDescription { get; set; }
    }
}
