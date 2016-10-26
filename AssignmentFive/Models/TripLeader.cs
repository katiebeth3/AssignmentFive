using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentFive.Models
{
    public class TripLeader
    {
        public int TripLeaderID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public String FirstName { get; set; }

        [Display(Name = "Trip Leader")]
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}