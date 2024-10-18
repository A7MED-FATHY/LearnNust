using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
using System.IO;
[Authorize(Roles = "Admin")]
public class TrackController : Controller
{
    private readonly IRepository<Instructor> _instructorRepository;
    private readonly IRepository<Track> _trackRepository;
    private readonly IRepository<Course> _courseRepository;

    public TrackController(IRepository<Instructor> instructorRepository,
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
        var tracks = _trackRepository.GetAll();



        return View(tracks);
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
    public IActionResult Create(Track track, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    var filePath = Path.Combine(uploadsPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    track.ImageUrl = "/images/" + fileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error uploading image: {ex.Message}");
                    return View(track);
                }
            }

            _trackRepository.Add(track);
            _trackRepository.Save();
            return RedirectToAction("Index");
        }

        return View(track);
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var track = _trackRepository.GetById(id);
        if (track == null)
        {
            return NotFound();
        }
        return View(track);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _trackRepository.Delete(id);
        _trackRepository.Save();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var track = _trackRepository.GetById(id);
        if (track == null)
        {
            return NotFound();
        }
        return View(track);
    }

    // POST: Edit Track
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Track track, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    var filePath = Path.Combine(uploadsPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    track.ImageUrl = "/images/" + fileName; 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error uploading image: {ex.Message}");
                    return View(track); 
                }
            }

            _trackRepository.Update(track); 
            _trackRepository.Save();
            return RedirectToAction("Index"); 
        }

        return View(track); 
    }
        [AllowAnonymous]
    public IActionResult ViewCourses(int trackId)
    {
        var courses = _courseRepository.GetAll().Where(c => c.TrackId == trackId).ToList();
        if (courses == null || !courses.Any())
        {
            return NotFound();
        }

        return View(courses); 
    }



}
