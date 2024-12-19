using FinTrack.Data;
using FinTrack.Data.Entities;
using FinTrack.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace FinTrack.Services
{
    public class FinService : IFinService
    {
        private readonly IMongoCollection<BorsaHisse> hisseCollection;
        public FinService(IOptions<MongoDbSettings> carDatabaseSetting, IDbConnectionFactory factory)
        {
            var mongoClient = new MongoClient(carDatabaseSetting.Value.Connection);
            var mongoDatabase = mongoClient.GetDatabase(carDatabaseSetting.Value.Database);
            hisseCollection = factory.OpenConnection().GetCollection<BorsaHisse>("BorsaHisse");
        }
        public async Task<ResponseData<AllHisseResponse>> AllReadHisse()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("https://bigpara.hurriyet.com.tr/api/v1/hisse/list");
                var allHisseResponse = JsonConvert.DeserializeObject<AllHisseResponse>(response);

                if (allHisseResponse.data.Count < 1)
                {
                    return new ResponseData<AllHisseResponse>(null, "Data not found.", 400);
                }
                else
                {
                    foreach (var datum in allHisseResponse.data)
                    {
                        var borsaHisse = new BorsaHisse
                        {
                            Kod = datum.kod,
                            Ad = datum.ad,
                            Tip = datum.tip,
                            CreatedDate = DateTime.UtcNow,
                        };
                        await hisseCollection.InsertOneAsync(borsaHisse);
                    }

                    return new ResponseData<AllHisseResponse>(allHisseResponse, "Data successfully saved.", 200);
                } 
            }
            catch (Exception ex)
            {
                return new ResponseData<AllHisseResponse>(null, $"Error: {ex.Message}", 500);
            }
        }

        public async Task<ResponseData<DetayliResponse>> DetayliHisse()
        {
            return null;
        }
        public IQueryable<BorsaHisse> GetHisseler()
        {
            var res = hisseCollection.AsQueryable();
            return res;
        }
    }
}

