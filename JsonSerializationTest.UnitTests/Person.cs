namespace JsonSerializationTest.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public Hobby[] hobbies { get; set; }

        public IDictionary<string, object> ToJson()
        {
            var x = new Dictionary<string, object>
            {
                [nameof(name)] = name,
                [nameof(age)] = age,
                [nameof(hobbies)] = hobbies.Select(h => h.ToJson()).ToArray()
            };
            return x;
        }
    }
}