using System;
namespace MvvmReady.CliTests.Services
{
    public class HelloWorldService: IHelloService
    {
        public HelloWorldService()
        {
        }

        public string Name { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hello to the world, {Name}!");
        }
    }
}
