
The packages added to the package manager feeds are named in a hackable format: `{product}-{type}-{version}`.

- **product**\
The type of .NET product to install. Valid options are:

  - dotnet
  - aspnetcore

- **type**\
Chooses the SDK or the runtime. Valid options are:

  - sdk
  - runtime

- **version**\
The version of the SDK or runtime to install. This article will always give the instructions for the latest supported version. Valid options are any released version, such as:

  - 3.0
  - 2.2
  - 2.1

### Examples

- Install the .NET Core 2.2 SDK: `dotnet-sdk-2.2`
- Install the ASP.NET Core 3.0 runtime: `aspnetcore-runtime-3.0`
- Install the .NET Core 2.1 runtime: `dotnet-runtime-2.1`

### Troubleshoot

If the package combination doesn't work, it's not available. For example, there isn't an ASP.NET Core SDK, the SDK components are included with the .NET Core SDK. The value `aspnetcore-sdk-2.2` is incorrect and should be `dotnet-sdk-2.2`
