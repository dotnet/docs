# NewTypes Pets Sample

This sample is part of the [Organizing and testing projects with the .NET Core command line tutorial](https://learn.microsoft.com/dotnet/core/tutorials/testing-with-cli) for creating .NET Core console applications. See the tutorial for details on the code for this sample.

## Key Features

This sample builds a program and an associated unit test assembly. Using this sample, you learn how to structure projects as part of a larger solution and incorporate unit tests into your projects.

## Build and run

To build and run the sample, change to the *src/NewTypes* directory and execute the following command:

```console
dotnet run
```

`dotnet restore` ([see note](#dotnet-restore-note)) restores the dependencies of the sample. `dotnet run` builds the sample and runs the output executable. It implicitly runs `dotnet restore` to restore the dependencies of the sample. If you're using .NET Core 1.0 or .NET Core 1.1 instead of .NET Core 2.0 or a later version, you have to run `dotnet restore` yourself.

To run the tests, change to the *test/NewTypesTests* directory and execute the following two commands:

```console
dotnet build
dotnet test
```

`dotnet test` runs the configured tests.

`dotnet build` will follow the dependency on the `NewTypesMsBuild` project and build both the app and unit tests projects. It implicitly runs `dotnet restore` on .NET Core 2.0 and later versions. If you're using .NET Core 1.0 or .NET Core 1.1, you first have to run `dotnet restore` yourself.

<a name="dotnet-restore-note"></a>
**Note:** Starting with .NET Core 2.0 SDK, you don't have to run [`dotnet restore`](https://learn.microsoft.com/dotnet/core/tools/dotnet-restore) because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build` and `dotnet run`. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as [continuous integration builds in Azure DevOps Services](https://learn.microsoft.com/azure/devops/build-release/apps/aspnet/build-aspnet-core) or in build systems that need to explicitly control the time at which the restore occurs.
