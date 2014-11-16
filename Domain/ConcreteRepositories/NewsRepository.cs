using Domain.AdstractRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ConcreteRepositories
{
    public class NewsRepository : INewsRepository, IDisposable
    {
        private MediaContext _context = null;

        public NewsRepository()
        {
            _context = new MediaContext();
        }

        public NewsRepository(MediaContext context)
        {
            _context = context;
        }

        public IEnumerable<News> SelectAll()
        {
            return _context.News.ToList();
        }

        public News SelectById(int id)
        {
            return _context.News.Find(id);
        }

        public News SelectByMostRecent()
        {
            return _context.News.OrderByDescending(n => n.DateCreated).FirstOrDefault();

        }

        public void Insert(News news)
        {
            throw new NotImplementedException();
        }
        public void Update(News news)
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
            throw new NotImplementedException();
        }
    }
}
