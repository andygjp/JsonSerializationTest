namespace JsonSerializationTest
{
    using static System.Threading.Thread;

    internal static class Volatile
    {
        public static bool Read(ref bool location)
        {
            int num = location ? 1 : 0;
            MemoryBarrier();
            return num != 0;
        }

        public static void Write(ref bool location, bool value)
        {
            MemoryBarrier();
            location = value;
        }
    }
}