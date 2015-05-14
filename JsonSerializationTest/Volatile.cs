namespace JsonSerializationTest
{
    using static System.Threading.Thread;

    internal static class Volatile
    {
        public static T Read<T>(ref T location) where T : class
        {
            T obj = location;
            MemoryBarrier();
            return obj;
        }
    }
}