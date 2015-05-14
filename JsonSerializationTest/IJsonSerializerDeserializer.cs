namespace JsonSerializationTest
{
    public interface IJsonSerializerDeserializer
    {
        string ToJson(object obj);
        T FromJson<T>(string json);
    }
}