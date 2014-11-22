using Domain.AdstractRepositories;
using Domain.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Domain.Entities;

namespace UALMedia.Controllers
{
    public class GalleryController : Controller
    {
        private IMediaRepository _repository;

        public GalleryController()
        {
            _repository = new MediaRepository();
        }
        public GalleryController(IMediaRepository repository)
        {
            _repository = repository;
        }
        public int PageSize = 12;
        //
        // GET: /Gallery/
        public ActionResult Index(int page = 1, int mediaType = 0)
        {
            IPagedList<Media> model;
            //TODO Change to an IQueryable in the repository
            if (mediaType == 0)
            {
                 model = _repository.SelectAll().OrderBy(p => p.DateCreated).ToPagedList(page, PageSize);
            }
            else
            {
                 model = _repository.SelectAll()
                                    .Where(x => x.Type == mediaType)
                                    .OrderBy(p => p.DateCreated)
                                    .ToPagedList(page, PageSize);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }      
    }
}
