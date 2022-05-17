using System;
using System.Collections.Generic;
using System.Data;
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
            try { 
            usersVM user = new usersVM();
            user.listUsers = _unitOfWork.usersRepo.GetUsers();
            return View(user);
            }
            catch (DataException)
            {

            }
            return View();


        }
    }
}