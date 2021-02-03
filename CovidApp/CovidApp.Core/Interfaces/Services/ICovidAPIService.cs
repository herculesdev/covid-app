using System;
using System.Collections.Generic;
using CovidApp.Core.Entities;

namespace CovidApp.Core.Interfaces.Services
{
    public interface ICovidAPIService
    {
        IList<CasoCovid> ObterCasosApartirDe(string pais, DateTime data);
    }
}