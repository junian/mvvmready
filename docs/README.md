<p align="center"><img src="https://3.bp.blogspot.com/-56Kz5T5WL04/Wn_KIg1oEkI/AAAAAAAAC1I/vCszFiZ8SjkW22dAKeCfml74SSfy1i_7wCLcBGAs/s1600/mvvmready.png" alt="MvvmReady Logo"></p>

<h1 align="center">MvvmReady</h1>

<p align="center">Make cross-platform app MVVM-Ready. Lightweight with only one small binary/file.</p>

<p align="center">
    <a href="https://www.nuget.org/packages/MvvmReady/"><img src="https://img.shields.io/nuget/v/MvvmReady.svg?label=NuGet" alt="MvvmReady latest version on NuGet" title="MvvmReady latest version on NuGet"></a>
    <a href="https://www.nuget.org/packages/MvvmReady/"><img src="https://img.shields.io/nuget/dt/MvvmReady.svg" alt="MvvmReady total downloads on NuGet" title="MvvmReady total downloads on NuGet"></a>
    <a href="https://twitter.com/JunianDev"><img src="https://img.shields.io/twitter/follow/juniandev" alt="Follow me on X" title="Follow me on X"></a>
</p>

----

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
