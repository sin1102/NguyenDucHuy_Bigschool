using Microsoft.AspNet.Identity;
using NguyenDucHuy_Bigschool.Models;
using NguyenDucHuy_Bigschool.ViewModels;
using System;
using System.Collections.Generic;
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
        [Authorize]
        
        public ActionResult Create()
        {
            var viewModel = new CouresViewModel
            {
                Categories = _dbContext.Categories.ToList()
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
    }
}