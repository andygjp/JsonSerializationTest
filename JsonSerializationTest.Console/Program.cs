namespace JsonSerializationTest.Console
{
    using Console = System.Console;

    public class MyTestObject
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var suite = new SerializerTests();
            suite.Output = Console.WriteLine;
            suite.RunTestSuite(new MyTestObject {Name = "John Smith"});
            Console.ReadLine();
        }
    }
}
