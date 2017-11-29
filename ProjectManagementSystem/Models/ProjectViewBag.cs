using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class ProjectViewBag
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Status { get; set; }
        public int NoOFMember { get; set; }
        public int NoOFTask { get; set; }
    }
}