using ListingApp.BusinessObjects;
using ListingApp.Infrastructure.Interfaces;
using ListingApp.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListingApp.View.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(usersVM data)
        {
            try
            {
                var checking = _unitOfWork.loginRepo.check_username_pass(data.userName, data.pass);
                //var pass = _unitOfWork.usersRepo.checkpass(data.pass);
                if (checking != null)
                {
                    return RedirectToAction("Index", "toDoList");
                }
                else
                {
                    ModelState.AddModelError("", "Fucker!!!");
                    return View("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Couldnot be logged in");
            }
            return View();
        }
    }
}