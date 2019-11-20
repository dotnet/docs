
The packages added to feeds are named in a hackable format: `{product}-{type}-{version}`.

- **product**\
The type of .NET product to install. Valid options are:

  - dotnet
  - aspnetcore

- **type**\
Chooses the SDK or the runtime. Valid options are:

  - sdk
  - runtime

- **version**\
The version of the SDK or runtime to install. This article will always give the instructions for the latest supported version. Valid options are:

  - 3.0
  - 3.1-preview
  - 2.2
  - 2.1

### Examples

- Install the 2.2 SDK: `dotnet-sdk-2.2`
- Install the ASP.NET Core 3.0 runtime: `aspnetcore-runtime-3.0`
- Install the 2.1 .NET Core runtime: `dotnet-runtime-2.1`

### Troubleshooting

If the package combination doesn't work, it's not available. For example, there isn't an ASP.NET Core SDK, the SDK components are included with the .NET Core SDK. The value `aspnetcore-sdk-2.2` is incorrect and should be `dotnet-sdk-2.2`
