using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlorpShack.Data
{
    public class StudentBooks
    {
        [Key]
        public int StudentBooksId { get; set; }

        [ForeignKey(nameof(StudentNavigation))]
        public int StudentId { get; set; }
        
        //Navigation Property
        public virtual Student StudentNavigation { get; set; }

        [ForeignKey(nameof(BookNavigation))]
        public int BookId { get; set; }

        //Navigation Property
        public virtual Book BookNavigation { get; set; }
    }
}
