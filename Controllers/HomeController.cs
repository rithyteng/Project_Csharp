using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace game.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register(User adduser){
        if(ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == adduser.Email))
        {
            // Manually add a ModelState error to the Email field, with provided
            // error message
            ModelState.AddModelError("Email", "Email already in use!");
            return View("Index");
            
        }
         // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                adduser.Password = Hasher.HashPassword(adduser, adduser.Password);
                //Save your user object to the database
                dbContext.Add(adduser);
                dbContext.SaveChanges();

                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == adduser.Email);
                HttpContext.Session.SetInt32("ID",userInDb.UserId);
                return RedirectToAction("Dashboard",new{id = userInDb.UserId});
            }
            return View("Index");
        }

        [HttpPost("LogIn")]
        public IActionResult LogIn(Login thisuser){
        if(ModelState.IsValid)
        {
            // If inital ModelState is valid, query for a user with provided email
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == thisuser.Email);
            // If no user exists with provided email
            if(userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            
            // Initialize hasher object
            var hasher = new PasswordHasher<Login>();
            
            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(thisuser, userInDb.Password, thisuser.Password);
            
            // result can be compared to 0 for failure
            if(result == 0)
            {
                ModelState.AddModelError("Password","Invalid Email/Passwordz");
                return View("Index");
                // handle failure (this should be similar to how "existing email" is handled)
            }
            else{
                HttpContext.Session.SetInt32("ID",userInDb.UserId);
                return RedirectToAction("Dashboard",new{id = userInDb.UserId});
            }
        }
        return View("Index");
        }
        [HttpGet("Dashboard/{id}")]
        public IActionResult Dashboard(int id){
            
            int? myid = HttpContext.Session.GetInt32("ID");
            ViewBag.Id = myid;
            if(myid !=id ){
                return View("Index");
            }
            User myuser = dbContext.Users.FirstOrDefault( u => u.UserId == myid);
            ViewBag.Name = myuser.UserName;
            if(myuser.Wizard ==true){

                ViewBag.Wizard = true;
            }
            if(myuser.Samurai ==true){
                ViewBag.Samurai = true;
            }
            if(myuser.Archer ==true){
                Archer myarcher = new Archer("Legolas");
                ViewBag.Str = myarcher.Strength;
                ViewBag.Lv = myarcher.Level;
                ViewBag.Exp = myarcher.Exp;
                ViewBag.Int = myarcher.Intelligence;
                ViewBag.Dex = myarcher.Dexterity;
                ViewBag.Hp = myarcher.Health;
                ViewBag.Archer = true;
            }
            

            
            return View("Dashboard");
        }
        [HttpGet("train/{id}")]
        public IActionResult train(int id){
            Archer myarcher = new Archer("Legolas");
            myarcher.Level += 1;
            return RedirectToAction("Dashboard",new{id = id});
        }

        [HttpGet("addcharacter/{id}")]
        public IActionResult addcharacter(int id){
            return View("ChoseCharacter");
        }
        [HttpGet("/wizard")]
        public IActionResult Wizard(){
            int? myid = HttpContext.Session.GetInt32("ID");

            User myuser = dbContext.Users.FirstOrDefault( u => u.UserId == myid);
            myuser.Wizard = true;
            myuser.Samurai = false;
            myuser.Archer = false;
            dbContext.Update(myuser);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard",new{id = myid});
        }

        [HttpGet("/samurai")]
        public IActionResult Samurai(){
            int? myid = HttpContext.Session.GetInt32("ID");

            User myuser = dbContext.Users.FirstOrDefault( u => u.UserId == myid);
            myuser.Wizard = false;
            myuser.Samurai = true;
            myuser.Archer = false;
            dbContext.Update(myuser);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard",new{id = myid});
        }

        [HttpGet("/archer")]
        public IActionResult archer(){
            int? myid = HttpContext.Session.GetInt32("ID");

            User myuser = dbContext.Users.FirstOrDefault( u => u.UserId == myid);
            myuser.Wizard = false;
            myuser.Samurai = false;
            myuser.Archer = true;
            dbContext.Update(myuser);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard",new{id = myid});
        }


        [HttpGet("logout")]
        public IActionResult LogOut(){

            HttpContext.Session.Clear();
            return View("Index");
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
    }
}
