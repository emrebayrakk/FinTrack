using FinTrack.Data.Entities;
using FinTrack.Dtos;
using FinTrack.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace FinTrack.Components.Pages
{
    public partial class Hisse
    {
        [Inject]
        private IFinService FinService {  get; set; }
        private BorsaHisse BorsaHisse { get; set; } = default!;
        private RadzenDataGrid<BorsaHisse> BorsaHis { get; set; }
        private int count { get; set; }
        private IEnumerable<BorsaHisse> BorsaHisseler { get; set; }
        bool isLoading { get; set; } = false;
        public async Task Reset()
        {
            BorsaHis.Reset(true);
            await BorsaHis.FirstPage(true);
        }
        public async Task LoadData(LoadDataArgs args)
        {
            isLoading = true;

            await Task.Yield();

            var query = FinService.GetHisseler();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(args.Filter);
            }

            if (!string.IsNullOrEmpty(args.OrderBy))
            {
                query = query.OrderBy(args.OrderBy);
            }
            count = query.Count();
            BorsaHisseler = FinService.GetHisseler().Skip(args.Skip.Value).Take(args.Top.Value).ToList();

            isLoading = false;
        }
    }
}
