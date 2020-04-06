using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models
{
    public class PersonalDetail
    {
        [Key]
        public int PersonalDetailID { get; set; }

       // public string UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
         public string LastName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [Display(Name ="Birth of Date")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Display(Name = "National ID")]
        public string NationalID { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Photo { get; set; }



        public virtual ICollection<ApplyJob> ApplyJobs { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Skill>  Skills { get; set; }

               
    }
}