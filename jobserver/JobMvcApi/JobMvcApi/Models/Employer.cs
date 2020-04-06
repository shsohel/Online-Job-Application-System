using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models
{
    public class Employer
    {
        [Key]
        public int EmployerID { get; set; }
        //[Required(ErrorMessage = "The User name cannot be blank")]
        [Display(Name = "User Name")]

        public string UserName { get; set; }

        // public string UserId { get; set; }
        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Catageory { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Business Description")]
        public string BusinessDescription { get; set; }
        [Display(Name = "Website Url")]
        public  string WebsiteUrl { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "TelePhone")]
        public string TelePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
                  


        public virtual ICollection<JobList> JobLists { get; set; }
        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }




    }
}