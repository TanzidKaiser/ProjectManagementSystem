using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Task
        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        public ActionResult Index()
        {
            ViewBag.projects = db.Project.ToList();
            ViewBag.Prioritys = GetPrioritys();
            var TaskList = db.Task.ToList();
            return View(TaskList);
        }
        [HttpPost]
        public ActionResult Index(Task model, string UserID)
        {

            var priorityList = GetPrioritys();
            string aPriorityName = priorityList.First(p => p.ID == Convert.ToInt32(model.Priority)).Name;

            int Id = Convert.ToInt32(UserID);
            string aUser = db.User.First(p => p.UserID == Id).Name;

            model.Priority = aPriorityName;
            model.AssignedBy = aUser;


            db.Task.Add(model);

            int i = db.SaveChanges();

            if (i == 1)
            {
                ViewBag.Msg = i;
            }
            else
            {
                ViewBag.Msg = 0;
            }
            ViewBag.projects = db.Project.ToList();
            ViewBag.Prioritys = GetPrioritys();
            var TaskList = db.Task.ToList();
            return View(TaskList);
        }
        private List<Priority> GetPrioritys()
        {
            List<Priority> designations = new List<Priority>()
            {
                new Priority { ID=1, Name= "High"},
                new Priority { ID=2, Name= "Midium"},
                new Priority { ID=3, Name= "Low"},
            };


            return designations;
        }

        public JsonResult EditTask(int TaskId)
        {
            var aTask = db.Task.Where(p => p.TaskID == TaskId).FirstOrDefault();

            var priorityList = GetPrioritys();
            int Id = priorityList.First(p => p.Name == aTask.Priority).ID;

            aTask.Priority = Convert.ToString(Id);

            var returnTask = new {

                ID = aTask.TaskID,
                //proID = aTask.ProjectID,
                //UserID = aTask.UserID,
                discription = aTask.TaskDescription,
                date = aTask.TaskDueDate,
                priority = aTask.Priority               
            };

            return Json(returnTask, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTask(Task model)
        {

            var priorityList = GetPrioritys();
            string aPriorityName = priorityList.First(p => p.ID == Convert.ToInt32(model.Priority)).Name;

            model.Priority = aPriorityName;

            var aTask = db.Task.SingleOrDefault(p => p.TaskID == model.TaskID);

            aTask.ProjectID = model.ProjectID;
            aTask.UserID = model.UserID;
            aTask.TaskDescription = model.TaskDescription;
            aTask.TaskDueDate = model.TaskDueDate;
            aTask.Priority = model.Priority;

            int i = db.SaveChanges();

            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetResourceByProjectID(int ProjectID)
        {

            var users = db.AssignProject.Where(p => p.ProjectID == ProjectID).ToList();

            List<SelectListItem> userList = new List<SelectListItem>();

            userList.Add(new SelectListItem { Text = "Select Resource", Value = "0" });

            foreach (var m in users)
            {
                userList.Add(new SelectListItem { Text = m.User.Name, Value = Convert.ToString(m.UserID) });
            }
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}