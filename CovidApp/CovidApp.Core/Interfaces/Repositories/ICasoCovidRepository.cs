using System;
using System.Collections.Generic;
using CovidApp.Core.Entities;

namespace CovidApp.Core.Interfaces.Repository
{
    public interface ICasoCovidRepository
    {
        CasoCovid Salvar(CasoCovid caso);
        IList<CasoCovid> ObterPorIntervalo(DateTime de, DateTime ate);
    }
}