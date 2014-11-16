using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.AdstractRepositories;
using Domain.FakeRepositories;
using Domain.ConcreteRepositories;
using System.IO;

namespace UALMedia.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _repository;

        public NewsController()
        {
            _repository = new NewsRepository();
        }
        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }
        //
        // GET: /News/
        public ActionResult Index()
        {
            
            return View(_repository.SelectAll());
        }

        public ActionResult GetNewsBody(int id)
        {
            string initialPath = "~/Articles/" + id + ".html";
            //TODO:Change to use FilePathValidator util when it is completed
            if (System.IO.File.Exists(initialPath))
            {
                try
                {
                    return new FilePathResult(initialPath, "text/html");
                }
                catch (Exception)
                {
                    return Content("<h2>Sorry, this article is not currently available.</h2>", "text/html");
                }
            }
            else
            {
                return Content("<h2>Sorry, this article is not currently available.</h2>", "text/html");
            }
        }

        //[ChildActionOnly]
        public ActionResult GetArticleById(int? id)
        {
            if (id == null)
            {
                return PartialView("NewsArticle", _repository.SelectByMostRecent());
            }
            return PartialView("NewsArticle", _repository.SelectById((int)id));
        }

        //
        // GET: /News/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
