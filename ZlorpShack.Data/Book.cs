using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlorpShack.Data
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

        public string Summary { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }

        //Navigation Property
        public virtual List<Student> Student { get; set; } = new List<Student>();
    }
}
