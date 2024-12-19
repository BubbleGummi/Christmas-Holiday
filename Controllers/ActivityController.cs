using System.Diagnostics;
using Christmas_Holiday.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Christmas_Holiday.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            List<Models.Activity> activitylist;

            using (ChristmasContext db = new ChristmasContext())
            {
                activitylist = db.Activities.Include(m => m.Member).ToList();
            }

            return View(activitylist);
        }

        public IActionResult Dropdown()
        {
            List<SelectListItem> dropdownItems;

            using (ChristmasContext db = new ChristmasContext())
            {
                dropdownItems = db.Activities
                    .Include(a => a.Member)
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = $"{a.Title} ({(a.Member != null ? a.Member.Name : "No Member")})"
                    })
                    .ToList();
            }

            ViewBag.ActivityDropdown = dropdownItems;
            return View();
        }

        public IActionResult Create(int id)
        {
            List<SelectListItem> membersDropdown;

            using (ChristmasContext db = new ChristmasContext())
            {
                var members = db.Members.ToList();

                if (members == null || !members.Any())
                {
                    ViewBag.ErrorMessage = "Inga medlemmar tillgängliga. Lägg till medlemmar först.";
                    return View("Error");
                }

                membersDropdown = members
                    .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name })
                    .ToList();

            }

            ViewBag.MembersDropdown = membersDropdown;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Activity newActivity)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> membersDropdown;

                using (ChristmasContext db = new ChristmasContext())
                {
                    membersDropdown = db.Members
                        .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name })
                        .ToList();
                }

        
            }

            using (ChristmasContext db = new ChristmasContext())
            {
                db.Activities.Add(newActivity); 
                db.SaveChanges(); 
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Models.Activity activity;
            List<SelectListItem> membersDropdown;

            using (ChristmasContext db = new ChristmasContext())
            {
                activity = db.Activities.Include(a => a.Member).FirstOrDefault(a => a.Id == id);

                if (activity == null)
                {
                    ViewBag.ErrorMessage = "Aktiviteten finns inte.";
                    return View("Error");
                }

                membersDropdown = db.Members
                    .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name })
                    .ToList();
            }

            ViewBag.MembersDropdown = membersDropdown;
            return View(activity);
        }
        public IActionResult Edit(int id)
        {
            Models.Activity activity;
            List<SelectListItem> membersDropdown;

            using (ChristmasContext db = new ChristmasContext())
            {
                activity = db.Activities.Include(a => a.Member).FirstOrDefault(a => a.Id == id);

                if (activity == null)
                {
                    ViewBag.ErrorMessage = "Denna aktivitet finns inte, försök igen.";
                    return View("Error");
                }

                membersDropdown = db.Members
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name
                    })
                    .ToList();
            }

            ViewBag.MembersDropdown = membersDropdown;

            return View(activity);
        }

        [HttpPost]
        public IActionResult Edit(Models.Activity activity)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> membersDropdown;

                using (ChristmasContext db = new ChristmasContext())
                {
                    membersDropdown = db.Members
                        .Select(m => new SelectListItem
                        {
                            Value = m.Id.ToString(),
                            Text = m.Name
                        })
                        .ToList();
                        db.Activities.Update(activity);
                        db.SaveChanges();
                }

                ViewBag.MembersDropdown = membersDropdown;

            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Models.Activity activity;

            using (ChristmasContext db = new ChristmasContext())
            {
                activity = db.Activities.FirstOrDefault(a => a.Id == id);

                if (activity == null)
                {
                    ViewBag.ErrorMessage = "Denna aktivitet finns inte, försök igen.";
                    return View("Error");
                }
            }

            return View(activity);
        }

        [HttpPost]
        public IActionResult Delete(Models.Activity activity)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.Activities.Remove(activity);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
