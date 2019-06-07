using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Darwin
{
    public static class Runtime
    {
        private static ConcurrentDictionary<IntPtr, object> _objects =
                   new ConcurrentDictionary<IntPtr, object>();

        private static ConcurrentDictionary<Type, Func<IntPtr, object>> _constructors =
                   new ConcurrentDictionary<Type, Func<IntPtr, object>>();

        public static void RegisterType<T>(Func<IntPtr, object> constructor) where T : NSObject
        {
            _constructors[typeof(T)] = constructor;
        }

        public static T GetObject<T>(IntPtr handle) where T : NSObject
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            if (_objects.TryGetValue(handle, out var obj))
            {
                return (T)obj;
            }

            return ConstructObject<T>(handle);
        }

        private static T ConstructObject<T>(IntPtr handle) where T : NSObject
        {
            if (!_constructors.TryGetValue(typeof(T), out var constructor))
            {
                constructor = GetConstructorByReflection<T>();
                RegisterType<T>(constructor);
            }

            return (T)constructor(handle);
        }

        private static Func<IntPtr,object> GetConstructorByReflection<T>() where T : NSObject
        {
            Type type = typeof(T);

            ConstructorInfo ctor = type.GetConstructor(new[] {typeof(IntPtr)});

            if (ctor is null)
            {
                throw new InvalidOperationException($"Type '{type.Name}' is missing a constructor that takes one {nameof(IntPtr)} argument");
            }

            return x => ctor.Invoke(new object[] {x});
        }

        public static void RegisterObject(NSObject obj)
        {
            if (obj == null || obj.Handle == IntPtr.Zero)
            {
                return;
            }

            _objects[obj.Handle] = obj;
        }

        public static void UnregisterObject(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return;
            }

            _objects.TryRemove(handle, out _);
        }
    }
}
