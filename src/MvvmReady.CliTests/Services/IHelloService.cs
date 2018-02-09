using System;
namespace MvvmReady.CliTests.Services
{
    public interface IHelloService
    {
        string Name { get; set; }
        void SayHello();
    }
}
