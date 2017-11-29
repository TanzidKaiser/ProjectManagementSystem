using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    [Table("user_tbl")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        [Required]                
        public string Email { get; set; }        
        public string Password { get; set; }
        public string Status { get; set; }
        public string Designation { get; set; }
        public virtual List<AssignProjectToUser> AssignProject { get; set; }
        public virtual List<Task> TaskLsit { get; set; }
    }
}