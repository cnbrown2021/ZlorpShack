using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZlorpShack.Data.Award;

namespace ZlorpShack.Model
{
    public class AwardListItems
    {
        [Display(Name="First Prize")]
        public string AwardName { get; set; }

        [Display(Name="Award Tier")]
        public Tiers AwardTier { get; set; }

        [Display(Name="Award Description")]
        public string AwardDescription { get; set; }
    }
}
