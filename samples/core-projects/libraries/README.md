# .NET Core Library Samples

These samples can be built and run using the .NET Core rc1 toolchain.

They are small and intended to demonstrate how to target and build NuGet packages for different targets.

To build/use any of these (using `new-library` as an example):

1. Open your favorite Command Line Interface.

2. Navigate to the top-level directory:

	`$ cd new-library`

3. Restore packages by typing the following:

	`$ dnu restore -s "https://myget.org/F/xunit"`
	
	`$ dnu restore`
	
	Note: The first `dnu restore` is needed right not to allow for unit tests to run.  This will not be required in the future.

4. To build and package the library as a NuGet package, type the following:

	`$ cd src/Library`
	
	`$ dnu build`
	
	`$ dnu pack`
	
	Check out the `/bin/Debug` directory to see the generated artifacts and `.nupkg`.

5. To run unit tests (only applicable to `new-library`):

	`$ cd ../../test/LibraryTests`
	
	`$ dnx test`

And that's it!

## new-library

The project under `/new-library` is a project targeting **only** .NET Core.  Backwards compatibility is not a goal.

It also showcases two other things: how to use multiple projects and how to test.

There are two libraries showcased.  The first, `DependencyLibrary`, contains functionality that the second, `Library` uses.  The `LibraryTests` test project takes a dependency on `Library` to test that project.

## net45-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/net45-library` is for targeting any of the following:

* .NET Framework 4.5 and above
* Windows Phone 8.1
* Whindows Phone Silverlight 8
* Universal Windows Platform
* DNX Core
* Xamarin
* Mono

It uses the new `dotnetXX` Target Framework Moniker introduced with the .NET Platform Standard.

## net40-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/net40-library` is for compatibility with .NET Framework 4.0 and above.  It also demonstrates how to use `#if` compile guards to multi-target for a .NET 4.0 target.

## pcl-library

**IMPORTANT:** This project requires Windows and .NET Framework installed on your machine.

The project under `/pcl-library` is for compatibility with a supported PCL Profile (e.g. 3344).  It shows how to structure the `project.json` file to allow for targeting a PCL.  It also demonstrates how to use `#if` compile guards and how to set those up in conjunction with the `project.json` file.