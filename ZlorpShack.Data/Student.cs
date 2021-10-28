using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlorpShack.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
        public int Age { get; set; }
       
        public int Grade { get; set; }
        [Required]
        public int NumberOfBooksRead { get; set; }
        public int CurrentRewardTier { get; set; }

        //Navigation Property
        //public virtual Book Book { get; set; }


    }
}
