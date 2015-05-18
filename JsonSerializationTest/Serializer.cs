namespace JsonSerializationTest
{
    using static LazyInitializer;

    public static class Serializer
    {
        private class State
        {
            public IJsonSerializerDeserializer Serializer;
            public bool Initialized;
            public object Lock = new object();

            public void SetSerializer(IJsonSerializerDeserializer serializer)
            {
                lock (Lock)
                {
                    Serializer = serializer;
                    Initialized = true;
                }
            }
        }

        static readonly State _newtonsoft = new State();
        static readonly State _fastJSON = new State();
        static readonly State _fastJSONUsingParser = new State();
        static readonly State _simpleJson = new State();
        static readonly State _simpleJsonUsingParser = new State();

        public static IJsonSerializerDeserializer Newtonsoft
        {
            get { return EnsureInitialized(ref _newtonsoft.Serializer, ref _newtonsoft.Initialized, ref _newtonsoft.Lock, () => new NewtonsoftSerializer()); }
            set { _newtonsoft.SetSerializer(value);}
        }

        public static IJsonSerializerDeserializer FastJSON
        {
            get { return EnsureInitialized(ref _fastJSON.Serializer, ref _fastJSON.Initialized, ref _fastJSON.Lock, () => new FastJsonSerializer()); }
            set { _fastJSON.SetSerializer(value); }
        }

        public static IJsonSerializerDeserializer FastJSONUsingParser
        {
            get { return EnsureInitialized(ref _fastJSONUsingParser.Serializer, ref _fastJSONUsingParser.Initialized, ref _fastJSONUsingParser.Lock, () => new FastJsonSerializerUsingParser()); }
            set { _fastJSONUsingParser.SetSerializer(value); }
        }
        
        public static IJsonSerializerDeserializer SimpleJson
        {
            get { return EnsureInitialized(ref _simpleJson.Serializer, ref _simpleJson.Initialized, ref _simpleJson.Lock, () => new SimpleJsonSerializer()); }
            set { _simpleJson.SetSerializer(value); }
        }

        public static IJsonSerializerDeserializer SimpleJsonUsingParser
        {
            get { return EnsureInitialized(ref _simpleJsonUsingParser.Serializer, ref _simpleJsonUsingParser.Initialized, ref _simpleJsonUsingParser.Lock, () => new SimpleJsonSerializerUsingParser()); }
            set { _simpleJsonUsingParser.SetSerializer(value); }
        }
    }
}
