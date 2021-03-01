namespace CovidApp.Core.Helpers
{
    public static class CopiadorPropriedade
    {
        public static void Copiar<TDestino, TOrigem>(TDestino destino, TOrigem origem)
        {
            var propriedadesOrigem = origem.GetType().GetProperties();
            var propriedadesDestino = origem.GetType().GetProperties();

            foreach(var propOrigem in propriedadesOrigem)
                foreach(var propDestino in propriedadesDestino)
                    if(propDestino.Name == propOrigem.Name){
                        propDestino.SetValue(destino, propOrigem.GetValue(origem));
                        break;
                    }
        }
    }
}