using System;
using System.Linq;
using PJATK.DataModels;
using PJATK.Models;
using PJATK.Services;
using PJATK.Utils;

namespace PJATK.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private object _initData;

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            var currentUserCredentials = CredentialLocker.GetUserCredentials();
            if (currentUserCredentials == null)
            {
                await CoreMethods.PushPageModel<LoginViewModel>();
                CoreMethods.RemoveFromNavigation();
            }
            else
            {
                if (_initData is StudentPersonalData studentPersonalData)
                {
                    AppData.StudentPersonalData = studentPersonalData;
                }
                else
                {
                    AppData.StudentPersonalData = await WebService.Instance.GetStudentPersonalData();
                }

                AppData.GradesDataModels = AppData.StudentPersonalData.Oceny
                    .GroupBy(x => x.Semestr)
                    .OrderByDescending(x => x.Key)
                    .Select(group => new GradesDataModel
                    {
                        Name = group.Key,
                        Grades = group.ToList()
                    }).ToList();

                AppData.PaymentsDataModel = new PaymentsDataModel
                {
                    Konto_wplat = AppData.StudentPersonalData.Konto_wplat,
                    Konto_wyplat = AppData.StudentPersonalData.Konto_wyplat,
                    Kwota_naleznosci = AppData.StudentPersonalData.Kwota_naleznosci,
                    Kwota_wplat = AppData.StudentPersonalData.Kwota_wplat,
                    Kwota_wyplat = AppData.StudentPersonalData.Kwota_wyplat,
                    Saldo = AppData.StudentPersonalData.Saldo,
                    Oplaty = AppData.StudentPersonalData.Oplaty.OrderByDescending(x => x.TerminPlatnosci).ToList(),
                    Platnosci = AppData.StudentPersonalData.Platnosci.OrderByDescending(x => x.DataWplaty).ToList()
                };

                var today = DateTime.Today;
                var studentSchedules = await WebService.Instance.GetStudentSchedules(today, today.AddMonths(1));
                AppData.StudentScheduleDataModels = studentSchedules
                    .GroupBy(x => x.Data_roz.Date)
                    .OrderBy(x => x.Key)
                    .Select(group => new ScheduleDataModel
                    {
                        Date = group.Key,
                        StudentSchedules = group.ToList()
                    }).ToList();

                await CoreMethods.PushPageModel<DashboardViewModel>();
                CoreMethods.RemoveFromNavigation();
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            _initData = initData;
        }
    }
}
