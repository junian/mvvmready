# MvvmReady

Make your Cross-platform app Mvvm-Ready. Lightweight with only one small binary/file.

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

To get service object, use `ServiceLocator.Current.Get<IService>()`.

## License

This work is licensed under [MIT](https://github.com/junian/mvvmready/blob/master/LICENSE).
