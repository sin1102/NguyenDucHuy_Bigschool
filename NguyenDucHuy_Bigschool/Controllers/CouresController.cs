using Microsoft.AspNet.Identity;
using NguyenDucHuy_Bigschool.Models;
using NguyenDucHuy_Bigschool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenDucHuy_Bigschool.Controllers
{
    public class CouresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CouresController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Coures
        //cham bai
        [Authorize]
        
        public ActionResult Create()
        {
            var viewModel = new CouresViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Heading = "Create Course"
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CouresViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var coures = new Course
            {
                LectureId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(coures);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecture)
                .Include(l => l.Category)
                .ToList();
            var viewModel = new CouresViewModel
            {
                UpcommingCourses = course,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Followings
                .Where(a => a.FolloweeId == userId)
                .Select(a => a.FollowerId)
                .ToList();
            
            var viewModel = new CouresViewModel
            {
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses
                .Where(c => c.LectureId == userId && c.DateTime > DateTime.Now)
                .Include(l => l.Lecture)
                .Include(l => l.Category)
                .ToList();
            return View(course);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(s => s.Id == id && s.LectureId == userId);
            var viewModel = new CouresViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Date = course.DateTime.ToString("dd/MM/yyyy"),
                Time = course.DateTime.ToString("HH:mm"),
                Category = course.CategoryId,
                Place = course.Place,
                Heading = "Edit Course",
                Id = course.Id
            };
            return View("Create",viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CouresViewModel Course)
        {
            if (!ModelState.IsValid)
            {
                Course.Categories = _dbContext.Categories.ToList();
                return View("Create", Course);
            }
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(s => s.Id == Course.Id && s.LectureId == userId);
            course.Place = Course.Place;
            course.DateTime = Course.GetDateTime();
            course.CategoryId = Course.Category;

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}