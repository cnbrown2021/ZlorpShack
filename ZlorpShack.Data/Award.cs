using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlorpShack.Data
{
    public class Award
    {
        public enum Tiers
        {
            TierOne = 1,
            TierTwo,
            TierThree,
            TierFour,
            TierFive
        }

        [Key]
        public int AwardId { get; set; }

        [Required]
        public string AwardName { get; set; }

        [Required]
        public Tiers AwardTier { get; set; }

        [Required]
        public string AwardDescription { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }

        //Navigation Property
        public virtual Student Student { get; set; }
    }
}
