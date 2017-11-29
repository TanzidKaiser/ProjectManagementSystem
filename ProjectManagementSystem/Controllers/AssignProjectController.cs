using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Controllers
{
    public class AssignProjectController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: AssignProject
        [Authorize(Roles ="Project Manager")]
        public ActionResult Index()
        {

             var AssignProjectResource = db.AssignProject.ToList();

            ViewBag.projects = db.Project.ToList();
            ViewBag.users = db.User.ToList();
            return View(AssignProjectResource);
        }
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public ActionResult Index(AssignProjectToUser model)
        {
            if (ModelState.IsValid)
            {
                var key = 0;
                var aUser = db.AssignProject.Where(p => p.UserID == model.UserID).ToList();
                foreach(var a in aUser)
                {
                   if(a.ProjectID == model.ProjectID)
                    {
                        key = 1;
                    }
                }
                if (key == 0)
                {
                    db.AssignProject.Add(model);
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
                    ViewBag.Msg = 2;
                }
            }
            var AssignProjectResource = db.AssignProject.ToList();
            ViewBag.projects = db.Project.ToList();
            ViewBag.users = db.User.ToList();
            return View(AssignProjectResource);
        }
       
    }
}
