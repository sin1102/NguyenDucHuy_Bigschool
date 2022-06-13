using Microsoft.AspNet.Identity;
using NguyenDucHuy_Bigschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenDucHuy_Bigschool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(s => s.Id == id && s.LectureId == userId);
            if (course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled = true;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
