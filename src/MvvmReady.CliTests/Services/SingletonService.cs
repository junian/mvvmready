using System;
namespace MvvmReady.CliTests.Services
{
    public class SingletonService
    {
        public string ID { get; set; }
        private SingletonService()
        {
            ID = Guid.NewGuid().ToString();
        }

        private static readonly Lazy<SingletonService> instance = new Lazy<SingletonService>(() => new SingletonService());
        public static SingletonService Instance => instance.Value;
    }
}
