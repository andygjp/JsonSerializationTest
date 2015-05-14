namespace JsonSerializationTest
{
    using System;
    using static System.Threading.Interlocked;
    using static Volatile;

    internal static class LazyInitializer
    {
        public static T EnsureInitialized<T>(ref T target, Func<T> valueFactory) where T : class
        {
            if (Read(ref target) != null)
            {
                return target;
            }
            return EnsureInitializedCore(ref target, valueFactory);
        }

        static T EnsureInitializedCore<T>(ref T target, Func<T> valueFactory) where T : class
        {
            T obj = valueFactory();
            CompareExchange(ref target, obj, default(T));
            return target;
        }
    }
}
