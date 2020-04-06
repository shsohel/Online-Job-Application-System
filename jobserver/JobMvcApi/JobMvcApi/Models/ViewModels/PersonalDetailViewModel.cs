using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.ViewModels
{
    public class PersonalDetailViewModel
    {
      
        public int? PersonalDetailID { get; set; }

        // public string UserId { get; set; }
 
        public string UserName { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }

        public string FirstName { get; set; }
    
        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }



        public DateTime? DOB { get; set; }


        public string NationalID { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }
    }

    public class AddressViewModel
    {
        public int? AddressID { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int PersonalDetailID { get; set; }
    }
    public class PutAddress
    {
        public PutAddress()
        {
            addressViewModels = new List<AddressViewModel>();
        }
        List<AddressViewModel> addressViewModels { get; set; }
    }

    //public CreateEduQualViewModel()
    //{
    //    EmployeeEduQualViewModels = new List<EmployeeEduQualViewModel>();
    //}
    //// public EmployeeEduQualViewModel[] EmployeeEduQualViewModels { get; set; }
    //public List<EmployeeEduQualViewModel> EmployeeEduQualViewModels { get; set; }
}