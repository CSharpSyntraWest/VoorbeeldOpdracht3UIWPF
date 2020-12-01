using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VoorbeeldOpdracht3UIWPF.Data;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace VoorbeeldOpdracht3UIWPF.Services
{
    class BierenService : IBierenService
    {
        private HttpClient _client = new HttpClient();

        public BierenService()
        {
            _client.BaseAddress = new Uri("https://localhost:44373/");

            _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

        }

        // GeefBierVoorID
        public async Task<ObservableCollection<Bier>> GeefAlleBieren()
        {

            HttpResponseMessage response = _client.GetAsync("api/Bieren/GeefAlleBieren").Result;

            if (response.IsSuccessStatusCode)
            {
                // var bieren = response.Content.<IEnumerable<Bier>>().Result;
                var bieren = JsonConvert.DeserializeObject<IEnumerable<Bier>>(await response.Content.ReadAsStringAsync());

                return new ObservableCollection<Bier>(bieren);
            }
            else
            {
                return null;
            }
        }

        public async Task<ObservableCollection<SoortBier>> GeefAlleBierSoorten()
        {
            HttpResponseMessage response = _client.GetAsync("api/Bieren/GeefAlleBierSoorten").Result;

            if (response.IsSuccessStatusCode)
            {
                var biersoorten = JsonConvert.DeserializeObject<IEnumerable<SoortBier>>(await response.Content.ReadAsStringAsync());

                return new ObservableCollection<SoortBier>(biersoorten);
            }
            else
            {
                return null;
            }
        }

        public async Task<ObservableCollection<Brouwer>> GeefAlleBrouwers()
        {
            HttpResponseMessage response = _client.GetAsync("api/Bieren/GeefAlleBrouwers").Result;

            if (response.IsSuccessStatusCode)
            {
                var brouwers = JsonConvert.DeserializeObject<IEnumerable<Brouwer>>(await response.Content.ReadAsStringAsync());

                return new ObservableCollection<Brouwer>(brouwers);
            }
            else
            {
                return null;
            }
        }

        public async Task<Bier> GeefBierVoorBierNr(int bierNr)
        {

            HttpResponseMessage response = _client.GetAsync("api/Bieren/GeefBierVoorID/" + bierNr).Result;

            if (response.IsSuccessStatusCode)
            {
                var bier = JsonConvert.DeserializeObject<Bier>(await response.Content.ReadAsStringAsync());

                return bier;
            }
            else
            {
                return null;
            }
        }

        public Task<ObservableCollection<SoortBier>> ZoekBieren(int brouwerNr, int soortNr)
        {
            throw new NotImplementedException();
        }
    }
}
