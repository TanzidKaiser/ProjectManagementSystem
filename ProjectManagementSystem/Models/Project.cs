using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjectManagementSystem.Models;
namespace ProjectManagementSystem.Models
{
    [Table("Project_tbl")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
        public string ProjectDurationDays { get; set; }
        public byte[] file { get; set; }
        public string Status { get; set; }
        public virtual List<AssignProjectToUser> AssignProject { get; set; }
        public virtual List<Task> TaskList { get; set; }
        public virtual List<Comment> CommentList { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}