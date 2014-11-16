using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AdstractRepositories
{
    public interface IMediaRepository
    {
        IEnumerable<Media> SelectAll();
        Media SelectById(int id);

        Media SelectByMostRecent();
        void Insert(Media content);
        void Update(Media content);
        void Delete(int id);
        void Save();
    }
}
