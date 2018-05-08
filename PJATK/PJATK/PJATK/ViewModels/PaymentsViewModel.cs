using PJATK.DataModels;

namespace PJATK.ViewModels
{
    public class PaymentsViewModel : BaseViewModel
    {
        public PaymentsDataModel PaymentsDataModel { get; set; }

        public PaymentsViewModel()
        {
            PaymentsDataModel = AppData.PaymentsDataModel;
        }
    }
}
