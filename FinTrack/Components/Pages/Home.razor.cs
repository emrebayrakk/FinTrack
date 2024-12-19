using FinTrack.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace FinTrack.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private NotificationService NotificationService { get; set; }
        [Inject] private IFinService FinService { get; set; }

        private async void OnClick()
        {
            var res = await FinService.AllReadHisse();
            if (res.Code != 200) 
            {
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = res.Message, Duration = 4000 });
            }
            else
            {
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success Summary", Detail = res.Message, Duration = 4000 });
            }

            
        }
    }
}
