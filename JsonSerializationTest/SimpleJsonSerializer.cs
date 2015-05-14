namespace JsonSerializationTest
{
    public class SimpleJsonSerializer : IJsonSerializerDeserializer
    {
        public string ToJson(object obj)
        {
            return SimpleJson.SerializeObject(obj);
        }

        public T FromJson<T>(string json)
        {
            return SimpleJson.DeserializeObject<T>(json);
        }
    }

    public class SimpleJsonSerializerUsingParser : IJsonSerializerDeserializer
    {
        public string ToJson(object obj)
        {
            return SimpleJson.SerializeObject(obj);
        }

        public T FromJson<T>(string json)
        {
            // Calls the TryDeserializeObject method which returns a dictionary.
            return (T) SimpleJson.DeserializeObject(json);
        }
    }
}