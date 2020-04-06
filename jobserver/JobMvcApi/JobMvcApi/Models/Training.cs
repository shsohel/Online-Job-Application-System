using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models
{
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }
        public string Title { get; set; }
        public string Topics { get; set; }
        public string Institute { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

        [Display(Name = "Training Year")]
        public string TrainingYear { get; set; }
        public string Duration { get; set; }

        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

    

    }
}