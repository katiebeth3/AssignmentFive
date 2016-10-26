using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AssignmentFive.Models;

namespace AssignmentFive.ViewModels
{
    public class LeaderActivityData
    {
        public String TripLeaderLastName { get; set; }
        public int ActivityCount { get; set; }
    }
}