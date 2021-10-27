using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;

namespace ZlorpShack.Model
{
    public class AwardEarnedList
    {
        [Key]
        public int AwardEarnedID { get; set; }
        [Required]
        public DateTime DateEarned { get; set; }
        public DateTime DateClaimed { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        //Navigation Property
        public virtual Student Student { get; set; }

        //[ForeignKey(nameof(Award))]
        //public int AwardId { get; set; }

        //Navigation Property
        //public virtual Award Award { get; set; }
    }
}
