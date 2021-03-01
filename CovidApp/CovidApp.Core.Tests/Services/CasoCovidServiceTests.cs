using NUnit.Framework;
using CovidApp.Core.Entities;
using System;
using CovidApp.Core.Services;
using System.Collections.Generic;
using Moq;
using CovidApp.Core.Interfaces.Repository;
using CovidApp.Infra.Services;
using System.Linq;
using CovidApp.Core.Helpers;

namespace CovidApp.Core.Tests.Services
{
    [TestFixture]
    public class CasoCovidServiceTests
    {
        List<CasoCovid> _bancoCasos;
        private ICasoCovidRepository _casoCovidRepository;

        [SetUp]
        public void Init()
        {
            _bancoCasos = new List<CasoCovid>();
            _bancoCasos.Add(new CasoCovid() {
                Id = "def",
                Pais = "EUA",
                Confirmados = 25,
                Mortes = 10,
                Recuperados = 5,
                Ativos = 5,
                Data = DateTime.Parse("2021-02-26"),
            });

            _bancoCasos.Add(new CasoCovid() {
                Id = "xyz",
                Pais = "Angola",
                Confirmados = 50,
                Mortes = 25,
                Recuperados = 10,
                Ativos = 12,
                Data = DateTime.Parse("2021-02-27"),
            });

            var casoCovidRepositoryMock = new Mock<ICasoCovidRepository>();
            _casoCovidRepository = casoCovidRepositoryMock.Object;

            casoCovidRepositoryMock.Setup(x => x.Salvar(It.IsAny<CasoCovid>())).Returns(
                (CasoCovid caso) => {
                    CasoCovid casoExistente = null;
                    if ((casoExistente = _bancoCasos.FirstOrDefault(x => x.Id == caso.Id)) == null)
                        _bancoCasos.Add(caso);
                    else
                        CopiadorPropriedade.Copiar<CasoCovid, CasoCovid>(casoExistente, caso);
                        
                    return caso;
                }
            );

            casoCovidRepositoryMock.Setup(x => x.ObterPorIntervalo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(
                (DateTime inicio, DateTime fim) => {
                    return _bancoCasos.Where(x => x.Data >= inicio && x.Data <= fim).ToList();
                }
            );

        }

        [Test]
        public void DeveInserirUmNovoCaso()
        {
            var casoCovidService = new CasoCovidService(_casoCovidRepository, new CovidAPIService());
            var caso = new CasoCovid() {
                Id = "abc123",
                Pais = "Brazil",
                Confirmados = 10,
                Mortes = 5,
                Recuperados = 2,
                Ativos = 5,
                Data = DateTime.Now,
            };
            casoCovidService.Salvar(caso);
            Assert.IsTrue(_bancoCasos.Any(x => x.Id == caso.Id));
        }

        [Test]
        public void DeveAtualizarUmCasoExistente()
        {
            var casoCovidService = new CasoCovidService(_casoCovidRepository, new CovidAPIService());
            var caso = new CasoCovid() {
                Id = "xyz",
                Pais = "Africa do Sul",
                Confirmados = 10,
                Mortes = 5,
                Recuperados = 2,
                Ativos = 5,
                Data = DateTime.Now,
            };

            casoCovidService.Salvar(caso);
            Assert.AreEqual("Africa do Sul", _bancoCasos.FirstOrDefault(x => x.Id == "xyz").Pais);
        }

        [Test]
        public void DeveCalcularMediaMovelPorPeriodo()
        {
            var casoCovidService = new CasoCovidService(_casoCovidRepository, new CovidAPIService());
            var inicio = DateTime.Parse("2021-02-26");
            var fim = DateTime.Parse("2021-02-27");
            var media = casoCovidService.CalcularMediaMovelPorPeriodo(inicio, fim);
            Assert.AreEqual(37, media.Casos);
            Assert.AreEqual(17, media.Mortes);
        }
    }
}