[![NuGet](https://img.shields.io/nuget/v/MvvmReady.svg?label=NuGet)](https://www.nuget.org/packages/MvvmReady)
[![NuGet](https://img.shields.io/nuget/dt/MvvmReady.svg)](https://www.nuget.org/packages/MvvmReady)
[![Build status](https://ci.appveyor.com/api/projects/status/msra1f35qd83uayo?svg=true)](https://ci.appveyor.com/project/junian/mvvmready)

## About

![](https://3.bp.blogspot.com/-56Kz5T5WL04/Wn_KIg1oEkI/AAAAAAAAC1I/vCszFiZ8SjkW22dAKeCfml74SSfy1i_7wCLcBGAs/s1600/mvvmready.png)

Make cross-platform app MVVM-Ready. Lightweight with only one small binary/file.

## Installation

Get [MvvmReady](http://www.nuget.org/packages/MvvmReady) library from NuGet.

```powershell
PM> Install-Package MvvmReady
```


## Features

### Command

It's a simple `ICommand` implementation. Here is an example:

```csharp
public ICommand HelloWorldCommand => new Command(() =>
{
    Debug.WriteLine("Hello, world!");
});
```

### ViewModelBase

It's an abstract base class for ViewModels.

Use `Set(ref variable, value)` to set value and trigger `PropertyChanged` event.

Use `RaisePropertyChanged()` to trigger `PropertyChanged` event for current property.

Here is an example:

```csharp
public class ProfileViewModel: ViewModelBase
{
    private string _name;
    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
    
    public int Age
    {
        get => DateTime.Now.Year - DateOfBirth.Year
    }
    
    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            Set(ref _dateOfBirth, value);
            RaisePropertyChanged(nameof(Age));
        }
    }
    
}
```

### ServiceLocator

It's a simple service locator.

You can register interface to implementation by using `ServiceLocator.Current.Register<IInterface, Implementation>()`.

You can also register service to itself by using `ServiceLocator.Current.Register<Service>()`.

You can register a singleton service by using `ServiceLocator.Current.Register<IInterface>(() => MyService.Instance)`.

To get service object, use `ServiceLocator.Current.Get<IService>()`.

## License

This work is licensed under [MIT](https://github.com/junian/mvvmready/blob/master/LICENSE).
