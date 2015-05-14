namespace JsonSerializationTest
{
    using Newtonsoft.Json;
    using static Newtonsoft.Json.JsonConvert;

    public class NewtonsoftSerializer : IJsonSerializerDeserializer
    {
        public string ToJson(object obj)
        {
            return SerializeObject(obj, Formatting.None);
        }

        public T FromJson<T>(string json)
        {
            return DeserializeObject<T>(json);
        }
    }
}