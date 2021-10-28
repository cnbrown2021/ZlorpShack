using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZlorpShack.Data.Award;

namespace ZlorpShack.Model
{
    public class AwardDetail
    {
        [Key]
        public int AwardId { get; set; }

        [Required]
        public string AwardName { get; set; }
        
        [Required]
        public Tiers AwardTier { get; set; }

        [Required]
        public string AwardDescription { get; set; }
    }
}
