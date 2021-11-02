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
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

        public string Summary { get; set; }
        [ForeignKey(nameof(Student))]
        [Required]
        public int StudentId { get; set; }
    }
}
