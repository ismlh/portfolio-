using BusinessModelLayer;
using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class profileItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public profileItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: profileItemsController
        public ActionResult Index()
        {

            return View(_context.ProfileItems.ToList());
        }


        // GET: profileItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: profileItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(profileItem profileItem, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string itemImage = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\portfolio", itemImage);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream);
                        }
                        profileItem.itemImage = itemImage;
                    }
                }
                _context.Add(profileItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(profileItem);
        }

        static profileItem oldprofileItem = new profileItem();
        // GET: Admin/teamMembers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileItem = _context.ProfileItems.Find(id);
            if (profileItem == null)
            {
                return NotFound();
            }
            oldprofileItem.itemImage = profileItem.itemImage;
            return View(profileItem);
        }

        // POST: profileItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(profileItem profileItem, List<IFormFile> Files)
        {


            if (ModelState.IsValid)
            {
                if (Files.Count > 0)
                {
                    foreach (var file in Files)
                    {

                        string itemImage = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\portfolio", itemImage);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }
                        profileItem.itemImage = itemImage;
                    }
                }
                else
                {
                    profileItem.itemImage = oldprofileItem.itemImage;
                }
                _context.Entry(profileItem).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileItem);
        }
        public ActionResult Delete(int id)
        {
            var profileItem = _context.ProfileItems.Find(id);
            _context.ProfileItems.Remove(profileItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
