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

        public async Task<CharacterResponse> GetCharacterAttributes()
        {
            var response = await _httpClient.GetAsync("/api/character/GetCharacter");
            var character = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterResponse>(character);
        }

        public async Task<IList<EquipmentResponse>> GetEquipmentList()
        {
            var response = await _httpClient.GetAsync("/api/equipment/GetEquipment");
            var equipments = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IList<EquipmentResponse>>(equipments);
        }

        public async Task<string> PurchaseEquipment(PurchaseRequest purchaseRequest)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var response = await _httpClient.PostAsJsonAsync("/api/purchases/CreatePurchase", purchaseRequest, options);

            var responseStatusCode=  response.StatusCode.ToString();

            return responseStatusCode;        
           

        }
    }
}
