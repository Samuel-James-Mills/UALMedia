namespace Domain.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.MediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Domain.MediaContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data. E.g.
            

            IList<News> newsTestData = new List<News>()
           { 
                  
            new News(){
                Id = 1,
                Headline = "YEAR 10 HAD BIG FUN ON THEIR CHESTER ZOO PHOTOGRAPHY TRIP",
                DateCreated = DateTime.Now,
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 0

            },
            new News()
            {
                Id = 2,
                Headline = "Test News Article With Long Headline 2",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 1
            },
            new News()
            {
                Id = 3,
                Headline = "Test News Article 3",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 2
            },
              new News(){
                Id = 4,
                Headline = "Test News Article With Very Very Long Headline 4",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 2

            },
            new News()
            {
                Id = 5,
                Headline = "Test News Article 5",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(4)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 10
            },
            new News()
            {
                Id = 6,
                Headline = "Test News Article 6",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(5)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 10
            },
            new News()
            {
                Id = 7,
                Headline = "Test News Article 7",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(6)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html"
            },
              new News()
              {
                   Id = 8,
                Headline = "Test News Article 8",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(7)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 20
            },
            new News()
            {
                Id = 9,
                Headline = "Test News Article 9",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(8)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 30
            },
            new News()
            {
                Id = 10,
                Headline = "Test News Article 10",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(9)),
                ImageSrc = "http://www.chester360.co.uk/whats-on/images/chester-zoo.jpg",
                BodyFileName = "test.html",
                Lead = "This is a really interesting article that you must read. It isn't at all boring, honest. If you don't read this then you are a looser and may as well be dead.",
                ViewCount = 100
            }};

            foreach (News news in newsTestData)
            {
                
                context.News.AddOrUpdate(news);
            }

            IEnumerable<Media> contents = new List<Media>(){
                new Media{
                    Id = 1,
                    Name = "Chester Zoo Photo",
                    Description = "A picture of an elephant, taken at Chester Zoo, on a trip for the year 10 photography module",
                    Resource = "ElephantPhoto1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now
                },
                 new Media{
                    Id = 2,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                },
                new Media{
                    Id = 3,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum2.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                },
                 new Media{
                    Id = 4,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum3.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(2))
                },
                 new Media{
                    Id = 5,
                    Name = "Liverbuilding Photo",
                    Description = "A picture of the Liverbuilding , on a trip for the year 11 photography module",
                    Resource = "Liverbuilding1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(2))
                },
                 new Media{
                    Id = 6,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum4.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                },
                 new Media{
                    Id = 7,
                    Name = "Chimp photo at Chester Zoo",
                    Description = "A picture of a monkey at Chester Zoo, on a trip for the year 11 photography module",
                    Resource = "MonkeyPhoto1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(7))
                },
                 new Media{
                    Id = 8,
                    Name = "Rhino photo at Chester Zoo",
                    Description = "A picture of a Rhino at Chester Zoo, on a trip for the year 11 photography module",
                    Resource = "Rhino1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(100))
                },
                 new Media{
                    Id = 9,
                    Name = " Photo of fish at Chester Zoo",
                    Description = "A picture of Fish at Chester Zoo, on a trip for the year 11 photography module",
                    Resource = "Fish1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                },
                 new Media{
                    Id = 10,
                    Name = "Museum of Liverpool Photo",
                    Description = "A picture of an the Museum of Liverpool, on a trip for the year 11 photography module",
                    Resource = "MuseumofLiverpool1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(1))
                },
                new Media{
                    Id = 11,
                    Name = "Museum of Liverpool Photo",
                    Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "MuseumofLiverpool2.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(10))
                },
                new Media{
                    Id = 12,
                    Name = "Spider at Chester Zoo",
                    Description = "A picture of a Spider at Chester Zoo, on a trip for the year 9 photography module",
                    Resource = "Spider1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(10))
                },
                new Media{
                    Id = 13,
                    Name = "Museum of Liverpool",
                    Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "MuseumofLiverpool3.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(5))
                },
                new Media{
                    Id = 14,
                    Name = "Liverpool Waterfront",
                    Description = "A picture of the Liverpool Waterfront, on a trip for the year 11 photography module",
                    Resource = "LiverpoolWaterfront1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(80))
                },
                 new Media{
                    Id = 15,
                    Name = "Liverpool Docks",
                    Description = "A picture of the Liverpool Docks, on a trip for the year 11 photography module",
                    Resource = "LiverpoolDocks1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(80))
                },
                new Media{
                    Id = 16,
                    Name = "A Rhino With Plastic Wrap",
                    Description = "A picture of the a rhino with a plastic wrap filter, created by a year 10 pupil",
                    Resource = "RhinoPlasticWrap.jpg",
                    Type = 2,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(81))
                },
                new Media{
                    Id = 17,
                    Name = "A Skateboarder with glowing lines filter",
                    Description = "A picture of the a skateboarder with a glowing lines filter, created by a year 10 pupil",
                    Resource = "SkaterGlowingLines.jpg",
                    Type = 2,
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(81))
                }
                
            };
            foreach (Media content in contents)
            {

                context.MediaContent.AddOrUpdate(content);
            }
        }
    }

}
