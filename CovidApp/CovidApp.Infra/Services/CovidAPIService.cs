using System;
using System.Collections.Generic;
using System.Net;
using CovidApp.Core.Entities;
using CovidApp.Core.Interfaces.Services;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CovidApp.Infra.Services
{
    public class CovidAPIService : ICovidAPIService
    {
        private string _urlBase = "https://api.covid19api.com";
        public IList<CasoCovid> ObterCasosApartirDe(string pais, DateTime data)
        {
            var formato = "yyy-MM-dd";
            var de = data.ToString(formato);
            var ate = DateTime.Now.ToString(formato);
            var cliente = new RestClient(_urlBase);
            var requisicao = new RestRequest($"https://api.covid19api.com/country/{pais}?from={de}T00:00:00Z&to={ate}T00:00:00Z");
            var resposta = cliente.Get(requisicao);
            if (resposta.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<IList<CasoCovid>>(resposta.Content, GetJsonSerializerSettings());
            
            return new List<CasoCovid>();
        }

        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomContractResolver(new Dictionary<string, string>{
                    {"Id", "ID"},
                    {"Pais", "Country"},
                    {"Confirmados", "Confirmed"},
                    {"Mortes", "Deaths"},
                    {"Recuperados", "Recovered"},
                    {"Ativo", "Active"},
                    {"Data", "Date"}
            });

            return settings;
        }
    }
}