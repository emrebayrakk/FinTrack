using FinTrack.Dtos;
using FinTrack.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace FinTrack.Components.Pages
{
    public partial class YüzeyselHisse
    {
        private string hisseAdi { get; set; } = default!;
        private DetayliResponse detayliResponse {  get; set; } 
        private bool isLoading { get; set; } = false;
        private string errorMessage { get; set; } = default!;
        [Inject] private IFinService FinService { get; set; }

        private async Task FetchHisseData()
        {
            isLoading = true;
            errorMessage = string.Empty;

            try
            {
                var res = await FinService.DetayliHisse(hisseAdi);
                if (res.Code == 200)
                {
                    detayliResponse = res.Data;
                }
                else
                {
                    errorMessage = "Veriler alınırken bir hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Veriler alınırken bir hata oluştu.";
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}
