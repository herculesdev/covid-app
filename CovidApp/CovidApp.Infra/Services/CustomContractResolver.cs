using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace CovidApp.Infra.Services
{
    class CustomContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> _propertyMappings;

        public CustomContractResolver(Dictionary<string, string> propertyMappings)
        {
            _propertyMappings = propertyMappings;
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = _propertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}