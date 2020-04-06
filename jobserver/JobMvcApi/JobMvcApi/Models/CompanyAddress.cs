using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models
{
    public class CompanyAddress
    {
        [Key]
        public int CompanyAddressID { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        [Display(Name = "Address Details")]
        public string AddressDetails { get; set; }

        public int EmployerID { get; set; }
        public virtual Employer Employer { get; set; }



    }
}