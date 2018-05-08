using System;
using System.Collections.Generic;
using System.Text;
using PJATK.Models;

namespace PJATK.DataModels
{
    public class ScheduleDataModel
    {
        public DateTime Date { get; set; }
        public ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
