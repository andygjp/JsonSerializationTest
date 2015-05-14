namespace JsonSerializationTest.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;
    using Xunit;
    using static Serializer;
    using static TestData;

    public class When_running_the_test_suite
    {
        StringBuilder Sb { get; } = new StringBuilder();

        public When_running_the_test_suite()
        {
            var fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());

            var suite = new SerializerTests
            {
                Serializers = fixture.CreateMany<IJsonSerializerDeserializer>(3),
                Output = s => Sb.AppendLine(s)
            };

            suite.RunTestSuite(PersonObject);
        }

        [Fact]
        public void It_should_enumerate_the_serializers_and_output_the_results()
        {
            var actuals = Sb.ToString().Split(new[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Distinct();
            actuals.Should().Contain(new[]
            {
                "The Castle.Proxies.IJsonSerializerDeserializerProxy successfully serialized the object:",
                "The Castle.Proxies.IJsonSerializerDeserializerProxy successfully deserialized the serializer output."
            });
        }
    }

    public class When_running_the_test_suite_but_the_suite_is_null
    {
        StringBuilder Sb { get; } = new StringBuilder();

        public When_running_the_test_suite_but_the_suite_is_null()
        {
            var suite = new SerializerTests
            {
                Serializers = null,
                Output = s => Sb.AppendLine(s)
            };

            suite.RunTestSuite(PersonObject);
        }

        [Fact]
        public void It_should_produce_error_message_without_exception()
        {
            Sb.ToString().Trim().ShouldBeEquivalentTo("No serializers to test. Either set the Serializers member with the serializers you want to use or use the defaults.");
        }
    }

    public class When_using_the_Newtonsoft_serializer
    {
        [Fact]
        public void It_should_serialize_correctly()
        {
            var json = Newtonsoft.ToJson(PersonObject);
            json.ShouldBeEquivalentTo(PersonAsJson);
        }
    }

    public class When_using_the_Newtonsoft_deserializer
    {
        [Fact]
        public void It_should_deserialize_correctly()
        {
            var json = Newtonsoft.FromJson<Person>(PersonAsJson);
            json.ShouldBeEquivalentTo(PersonObject);
        }
    }

    public class When_using_the_fastJSON_serializer
    {
        [Fact(Skip = "Output includes type data")]
        public void It_should_serialize_correctly()
        {
            var json = FastJSON.ToJson(PersonObject);
            json.ShouldBeEquivalentTo(PersonAsJson);
        }
    }
    
    public class When_using_the_fastJSON_deserializer
    {
        [Fact]
        public void It_should_deserialize_correctly()
        {
            var json = FastJSON.FromJson<Person>(PersonAsJson);
            json.ShouldBeEquivalentTo(PersonObject);
        }
    }

    public class When_using_the_fastJSONUsingParser_serializer
    {
        [Fact(Skip = "Output includes type data")]
        public void It_should_serialize_correctly()
        {
            var json = FastJSONUsingParser.ToJson(PersonObject);
            json.ShouldBeEquivalentTo(PersonAsJson);
        }
    }

    public class When_using_the_fastJSONUsingParser_deserializer
    {
        [Fact]
        public void It_should_deserialize_correctly()
        {
            var json = FastJSONUsingParser.FromJson<IDictionary<string, object>>(PersonAsJson);
            json.ShouldBeEquivalentTo(PersonAsDictionary);
        }
    }
    
    public class When_using_the_SimpleJson_serializer
    {
        [Fact]
        public void It_should_serialize_correctly()
        {
            var json = Serializer.SimpleJson.ToJson(PersonObject);
            json.ShouldBeEquivalentTo(PersonAsJson);
        }
    }

    public class When_using_the_SimpleJson_deserializer
    {
        [Fact]
        public void It_should_deserialize_correctly()
        {
            var json = Serializer.SimpleJson.FromJson<Person>(PersonAsJson);
            json.ShouldBeEquivalentTo(PersonObject);
        }
    }

    public class When_using_the_SimpleJsonUsingParser_serializer
    {
        [Fact]
        public void It_should_serialize_correctly()
        {
            var json = SimpleJsonUsingParser.ToJson(PersonObject);
            json.ShouldBeEquivalentTo(PersonAsJson);
        }
    }

    public class When_using_the_SimpleJsonUsingParser_deserializer
    {
        [Fact]
        public void It_should_deserialize_correctly()
        {
            var json = SimpleJsonUsingParser.FromJson<IDictionary<string, object>>(PersonAsJson);
            json.ShouldBeEquivalentTo(PersonAsDictionary);
        }
    }
}
