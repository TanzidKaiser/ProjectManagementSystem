using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    [Table("AssignProject_tbl")]
    public class AssignProjectToUser
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}