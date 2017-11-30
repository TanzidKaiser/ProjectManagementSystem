using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Project
        [Authorize(Roles ="Project Manager")]
        public ActionResult ProjectCreate()
        {
            var projects = db.Project.ToList();
            return View(projects);
        }
        [HttpPost]
        public ActionResult ProjectCreate(Project model)
        {
            
                
                    //if(file != null)
                    //{
                    //    model.file = new byte[file.ContentLength];
                    //    file.InputStream.Read(model.file, 0, file.ContentLength);
                    //}
                    db.Project.Add(model);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        ViewBag.Msg = i;
                    }
                    else
                    {
                        ViewBag.Msg = 0;
                    }
                
           
            var projects = db.Project.ToList();
            return View(projects);
        }
        public JsonResult EditProject(int ProjectId)
        {

            var aProject = db.Project.Where(p => p.ProjectID == ProjectId).FirstOrDefault();
            var returnProject = new
            {
                ProjectID = aProject.ProjectID,
                ProjectName = aProject.ProjectName,
                ProjectCode = aProject.ProjectCode,
                Description = aProject.Description,
                ProjectStartDate = aProject.ProjectStartDate,
                ProjectEndDate = aProject.ProjectEndDate,
                ProjectDurationDays = aProject.ProjectDurationDays,
                Status = aProject.Status,               
            };

            return Json(returnProject, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProject(Project model)
        {
            var aProject = db.Project.SingleOrDefault(p => p.ProjectID == model.ProjectID);

            aProject.ProjectName = model.ProjectName;
            aProject.ProjectCode = model.ProjectCode;
            aProject.Description = model.Description;
            aProject.ProjectStartDate = model.ProjectStartDate;
            aProject.ProjectEndDate = model.ProjectEndDate;
            aProject.ProjectDurationDays = model.ProjectDurationDays;
            aProject.Status = model.Status;

            int key = db.SaveChanges();
            return Json(key, JsonRequestBehavior.AllowGet);
        }

     
    }
}