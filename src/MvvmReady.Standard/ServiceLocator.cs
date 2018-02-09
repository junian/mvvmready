using System;
using System.Collections.Generic;

namespace Juniansoft.MvvmReady
{
    public sealed class ServiceLocator
    {
        static readonly Lazy<ServiceLocator> instance = new Lazy<ServiceLocator>(() => new ServiceLocator());
        readonly Dictionary<Type, Dictionary<string, Lazy<object>>> registeredServices = new Dictionary<Type, Dictionary<string, Lazy<object>>>();

        public static ServiceLocator Current => instance.Value;

        public void Register<TContract, TService>(string key = "") where TService : new()
        {
            var instanceType = typeof(TContract);

            EnsureLazyDictionary(instanceType);

            registeredServices[instanceType][key] =
                new Lazy<object>(() => Activator.CreateInstance(typeof(TService)));
        }

        public void Register<TService>(string key = "") where TService : new()
        {
            Register<TService, TService>(key);
        }

        public T Get<T>(string key = "") where T : class
        {
            var instanceType = typeof(T);

            EnsureLazyDictionary(instanceType);

            if (registeredServices.TryGetValue(instanceType, out var dict))
            {
                if (dict.TryGetValue(key, out var service))
                {
                    return (T) service.Value;
                }
                else
                {
                    dict[key] = new Lazy<object>(() => Activator.CreateInstance(instanceType));
                    return (T) dict[key].Value;
                }
            }

            throw new Exception($"Couldn't find service with type of {typeof(T).FullName}");
        }

        private void EnsureLazyDictionary(Type contractKey)
        {
            if (!registeredServices.ContainsKey(contractKey))
                registeredServices[contractKey] = new Dictionary<string, Lazy<object>>();
        }
    }
}
