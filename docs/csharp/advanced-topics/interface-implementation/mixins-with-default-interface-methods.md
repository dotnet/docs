---
title: Create mixin types using default interface methods
description: Using default interface members you can extend interfaces with optional default implementations for implementors.
ms.date: 07/31/2024
---
# Tutorial: Mix functionality in when creating classes using interfaces with default interface methods

You can define an implementation when you declare a member of an interface. This feature provides new capabilities where you can define default implementations for features declared in interfaces. Classes can pick when to override functionality, when to use the default functionality, and when not to declare support for discrete features.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Create interfaces with implementations that describe discrete features.
> * Create classes that use the default implementations.
> * Create classes that override some or all of the default implementations.

## Prerequisites

You need to set up your machine to run .NET, including the C# compiler. The C# compiler is available with [Visual Studio 2022](https://visualstudio.microsoft.com/downloads), or the [.NET SDK](https://dotnet.microsoft.com/download/dotnet).

## Limitations of extension methods

One way you can implement behavior that appears as part of an interface is to define [extension methods](../../programming-guide/classes-and-structs/extension-methods.md) that provide the default behavior. Interfaces declare a minimum set of members while providing a greater surface area for any class that implements that interface. For example, the extension methods in <xref:System.Linq.Enumerable> provide the implementation for any sequence to be the source of a LINQ query.

Extension methods are resolved at compile time, using the declared type of the variable. Classes that implement the interface can provide a better implementation for any extension method. Variable declarations must match the implementing type to enable the compiler to choose that implementation. When the compile-time type matches the interface, method calls resolve to the extension method. Another concern with extension methods is that those methods are accessible wherever the class containing the extension methods is accessible. Classes can't declare if they should or shouldn't provide features declared in extension methods.

You can declare the default implementations as interface methods. Then, every class automatically uses the default implementation. Any class that can provide a better implementation can override the interface method definition with a better algorithm. In one sense, this technique sounds similar to how you could use [extension methods](../../programming-guide/classes-and-structs/extension-methods.md).

In this article, you learn how default interface implementations enable new scenarios.

## Design the application

Consider a home automation application. You probably have many different types of lights and indicators that could be used throughout the house. Every light must support APIs to turn them on and off, and to report the current state. Some lights and indicators might support other features, such as:

- Turn light on, then turn it off after a timer.
- Blink the light for a period of time.

Some of these extended capabilities could be emulated in devices that support the minimal set. That indicates providing a default implementation. For those devices that have more capabilities built in, the device software would use the native capabilities. For other lights, they could choose to implement the interface and use the default implementation.

Default interface members provide a better solution for this scenario than extension methods. Class authors can control which interfaces they choose to implement. Those interfaces they choose are available as methods. In addition, because default interface methods are virtual by default, the method dispatch always chooses the implementation in the class.

Let's create the code to demonstrate these differences.

## Create interfaces

Start by creating the interface that defines the behavior for all lights:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/UnusedExampleCode.cs" id="SnippetILightInterfaceV1":::

A basic overhead light fixture might implement this interface as shown in the following code:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/UnusedExampleCode.cs" id="SnippetOverheadLightV1":::

In this tutorial, the code doesn't drive IoT devices, but emulates those activities by writing messages to the console. You can explore the code without automating your house.

Next, let's define the interface for a light that can automatically turn off after a timeout:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/UnusedExampleCode.cs" id="SnippetPureTimerInterface":::

You could add a basic implementation to the overhead light, but a better solution is to modify this interface definition to provide a `virtual` default implementation:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/ITimerLight.cs" id="SnippetTimerLightFinal":::

The `OverheadLight` class can implement the timer function by declaring support for the interface:

```csharp
public class OverheadLight : ITimerLight { }
```

A different light type might support a more sophisticated protocol. It can provide its own implementation for `TurnOnFor`, as shown in the following code:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/HalogenLight.cs" id="SnippetHalogenLight":::

