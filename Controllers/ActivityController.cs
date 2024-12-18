using System.Diagnostics;
using Christmas_Holiday.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Christmas_Holiday.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                List<Models.Activity> activitylist = db.activities.ToList();
                return View(activitylist);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                ViewBag.Id = new SelectList(db.members, "MemberId", "Name");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Activity newActivity)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.activities.Add(newActivity);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                Models.Activity activity = db.activities.Find(id);
                return View(activity);
            }
        }
        public IActionResult Edit(int id)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                Models.Activity activity = db.activities.Find(id);
                if (activity == null)
                {
                    ViewBag.ErrorMessage = "Denna aktivitet finns inte, försök igen.";
                    return View("Error");
                }
                return View(activity);

            }
        }
        [HttpPost]
        public IActionResult Edit(Models.Activity activity)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.Update(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int Id)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                Models.Activity activity = db.activities.Find(Id);
                if (activity == null)
                {
                    ViewBag.ErrorMessage = "Denna aktivitet finns inte, försök igen.";
                    return View("Error");
                }
                return View(activity);
            }
        }
        [HttpPost]
        public IActionResult DeleteActivity(Models.Activity activity)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.activities.Remove(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
