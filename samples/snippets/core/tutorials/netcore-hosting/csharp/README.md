# Sample .NET Core Hosts

This folder contains sample code demonstrating how to host managed .NET Core code in a native process. These hosts bypass the usual `dotnet` host and launch managed code directly.

There are three samples demonstrating three different hosting interfaces for .NET Core.

1. The [HostWithHostFxr](HostWithHostFxr) folder demonstrates how to host the .NET Core runtime using the `nethost` and `hostfxr` libraries' APIs. These APIs were introduced in .NET Core 3.0 and are the recommended method of hosting .NET Core 3.0 and above. These entry points handle the complexity of finding and setting up the runtime for initialization. This host demonstrates calling from native code into a static managed method and passing it a message to display.
1. The [HostWithCoreClrHost](HostWithCoreClrHost) folder demonstrates how to host the .NET Core runtime using the newer `coreclrhost.h` API. This API is the preferred method of hosting .NET Core 2.2 and below. This host demonstrates calling from native code into a static managed method and supplying a function pointer for the managed code to use to call back into the host.

These hosts are small and bypass a lot of complexity (probing for assemblies in multiple locations, thorough error checking, etc.) that a real host would have. Hopefully by remaining simple, though, they will be useful for demonstrating the core concepts of hosting managed .NET Core code in a native process. Other (more real-world) hosts which may be useful as a guide can be found in .NET Core product source in the [dotnet/runtime](https://github.com/dotnet/runtime/tree/main/src/coreclr/hosts) repository.

These samples are part of the [.NET Core hosting tutorial](https://docs.microsoft.com/dotnet/core/tutorials/netcore-hosting). Please see that topic for a more detailed explanation of the samples and the steps necessary to host .NET Core.
