using System;
using System.Collections.Generic;

namespace Juniansoft.MvvmReady
{
    public sealed class ServiceLocator
    {
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Dictionary<string, Lazy<object>>> instances = new Dictionary<Type, Dictionary<string, Lazy<object>>>();

        private static readonly Lazy<ServiceLocator> current = new Lazy<ServiceLocator>(() => new ServiceLocator());
        public static ServiceLocator Current => current.Value;

        public void Register<TContract, TService>(string key = "") where TService : new()
        {
            var contractType = typeof(TContract);
            var serviceType = typeof(TService);

            Register(contractType, serviceType);

            instances[contractType][key] = new Lazy<object>(
                () => Activator.CreateInstance(serviceType)
            );
        }

        public void Register<TService>(string key = "") where TService : new()
        {
            Register<TService, TService>(key);
        }

        public T Get<T>(string key = "") where T : class
        {
            var contractType = typeof(T);

            if (types.TryGetValue(contractType, out var serviceType) && instances.TryGetValue(contractType, out var dict))
            {
                if (dict.TryGetValue(key, out var lazy))
                {
                    return (T)lazy.Value;
                }
                else
                {
                    dict[key] = new Lazy<object>(
                        () => Activator.CreateInstance(serviceType)
                    );
                    return (T)dict[key].Value;
                }
            }

            throw new Exception($"Couldn't find service with type of {typeof(T).FullName}");
        }

        private void Register(Type contractType, Type serviceType)
        {
            if(!types.ContainsKey(contractType))
                types[contractType] = serviceType;

            if (!instances.ContainsKey(contractType))
                instances[contractType] = new Dictionary<string, Lazy<object>>();
        }
    }
}
