using System.Collections.Generic;
using PJATK.DataModels;

namespace PJATK.ViewModels
{
    public class GradesViewModel : BaseViewModel
    {
        public IList<GradesDataModel> GradesDataModels { get; set; }

        public GradesViewModel()
        {
            GradesDataModels = AppData.GradesDataModels;
        }
    }
}
