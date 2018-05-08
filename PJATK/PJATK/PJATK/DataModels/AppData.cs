using System.Collections.Generic;
using PJATK.Models;

namespace PJATK.DataModels
{
    public static class AppData
    {
        public static StudentPersonalData StudentPersonalData { get; set; }
        public static IList<ScheduleDataModel> StudentScheduleDataModels { get; set; }
        public static PaymentsDataModel PaymentsDataModel { get; set; }
        public static IList<GradesDataModel> GradesDataModels { get; set; }
    }
}
