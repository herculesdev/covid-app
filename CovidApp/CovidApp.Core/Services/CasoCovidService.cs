using System;
using System.Linq;
using CovidApp.Core.DTO;
using CovidApp.Core.Entities;
using CovidApp.Core.Interfaces.Repository;
using CovidApp.Core.Interfaces.Services;

namespace CovidApp.Core.Services
{
    public class CasoCovidService : ICasoCovidService
    {
        private ICasoCovidRepository _casoRepository;
        private ICovidAPIService _covidApi;
        public CasoCovidService(ICasoCovidRepository casoRepository, ICovidAPIService covidApi)
        {
            _casoRepository = casoRepository;
            _covidApi = covidApi;
        }

        public void AtualizarBaseComDadosDaApiCovid19()
        {
            var casos = _covidApi.ObterCasosApartirDe("brazil", DateTime.Now.AddMonths(-6));

            foreach(var caso in casos)
                Salvar(caso);
        }

        public MediaMovelDTO CalcularMediaMovelPorPeriodo(DateTime de, DateTime ate)
        {
            var casos = _casoRepository.ObterPorIntervalo(de, ate);
            var dias = (ate - de).TotalDays;
            var mediaMovel = new MediaMovelDTO(){
                Casos = Convert.ToInt32(casos.Where(x => x.Data >= de && x.Data <= ate).Sum(x => x.Confirmados)/dias),
                Mortes = Convert.ToInt32(casos.Where(x => x.Data >= de && x.Data <= ate).Sum(x => x.Mortes)/dias)
            };
            
            return mediaMovel;
        }

        public CasoCovid Salvar(CasoCovid caso)
        {
            return _casoRepository.Salvar(caso);
        }
    }
}