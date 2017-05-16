# NewTypes Pets Sample

This sample is part of the [Organizing and testing projects with the .NET Core command line tutorial](https://docs.microsoft.com/dotnet/articles/core/tutorials/testing-with-cli) for creating .NET Core console applications. See the tutorial for details on the code for this sample.

## Key Features

This sample builds a program and an associated unit test assembly. Using this sample, you learn how to structure projects as part of a larger solution and incorporate unit tests into your projects.

## Build and run

To build and run the sample, change to the *src/NewTypesMsBuild* directory and execute the following two commands:

```console
dotnet restore
dotnet run
```

`dotnet restore` restores the dependencies of the sample. `dotnet run` builds the sample and runs the output executable. 

To run the tests, change to the *test/NewTypesTests* directory and execute the following three commands:

```console
dotnet restore
dotnet build
dotnet test
```

`dotnet test` runs the configured tests.

Note that you must run `dotnet restore` in the *src/NewTypesMsBuild* directory before you can run the tests. `dotnet build` will follow the dependency on the `NewTypesMsBuild` project and build both the app and unit tests projects, but it won't restore NuGet packages.
