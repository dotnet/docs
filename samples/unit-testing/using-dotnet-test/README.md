Unit Testing using dotnet test Sample
================

This sample is part of the [unit testing tutorial](https://docs.microsoft.com/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
for creating applications with unit tests included. Please see that topic for detailed steps on the code
for this sample.

Key Features
------------

This sample demonstrates creating a library and writing effective unit tests
that validate the features in that library. 

The example provides a service that indicates whether a number is or is not
a prime number.

Build and Run
-------------

To build and run the sample, change to the `src/PrimeService` directory and
type the following three commands:

`dotnet restore`
`dotnet build`
`dotnet run`

`dotnet restore` installs all the dependencies for this sample into the current directory.
`dotnet build` creates the output assembly (or assemblies).
`dotnet run` runs the output executable. 

To run the tests, change to the `tests/PrimeService.Tests` directory and
type the following three commands:

`dotnet restore`
`dotnet build`
`dotnet test`

`dotnet test` runs all the configure tests 

Note that you must run `dotnet restore` in the `src/PrimeService` directory before you can run
the tests. `dotnet build` will follow the dependency and build both the library and unit
tests projects, but it will not restore NuGet packages.
