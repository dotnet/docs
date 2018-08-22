# Managing .NET Core installations

.NET Core is designed to allow multiple versions of the SDK and Runtime to exist side-by-side, enabling version dependency flexibility for both building and running .NET Core applications. These installation and automatic version roll forward behaviors offer valuable benefits but one pronounced drawback. As updates of the .NET Core SDK or .NET Core Runtime are installed, previous versions remain on-disk, resulting in increasing disk usage, over time. More than 50 .NET Core SDK updates have been released, which means there may be many versions of the SDK and Runtime installed on your system that could be removed.

## Safe to remove?

The safe removal of previous versions of the SDK and Runtime is enabled by [.NET Core version selection](https://docs.microsoft.com/en-us/dotnet/core/versions/selection) behaviors, and the runtime compatibility of .NET Core across updates. It is a first order principle that .NET Core runtime updates are compatible within a major version 'band' such as 1.x and 2.x. Additionally, newer releases of the .NET Core SDK generally maintain the ability to build applications which target previous versions of the runtime in a compatible manner.

There are instances where retaining older SDK or Runtime versions makes sense, such as when maintianing project.json-based applications. Absent specific dependencies around application maintenance or application runtime requirements, there are no functional reasons for retaining anything more than the latest SDK and latest patch version of the Runtimes required for your applications.

The methods for removing .NET Core vary from platform to platform and have changed somewhat across .NET Core versions. For details on removing versions of .NET Core which are no longer needed, see ['How to remove the .NET Core Runtime and SDK'](https://docs.microsoft.com/en-us/dotnet/core/versions/remove-runtime-sdk-versions?tabs=Windows) in the [.NET Core documentation](https://docs.microsoft.com/en-us/dotnet/core/).

## In summary

There are a number of good reasons why particular versions of the .NET Core SDK or .NET Core Runtime would need to be maintained on a given system. However, the reasons are specific. If you do not have a specific need to use previous SDK or Runtime versions to maintain or run existing applications, it is safe to remove them.
