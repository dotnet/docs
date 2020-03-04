# C# List Collections Sample

This sample is part of the [List Collections tutorial](https://docs.microsoft.com/dotnet/csharp/tutorials/intro-to-csharp/arrays-and-collections)
for learning C# features. Please see that topic for detailed steps on the code
for this sample.

## Key Features

This sample demonstrates management of data collections using generic list type which explains about creation of generic [List&lt;T&gt;](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) type. It also explains about modification, searching and sorting of list items.

## Build and Run

To build and run the sample, type the following two commands:

```
dotnet restore
dotnet run
```

`dotnet restore` restores the dependencies for this sample.

`dotnet run` builds the sample and runs the output assembly.

**Note:** Starting with .NET Core 2.0 SDK, you don't have to run [`dotnet restore`](https://docs.microsoft.com/dotnet/core/tools/dotnet-restore) because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build` and `dotnet run`. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as [continuous integration builds in Azure DevOps Services](https://docs.microsoft.com/azure/devops/build-release/apps/aspnet/build-aspnet-core) or in build systems that need to explicitly control the time at which the restore occurs.
