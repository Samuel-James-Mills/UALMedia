using Domain.AdstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.FakeRepositories
{
    public class FakeNewsRepository : INewsRepository
    {
        public IEnumerable<News> SelectAll()
        {


            List<News> testNewsList = new List<News>() {
            new News(){
                Headline = "YEAR 10 HAD BIG FUN ON THEIR CHESTER ZOO PHOTOGRAPHY TRIP",
                DateCreated = DateTime.Now,
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article With Long Headline 2",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 3",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
              new News(){
                Headline = "Test News Article With Very Very Long Headline 4",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 5",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(4)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 6",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(5)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 7",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(6)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
              new News()
              {
                Headline = "Test News Article 8",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(7)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 9",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(8)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
            new News()
            {
                Headline = "Test News Article 10",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(9)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            }

            };


            return testNewsList;

        }

        public Entities.News SelectById(int id)
        {
            News testNews = new News
            {
                Headline = "Test News Article",
                DateCreated = DateTime.Now,
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            };
            return testNews;
        }

        public Entities.News SelectByMostRecent()
        {
            throw new NotImplementedException();
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
