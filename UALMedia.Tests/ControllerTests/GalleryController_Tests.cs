using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UALMedia.Controllers;
using Moq;
using Domain.AdstractRepositories;
using Domain.Entities;
using System.Collections;
using System.Web.Mvc;

namespace UALMedia.Tests.ControllerTests
{
    [TestFixture]
    public class GalleryController_Tests
    {
        private Mock<IMediaRepository> mediaRepositoryMock;
        [SetUp]
        public void Setup()
        {
            mediaRepositoryMock = new Mock<IMediaRepository>();
        }

        [Test]
        public void Index_OnIsAjaxRequest_ReturnsAPartialViewResult()
        {
            GalleryController galleryController = arrangeOnIsAjaxRequestGalleryController();

            var viewResult = galleryController.Index();

            Assert.NotNull(viewResult);
            Assert.IsInstanceOf<PartialViewResult>(viewResult);
        }

        [Test]
        public void Index_OnIsAjaxRequest_ReturnsAPagedListOfMediaItemsInThePartialViewModel()
        {
            GalleryController galleryController = arrangeOnIsAjaxRequestGalleryController();

            var viewResult = galleryController.Index() as PartialViewResult;

            var model = (IEnumerable<Media>)viewResult.Model;

            Assert.NotNull(viewResult);
            Assert.AreEqual(1, model.ElementAt(0).Id);
            Assert.AreEqual(12, model.Count());
        }

        [Test]
        public void Index_OnNonAjaxRequest_ReturnsAViewResult()
        {
            GalleryController galleryController = arrangeOnNonAjaxRequestGalleryController();

            var viewResult = galleryController.Index();

            Assert.NotNull(viewResult);
            Assert.IsInstanceOf<ViewResult>(viewResult);
        }

        [Test]
        public void Index_OnNonAjaxRequest_ReturnsAPagedListOfMediaItemsInTheViewModel()
        {
            GalleryController galleryController = arrangeOnNonAjaxRequestGalleryController();

            var viewResult = galleryController.Index() as ViewResult;

            var model = (IEnumerable<Media>)viewResult.Model;

            Assert.NotNull(viewResult);
            Assert.AreEqual(1, model.ElementAt(0).Id);
            Assert.AreEqual(12, model.Count());
        }
        [Test]
        public void Index_OnNonAjaxRequestForPhotographyCategory_ReturnsAPagedListOfPhotographyCategoryMediaItems()
        {
            GalleryController galleryController = arrangeOnNonAjaxRequestGalleryController();

            var viewResult = galleryController.Index(mediaType: 1) as ViewResult;

            var model = (IEnumerable<Media>)viewResult.Model;
            Assert.NotNull(viewResult);
            Assert.AreEqual(12, model.Where(x => x.Type == 1).Count());
            Assert.AreEqual(0, model.Where(x => x.Type == 2).Count());
        }
        [Test]
        public void Index_OnIsAjaxRequestForPhotographyCategory_ReturnsAPagedListOfPhotographyCategoryMediaItems()
        {
            GalleryController galleryController = arrangeOnIsAjaxRequestGalleryController();

            var viewResult = galleryController.Index(mediaType: 1) as PartialViewResult;

            var model = (IEnumerable<Media>)viewResult.Model;
            Assert.NotNull(viewResult);
            Assert.AreEqual(12, model.Where(x => x.Type == 1).Count());
            Assert.AreEqual(0, model.Where(x => x.Type == 2).Count());
        }

        private GalleryController arrangeOnIsAjaxRequestGalleryController()
        {
            setupMediaRepositoryMock();
            GalleryController galleryController = setupGalleryController(isAjaxRequest: true);

            return galleryController;
        }

        private GalleryController arrangeOnNonAjaxRequestGalleryController()
        {
            setupMediaRepositoryMock();
            GalleryController galleryController = setupGalleryController(isAjaxRequest: false);

            return galleryController;
        }

        private void setupMediaRepositoryMock()
        {
            IEnumerable<Media> mediaItems = getMediaItems();
            mediaRepositoryMock.Setup(x => x.SelectAll()).Returns(mediaItems);
        }

        private GalleryController setupGalleryController(bool isAjaxRequest)
        {
            GalleryController galleryController = new GalleryController(mediaRepositoryMock.Object);

            var controllerContext = getMockControllerContext(isAjaxRequest); //Defines Whether Request is an Ajax Request 

            galleryController.ControllerContext = controllerContext.Object;

            return galleryController;
        }

