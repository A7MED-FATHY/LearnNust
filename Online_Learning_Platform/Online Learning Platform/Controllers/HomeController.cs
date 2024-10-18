using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Data;
using Online_Learning_Platform.Models;
using System.Linq;
using System.Net.Mail;
using System.Net;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult InstructorProfile(int id)
    {
        var instructor = _context.Instructors
                                .Include(i => i.Course)
                                .Include(i => i.Tracks)
                                .FirstOrDefault(i => i.InstructorId == id);

        if (instructor == null)
        {
            return NotFound();
        }

        return View(instructor);
    }

    public IActionResult Index()
    {
        var tracks = _context.Tracks.ToList();

        var instructors = _context.Instructors.ToList();

        ViewData["Instructors"] = instructors;

        return View(tracks);
    }

    public IActionResult HtmlCourse()
    {
        return View();
    }
    public IActionResult jsCourse()
    {
        return View();
    }
    public IActionResult CssCourse()
    {
        return View();
    }

    public IActionResult CourseDetails()
    {
     
        return View();
    }

    public IActionResult viewCourse()
    {

        return View();
    }



}
