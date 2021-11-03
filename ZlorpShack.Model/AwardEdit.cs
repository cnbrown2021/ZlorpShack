using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;
using static ZlorpShack.Data.Award;

namespace ZlorpShack.Model
{
    public class AwardEdit
    {

        public int AwardId { get; set; }

        public string AwardName { get; set; }
        
        public Tiers AwardTier { get; set; }
     
        public string AwardDescription { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }

        //Navigation Property
        public virtual Student Student { get; set; }

    }
}
