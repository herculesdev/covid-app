using System;
using CovidApp.Core.DTO;
using CovidApp.Core.Entities;

namespace CovidApp.Core.Interfaces.Services
{
    public interface ICasoCovidService
    {
        CasoCovid Salvar(CasoCovid caso);
        void AtualizarBaseComDadosDaApiCovid19();
        MediaMovelDTO CalcularMediaMovelPorPeriodo(DateTime de, DateTime ate);
    }
}