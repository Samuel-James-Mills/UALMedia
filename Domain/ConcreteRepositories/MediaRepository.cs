using Domain.AdstractRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ConcreteRepositories
{
    public class MediaRepository : IMediaRepository, IDisposable
    {
        private MediaContext _context = null;

        public MediaRepository()
        {
            _context = new MediaContext();
        }

        public MediaRepository(MediaContext context)
        {
            _context = context;
        }
        public IEnumerable<Media> SelectAll()
        {
            return _context.MediaContent.ToList();
        }

        public Media SelectById(int id)
        {
            return _context.MediaContent.Find(id);
        }

        public Media SelectByMostRecent()
        {
            return _context.MediaContent.OrderByDescending(m => m.DateCreated).FirstOrDefault();
        }

        public void Insert(Media content)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Media content)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
