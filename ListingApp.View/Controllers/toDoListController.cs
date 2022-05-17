using ListingApp.Infrastructure.Interfaces;
using ListingApp.Infrastructure;
using ListingApp.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListingApp.BusinessObjects;

namespace ListingApp.View.Controllers
{
    public class toDoListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        // GET: toDoList
        public ActionResult Index()
        {
            try
            {
                var data = new toDoListVM();
               data.ListingData= _unitOfWork.toDoListRepo.Getlists();
                return View(data);
                
            }
            catch (DataException)
            {
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, CreatedOn, is_Deleted")] toDoListVM list)
        {
            try
            { if (ModelState.IsValid)
                {
                    _unitOfWork.toDoListRepo.InsertList(list);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                } 
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

            }
            return View(list);
        }

        public ActionResult Details(int listId)
        {
            try
            {
                var data = _unitOfWork.toDoListRepo.GetListById(listId);
                return View(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpGet]
        public ActionResult Edit(int listId)
        {
            try
            {
                toDoListVM list = _unitOfWork.toDoListRepo.GetListById(listId);
                return View(list);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        [HttpPost]
     
        public ActionResult Edit([Bind(Include = "toDoListId,Name,CreatedOn, is_Deleted")] toDoListVM list)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.toDoListRepo.UpdateList(list);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(list);
        }

        public ActionResult Delete(int listId)
        {
            toDoListVM list = _unitOfWork.toDoListRepo.GetListById(listId);
            return View(list);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleted(int listId)
        {
            toDoListVM list = _unitOfWork.toDoListRepo.GetListById(listId);
            _unitOfWork.toDoListRepo.DeleteList(listId);
            _unitOfWork.Save();
            return RedirectToAction("Index");
            
        }
    }
}