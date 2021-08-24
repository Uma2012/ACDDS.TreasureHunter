using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ACDDS.TreasureHunter.Web.Models;

namespace ACDDS.TreasureHunter.Web.Repository
{
    public class TreasureHunterRepository : ITreasureHunterRepository
    {
        private readonly HttpClient _httpClient;

        public TreasureHunterRepository(HttpClient httpClient)
        {            
            this._httpClient = httpClient;
        }       

        public async Task<CharacterResponse> GetCharacterAttributes(int id)
        {
            var request = await _httpClient.GetAsync("/api/character/GetCharacter?id="+id);
            var response = await request.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterResponse>(response);
        }

        public async Task<IList<EquipmentResponse>> GetEquipmentList()
        {
            var request = await _httpClient.GetAsync("/api/equipment/GetEquipment");
            var response = await request.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IList<EquipmentResponse>>(response);
        }

        public async Task<PurchaseResponse> PurchaseEquipment(PurchaseRequest purchaseRequest)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/purchases/CreatePurchase", purchaseRequest, options);

            var responseStatusCode=  request.StatusCode.ToString();

            var response = await request.Content.ReadAsStringAsync();
            
            var purchaseResponse= JsonConvert.DeserializeObject<PurchaseResponse>(response);
            purchaseResponse.StatusResponse = responseStatusCode;
            return purchaseResponse;


        }
    }
}
