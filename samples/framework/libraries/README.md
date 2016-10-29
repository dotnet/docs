# .NET Core Library Samples

**Note:** This document is  compatible with tooling that is still in active development.  Details are subject to change over time.

These samples are buildable projects whose source is used for code snippets in [the guide for writing cross-platform libraries](../../../docs/core/tutorials/libraries.md).  They can be built and run using the .NET Core RC1 toolchain, and are intended to simply demonstrate how to target and build NuGet packages for different targets.  They aren't examples of how you'd build a real, feature-complete library.

To build/use any of these (using `new-library` as an example):

1. Open your favorite Command Line Interface (e.g. Cmd.exe or Terminal).

2. Navigate to the top-level directory:

	`$ cd new-library`

3. Restore packages by typing the following:

	`$ dotnet restore`
		
4. To build and package the library as a NuGet package, type the following:

	`$ cd src/Library`
	
	`$ dotnet build`
	
	`$ dotnet pack`
	
	Check out the `/bin/Debug` directory to see the generated artifacts and `.nupkg`.

5. To run unit tests (only applicable to `new-library`):

	`$ cd ../../test/LibraryTests`
	
	`$ dotnet test`

And that's it!

## new-library

The project under `/new-library` is a project targeting **only** .NET Core. For that reason,
this project is stored under the core project directory, so our build server builds it on
all platforms. Look under https://github.com/dotnet/docs/tree/master/samples/core/libraries/new-library/

It demonstrates two other things: how to use multiple projects and how to test.

There are two libraries showcased.  The first, `DependencyLibrary`, contains functionality that the second, `Library` uses.  The `LibraryTests` test project takes a dependency on `Library` to test that project.

## frameworks-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/frameworks-library` demonstrates a project for targeting .NET Framework that you can build and run with the CLI tools.  It does so with a simple project targeting .NET Framework 4.0.  You could extend this to target additional version so of .NET Framework by adding new build targets in the `project.json`.  Check out the [section on cross-compiling](../../../docs/core/tutorials/libraries.md#how-to-multitarget) in the CLI libraries article for more information.

## net45-compat-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/net45-compat-library` is for targeting any of the following:

* .NET Framework 4.5 and above
* Windows Phone 8.1
* Whindows Phone Silverlight 8
* Universal Windows Platform
* DNX Core
* Xamarin
* Mono

It uses the `dotnet51` Target Framework Moniker introduced with the .NET Platform Standard.

## net40-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/net40-library` is for how to target .NET Framework 4.0 and above.  It also demonstrates how to use `#if` directives to multi-target for a .NET 4.0 target.

## pcl-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/pcl-library` is for showing how to target a supported PCL Profile (e.g. 3344).  It shows how to structure the `project.json` file to allow for targeting a PCL.  It also demonstrates how to use `#if` directives and how to set those up in conjunction with the `project.json` file.
