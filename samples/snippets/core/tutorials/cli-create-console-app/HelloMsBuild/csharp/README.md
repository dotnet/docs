# Hello Sample

This sample is part of the [step-by-step tutorial](https://docs.microsoft.com/dotnet/core/tutorials/using-with-xplat-cli)
for creating .NET Core Console Applications. Please see that topic for detailed steps on the code
for this sample.

## Key Features

This is the basic Hello World sample. It demonstrates the basics of the environment.

## Build and Run

To build and run the sample, type the following command:

`dotnet run`

`dotnet run` builds the sample and runs the output assembly. It implicitly calls `dotnet restore` on .NET Core 2.0 and later versions. If you're using a .NET Core 1.x SDK, you first have to call `dotnet restore` yourself.

**Note:** Starting with .NET Core 2.0 SDK, you don't have to run [`dotnet restore`](https://docs.microsoft.com/dotnet/core/tools/dotnet-restore) because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build` and `dotnet run`. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as [continuous integration builds in Azure DevOps Services](https://docs.microsoft.com/azure/devops/build-release/apps/aspnet/build-aspnet-core) or in build systems that need to explicitly control the time at which the restore occurs.
