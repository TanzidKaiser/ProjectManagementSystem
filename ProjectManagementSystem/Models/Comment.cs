using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    [Table("Comment_tbl")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ProjectID { get; set; }
        public int TaskID { get; set; }
        public string Description { get; set; }
        public string CommentBy { get; set; }
        public string DateTiem { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        [ForeignKey("TaskID")]
        public virtual Task Task { get; set; }

    }
}