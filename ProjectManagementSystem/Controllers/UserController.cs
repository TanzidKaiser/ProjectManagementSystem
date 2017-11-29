using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: User
        [Authorize(Roles = "IT Admin")]
        public ActionResult UserCreate()
        {
            var userList = db.User.ToList();
            ViewBag.designations = GetDesignationList();

            return View(userList);
        }

        [HttpPost]
        public ActionResult UserCreate(User model)
        {
            if (ModelState.IsValid)
            {
                var emailExist = db.User.Where(p => p.Email == model.Email).FirstOrDefault();
                if (emailExist == null)
                {
                    var designationList = GetDesignationList();
                    string name = designationList.First(p => p.Id == Convert.ToInt32(model.Designation)).Name;
                    model.Designation = name;
                    model.Password = model.Email + "" + 123;
                    db.User.Add(model);
                    db.SaveChanges();
                    ViewBag.Msg = 1;

                }
                else
                {
                    ViewBag.Msg = 2;
                }
            }
            var userList = db.User.ToList();
            ViewBag.designations = GetDesignationList();
            return View(userList);
        }

        private List<Designation> GetDesignationList()
        {
            List<Designation> designations = new List<Designation>()
            {
                new Designation { Id=1, Name="Developer"},
                new Designation { Id=2, Name="Project Manager"},
                new Designation { Id=3, Name="Team Lead"},
                new Designation { Id=4, Name="QA Engineer"},
                new Designation { Id=5, Name="UX Engineer"},
                new Designation {Id=6, Name="IT Admin"},
            };


            return designations;
        }

        public JsonResult EditUser(int UserId)
        {
            var aUser = db.User.Where(p => p.UserID == UserId).FirstOrDefault();

            var designationList = GetDesignationList();

            int value = designationList.First(p => p.Name == aUser.Designation).Id;
            //aUser.Designation = Convert.ToString(value);
            var returnUser = new
            {

                ID = aUser.UserID,
                Name = aUser.Name,
                Email = aUser.Email,
                Password = aUser.Password,
                Status = aUser.Status,
                DesId = value
            };
            return Json(returnUser, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateUser(User model)
        {
            var aUser = db.User.SingleOrDefault(p => p.Email == model.Email);
            aUser.Name = model.Name;
            aUser.Email = model.Email;
            aUser.Password = model.Password;
            aUser.Status = model.Status;
            //aUser.Designation = model.Designation;
            var designationList = GetDesignationList();
            string name = designationList.First(p => p.Id == Convert.ToInt32(model.Designation)).Name;

            aUser.Designation = name;

            int key = db.SaveChanges();
            return Json(key, JsonRequestBehavior.AllowGet);
        }
    }
}