using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Controllers
{
    public class CommentController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Comment
        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        public ActionResult CommentCreate()
        {
            ViewBag.projects = db.Project.ToList();

            return View();
        }
        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        [HttpPost]
        public ActionResult CommentCreate(Comment model, string UserID)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now.ToString("dd");
                var month = DateTime.Now.ToString("MMM");
                var year = DateTime.Now.ToString("yyyy");
                var time = DateTime.Now.ToString("h:mm tt");

                var FullDate = date + " " + month + " " + year + " " + time;

                model.DateTiem = FullDate;

                int Id = Convert.ToInt32(UserID);

                string aUser = db.User.First(p => p.UserID == Id).Name;

                model.CommentBy = aUser;

                db.Comment.Add(model);
                int i = db.SaveChanges();
                if (i == 1)
                {
                    ViewBag.Msg = i;
                }
                else
                {
                    ViewBag.Msg = 0;
                }

            }
            else
            {
                ViewBag.Msg = 0;
            }

            ViewBag.projects = db.Project.ToList();
            return View();

        }

        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        public ActionResult ViewComments()
        {
            ViewBag.projectList = db.Project.ToList();
            return View();
        }


        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        [HttpPost]
        public ActionResult ViewComments(Task model)
        {
            var comments = db.Comment.Where(p => p.ProjectID == model.ProjectID && p.TaskID == model.TaskID).ToList();
            ViewBag.totalComment  = comments.Count();
            ViewBag.projectList = db.Project.ToList();
            return View(comments);
        }


        public JsonResult GetTaskByProjectID(int ProjectID)
        {
            var Tasks = db.Task.Where(p => p.ProjectID == ProjectID).ToList();

            List<SelectListItem> taskList = new List<SelectListItem>();

            taskList.Add(new SelectListItem { Text = "Select Task", Value = "0" });

            foreach (var m in Tasks)
            {
                taskList.Add(new SelectListItem { Text = m.TaskDescription, Value = Convert.ToString(m.TaskID) });
            }
            return Json(taskList, JsonRequestBehavior.AllowGet);

        }
    }
}