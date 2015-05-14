namespace JsonSerializationTest
{
    using static LazyInitializer;

    public static class Serializer
    {
        static IJsonSerializerDeserializer _newtonsoft;
        static IJsonSerializerDeserializer _fastJSON;
        static IJsonSerializerDeserializer _fastJSONUsingParser;
        static IJsonSerializerDeserializer _simpleJson;
        static IJsonSerializerDeserializer _simpleJsonUsingParser;

        public static IJsonSerializerDeserializer Newtonsoft
        {
            get { return EnsureInitialized(ref _newtonsoft, () => new NewtonsoftSerializer()); }
            set { _newtonsoft = value; }
        }

        public static IJsonSerializerDeserializer FastJSON
        {
            get { return EnsureInitialized(ref _fastJSON, () => new FastJsonSerializer()); }
            set { _fastJSON = value; }
        }

        public static IJsonSerializerDeserializer FastJSONUsingParser
        {
            get { return EnsureInitialized(ref _fastJSONUsingParser, () => new FastJsonSerializerUsingParser()); }
            set { _fastJSONUsingParser = value; }
        }
        
        public static IJsonSerializerDeserializer SimpleJson
        {
            get { return EnsureInitialized(ref _simpleJson, () => new SimpleJsonSerializer()); }
            set { _simpleJson = value; }
        }

        public static IJsonSerializerDeserializer SimpleJsonUsingParser
        {
            get { return EnsureInitialized(ref _simpleJsonUsingParser, () => new SimpleJsonSerializerUsingParser()); }
            set { _simpleJsonUsingParser = value; }
        }
    }
}
