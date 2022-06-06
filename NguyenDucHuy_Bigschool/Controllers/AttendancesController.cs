using Microsoft.AspNet.Identity;
using NguyenDucHuy_Bigschool.DTOs;
using NguyenDucHuy_Bigschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenDucHuy_Bigschool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        //[HttpPost]
        //public IHttpActionResult Attend([FromBody] int CourseId)
        //{
        //    var attendace = new Attendance
        //    {
        //        CourseId = CourseId,
        //        AttendeeId = User.Identity.GetUserId()
        //    };
        //    _dbContext.Attendances.Add(attendace);
        //    _dbContext.SaveChanges();
        //    return Ok();
        //}

        [HttpPost]
        public IHttpActionResult Attend(AttendaceDto attendaceDto)
        {
            var userID = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userID && a.CourseId == attendaceDto.CourseId))
            {
                return BadRequest("The Attendee already exist");
            }
            var attendace = new Attendance
            {
                CourseId = attendaceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendances.Add(attendace);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
