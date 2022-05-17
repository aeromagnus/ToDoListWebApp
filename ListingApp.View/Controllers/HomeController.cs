using ListingApp.Infrastructure.Interfaces;
using ListingApp.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListingApp.View.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitofwork = new UnitOfWork();

        
        public ActionResult Index()
        {
            try
            {
                var data = _unitofwork.toDoListRepo.Getlists();

                return View(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}