using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;
using ZlorpShack.Model;

namespace ZlorpShack.Service
{
    public class StudentService
    {
        private readonly int _studentId;

        public StudentService(int studentId)
        {
            _studentId = studentId;
        }

        //Create
        public bool CreateStudent(StudentCreate profile)
        {
            var content = new Student()
            {
                StudentId = _studentId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                NumberOfBooksRead = profile.NumberOfBooksRead
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get

        //GetbyID

        //Update

        //Delete
        public bool DeleteStudent(int _studentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Students.Single(c => c.StudentId == _studentId);
                ctx.Students.Remove(content);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
