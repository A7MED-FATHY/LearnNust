using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repositories;
using Online_Learning_Platform.Repository;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
using System.Linq;

namespace Online_Learning_Platform.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Track> _trackRepository;
        public CourseController(IRepository<Course> courseRepository, IRepository<Track> trackRepository)
        {
            _courseRepository = courseRepository;
            _trackRepository = trackRepository;
        }


       


        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TrackList"] = _trackRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveCreate(Course course, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    course.ImageUrl = "/images/" + fileName;
                }

                _courseRepository.Add(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }

            ViewData["TrackList"] = _trackRepository.GetAll();
         
            return View(course );
        }

        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                _courseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Videos(int id)
        {
            
            ViewBag.CourseId = id;
            return View();
        }
    }
}
