using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    [Table("Task_tbl")]
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string TaskDescription { get; set; }
        public string TaskDueDate { get; set; }
        public string Priority { get; set; }
        public string AssignedBy { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual List<Comment> CommentList { get; set; }

        [NotMapped]
        public string AssignTo { get; set; }
    }
}