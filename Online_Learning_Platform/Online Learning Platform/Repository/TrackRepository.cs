using Online_Learning_Platform.Data;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Online_Learning_Platform.Repositories
{
    public class TrackRepository : IRepository<Track>
    {
        private readonly ApplicationDbContext _context;

        public TrackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Track> GetAll()
        {
            return _context.Tracks.ToList();
        }

        public Track GetById(int id)
        {
            return _context.Tracks.Find(id);
        }

        public void Add(Track entity)
        {
            _context.Tracks.Add(entity);
            Save();
        }

        public void Update(Track entity)
        {
            _context.Tracks.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var track = GetById(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
