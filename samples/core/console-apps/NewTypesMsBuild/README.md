NewTypes Pets Sample
================

This sample is part of the [step-by-step tutorial](https://docs.microsoft.com/dotnet/articles/core/tutorials/using-with-xplat-cli) for creating .NET Core Console Applications. Please see that topic for detailed steps on the code for this sample.

Key Features
------------

This sample builds a program and an associated unit test assembly. You'll learn how to structure projects as part of a larger solution, and incorporate unit tests into your projects.

Build and Run
-------------

To build and run the sample, change to the `src/NewTypes` directory and
type the following two commands:

`dotnet restore`
`dotnet run`

`dotnet restore` restores the dependencies for this sample.
`dotnet run` builds the sample and runs the output executable. 

To run the tests, change to the `tests/NewTypesTests` directory and type the following three commands:

`dotnet restore`
`dotnet build`
`dotnet test`

`dotnet test` runs all the configured tests.

Note that you must run `dotnet restore` in the `src/NewTypes` directory before you can run the tests. `dotnet build` will follow the dependency and build both the library and unit tests projects, but it will not restore NuGet packages.
