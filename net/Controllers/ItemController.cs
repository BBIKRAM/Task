using Microsoft.AspNetCore.Mvc;
using net.Models;
using System.Collections.Generic;

namespace net.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objlist = _db.Items;
            return View(objlist);
        }
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else {
                var obj = _db.Items.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
        }

        [HttpPost]
        public IActionResult AddorEdit(int id,Item obj )
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _db.Items.Add(obj);
                    _db.SaveChanges();
                    return Json(new { success = true, responseText = "login successfull" });
                   // return Json(new { success = true, responseText = "created" });
                    //return RedirectToAction("Index");
                }
                else
                {
                    _db.Items.Update(obj);
                    _db.SaveChanges();
                     return Json(new { success = true, responseText = "updated" });
                    //return RedirectToAction("Index");

                }

            }
            return NotFound("not found");
        }

      /*  public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item obj)
        {

            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }*/
/*        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }*/
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Items.Find(id);
            if (obj == null || id == 0)
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return Json(new { success = true, responseText = "deleted" });
            //return RedirectToAction("Index");
        }
    /*    public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        public IActionResult update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);  
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }*/
    }
}
