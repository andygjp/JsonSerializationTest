namespace JsonSerializationTest
{
    using static fastJSON.JSON;

    public class FastJsonSerializer : IJsonSerializerDeserializer
    {
        public string ToJson(object obj)
        {
            return ToJSON(obj);
        }

        public T FromJson<T>(string json)
        {
            return ToObject<T>(json);
        }
    }

    public class FastJsonSerializerUsingParser : IJsonSerializerDeserializer
    {
        public string ToJson(object obj)
        {
            return ToJSON(obj);
        }

        public T FromJson<T>(string json)
        {
            return (T)Parse(json);
        }
    }
}