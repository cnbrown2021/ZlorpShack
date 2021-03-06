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
        //Create
        public bool CreateStudent(StudentCreate profile)
        {
            var content = new Student()
            {
                StudentId = profile.StudentId,
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
        public bool AddBookToStudentList(int studentId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student = ctx.Students.Single(c => c.StudentId == studentId);
                var book = ctx.Books.Single(b => b.BookID == bookId);
                student.Books.Add(book);
                
                return ctx.SaveChanges() == 1;
            }
        }
        //Get
        public IEnumerable<StudentList> GetStudent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Students
                    .Select(c => new StudentList
                    {
                        StudentId = c.StudentId,
                        FullName = c.FirstName + " " + c.LastName,
                        NumberOfBooksRead = c.NumberOfBooksRead,
                    });
                   
                return query.ToArray();
            }
        }

        //GetbyID
        public StudentDetail GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Students.Single(c => c.StudentId == id);

                return new StudentDetail
                {
                    StudentId = content.StudentId,
                    FirstName = content.FirstName,
                    LastName = content.LastName,
                    NumberOfBooksRead = content.NumberOfBooksRead,
                    Books = content.Books.Select(e => new Book { Title = e.Title }).ToList(),
                    Awards = content.Awards.Select(b => new Award { AwardName = b.AwardName }).ToList()
                };
            }
        }

        //GetbyName
        public StudentDetail GetStudentByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Students.Single(c => c.LastName == name);

                return new StudentDetail
                {
                    StudentId = content.StudentId,
                    FirstName = content.FirstName,
                    LastName = content.LastName,
                    NumberOfBooksRead = content.NumberOfBooksRead,
                    Books = content.Books.Select(e => new Book { Title = e.Title }).ToList(),
                    Awards = content.Awards.Select(b => new Award { AwardName = b.AwardName }).ToList()
                };
            }
        }

        public IEnumerable<StudentList> GetStudentByBookId (int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var studentsBooks = ctx.StudentsBooks
                        .Where(sb => sb.BookId == bookId);

                List<StudentList> results = new List<StudentList>();
                Student studentToAdd = new Student();
                foreach(var studentBook in studentsBooks)
                {
                    studentToAdd = studentBook.StudentNavigation;
                    results.Add(new StudentList
                    {
                        StudentId = studentToAdd.StudentId,
                        FullName = studentToAdd.FullName,
                        NumberOfBooksRead = studentToAdd.NumberOfBooksRead

                    });
                }
                return results;
            }
        }

        //Update
        public bool UpdateStudent(StudentEdit profile)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var content = ctx.Students.Single(c => c.StudentId == profile.StudentId);

                content.StudentId = profile.StudentId;
                content.FirstName = profile.FirstName;
                content.LastName = profile.LastName;
                content.NumberOfBooksRead = profile.NumberOfBooksRead;

                return ctx.SaveChanges() == 1;
            }
        }
       
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

