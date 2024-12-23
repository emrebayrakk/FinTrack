using FinTrack.Data;
using FinTrack.Data.Entities;
using FinTrack.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace FinTrack.Services
{
    public class FinService : IFinService
    {
        private readonly IMongoCollection<BorsaHisse> hisseCollection;
        private readonly HttpClient _httpClient;
        public FinService(IOptions<MongoDbSettings> carDatabaseSetting, IDbConnectionFactory factory, HttpClient httpClient)
        {
            var mongoClient = new MongoClient(carDatabaseSetting.Value.Connection);
            var mongoDatabase = mongoClient.GetDatabase(carDatabaseSetting.Value.Database);
            hisseCollection = factory.OpenConnection().GetCollection<BorsaHisse>("BorsaHisse");
            _httpClient = httpClient;
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
                        var anyExist = await hisseCollection.FindAsync(a => a.Kod == datum.kod);
                        if (anyExist == null) 
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
                        
                    }

                    return new ResponseData<AllHisseResponse>(allHisseResponse, "Data successfully saved.", 200);
                } 
            }
            catch (Exception ex)
            {
                return new ResponseData<AllHisseResponse>(null, $"Error: {ex.Message}", 500);
            }
        }

        public async Task<ResponseData<DetayliResponse>> DetayliHisse(string hisseAdi)
        {
            var req = hisseAdi.ToUpper();
            var url = "https://bigpara.hurriyet.com.tr/api/v1/borsa/hisseyuzeysel/" + req;

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var detayliResponse = System.Text.Json.JsonSerializer.Deserialize<SuperficialHisseResponse>(json);

                    DetayliResponse detayli = new DetayliResponse()
                    {
                        ad = detayliResponse.Data.HisseYuzeysel.Aciklama,
                        kod = detayliResponse.Data.HisseYuzeysel.Sembol,
                        hisseYuzeysel = detayliResponse.Data.HisseYuzeysel,
                    };

                    return new ResponseData<DetayliResponse>(detayli, "Successfully.", 200);
                }
                else
                {
                    Console.WriteLine($"API Hatası: {response.StatusCode}");
                    return new ResponseData<DetayliResponse>(null, "Error.", 400); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return new ResponseData<DetayliResponse>(null, $"Hata: {ex.Message}", 500);
            }
        }
        public IQueryable<BorsaHisse> GetHisseler()
        {
            var res = hisseCollection.AsQueryable();
            return res;
        }
    }
}

