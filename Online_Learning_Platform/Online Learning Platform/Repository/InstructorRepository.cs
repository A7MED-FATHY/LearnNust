using Online_Learning_Platform.Data;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Online_Learning_Platform.Repositories
{
    public class InstructorRepository : IRepository<Instructor>
    {
        private readonly ApplicationDbContext _context;

        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public void Add(Instructor entity)
        {
            _context.Instructors.Add(entity);
            Save();
        }

        public void Update(Instructor entity)
        {
            _context.Instructors.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var instructor = GetById(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
