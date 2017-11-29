using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Controllers
{
    public class ViewProjectController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: ViewProject

        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        public ActionResult Index(string UserId)
        {
            List<ProjectViewBag> projectViewBag = new List<ProjectViewBag>();
            int id = Convert.ToInt32(UserId);
            var assignedProjet = db.AssignProject.Where(p => p.UserID == id).ToList();

            foreach(var a in assignedProjet)
            {
                ProjectViewBag pViewBag = new ProjectViewBag();

                var project = db.Project.Where(p => p.ProjectID == a.ProjectID).Select(x => new { ProjectName = x.ProjectName, ProjectCode = x.ProjectCode, Status = x.Status , ProjectID =x.ProjectID}).FirstOrDefault();

                pViewBag.ProjectID = project.ProjectID;
                pViewBag.ProjectName = project.ProjectName;
                pViewBag.ProjectCode = project.ProjectCode;
                pViewBag.Status = project.Status;

                var noOfMembers = db.AssignProject.Where(c => c.ProjectID == project.ProjectID)
                   .GroupBy(c => c.ProjectID).Select(g => new { total = g.Count() }).FirstOrDefault();
                if(noOfMembers != null)
                {
                    pViewBag.NoOFMember = noOfMembers.total;

                }
                else
                {
                    pViewBag.NoOFMember = 0;
                }

                var noOfTask = db.Task.Where(c => c.ProjectID == project.ProjectID)
                  .GroupBy(c => c.ProjectID).Select(g => new { totalTask = g.Count() }).FirstOrDefault();
                if (noOfTask != null)
                {
                    pViewBag.NoOFTask = noOfTask.totalTask;

                }
                else
                {
                    pViewBag.NoOFTask = 0;
                }
                
                projectViewBag.Add(pViewBag);

                
            }

            return View(projectViewBag);
        }
        [Authorize(Roles = "Developer,Project Manager,Team Lead, QA Engineer,UX Engineer")]
        public ActionResult ProjectDetails(int id)
        {
            List<Task> TaskList = new List<Task>();
            List<Project> AssignProjectList = new List<Project>();

            ViewBag.project = db.Project.Where(p => p.ProjectID == id).ToList();

            var tasks = db.Task.Where(p => p.ProjectID == id).ToList();

            var assignMember = db.AssignProject.Where(p => p.ProjectID == id).ToList();

            foreach(var b in assignMember)
            {
                Project project = new Project();
                var user = db.User.First(p => p.UserID == b.UserID).Name;
                project.UserName = user;
                AssignProjectList.Add(project);
            }

            foreach (var a in tasks)
            {
                Task task = new Task();
                string assignName = db.User.First(p => p.UserID == a.UserID).Name;

                task.TaskDescription = a.TaskDescription;
                task.Priority = a.Priority;
                task.TaskDueDate = a.TaskDueDate;
                task.AssignedBy = a.AssignedBy;
                task.AssignTo = assignName;

                TaskList.Add(task);
            }
            ViewBag.assignMembers = AssignProjectList;
            return View(TaskList);
        }
        
        
    }
}
