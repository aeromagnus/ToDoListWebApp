using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListingApp.BusinessObjects;
using ListingApp.Infrastructure.Interfaces;
using ListingApp.Infrastructure.Repos;

namespace ListingApp.View.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        // GET: Users
        public ActionResult Index()
        {
            try
            {
                usersVM user = new usersVM();
                user.listUsers = _unitOfWork.usersRepo.GetUsers();
                return View(user);
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
        public ActionResult Create([Bind(Include = "userName, pass")] usersVM data)
        {
            try
            {
                var result = _unitOfWork.usersRepo.checkusername(data.userName);
                if (ModelState.IsValid)
                {
                    if (result == null)
                    {
                        _unitOfWork.usersRepo.InsertUsers(data);
                        _unitOfWork.Save();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("userName", "Cannot be added as this username already exists");

                    }
                }
            }
            catch (/*DataException*/ Exception ex)
            {
                throw ex.InnerException;
                //ModelState.AddModelError("","users cannot be created. So, Fucker Refresh this page or do nothing MF");
            }
            return View(data);
        }
        public ActionResult Details(int id)
        {
            try
            {
                var data = _unitOfWork.usersRepo.GetUsersByID(id);
                return View(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                usersVM list = _unitOfWork.usersRepo.GetUsersByID(id);
                return View(list);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userName, pass,createdOn, is_Deleted")] usersVM _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.usersRepo.UpdateUsers(_user);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(_user);
        }

        public ActionResult Delete(int listId)
        {
            usersVM list = _unitOfWork.usersRepo.GetUsersByID(listId);
            return View(list);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleted(int listId)
        {
            usersVM list = _unitOfWork.usersRepo.GetUsersByID(listId);
            _unitOfWork.usersRepo.DeleteUsers(listId);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }
        
        //[HttpPost]
        //public ActionResult Login(usersVM data)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var _username = _unitOfWork.usersRepo.checkusername(data.userName);
        //            var _password = _unitOfWork.usersRepo.checkpass(data.pass);
        //            if (_username == data.userName && _password == data.pass)
        //            {
        //                TempData["success"] = "Successfully Added";
        //                return RedirectToAction("Index", "todoList");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "cannot be Logged in");
        //                return View("Login");
        //            }
        //        }
        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", "cannot be Logged in");
        //    }
        //    return RedirectToAction("Login", "Users");
        //}

    }
}