Getting Started using Visual Studio Code Sample
================

This sample is part of the [Getting started with .NET Core on macOS, using Visual Studio Code](../../../../docs/core/tutorials/using-on-macos.md)
walkthrough. Please see that topic for detailed steps on the code
for this sample.

Key Features
------------

This sample builds a program and an associated unit test assembly. You'll learn how to structure
projects as part of a larger solution, and incorporate unit tests into your projects.

Build and Run
-------------

To build and run the sample, change to the `src/library` directory and
type the following two commands:

`dotnet restore`
`dotnet build`

`dotnet restore` installs all the dependencies for this sample into the current directory.
`dotnet build` creates the output assembly (or assemblies).

Next, change to the `src/app` directory and run those same
two commands again.

After that, type this command to run the executable:

`dotnet run`

`dotnet run` runs the output executable. 

To run the tests, change to the `test/test-library` directory and
type the following three commands:

`dotnet restore`
`dotnet build`
`dotnet test`

`dotnet test` runs all the configure tests 

Note that you must run `dotnet restore` in the `src/library` directory before you can run
the tests. `dotnet build` will follow the dependency and build both the library and unit
tests projects, but it will not restore NuGet packages.

This sample focuses on setting up and using [Visual Studio Code](http://code.visualstudio.com)
as your development editor. The topic walks through all the setup and configuration steps for
that environment.
