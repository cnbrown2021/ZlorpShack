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

        [Required]
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

        public string BooksRead 
        { 
            get
            {
                string masterString = "";

                if (Books.Count == 0)
                    return ("no book");

                foreach (var book in Books)
                    masterString += book.Title + ", ";

                return masterString;
            }
        }
        public string AwardsEarned
        {
            get
            {
                string masterString = "";

                if (Awards.Count == 0)
                    return ("no awards");

                foreach (var award in Awards)
                    masterString += award.AwardName + ", ";

                return masterString;
            }
        }

        //Navigation Property
        public virtual List<Book> Books { get; set; } = new List<Book>();
        public virtual List<Award> Awards { get; set; } = new List<Award>();
        

    }
}
