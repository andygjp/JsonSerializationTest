namespace JsonSerializationTest.UnitTests
{
    using System.Collections.Generic;

    public static class TestData
    {
        public static Person PersonObject => 
            new Person {name = "John Smith", age = 28, hobbies = new[] {new Hobby {description = "Watching paint dry"}}};

        public static string PersonAsJson => 
            "{\"name\":\"John Smith\",\"age\":28,\"hobbies\":[{\"description\":\"Watching paint dry\"}]}";

        public static IDictionary<string, object> PersonAsDictionary => PersonObject.ToJson();
    }
}