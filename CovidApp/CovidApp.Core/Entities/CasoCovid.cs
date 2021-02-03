using System;

namespace CovidApp.Core.Entities
{
    public class CasoCovid
    {
        public string Id { get; set; }
        public string Pais { get; set; }
        public int Confirmados { get; set; }
        public int Mortes { get; set; }
        public int Recuperados { get; set; }
        public int Ativos { get; set; }
        public DateTime Data { get; set; }

    }
}