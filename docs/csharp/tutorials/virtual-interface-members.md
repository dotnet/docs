---
title: Create virtual extension methods with default interface members
description: Using default interface members you can extend interfaces with optional virtual implementations. 
ms.date: 00/12/2019
---
# Tutorial: Update interfaces with default interface members in C# 8.0

Beginning with C# 8.0 on .NET Core 3.0, you can define an implementation when you declare a member of an interface. This provides new capabilities where you can declare if implementors can or must override the default implementation. You can also specify if an implementation from a class can be overriden by more derived classes.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> * Extend interfaces safely by adding methods with implementations.
> * Create parameterized implementations to provide greater flexibility.
> * Enable implementers to provide a more specific implementation in the form of an override.

## Prerequisites

You’ll need to set up your machine to run .NET Core, including the C# 8.0 preview compiler. The C# 8.0 preview compiler is available starting with [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019), or the latest [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0). Default interface members are available beginning with .NET Core 3.0 preview 4.

## Limitations of extension methods

One way provide behavior that appears to be part of an interface is to define [extension methods](../programming-guide/classes-and-structs/extension-methods.md) that provide the default behavior. This enables interfaces to declare a minimum set of members while providing a greater surface area for any class that implements that interface. This works well. The extension methods in <xref:System.Linq.Enumerable> provide the implementation for any sequence to be the source of a LINQ query.

Extension methods are resolved at compile time, using the declared type of the variable. Classes that implement the interface can provide a better implementation for any extension method. Variable declarations must match the implementing type to enable the compiler to chose that implementation. When the compile time type matches the interface, method calls resolve to the extension method.

Starting with C# 8.0, you can use declare the default implementations as interface methods. Then, every class automatically uses the default implementation. Any class that can provide a better implementation can override the interface method definition with a better algorithm. In one sense, this sounds similar to how you could use [extension methods](../programming-guide/classes-and-structs/extension-methods.md). Default interface methods enable `virtual` methods, which provides important new behavior. 

In this article, you'll learn how virtual default interface implementations enable new scenarios.

## Design the application.

Consider a home automation application. You'd probably have many different types of lights and indicators that could be used throughout the house. Every light must support APIs to turn them on and off, and to report the current state. Some lights and indicators may support other features, such as:

- Blinking, or other patterns.
- Auto-off capability.

Some of these extended capabilities could be emulated in devices that support the minimal set. That indicates providing a default implementation. For those devices that have more capabilities built in, the device software would use the native capabilities. For other lights, they could choose to implement the interface and use the default implementation.

Default interface members is a better solution for this scenario than extension methods. Class authors can control which interfaces they choose to implement. Only those interfaces they choose are available as methods. In addition, because default interface methods can be virtual, the method dispatch always chooses the implementation in the class. 

Let's create the code to demonstrate these differences.

Start by creating the interface that defines the behavior for all indicator lights:

```csharp
public interface IIndicatorLight
{
    void SwitchOn();
    void SwitchOff();
    bool IsOn();
}
```

For this tutorial, you'll create classes that emulate the behavior of an IoT device. Here's a light implementation for a basic light:

```csharp
public class OverheadLight : IIndicatorLight
{
    public void SwitchOn() => isOn = true;
    public void SwitchOff() => isOn = false;
    public bool IsOn() => isOn;

    private bool isOn;
    override string ToString() => $"The light is {isOn : "on", "off"}";
}
```

Next, let's add an interface for a blinking light. It can derive from the indicator light interface:

```csharp
public interface IBlinkingLight : IIndicatorLight
{
    Task Blink(int period, int repeatCount);
}
```

You could add that capability to the `OverheadLight` by creating the following implementation:

```csharp
public async Task Blink(int duration, int repeatCount)
{
    for(int count = 0; count < repeatCount; count++)
    {
        SwitchOn();
        await Task.Delay(duration);
        SwitchOff();
        await Task.Delay(duration);
    }
}
```

## Create virtual default implementations

You can see that the implementation of `Blink` relies only on capabilities in the base interface. This implementation could be used for any light that blinks. So, let's declare that implementation as the default for the `IBlinkingLight`:

```csharp
public interface IBlinkingLight : IIndicatorLight
{
    public virtual Task Blink(int period, int repeatCount)
    {
        for(int count = 0; count < repeatCount; count++)
        {
            SwitchOn();
            await Task.Delay(duration);
            SwitchOff();
            await Task.Delay(duration);
        }
    }
}
```

The overhead light no longer needs to provide its own implementation, that would likely be repeated in many classes. By declaring that it supports the `IBlinkingLight` interface, the `OverheadLight` class inherits the default interface methods. Because those are virtual, they become part of the public interface (true?).

A more sophisticated light device might support blinking in its message protocol. In that case, the class would override the `virtual` `Blink` method with its own implementation. The same design pattern can be used with an auto off timer:

```csharp
// cool implementation notes
// The overhead light supports both interfaces (using the default)
// LED has blink native, timer by default.
// WhizzBangLight supports both by natively.
// Halogen light only supports auto-off, uses the default
```

## Compare alternative designs.

This scenario shows how easy it is to mix an match different interfaces that *extend* a base interface with new behavior, including a default interfaces. Implementing classes can choose only those interfaces applicable to that class. The class author can use the default implementation, or provide a better custom implementation.

- abstract base classes can't support mix and match
- extension methods can't override behavior. Can't limit which extensiosn are applicable.


## Implications for dynamic

## DIM: Understanding "nearest" implementation

