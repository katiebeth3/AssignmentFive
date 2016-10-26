using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentFive.Models;
using System.Collections.Generic;
using AssignmentFive.DAL;

namespace AssignmentFive.Controllers
{
    public class ActivitiesController : Controller
    {
        private ActivityDBContext db = new ActivityDBContext();

        // GET: Activities
        public ActionResult Index(string activityCategory, string searchString)
        {
            var activities = db.Activities.Include(c => c.TripLeader);
            return View(activities.ToList());

            //var ActivityLst = new List<string>();

            //var ActivityQry = from d in db.Activities
            //                  orderby d.ActivityCategory
            //                  select d.ActivityCategory;
            //ActivityLst.AddRange(ActivityQry.Distinct());
            //ViewBag.activityCategory = new SelectList(ActivityLst);


            //var activities = from m in db.Activities //this is like select * from  movies
            //                 select m;

            //if (!string.IsNullOrEmpty(searchString))
            //    activities = activities.Where(s => s.ActivityTitle.Contains(searchString));

            //if (!string.IsNullOrEmpty(activityCategory))
            //{
            //    activities = activities.Where(x => x.ActivityCategory == activityCategory);
            //}
            //return View(activities);
        }
        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            PopulateTripLeadersDropDownList();
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ActivityName,ActivityDate,TripLeaderID,ActivityParticipants,ActivityCategory,ActivityDescription,ActivityLengthHours,ActivityText")] Activity activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Activities.Add(activity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            { //Log the error (uncomment dex variable name and add a line here to write a log.) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateTripLeadersDropDownList(activity.TripLeaderID);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            PopulateTripLeadersDropDownList(activity.TripLeaderID);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,ActivityName,ActivityDate,ActivityTitle,TripLeaderID,ActivityParticipants,ActivityCategory,ActivityDescription,ActivityLengthHours,ActivityText")] Activity activity)
        public ActionResult Edit([Bind(Include = "ID,ActivityName,ActivityDate,TripLeaderID,ActivityParticipants,ActivityCategory,ActivityDescription,ActivityLengthHours,ActivityText")] Activity activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(activity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateTripLeadersDropDownList(activity.TripLeaderID);
            return View(activity);
        }

        private void PopulateTripLeadersDropDownList(object selectedTripLeader = null)
        {
            var tripleadersQuery = from d in db.TripLeaders
                                   orderby d.LastName
                                   select d;
            ViewBag.TripLeaderID = new SelectList(tripleadersQuery, "TripLeaderID", "LastName", selectedTripLeader);
        }


        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
