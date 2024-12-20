﻿using Christmas_Holiday.Models;
using Microsoft.AspNetCore.Authorization;
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

                List<Member> memberslist = db.Members.ToList();
                return View(memberslist);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Member newMember)
        {
            using (ChristmasContext db = new ChristmasContext())
            {
                db.Members.Add(newMember);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
