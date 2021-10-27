using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlorpShack.Model
{
    public class StudentList
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int NumberOfBooksRead { get; set; }
        public int CurrentRewardTier { get; set; }
    }
}
