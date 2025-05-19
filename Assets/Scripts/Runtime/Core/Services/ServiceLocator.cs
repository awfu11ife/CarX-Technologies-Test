using System;
using System.Collections.Generic;

namespace Runtime.Core.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            var type = typeof(T);

            if (!_services.TryAdd(type, service))
                throw new Exception($"Service of type {type.Name} already registered.");
        }

        public static T Resolve<T>() where T : class
        {
            var type = typeof(T);

            if (_services.TryGetValue(type, out var service))
                return service as T;

            throw new Exception($"Service of type {type.Name} not found.");
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}