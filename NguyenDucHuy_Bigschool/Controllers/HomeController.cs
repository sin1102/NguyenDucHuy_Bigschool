using NguyenDucHuy_Bigschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NguyenDucHuy_Bigschool.ViewModels;

namespace NguyenDucHuy_Bigschool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourse = _dbContext.Courses
                .Include(c => c.Lecture)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);
            var viewModel = new CouresViewModel
            {
                UpcommingCourses = upcomingCourse,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}