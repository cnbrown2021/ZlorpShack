using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZlorpShack.Data;
using ZlorpShack.Model;
using ZlorpShack.Service;

namespace ZlorpShack.WebAPI.Controllers
{
    /*{private readonly ApplicationDbContext _studentContent = new ApplicationDbContext();
    }*/

    [Authorize]
    public class StudentController : ApiController
    //CRUD
    {
        //private readonly ApplicationDbContext _studentId = new ApplicationDbContext();
        private StudentService CreateStudentService()
        {
            //var studentId = Guid.Parse(User.Identity.GetUserId());
            StudentService studentService = new StudentService();
            return studentService;
        }

        [HttpPost]
        public IHttpActionResult Post(StudentCreate student)
        {
            if (student == null)
                return BadRequest("Please Enter Information");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.CreateStudent(student))
            return InternalServerError();

            //_studentId.Students.Add(student);
            //if(_studentId.SaveChanges() == 1)
            //{
              //  return Ok($"{student.FirstName} was added.");
            //}
            //return InternalServerErr

            return Ok();


        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            StudentService studentService = CreateStudentService();
            var student = studentService.GetStudent();
            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            StudentService studentService = CreateStudentService();
            var student = studentService.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult GetByName(string name)
        {
            StudentService studentService = CreateStudentService();
            var student = studentService.GetStudentByName(name);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Put(StudentEdit student)
        {
            if (student == null)
                return BadRequest("More Information Needed");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.UpdateStudent(student))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStudentService();

            if (!service.DeleteStudent(id))
                return InternalServerError();

            return Ok();
        }
    }

}
