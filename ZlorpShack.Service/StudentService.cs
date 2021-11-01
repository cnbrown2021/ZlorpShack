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

        //private readonly int _studentId;
        //private readonly List<StudentList> _studentDirectory;


        //public StudentService(int studentId)
        //{
          //  _studentId = studentId;
        //}

        //public StudentService()
        //{
        //}


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

        //Get
        //public List<StudentList> GetList()
        //{
        //    return _studentDirectory;
        //}

        //Get
        public IEnumerable<StudentList> GetStudent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Students
                    .Select(c => new StudentList
                    {
                        StudentId = c.StudentId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        //FullName = c.FullName, wasn't working
                        NumberOfBooksRead = c.NumberOfBooksRead,
                        CurrentRewardTier = c.NumberOfBooksRead
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
                    CurrentRewardTier = content.CurrentRewardTier
                };
            }
        }

        //GetbyName
        public StudentDetail GetStudentByName(string name) //Maybe do by first or last name
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
                    CurrentRewardTier = content.CurrentRewardTier
                };
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

