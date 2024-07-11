---
title: Microsoft.Testing.Platform architecture overview
description: Learn about how to extend Microsoft.Testing.Platform.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 07/11/2024
---

# Microsoft.Testing.Platform capabilities

In the context of the testing platform, a *capability* refers to the *potential to perform a specific action or provide specific information*. It is a means for the testing framework and extensions to *declare* their *ability* to *operate* in a certain manner or provide specific information to the *requesters*.

The *requesters* can be any component involved in a test session, such as the platform itself, an extension, or the testing framework itself.

The primary objective of the capability system is to facilitate effective communication among the components involved in a test session, enabling them to exchange information and meet their respective needs accurately.

## Guided example

Let's consider a hypothetical example to demonstrate the necessity of a capability system. **Please note that this example is purely for illustrative purposes and is not currently implemented within the testing platform or any testing framework.**

Imagine a situation where we have an extension that requires the testing framework to execute no more than one test at a time. Furthermore, after each test, the extension needs to know the CPU usage for that specific test.

To accommodate the above scenario, we need to inquire from the testing framework if:

1. It has the capability to execute only one test at a time.
2. It can provide information regarding the amount of CPU consumed by each test.

How can the extension determine if the testing framework has the ability to operate in this mode and provide CPU usage information for a test session?
In the testing platform, this capability is represented by an implementation of an interface that inherits from a base one named `Microsoft.Testing.Platform.Capabilities.ICapability`:

```cs
// Base capabilities contracts

public interface ICapability
{
}

public interface ICapabilities<TCapability>
    where TCapability : ICapability
{
    IReadOnlyCollection<TCapability> Capabilities { get; }
}

// Specific testing framework capabilities

public interface ITestFrameworkCapabilities : ICapabilities<ITestFrameworkCapability>
{
}

public interface ITestFrameworkCapability : ICapability
{
}
```

As you can see, the  interface `ICapability` is *empty* because it can represent *any capability*, and the actual implementation will be context-dependent. You'll also observe the `ITestFrameworkCapability`, which inherits from `ICapability` to classify the capability. The capability system's generic nature allows for convenient grouping by context. The `ITestFrameworkCapability` groups all the capabilities implemented by the [testing framework](./unit-testing-platform-architecture-extensions.md#creating-a-testing-framework). The `ICapabilities<TCapability>` interface reveals the *set* of all capabilities implemented by an extension. Similarly, for the base one, we have a context-specific testing framework called `ITestFrameworkCapabilities`.  The `ITestFrameworkCapabilities` is provided to the platform during the [testing framework registration](./unit-testing-platform-architecture-extensions.md#registering-a-testing-framework) process.

Now, let's attempt to create our capability to address the aforementioned scenario. We could define it as follows:

```cs
public interface IDisableParallelismCapability : ITestFrameworkCapability
{
    bool CanDisableParallelism {get;}
    bool CanProvidePerTestCPUConsumption {get;}
    void Enable();
}
```

If the testing framework implements this interface and we can query it at runtime, we can:

* Verify if the testing framework has the ability to turn off parallelism `CanDisableParallelism = true`
* Determine if the testing framework can supply CPU usage data `CanProvidePerTestCPUConsumption = true`
* Request the testing adapter to activate this mode by invoking the `Enable()` method before the test session commences

The hypothetical code fragment inside the extension could be something like:

```cs
IServiceProvider serviceProvider = ...get service provider...
ITestFrameworkCapabilities testFrameworkCapabilities = serviceProvider.GetRequiredService<ITestFrameworkCapabilities>();

// We utilize the handy `GetCapability` API to search for the specific capability we wish to query.
IDisableParallelismCapability? capability = testFrameworkCapabilities.GetCapability<IDisableParallelismCapability>();
if (capability is null)
{
   ...capability not supported...
}
else
{
    capability.Enable();
    if (capability.CanDisableParallelism)
    {
        ...do something...
    }

    if (capability.CanProvidePerTestCPUConsumption)
    {
        ...do something...
    }
}
```

The example above illustrates how the capability infrastructure enables a powerful mechanism for communicating abilities between the components involved in a test session. While the sample demonstrates a capability specifically designed for the testing framework, any component can expose and implement extensions that inherit from `ICapability`.

It's evident that not all details can be communicated through an interface. For example, in the scenario above, what should the extension expected if the `CanProvidePerTestCPUConsumption` is supported? What kind of custom information is expected to be transmitted via the [`IMessageBus`](./unit-testing-platform-architecture-services.md#the-imessagebus-service) by the testing framework? The solution to this is **DOCUMENTATION OF THE CAPABILITY**. It's the responsibility of the capability *owner* to design, ship, and document it as clearly as possible to assist implementors who want to effectively *collaborate* with the extension that requires the specific capability.

For instance, at the time of writing, the TRX report extension enables the testing framework to implement the necessary capability to accurately generate a TRX report. The extension to register is included in the package <https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport>, but the capability to implement is found in the *contract only* package <https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport.Abstractions>.

In conclusion, let's summarize the primary aspects of the capability system:

* It is essential for facilitating clear and stable communication between components.
* All capabilities should inherit from `ICapability` or an interface that inherits from it, and are exposed through a collection with the `ICapabilities` interface.
* It aids in the evolution of features without causing breaking changes. If a certain capability is not supported, appropriate action can be taken.
* The responsibility of designing, shipping, and documenting the usage of a capability lies with the *capability owner*. The testing platform can also *own* a capability in the same way as any other extension.

## Platform capabilities

## Framework capabilities

The platform exposes a specialized interface named `ITestFrameworkCapability` that is the base of all capabilities exposed for test frameworks. These capabilities are provided when [registering the test framework to the platform](./unit-testing-platform-architecture-extensions.md#registering-a-testing-framework).

### `IBannerMessageOwnerCapability`

An optional [test framework capability](#framework-capabilities) that allows the test framework to provide the banner message to the platform. If the message is null or if the capability is not present, the platform will use its default banner message.

This capability implementation allows to abstract away the various conditions that the test framework may need to consider to decide whether or not the banner message should be displayed.

The platform exposes the [`IPlatformInformation` service](./unit-testing-platform-architecture-services.md#the-iplatforminformation-service) to provide some information about the platform that could be useful when building your custom banner message.
