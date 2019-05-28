using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serialization;

namespace cinex.Services
{
    public class JsonNetSerializer : IRestSerializer
    {
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj);

        public string Serialize(Parameter bodyParameter) =>
            JsonConvert.SerializeObject(bodyParameter.Value);

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });

        public string[] SupportedContentTypes { get; } =
        {
                "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
            };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}
