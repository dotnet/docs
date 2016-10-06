Unit Testing using dotnet test Sample
================

This sample is part of the [unit testing tutorial](https://docs.microsoft.com/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
for creating applications with unit tests included. See that topic for detailed steps on the code
for this sample.

Key Features
------------

This sample demonstrates creating a library and writing effective unit tests that validate the features in that library. 

The example provides a service that indicates whether a number is prime.

Build and Run
-------------

To build and run the sample, navigate to `src/PrimeService` and run the following commands:

```
dotnet restore
dotnet build
dotnet run
```

`dotnet restore` installs all the dependencies.
`dotnet build` creates the assembly (or assemblies).
`dotnet run` runs the executable. 

To run the tests, navigate to the `tests/PrimeService.Tests` directory and type the following commands:

```
dotnet restore
dotnet build
dotnet test
```

`dotnet test` runs all the configured tests.

You must run `dotnet restore` in the `src/PrimeService` directory before you can run
the tests. `dotnet build` will follow the dependency and build both the library and unit
tests projects, but it will not restore NuGet packages.
