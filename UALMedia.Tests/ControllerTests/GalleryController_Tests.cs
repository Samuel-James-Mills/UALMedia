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
        public void Index_OnIsAjaxRequest_ReturnsAPagedListOfMediaItemsInTheViewModel()
        {
            GalleryController galleryController = arrangeOnIsAjaxRequestGalleryController();
            
            var viewResult = galleryController.Index() as PartialViewResult;

            var model = (IEnumerable<Media>)viewResult.Model;

            Assert.NotNull(viewResult);
            Assert.AreEqual(1, model.ElementAt(0).Id);
            Assert.AreEqual(2, model.Count());
        }
        
        [Test]
        public void Index_OnNonAjaxRequest_ReturnsAViewResult()
        {
            GalleryController galleryController = arrangeOnNonAjaxRequestGalleryController();

            var viewResult = galleryController.Index();

            Assert.NotNull(viewResult);
            Assert.IsInstanceOf<ViewResult>(viewResult);
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
