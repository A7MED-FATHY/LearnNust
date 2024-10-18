using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Data;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;



namespace Online_Learning_Platform.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(p=>p.Track).ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(p=>p.Track).FirstOrDefault(o=>o.CourseId==id);
        }

        public void Add(Course entity)
        {
            _context.Courses.Add(entity);
            Save();
        }

        public void Update(Course entity)
        {
            _context.Courses.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
