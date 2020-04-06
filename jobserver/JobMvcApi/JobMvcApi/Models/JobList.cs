using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models
{
    public class JobList
    {
        [Key]
        public int JobListID { get; set; }
        public int EmployerID { get; set; }
        public virtual Employer Employer { get; set; }
        public string Position { get; set; }
        [Display(Name = "Number of Post")]
        public int NumberofPost { get; set; }
        [Display(Name = "Salary Scale")]
        public string SalaryScale { get; set; }
        [Display(Name = "Age Limit")]
        public string AgeLimit { get; set; }
        [Display(Name = "Education Requirement")]
        public string EducationRequirement { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Date of Application")]
        public DateTime LastDateofApplication { get; set; }
        [Display(Name = "Is Approve")]
        public bool IsApprove { get; set; }


        public virtual ICollection<ApplyJob> ApplyJobs { get; set; }
    }
}