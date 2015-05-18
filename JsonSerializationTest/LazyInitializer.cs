namespace JsonSerializationTest
{
    using System;
    using static Volatile;

    internal static class LazyInitializer
    {
        public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory) where T : class
        {
            if (Read(ref initialized))
            {
                return target;
            }
            return EnsureInitializedCore(ref target, ref initialized, ref syncLock, valueFactory);
        }

        static T EnsureInitializedCore<T>(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory) where T : class
        {
            lock (syncLock)
            {
                if (!Read(ref initialized))
                {
                    target = valueFactory();
                    Write(ref initialized, true);
                }
            }
            return target;
        }
    }
}
