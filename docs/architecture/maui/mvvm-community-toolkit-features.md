---
title: MVVM Toolkit Features
description: Helper components to simplify app development and maintenance
author: michaelstonis
no-loc: [MAUI]
ms.date: 03/10/2023
---

# MVVM Toolkit Features

[!INCLUDE [download-alert](includes/download-alert.md)]

## MVVM Toolkit

The [Model-View-ViewModel (MVVM)](mvvm.md) pattern is a great structural basis for creating our applications. In this pattern, the ViewModel becomes the backbone of our application as it provides communication to our front-end user interface and backing components. To provide integration with the user interface, we will rely on the ViewModel's properties and commands. As detailed in [Updating views in response to changes in the underlying view model or model](mvvm.md#updating-views-in-response-to-changes-in-the-underlying-view-model-or-model), the `INotifyPropertyChanged` interface on our ViewModel to allows changes to our properties to notify when the value is changed. Implementing all of these features means that our ViewModel can end up becoming very verbose. For example, the following code shows a simple ViewModel with properties that raise changes:

```csharp
public class SampleViewModel : INotifyPropertyChanged
{
    private string _name;
    private int _value;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Name
    {
        get => _name;
        set => SetPropertyValue(ref _name, value);
    }

    public int Value
    {
        get => _value;
        set => SetPropertyValue(ref _value, value);
    }

    protected void SetPropertyValue<T>(ref T storageField, T newValue, [CallerMemberName] string propertyName = "")
    {
        if (Equals(storageField, newValue))
            return;

        storageField = newValue;
        RaisePropertyChanged(propertyName);
    }

    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

While some optimizations could be made over time, we will still end up with a fairly verbose set of code for defining our ViewModel. This code can be difficult to maintain and becomes error-prone.

The MVVM Toolkit (`CommunityToolkit.Mvvm`) package can be used to help address and simplify these common MVVM patterns. The MVVM Toolkit, along with newer features to the .NET language, allows for simplified logic, easy adoption into a project, and runtime independence. The example below shows the same ViewModel using components that come with the MVVM Toolkit:

```csharp
public partial class SampleViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private int _value;
}
```

> [!NOTE]
> The MVVM Toolkit is provided with the `CommunityToolkit.Mvvm` package. For information on how to add the package to your project, see [Introduction to the MVVM Toolkit](/dotnet/communitytoolkit/mvvm/) on the Microsoft Developer Center.

In comparison to the original example, we were able to drastically reduce the overall complexity and simplify the maintainability of our ViewModel. The MVVM Toolkit comes with many pre-built common components and features, such as the `ObservableObject` shown above, that simplifies and standardizes the code that we have throughout the application.

## `ObservableObject`

The MVVM Toolkit provides `ObservableObject` which is intended for use as the base of our `ViewModel` objects or any object that needs to raise change notifications. It implements `INotifyPropertyChanged` and `INotifyPropertyChanging` along with helper methods for setting properties and raising changes. Below is an example of a standard ViewModel using `ObservableObject`:

```csharp
public class SampleViewModel : ObservableObject
{
    private string _name;
    private int _value;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public int Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
}
```

`ObservableObject` handles all of the logic needed for raising change notifications by using the `SetProperty` method in your property setter. If you have a property that returns a `Task<T>`, the `SetPropertyAndNotifyOnCompletion` method can be used to delay publishing a property change until the task has been completed. The methods `OnPropertyChanged` and `OnPropertyChanging` that can also be used for raising property changes where needed in your object.

For more detailed information on `ObservableObject`, see [ObservableObject](/dotnet/communitytoolkit/mvvm/observableobject) in the MVVM Toolkit Developer Center.

## `RelayCommand` and `AsyncRelayCommand`

Interaction between .NET MAUI controls (for example, tapping a button or selecting an item from a collection) and the ViewModel is done with the `ICommand` interface. .NET MAUI comes with a default implementation of `ICommand` with the `Command` object. .NET MAUI's `Command` is fairly basic and lacks support for more advanced features, such as supporting asynchronous work and command execution status.

The MVVM Toolkit comes with two commands, `RelayCommand` and `AsyncRelayCommand`. `RelayCommand` is intended for situations where you have synchronous code to execute and has a fairly similar implementation to the .NET MAUI `Command` object.

> [!NOTE]
> Even though the .NET MAUI `Command` and `RelayCommand` are similar, using `RelayCommand` allows for decoupling your ViewModel from any direct .NET MAUI references. This means that your ViewModel is more portable, leading to easier reuse across projects.

`AsyncRelayCommand` provides many additional features when working with asynchronous workflows. This is quite common in our ViewModel as we are typically communicating with repositories, APIs, databases, and other systems that utilize `async/await`. The `AsyncRelayCommand` constructor takes in an execution task defined as a `Func<Task>` or a delegate returning `Task` as part of the constructor. While the execution task is running, `AsyncRelayCommand` will monitor the state of the task and provides updates using the `IsRunning` property. The `IsRunning` property can be bound to the UI which helps manage control states such as showing loading with an `ActivityIndicator` or disabling/enabling a control. While the execution task is being executed, the `Cancel` method can be called to attempt cancellation of the execution task, if supported.

By default, `AsyncRelayCommand` doesn't allow concurrent execution. This is very helpful in situations where a user could unintentionally tap a control multiple times to execute a long-running or costly operation. During task execution, `AsyncRelayCommand` will automatically call the `CanExecuteChanged` event. In .NET MAUI, controls that support the `Command` and `CommandParameter` properties, such as `Button`, will listen to this event and automatically enable or disable it during execution. This functionality can be overridden by using a custom `canExecute` parameter or setting the `AsyncRelayCommandOptions.AllowConcurrentExecutions` flag in the constructor.

For more detailed information on implementing commands, see the section [Implementing commands](mvvm.md#implementing-commands) in the MVVM chapter. Detailed information for the `RelayCommand` and `AsyncRelayCommand` is available in the [Commanding](/dotnet/communitytoolkit/mvvm/relaycommand) of the MVVM Toolkit Developer Center.

## Source Generators

Using the MVVM Toolkit components out-of-the-box allows you to greatly simplify our ViewModel. The MVVM Toolkit allows you to simplify common code use cases even further by using [Source Generators](/dotnet/csharp/roslyn-sdk/source-generators-overview). The MVVM Toolkit source generators look for specific attributes in our code and can generate wrappers for properties and commands.

> [!IMPORTANT]
> The MVVM Toolkit Source Generators generate code that is additive to our existing objects. Because of this, any object that is leveraging a source generator will need to be marked as `partial`.

The MVVM Toolkit `ObservableProperty` attribute can be applied to fields in objects that inherit from `ObservableObject` and will wrap a private field with a property that generates changes. The following code shows an example of using the `ObservableObject` attribute on the `_name` field:

```csharp
public partial class SampleViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name;
}
```

With the `ObservableProperty` attribute applied to the `_name` field, the source generator will run and generate another partial class with the following code:

```csharp
partial class SampleViewModel
{
    public string Name
    {
        get => _name;
        set
        {
            if (!EqualityComparer<string>.Default.Equals(_name, value))
            {
                OnNameChanging(value);
                OnPropertyChanging("Name");
                _name = value;
                OnNameChanged(value);
                OnPropertyChanged("Name");
            }
        }
    }
}
```

The generated `SampleViewModel` has used the private `_name` field and generated a new `Name` property that implements all of the logic needed for raising change notifications.

The MVVM Toolkit `RelayCommand` attribute can be applied to methods within an `ObservableObject` and will create a corresponding `RelayCommand` or `AsyncRelayCommand`. The following code shows examples of using the `RelayCommand` attribute:

```csharp
public partial class SampleViewModel : ObservableObject
{
    public INavigationService NavigationService { get; set; }

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    bool _isValid;