Unlike overriding virtual class methods, the declaration of `TurnOnFor` in the `HalogenLight` class doesn't use the `override` keyword.

## Mix and match capabilities

The advantages of default interface methods become clearer as you introduce more advanced capabilities. Using interfaces enables you to mix and match capabilities. It also enables each class author to choose between the default implementation and a custom implementation. Let's add an interface with a default implementation for a blinking light:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/IBlinkingLight.cs" id="SnippetBlinkingLight":::

The default implementation enables any light to blink. The overhead light can add both timer and blink capabilities using the default implementation:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/OverheadLight.cs" id="SnippetOverheadLight":::

A new light type, the `LEDLight` supports both the timer function and the blink function directly. This light style implements both the `ITimerLight` and `IBlinkingLight` interfaces, and overrides the `Blink` method:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/LEDLight.cs" id="SnippetLEDLight":::

An `ExtraFancyLight` might support both blink and timer functions directly:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/ExtraFancyLight.cs" id="SnippetExtraFancyLight":::

The `HalogenLight` you created earlier doesn't support blinking. So, don't add the `IBlinkingLight` to the list of its supported interfaces.

## Detect the light types using pattern matching

Next, let's write some test code. You can make use of C#'s [pattern matching](../../fundamentals/functional/pattern-matching.md) feature to determine a light's capabilities by examining which interfaces it supports. The following method exercises the supported capabilities of each light:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/Program.cs" id="SnippetTestLightFunctions":::

The following code in your `Main` method creates each light type in sequence and tests that light:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/Program.cs" id="SnippetMainMethod":::

## How the compiler determines best implementation

This scenario shows a base interface without any implementations. Adding a method into the `ILight` interface introduces new complexities. The language rules governing default interface methods minimize the effect on the concrete classes that implement multiple derived interfaces. Let's enhance the original interface with a new method to show how that changes its use. Every indicator light can report its power status as an enumerated value:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/ILight.cs" id="SnippetPowerStatus":::

The default implementation assumes no power:

:::code language="csharp" source="./snippets/mixins-with-default-interface-methods/ILight.cs" id="SnippetILightInterface":::

These changes compile cleanly, even though the `ExtraFancyLight` declares support for the `ILight` interface and both derived interfaces, `ITimerLight` and `IBlinkingLight`. There's only one "closest" implementation declared in the `ILight` interface. Any class that declared an override would become the one "closest" implementation. You saw examples in the preceding classes that overrode the members of other derived interfaces.

Avoid overriding the same method in multiple derived interfaces. Doing so creates an ambiguous method call whenever a class implements both derived interfaces. The compiler can't pick a single better method so it issues an error. For example, if both the `IBlinkingLight` and `ITimerLight` implemented an override of `Power()`, the `OverheadLight` would need to provide a more specific override. Otherwise, the compiler can't pick between the implementations in the two derived interfaces. This situation is shown in the following diagram:

:::image type="content" source="./media/mixins-with-default-interface-methods/diamond-problem.svg" alt-text="illustration of the diamond problem with default interface methods":::

The preceding diagram illustrates the ambiguity. `OverheadLight` doesn't provide an implementation of `ILight.Power()`. Both `IBlinkingLight` and `ITimerLight` provide overrides that are more specific. A call to `ILight.Power()` on an instance of `OverheadLight` is ambiguous. You must add a new override in `OverheadLight` to resolve the ambiguity.

You can usually avoid this situation by keeping interface definitions small and focused on one feature. In this scenario, each capability of a light is its own interface; only classes inherit multiple interfaces.

This sample shows one scenario where you can define discrete features that can be mixed into classes. You declare any set of supported functionality by declaring which interfaces a class supports. The use of virtual default interface methods enables classes to use or define a different implementation for any or all the interface methods. This language capability provides new ways to model the real-world systems you're building. Default interface methods provide a clearer way to express related classes that might mix and match different features using virtual implementations of those capabilities.
