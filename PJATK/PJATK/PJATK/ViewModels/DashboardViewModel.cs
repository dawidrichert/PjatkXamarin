using System;
using PJATK.DataModels;
using PJATK.Utils;
using Xamarin.Forms;

namespace PJATK.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public string UserName { get; set; }

        public DashboardViewModel()
        {
            UserName = AppData.StudentPersonalData.Imie;
        }

        public Command QuickLinkCommand
        {
            get
            {
                return new Command(parameter =>
                {
                    Device.OpenUri(new Uri(parameter.ToString()));
                });
            }
        }
        
        public Command ScheduleCommand
        {
            get
            {
                return new Command(async () =>
                {
                });
            }
        }

        public Command PaymentsCommand
        {
            get
            {
                return new Command(async () =>
                {
                });
            }
        }

        public Command GradesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<GradesViewModel>();
                });
            }
        }

        public Command LogoutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    CredentialLocker.RemoveUserCredentials();
                    await CoreMethods.PushPageModel<LoginViewModel>();
                    CoreMethods.RemoveFromNavigation();
                });
            }
        }
    }
}
