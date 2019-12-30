using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(int id ,string name ,string email,string password,int age)
        {
            Student stud = new Student { Id = id, Name = name, Email = email, Password = password, Age = age };
            bool status=StudentManager.RegisterStudent(stud);
            return RedirectToAction("authenticate","Student");
        }

        [HttpGet]
        public ActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(string email,string password)
        {
            if(StudentManager.Authenticate(email,password))
            {
                return RedirectToAction("Insert", "Student");
            }
            return View();
        }

            
    }

}