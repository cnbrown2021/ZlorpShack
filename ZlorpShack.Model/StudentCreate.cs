using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;

namespace ZlorpShack.Model
{
    public class StudentCreate
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfBooksRead { get; set; }
        public int CurrentRewardTier 
        {
            get
            {
                if (NumberOfBooksRead >= 1 && NumberOfBooksRead < 3)
                    return (int)Award.Tiers.TierOne;
                if (NumberOfBooksRead >= 3 && NumberOfBooksRead < 5)
                    return (int)Award.Tiers.TierTwo;
                if (NumberOfBooksRead >= 5 && NumberOfBooksRead < 8)
                    return (int)Award.Tiers.TierThree;
                if (NumberOfBooksRead >= 8 && NumberOfBooksRead < 13)
                    return (int)Award.Tiers.TierFour;
                if (NumberOfBooksRead >= 13)
                    return (int)Award.Tiers.TierFive;
                else 
                    return 0;

            } 
        }

        

    }
}
