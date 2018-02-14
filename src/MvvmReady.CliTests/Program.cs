using System;
using Juniansoft.MvvmReady;
using MvvmReady.CliTests.Services;

namespace MvvmReady.CliTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator.Current.Register<IHelloService, HelloWorldService>();
            var a = ServiceLocator.Current.Get<IHelloService>();
            var b = ServiceLocator.Current.Get<IHelloService>("bat");
            var c = ServiceLocator.Current.Get<IHelloService>();
            var d = ServiceLocator.Current.Get<IHelloService>("man");

            a.Name = nameof(a);
            b.Name = nameof(b);
            c.Name = nameof(c);
            d.Name = nameof(d);

            a.SayHello();
            b.SayHello();
            c.SayHello();
            d.SayHello();

            ServiceLocator.Current.Register<SingletonService>(() => SingletonService.Instance);
            var e = ServiceLocator.Current.Get<SingletonService>();
            var f = ServiceLocator.Current.Get<SingletonService>();
            Console.WriteLine(e.ID);
            Console.WriteLine(f.ID);
        }
    }
}
