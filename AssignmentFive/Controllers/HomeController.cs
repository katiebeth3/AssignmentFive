using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentFive.DAL;
using AssignmentFive.ViewModels;

namespace AssignmentFive.Controllers
{
    public class HomeController : Controller
    {
        private ActivityDBContext db = new ActivityDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            {
                IQueryable<LeaderActivityData> data = from tripleader in db.Activities
                                                       group tripleader by tripleader.TripLeader.LastName into dateGroup
                                                       select new LeaderActivityData()
                                                       {
                                                           TripLeaderLastName = dateGroup.Key,
                                                           ActivityCount = dateGroup.Count()
                                                       };
                return View(data.ToList());
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}