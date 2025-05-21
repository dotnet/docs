---
title: Microsoft.Testing.Platform capabilities overview
description: Learn about Microsoft.Testing.Platform capabilities concept.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 07/11/2024
ms.topic: article
---

# Microsoft.Testing.Platform capabilities

In the context of Microsoft.Testing.Platform, a *capability* refers to the *potential to perform a specific action or provide specific information*. It's a means for the testing framework and extensions to *declare* their *ability* to *operate* in a certain manner or provide specific information to the *requesters*.

The *requesters* can be any component involved in a test session, such as the platform, an extension, or the testing framework itself.

The primary objective of the capability system is to facilitate effective communication among the components involved in a test session, enabling them to exchange information and meet their respective needs accurately.

## Guided example

Let's consider a hypothetical example to demonstrate the necessity of a capability system.

> [!NOTE]
> This example is purely for illustrative purposes and isn't currently implemented within Microsoft.Testing.Platform or any testing framework.

Imagine a situation where you have an extension that requires the testing framework to execute no more than one test at a time. Furthermore, after each test, the extension needs to know the CPU usage for that specific test.

To accommodate the preceding scenario, you need to inquire from the testing framework if:

1. It has the capability to execute only one test at a time.
2. It can provide information regarding the amount of CPU consumed by each test.

How can the extension determine if the testing framework has the ability to operate in this mode and provide CPU usage information for a test session? In Microsoft.Testing.Platform, this capability is represented by an implementation the `Microsoft.Testing.Platform.Capabilities.ICapability` interface:

```csharp
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

As you can see, the `ICapability` interface is a *marker* interface because it can represent *any capability*, and the actual implementation will be context dependent. You'll also observe the `ITestFrameworkCapability`, which inherits from `ICapability` to classify the capability. The capability system's generic nature allows for convenient grouping by context. The `ITestFrameworkCapability` groups all the capabilities implemented by the [testing framework](./microsoft-testing-platform-architecture-extensions.md#create-a-testing-framework). The `ICapabilities<TCapability>` interface reveals the *set* of all capabilities implemented by an extension. Similarly, for the base one, there's a context-specific testing framework called `ITestFrameworkCapabilities`. The `ITestFrameworkCapabilities` is provided to the platform during the [testing framework registration](./microsoft-testing-platform-architecture-extensions.md#register-a-testing-framework) process.

To create a capability that addresses the aforementioned scenario, you define it as follows:

```csharp
public interface IDisableParallelismCapability : ITestFrameworkCapability
{
    bool CanDisableParallelism { get; }
    bool CanProvidePerTestCpuConsumption { get; }
    void Enable();
}
```

If the testing framework implements this interface, at runtime, the following can be queried:

* Verify if the testing framework has the ability to turn off parallelism `CanDisableParallelism = true`.
* Determine if the testing framework can supply CPU usage data `CanProvidePerTestCPUConsumption = true`.
* Request the testing adapter to activate this mode by invoking the `Enable()` method before the test session commences.

The hypothetical code fragment inside the extension could be something like:

```csharp
IServiceProvider provider = null; // TODO: Get IServiceProvider.
var capabilities = serviceProvider.GetRequiredService<ITestFrameworkCapabilities>();

// Utilize the `GetCapability` API to search for the specific capability to query.
var capability = capabilities.GetCapability<IDisableParallelismCapability>();
if (capability is null)
{
    // Capability not supported...
}
else
{
    capability.Enable();
    if (capability.CanDisableParallelism)
    {
        // Do something...
    }

    if (capability.CanProvidePerTestCpuConsumption)
    {
        // Do something...
    }
}
```

The preceding example illustrates how the capability infrastructure enables a powerful mechanism for communicating abilities between the components involved in a test session. While the sample demonstrates a capability specifically designed for the testing framework, any component can expose and implement extensions that inherit from `ICapability`.

It's evident that not all details can be communicated through an interface. Considering the previous example, what should the extension expect if the `CanProvidePerTestCpuConsumption` is supported? What kind of custom information is expected to be transmitted via the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) by the testing framework? The solution is **documentation of the capability**. It's the responsibility of the capability *owner* to design, ship, and document it as clearly as possible to assist implementors who want to effectively *collaborate* with the extension that requires the specific capability.

For instance, the TRX report extension enables the testing framework to implement the necessary capability to accurately generate a TRX report. The extension to register is included in the <https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport> NuGet package, but the capability to implement is found in the *contract only*<https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport.Abstractions> NuGet package.

In conclusion, let's summarize the primary aspects of the capability system:

* It's essential for facilitating clear and stable communication between components.
* All capabilities should inherit from `ICapability` or an interface that inherits from it, and are exposed through a collection with the `ICapabilities` interface.
* It aids in the evolution of features without causing breaking changes. If a certain capability isn't supported, appropriate action can be taken.
* The responsibility of designing, shipping, and documenting the usage of a capability lies with the *capability owner*. Microsoft.Testing.Platform can also *own* a capability in the same way as any other extension.

## Framework capabilities

The platform exposes a specialized interface named `ITestFrameworkCapability` that is the base of all capabilities exposed for test frameworks. These capabilities are provided when [registering the test framework to the platform](./microsoft-testing-platform-architecture-extensions.md#register-a-testing-framework).

### `IBannerMessageOwnerCapability`

An optional [test framework capability](#framework-capabilities) that allows the test framework to provide the banner message to the platform. If the message is `null` or if the capability is n't present, the platform will use its default banner message.

This capability implementation allows you to abstract away the various conditions that the test framework may need to consider when deciding whether or not the banner message should be displayed.

The platform exposes the [`IPlatformInformation` service](./microsoft-testing-platform-architecture-services.md#the-iplatforminformation-service) to provide some information about the platform that could be useful when building your custom banner message.