        private IEnumerable<Media> getMediaItems()
        {
            IEnumerable<Media> mediaItems = new List<Media>()
                { 
                    new Media
                    {
                    Id = 1,
                    Name = "Chester Zoo Photo",
                    Description = "A picture of an elephant, taken at Chester Zoo, on a trip for the year 10 photography module",
                    Resource = "ElephantPhoto1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Parse("01/01/01")
                    },
                    new Media
                    {
                    Id = 2,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum1.jpg",
                    Type = 1,
                    DateCreated = DateTime.Parse("02/02/02")
                    },
                    new Media
                    {
                    Id = 3,
                    Name = "Liverpool Museum Photo",
                    Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                    Resource = "LiverpoolMuseum2.jpg",
                    Type = 1,
                    DateCreated = DateTime.Parse("03/03/03")
                    },
                     new Media
                     {
                        Id = 4,
                        Name = "Liverpool Museum Photo",
                        Description = "A picture of Liverpool Museum, on a trip for the year 11 photography module",
                        Resource = "LiverpoolMuseum3.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("04/04/04")
                    },
                     new Media
                     {
                        Id = 5,
                        Name = "Liverbuilding Photo",
                        Description = "A picture of the Liverbuilding , on a trip for the year 11 photography module",
                        Resource = "Liverbuilding1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("05/05/05")
                    },
                     new Media
                     {
                        Id = 6,
                        Name = "Liverpool Museum Photo",
                        Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                        Resource = "LiverpoolMuseum4.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("06/06/06")
                    },
                     new Media
                     {
                        Id = 7,
                        Name = "Chimp photo at Chester Zoo",
                        Description = "A picture of a monkey at Chester Zoo, on a trip for the year 11 photography module",
                        Resource = "MonkeyPhoto1.jpg",
                        Type = 2,
                        DateCreated = DateTime.Parse("07/07/07")
                    },
                     new Media
                     {
                        Id = 8,
                        Name = "Rhino photo at Chester Zoo",
                        Description = "A picture of a Rhino at Chester Zoo, on a trip for the year 11 photography module",
                        Resource = "Rhino1.jpg",
                        Type = 2,
                        DateCreated = DateTime.Parse("08/08/08")
                    },
                     new Media
                     {
                        Id = 9,
                        Name = " Photo of fish at Chester Zoo",
                        Description = "A picture of Fish at Chester Zoo, on a trip for the year 11 photography module",
                        Resource = "Fish1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("09/09/09")
                    },
                     new Media
                     {
                        Id = 10,
                        Name = "Museum of Liverpool Photo",
                        Description = "A picture of an the Museum of Liverpool, on a trip for the year 11 photography module",
                        Resource = "MuseumofLiverpool1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("10/10/10")
                    },
                    new Media
                    {
                        Id = 11,
                        Name = "Museum of Liverpool Photo",
                        Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                        Resource = "MuseumofLiverpool2.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("11/11/11")
                    },
                    new Media
                    {
                        Id = 12,
                        Name = "Spider at Chester Zoo",
                        Description = "A picture of a Spider at Chester Zoo, on a trip for the year 9 photography module",
                        Resource = "Spider1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("12/12/12")
                    },
                    new Media
                    {
                        Id = 13,
                        Name = "Museum of Liverpool",
                        Description = "A picture of an Liverpool Museum, on a trip for the year 11 photography module",
                        Resource = "MuseumofLiverpool3.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("13/3/13")
                    },
                    new Media
                    {
                        Id = 14,
                        Name = "Liverpool Waterfront",
                        Description = "A picture of the Liverpool Waterfront, on a trip for the year 11 photography module",
                        Resource = "LiverpoolWaterfront1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("14/4/14")
                    },
                     new Media
                     {
                        Id = 15,
                        Name = "Liverpool Docks",
                        Description = "A picture of the Liverpool Docks, on a trip for the year 11 photography module",
                        Resource = "LiverpoolDocks1.jpg",
                        Type = 1,
                        DateCreated = DateTime.Parse("15/5/15")
                    },
                    new Media
                    {
                        Id = 16,
                        Name = "A Rhino With Plastic Wrap",
                        Description = "A picture of the a rhino with a plastic wrap filter, created by a year 10 pupil",
                        Resource = "RhinoPlasticWrap.jpg",
                        Type = 2,
                        DateCreated = DateTime.Parse("16/6/16")
                    },
                    new Media
                    {
                        Id = 17,
                        Name = "A Skateboarder with glowing lines filter",
                        Description = "A picture of the a skateboarder with a glowing lines filter, created by a year 10 pupil",
                        Resource = "SkaterGlowingLines.jpg",
                        Type = 2,
                        DateCreated = DateTime.Parse("17/7/17")
                    }

                };
            return mediaItems;
        }

        private Mock<ControllerContext> getMockControllerContext(bool isAjaxRequest)
        {
            var controllerContext = new Mock<ControllerContext>();
            string xRequestWithValue = String.Empty;
            if (isAjaxRequest)
            {
                xRequestWithValue = "XMLHttpRequest";
            }
            else
            {
                xRequestWithValue = "NotXMLHttpRequest";
            }
            controllerContext.Setup(r => r.HttpContext.Request["X-Requested-With"]).Returns(xRequestWithValue);
            return controllerContext;
        }
    }
}
