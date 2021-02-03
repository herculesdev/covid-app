using System;
using System.Collections.Generic;
using System.Linq;
using CovidApp.Core.Entities;
using CovidApp.Core.Interfaces.Repository;
using CovidApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidApp.Infra.Data.Repositories
{
    public class CasoCovidRepository : ICasoCovidRepository
    {
        private CovidDbContext _banco;
        public CasoCovidRepository(CovidDbContext contexto)
        {
            _banco = contexto;
        }
        public IList<CasoCovid> ObterPorIntervalo(DateTime de, DateTime ate)
        {
            return _banco.CasosCovid.Where(x => x.Data >= de && x.Data <= ate).ToList();
        }

        public CasoCovid Salvar(CasoCovid caso)
        {            
            if (_banco.CasosCovid.AsNoTracking().FirstOrDefault(x => x.Id == caso.Id) != null)
                _banco.Update(caso);
            else
                _banco.Add(caso);

            _banco.SaveChanges();

            return caso;
        }
    }
}