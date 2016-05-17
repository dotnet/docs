dotnet command
==============

## NAME

dotnet -- general driver for running the command-line commands

## SYNOPSIS

dotnet [--version] [--help] [--verbose] [--info] < command > [< args >]

## DESCRIPTION
dotnet is a generic driver for the CLI toolchain. Invoked on its own, it will give out brief usage instructions. 

Each specific feature is implemented as a command. In order to use the feature, command is specified after dotnet, that is, `dotnet compile`. All of the arguments following the command are its own arguments.  


## OPTIONS
`-v, --verbose`

Enable verbose output.

`--version`

Print out the version of the CLI tooling

`--info`

Print out more detailed information about the CLI tooling, such as the current operating system, commit SHA for the 
version etc. 

`-h, --help`

Print out a short help and a list of current commands. 

## DOTNET COMMANDS

The following commands exist for dotnet:

* [dotnet-new](dotnet-new.md)
   * Initializes a C# or F# console application project.
* [dotnet-restore](dotnet-restore.md)
  * Restores the dependencies for a given application. 
* [dotnet-build](dotnet-build.md)
  * Builds a .NET Core application.
* [dotnet-publish](dotnet-publish.md)
   * Publishes a .NET portable or self-contained application.
* [dotnet-run](dotnet-run.md)
   * Runs the application from source.
* [dotnet-test](dotnet-test.md)
   * Runs tests using a test runner specified in the project.json.
* [dotnet-pack](dotnet-pack.md)
   * Create a NuGet package of your code.

## EXAMPLES

`dotnew new`

    Initializes a sample .NET Core console application that can be compiled and run.

`dotnet restore`

    Restores dependencies for a given application. 

`dotnet compile`

    Compiles the application in a given directory. 

## ENVIRONMENT 

`DOTNET_PACKAGES`

    The primary package cache. If not set, defaults to $HOME/.nuget/packages on Unix or %HOME%\NuGet\Packages on Windows.

`DOTNET_SERVICING`

    Specifies the location of the servicing index to use by the shared host when loading the runtime. 


