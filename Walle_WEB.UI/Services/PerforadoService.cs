using Walle_WEB.Model;
using Walle_WEB.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Walle_WEB.UI.Services
{
    public class PeleerService : IPeelerService
    {
        private readonly HttpClient _httpClient;

        public PeleerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletePeeler(int id)
        {
            await _httpClient.DeleteAsync($"api/PeelerBitacora/{id}");
        }

        public async Task<IEnumerable<PeelerBitacora>> GetAllPeeler()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PeelerBitacora>>(
                await _httpClient.GetStreamAsync($"api/PeelerBitacora"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<PeelerBitacora> GetPeelerDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<PeelerBitacora>(
                await _httpClient.GetStreamAsync($"api/PeelerBitacora/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SavePeeler(PeelerBitacora peelerbitacora)
        {
            var peelerJson = new StringContent(JsonSerializer.Serialize(peelerbitacora), Encoding.UTF8, "application/json");

            if (peelerbitacora.IdPeeler == 0)
                await _httpClient.PostAsync("api/PeelerBitacora", peelerJson); //Insert Expense
            else
                await _httpClient.PutAsync("api/PeelerBitacora", peelerJson); //Update Expense
        }
    }
}
