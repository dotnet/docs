
All versions of .NET are available for download at <https://dotnet.microsoft.com/download/dotnet>, but require [manual installation](../linux-scripted-manual.md). You can try and use the package manager to install a different version of .NET. However, the requested version may not be available. Usually, the [Microsoft repository]() contains all .NET versions, while the official Ubuntu feeds only contain what is currently supported.

The packages added to package manager feeds are named in a hackable format, for example: `{product}-{type}-{version}`.

- **product**\
The type of .NET product to install. Valid options are:

  - dotnet
  - aspnetcore

- **type**\
Chooses the SDK or the runtime. Valid options are:

  - sdk (only available for the **dotnet** product)
  - runtime

- **version**\
The version of the SDK or runtime to install. This article will always give the instructions for the latest supported version. Valid options are any released version, such as:

  - 7.0
  - 5.0
  - 3.1
  - 2.1

  It's possible the SDK/runtime you're trying to download is not available for your Linux distribution. For a list of supported distributions, see [Install .NET on Linux](../linux.md).

### Examples

- Install the ASP.NET Core 7.0 runtime: `aspnetcore-runtime-7.0`
- Install the .NET Core 2.1 runtime: `dotnet-runtime-2.1`
- Install the .NET 5 SDK: `dotnet-sdk-5.0`
- Install the .NET Core 3.1 SDK: `dotnet-sdk-3.1`

### Package missing

If the package-version combination doesn't work, it's not available. For example, there isn't an ASP.NET Core SDK, the SDK components are included with the .NET SDK. The value `aspnetcore-sdk-7.0` is incorrect and should be `dotnet-sdk-7.0`. For a list of Linux distributions supported by .NET, see [.NET dependencies and requirements](../linux.md).
