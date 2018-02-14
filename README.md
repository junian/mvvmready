# MvvmReady

[![NuGet](https://img.shields.io/nuget/v/MvvmReady.svg?label=NuGet)](https://www.nuget.org/packages/MvvmReady)
[![Build status](https://ci.appveyor.com/api/projects/status/msra1f35qd83uayo?svg=true)](https://ci.appveyor.com/project/junian/mvvmready)

Make your Cross-platform app Mvvm-Ready. Lightweight with only one small binary/file.

## Installation

Get [MvvmReady](http://www.nuget.org/packages/MvvmReady) library from NuGet.

```
PM> Install-Package MvvmReady
```


## Features

### Command

It's a simple `ICommand` implementation.

Use `new Command(() => {})` to create a new Command.

### ViewModelBase

It's an abstract base class for ViewModels.

Use `Set(ref variable, value)` to set value and trigger `PropertyChanged` event.

Use `RaisePropertyChanged()` to trigger `PropertyChanged` event for current property.

### ServiceLocator

It's a simple service locator.

You can register interface to implementation by using `ServiceLocator.Current.Register<IInterface, Implementation>()`.

You can also register service to itself by using `ServiceLocator.Current.Register<Service>()`.

You can register a singleton service by using `ServiceLocator.Current.Register<IInterface>(() => MyService.Instance)`.

To get service object, use `ServiceLocator.Current.Get<IService>()`.

## License

This work is licensed under [MIT](https://github.com/junian/mvvmready/blob/master/LICENSE).