    [RelayCommand]
    private Task SettingsAsync()
    {
        return NavigationService.NavigateToAsync("Settings");
    }

    [RelayCommand]
    private void Validate()
    {
        IsValid = !string.IsNullOrEmpty(Name);
    }
}
```

The `RelayCommand` applied to the `Validate` method will generate a `RelayCommand` validate `ValidateCommand` because it has a `void` return and the `SettingsAsync` method will generate an `AsyncRelayCommand` named `SettingsCommand`. The source generator will generate the following code in other partial classes:

```csharp
partial class SampleViewModel
{
    private AsyncRelayCommand? settingsCommand;

    SettingsCommand => settingsCommand ??= new AsyncRelayCommand(SettingsAsync);
}

partial class SampleViewModel
{
    private RelayCommand? validateCommand;

    public IRelayCommand ValidateCommand => validateCommand ??= new RelayCommand(Validate);
}
```

All of the complexity of wrapping our ViewModel's methods with an `ICommand` implementation has been handled by the source generator.

For more detailed information on MVVM Toolkit Source Generators, see [MVVM source generators](/dotnet/communitytoolkit/mvvm/generators/overview) in the MVVM Toolkit Developer Center.

## Summary

The MVVM Toolkit is a great way to standardize and simplify our ViewModel code. The MVVM toolkit offers great implementations of standard MVVM components such as `ObservableObject` and `Async/RelayCommand`. The source generators help simplify our ViewModel properties and commands by generating all of the boilerplate code needed for user interface interactions. The MVVM Toolkit offers even more features outside of what has been shown in this chapter. For more information on the MVVM Toolkit, see [Introduction to the MVVM Toolkit](/dotnet/communitytoolkit/mvvm/) in the MVVM Toolkit Developer Center.
