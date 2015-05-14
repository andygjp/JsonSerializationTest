namespace JsonSerializationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SerializerTests
    {
        enum Operation
        {
            Serialization,
            Deserialization
        }

        public IEnumerable<IJsonSerializerDeserializer> Serializers { get; set; } =
            new[]
            {
                Serializer.Newtonsoft,
                Serializer.FastJSON,
                Serializer.FastJSONUsingParser,
                Serializer.SimpleJson,
                Serializer.SimpleJsonUsingParser
            };

        public Action<string> Output { get; set; } 

        public void RunTestSuite<T>(T obj)
        {
            RunTestSuite(obj, Serializers?.ToList(), Output ?? (_ => { }));
        }

        void RunTestSuite<T>(T obj, List<IJsonSerializerDeserializer> serializers, Action<string> output)
        {
            if (!(serializers?.Any()).GetValueOrDefault())
            {
                output($"No serializers to test. Either set the {nameof(Serializers)} member with the serializers you want to use or use the defaults.");
                return;
            }
            RunTestSuiteCore(obj, serializers, output);
        }

        static void RunTestSuiteCore<T>(T obj, IEnumerable<IJsonSerializerDeserializer> serializers, Action<string> output)
        {
            foreach (var serializer in serializers)
            {
                var json = Serialize(obj, serializer, output);
                Deserialize<T>(serializer, json, output);
            }
        }

        static string Serialize(object obj, IJsonSerializerDeserializer serializer, Action<string> output)
        {
            try
            {
                return SerializeCore(obj, serializer, output);
            }
            catch (Exception ex)
            {
                WriteError(serializer, output, ex, Operation.Serialization);
                return "";
            }
        }

        static string SerializeCore<T>(T obj, IJsonSerializerDeserializer serializer, Action<string> output)
        {
            var json = serializer.ToJson(obj);
            output($"The {serializer.GetType()} successfully serialized the object:");
            output(json);
            return json;
        }

        static void Deserialize<T>(IJsonSerializerDeserializer serializer, string json, Action<string> output)
        {
            try
            {
                DeserializeCore<T>(serializer, json, output);
            }
            catch(InvalidCastException)
            {
                Deserialize<IDictionary<string, object>>(serializer, json, output);
            }
            catch (Exception ex)
            {
                WriteError(serializer, output, ex, Operation.Deserialization);
            }
        }

        static void DeserializeCore<T>(IJsonSerializerDeserializer serializer, string json, Action<string> output)
        {
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            serializer.FromJson<T>(json);
            output($"The {serializer.GetType()} successfully deserialized the serializer output.");
        }

        static void WriteError(IJsonSerializerDeserializer serializer, Action<string> output, Exception ex, Operation operation)
        {
            var op = operation == Operation.Serialization ? "serialize" : "deserialize";
            output($"The {serializer.GetType()} failed to {op} the object:");
            output(ex.Message);
        }
    }
}