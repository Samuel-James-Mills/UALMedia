using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AdstractRepositories
{
    public interface INewsRepository : IDisposable
    {
        IEnumerable<News> SelectAll();
        News SelectById(int id);

        News SelectByMostRecent();
        void Insert(News news);
        void Update(News news);
        void Delete(int id);
        void Save();
    }
}
