namespace JsonSerializationTest.UnitTests
{
    using System.Collections.Generic;

    public class Hobby
    {
        public string description { get; set; }

        public IDictionary<string, object> ToJson()
        {
            return new Dictionary<string, object>
            {
                [nameof(description)] = description
            };
        }
    }
}