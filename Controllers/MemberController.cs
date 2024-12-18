using Christmas_Holiday.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Christmas_Holiday.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            using (ChristmasContext db = new ChristmasContext())
            {

                List<Member> memberslist = db.members.ToList();
                return View(memberslist);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Member newMember)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.members.Add(newMember);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
