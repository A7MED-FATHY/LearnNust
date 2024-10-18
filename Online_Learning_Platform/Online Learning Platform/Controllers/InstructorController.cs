using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
using System.IO;
[Authorize(Roles = "Admin")]
public class InstructorController : Controller
{
    private readonly IRepository<Instructor> _instructorRepository;
    private readonly IRepository<Track> _trackRepository;
    private readonly IRepository<Course> _courseRepository;


    public InstructorController(IRepository<Instructor> instructorRepository,
                                IRepository<Track> trackRepository,
                                IRepository<Course> courseRepository)
    {
        _instructorRepository = instructorRepository;
        _trackRepository = trackRepository;
        _courseRepository = courseRepository;
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
        var instructors = _instructorRepository.GetAll();
            

        return View(instructors);
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]

    public IActionResult Create()
    {
        ViewData["TrackList"] = _trackRepository.GetAll();
        ViewData["CourseList"] = _courseRepository.GetAll();
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]

    public IActionResult Create(Instructor instructor, IFormFile imageFile)
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

                instructor.Image = "/images/" + fileName;
            }

            _instructorRepository.Add(instructor);
            _instructorRepository.Save();
            return RedirectToAction("Index");
        }

        ViewData["TrackList"] = _trackRepository.GetAll();
        ViewData["CourseList"] = _courseRepository.GetAll();
        return View(instructor);
    }

    [Authorize(Roles = "Admin")]

    public IActionResult Delete(int id)
    {
        var Instructor = _instructorRepository.GetById(id);
        if (Instructor == null)
        {
            return NotFound();
        }
        return View(Instructor);
    }
    [Authorize(Roles = "Admin")]

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _instructorRepository.Delete(id);
        _instructorRepository.Save();
        return RedirectToAction(nameof(Index));
    }


    [Authorize(Roles = "Admin")]

    public IActionResult Edit(int id)
    {
        var Instructor = _instructorRepository.GetById(id);
        if (Instructor == null)
        {
            return NotFound();
        }
        return View(Instructor);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Instructor Instructor)
    {
        if (ModelState.IsValid)
        {
            _instructorRepository.Update(Instructor);
            _instructorRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        return View(Instructor);
    }
}
