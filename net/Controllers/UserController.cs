using Microsoft.AspNetCore.Mvc;
using net.Models;
using System.Collections.Generic;
using System.Linq;


namespace net.Controllers
{
    public class UserController : Controller
    {/*
        StudentContext context = new StudentContext();*/

        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext _context)
        {
            context = _context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public IActionResult createStudent([FromBody]User model)
        {
            var dataItem = context.Users.FirstOrDefault(x => x.UserName == model.UserName);
            if (dataItem == null)
            {
                context.Users.Add(model);
                context.SaveChanges();
                return Json(new { success = true, responseText = "successfull" });
            }
            else return Json(new { success = false, responseText = "UserName already exist" });
        }
         public JsonResult getStudent(string id)
            {
                List<User> students = new List<User>();
                students = context.Users.ToList();
                return Json(students);
            }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] User model)
        { 
            if(ModelState.IsValid)
            {
                var dataItem = context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                if (dataItem != null)
                {

                    if (dataItem.Password == model.Password)
                    {
                        return Json(new { success = true, responseText = "login successfull" });

                    }
                    else
                    {
                        return Json(new { success = false, responseText = "UserName Doesnot Exists" });

                    }
                }
                else
                {
                    return Json(new { success = false, responseText = "UserName Doesnot Exists" });
                }




            }
            else
            {
                return View(model);
            }
        }
       
    
                
        /*      [HttpPost]
               public IActionResult Login([FromBody] User model)
               {

                   var data = context.Users.Where(x => x.UserName == model.UserName).ToList() ;
                   if(data.Count() != 0)
                   {
                       var password = context.Users.Where(x=>x.Password == model.Password).ToList() ;
                       if (password.Count() != 0)
                       {
           bool isLogged;
                   if (dataItem != null)
                   {
                       isLogged = true;
                   }
                   else
                   {
                       isLogged = false;
                   }
                   return Json(isLogged);
                           //return Ok("Login Successfully");
                           return RedirectToAction(nameof(Index));
                          //return Json(new { success = true, responseText = "login successfull" });
                       }
                       else
                       {
                           return Json(new { success = false, responseText = "Password is incorrect" });
                           //return NotFound("Password is incorrect");
                       }
                   }
                   else
                   {
                       return Json(new { success = false, responseText = "UserName Doesnot Exists" });
                       //return NotFound("UserName Doesnot Exists");
                   }

               }*/
    }


}

    
