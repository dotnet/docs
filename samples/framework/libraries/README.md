# .NET Core Library Samples

These samples are buildable projects whose source is used for code snippets in [the guide for writing cross-platform libraries](https://docs.microsoft.com/dotnet/articles/core/tutorials/libraries).  They can be built and run using the .NET Core toolchain, and are intended to simply demonstrate how to target and build NuGet packages for different targets.  They aren't examples of how you'd build a real, feature-complete library.

To build/use any of these (using `new-library` as an example):

1. Open your favorite Command Line Interface (for example, Cmd.exe or Terminal).

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

The project under `/new-library` targets **only** .NET Core. For that reason,
this project is stored under the core project directory, so our build server builds it on
all platforms. Look under https://github.com/dotnet/docs/tree/master/samples/core/libraries/new-library/

It demonstrates two other things: how to use multiple projects, and how to test.

The sample showcases two libraries.  The first, `DependencyLibrary`, contains functionality that the second, `Library` uses.  The `LibraryTests` test project takes a dependency on `Library` to test that project.

## frameworks-library

**IMPORTANT:** This project requires Windows and the .NET Framework installed on your machine.

The project under `/frameworks-library` demonstrates how to use the CLI tools to build a library that targets the .NET Framework.  It does so with a simple project targeting the .NET Framework 4.0.  You could extend this to target additional versions of the .NET Framework by adding new build targets in the `library.csproj` project file.  Check out the [section on cross-compiling](https://docs.microsoft.com/dotnet/articles/core/tutorials/libraries#how-to-multitarget) in the CLI libraries article for more information.

## net45-compat-library

**IMPORTANT:** This project requires Windows and the .NET Framework installed on your machine.

The project under `/net45-compat-library` targets any of the following:

* .NET Framework 4.5.1 and above
* Windows Phone 8.1
* Universal Windows Platform
* Xamarin
* Mono

It uses the `netstandard1.2` Target Framework Moniker introduced with the [.NET Standard Library](https://docs.microsoft.com/en-us/dotnet/articles/standard/library).

## net40-library

**IMPORTANT:** This project requires Windows and the the .NET Framework installed on your machine.

The project under `/net40-library` targets the .NET Framework 4.0 and above.  It also demonstrates how to use [#if](https://docs.microsoft.com/en-us/dotnet/articles/csharp/language-reference/preprocessor-directives/preprocessor-if) directives to multi-target for a .NET 4.0 target.

## pcl-library

**IMPORTANT:** This project requires Windows and the .NET Framework installed on your machine.

The project under `/pcl-library` shows how to target a supported PCL Profile (for example, 344).  It shows how to structure the `Library.csproj` file to allow for targeting a PCL.  It also demonstrates how to use [#if](https://docs.microsoft.com/en-us/dotnet/articles/csharp/language-reference/preprocessor-directives/preprocessor-if) directives and how to define a preprocessor constant, `PORTABLE259` in the `Library.csproj` file.
