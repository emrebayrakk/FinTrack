using Microsoft.AspNetCore.Components;
using Radzen;

namespace FinTrack.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private NotificationService NotificationService { get; set; }

        private void OnClick()
        {
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success Summary", Detail = "Success Detail", Duration = 4000 });
        }
    }
}
