.NET Core (Windows) Hosting Sample
==================================

This sample demonstrates a very simple .NET Core Windows host. It is part of the [.NET Core hosting tutorial](https://docs.microsoft.com/dotnet/articles/core/tutorials/todo). Please see that topic for a more detailed explanation of this sample.

About .NET Core Hosts
---------------------

.NET Core applications are always run by a host. In the vast majority of cases, the default dotnet.exe host is used.

It is possible to create your own host, though, to enable starting and running .NET Core code from a native application, or to enable a high degree of control over how the runtime operates.

.NET Core hosting is platform-specific, so Windows hosting code will look different from Linux/Mac hosts. This sample shows how to host .NET Core on Windows. Future samples will cover Unix scenarios.

More complex, real-world hosts can be found in the [dotnet/coreclr](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts) repository.

Build and Run
-------------

To build this sample, just use msbuild: `msbuild.exe SampleHost.vcxproj`. Be sure to build for x64 to host a 64-bit verson of .NET Core (coreclr.dll) and Win32 to host a 32-bit version.

To run the host, you will need a .NET Core-targeted app to run with it.

1. Build a simple .NET Core app (like 'hello world') as a [self-contained](https://docs.microsoft.com/en-us/dotnet/articles/core/deploying/#self-contained-deployments-scd) app (since this host looks for coreclr.dll next to the target app) and publish it.
2. Run the SampleHost.exe built previously and pass the path to your app's published dll as a command line argument.

The sample host should start the .NET Core runtime and execute your app.