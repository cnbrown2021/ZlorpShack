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
    /*
    {
        private readonly ApplicationDbContext _studentContent = new ApplicationDbContext();
    }*/

    [Authorize]

    //CRUD
    public class NoteController : ApiController
    {

        private StudentService CreateStudentService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            StudentService studentService = new StudentService(userId);
            return studentService;
        }

        [HttpPost]
        public IHttpActionResult Post(StudentCreate student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.CreateStudent(student))
                return InternalServerError();

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
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Put(StudentEdit student)
        {
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
