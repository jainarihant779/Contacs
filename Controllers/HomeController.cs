using Contacs.BAL;
using Contacs.Models;
using Contacs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Contacs.Controllers
{
    public class HomeController : Controller
    {
        public IDbAccess DBAccess { get; set; }
        public HomeController(IDbAccess DB)
        {
            DBAccess = DB;
        }

        public IActionResult Index()
        {
            vmDetailList obj = new vmDetailList(DBAccess);
            var a = obj.GetList();
            return View(a);
           
        }

        public ActionResult Edit(int ID)
        {
            vmDetailList obj = new vmDetailList(DBAccess);

            Details objDetails = obj.GetList().Where(x => x.ID == ID).FirstOrDefault();
            return View(objDetails);
        }

        [HttpPost]
        public ActionResult Edit(Details ObjDetails)
        {
            vmDetailList obj = new vmDetailList(DBAccess);
            obj.UpdateDetails(ObjDetails);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Details ObjDetails)
        {
            vmDetailList obj = new vmDetailList(DBAccess);
            obj.AddContact(ObjDetails);
            return RedirectToAction(nameof(Index));
         
        }

        public ActionResult Delete(int id)
        {
            vmDetailList obj = new vmDetailList(DBAccess);

            Details objDetails = obj.GetList().Where(x => x.ID == id).FirstOrDefault();
            return View(objDetails);
        }

        [HttpPost]
        public ActionResult Delete(Details objDetails)
        {
            vmDetailList obj = new vmDetailList(DBAccess);
            obj.DeleteContact(objDetails.ID);
            return RedirectToAction(nameof(Index));
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}
