using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssignmentFive.Models;

namespace AssignmentFive.DAL
{
    public class ActivityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ActivityDBContext>
    {
        protected override void Seed(ActivityDBContext context)
        {

            var activities = new List<Activity>
                {
                new Activity{
                    ActivityName = "The Narrows",
                    ActivityTitle = "The Narrows",
                    ActivityDate = DateTime.Parse("1989-1-11"),
                    ActivityCategory = "Backpacking",
                    ActivityLengthHours = 72.25M,

                    ActivityParticipants = "Zachary David",
                    ActivityDescription = "3-day backpacking trip into the Narrows in Zion National Park"
                    ,
                    ActivityText = "A beautiful backpacking trip between the walls of the canyon.  Much of our time will be spent hiking in the water."
                },
                new Activity
                {
                    ActivityName = "Death Hollow",
                    ActivityTitle = "Death Hollow",
                    ActivityDate = DateTime.Parse("1984-3-13"),
                    ActivityCategory = "Backpacking",
                    ActivityLengthHours = 48.00M,

                    ActivityParticipants = "Brendan Michael",
                    ActivityDescription = "Backpacking an old mail trail in Southern Utah."
                    ,
                    ActivityText = "A somewhat technical backpacking trip in Southern Utah.  The last day is spent scrambling over 1,000 feet to the top."
                },

                new Activity
                {
                    ActivityName = "Lady Mountain",
                    ActivityTitle = "Lady Mountain",
                    ActivityDate = DateTime.Parse("2015-12-13"),
                    ActivityCategory = "Hiking",
                    ActivityLengthHours = 8.00M,

                    ActivityParticipants = "Logan Timothy",
                    ActivityDescription = "Difficult climb to the top of Lady Mountain."
                    ,
                    ActivityText = "Strenuous hike with exposure."
                },
                new Activity
                {
                    ActivityName = "Green River Rafting",
                    ActivityTitle = "Green River Rafting",
                    ActivityDate = DateTime.Parse("2012-09-13"),
                    ActivityCategory = "Rafting",
                    ActivityLengthHours = 72.00M,

                    ActivityParticipants = "Timothy Ronald",
                    ActivityDescription = "Beginner rafting trip."
                    ,
                    ActivityText = "Beginner-friendly rafting trip down the Green River.  We will be using duckys, rafts, and oar rigs."
                },
                new Activity
                {
                    ActivityName = "Monte Cristo",
                    ActivityTitle = "Monte Cristo",
                    ActivityDate = DateTime.Parse("1959-1-11"),
                    ActivityCategory = "Roadbike",
                    ActivityLengthHours = 5.00M,

                    ActivityParticipants = "Paula F",
                    ActivityDescription = "Climb from Huntsville to Monte Cristo Campground"
                    ,
                    ActivityText = "Almost 3 hours of climbing in this 60-mile round trip ride."
                }
               };
            activities.ForEach(s => context.Activities.Add(s));
            context.SaveChanges();
        }


    }
}
