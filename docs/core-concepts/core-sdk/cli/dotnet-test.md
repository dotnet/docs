dotnet-test
================

## NAME

`dotnet-test` - runs unit tests using the configured test runner

## SYNOPSIS

dotnet test [--configuration]  
    [--output] [--build-base-path] [--framework] [--runtime]
    [--no-build]
    [--parentProcessId] [--port]  
    [< project >]  

## DESCRIPTION

`dotnet test` is used to execute unit tests in a given project. Unit tests are class library 
projects that have dependencies on the unit test framework (for example, NUnit or xUnit) and the 
dotnet test runner for that unit testing framework. These are packaged as NuGet packages and are 
restored as ordinary dependencies for the project.

Test projects also need to specify a test runner property in project.json using the "testRunner" node. 
This value should contain the name of the unit test framework.

Below is a sample project.json that shows the needed properties:

```json
{
    "version": "1.0.0-*",

    "dependencies": {
        "Microsoft.NETCore.App": {
            "version": "1.0.0-rc2-3002702",
            "type": "platform"
        },
        "xunit": "2.1.0",
        "dotnet-test-xunit": "1.0.0-rc2-build10015"
    },
    "testRunner": "xunit",

    "frameworks": {
        "netcoreapp1.0": {
                "imports": [
                    "dnxcore50",
                    "portable-net45+win8"
                ]
        }
    }
}
```
Dotnet test supports two running modes:

1. Console: In console mode, dotnet test simply executes fully any command gets passed to it and outputs the results. Anytime you
invoke dotnet test without passing --port, it will run in console mode, which in turn will cause the runner to run in console mode.
2. Design time: when used in the context of other tools, such as editors or Integrated Development Environments (IDEs). You 
can find out more about this mode in the [dotnet-test protocol](dotnet-test-protocol.md) document. 

## OPTIONS

`[project]` 
    
Specifies a path to the test project. If omitted, will default to current directory. 

`-c`, `--configuration` [CONFIGURATION]

Configuration under which to build. Defaults to Release. 

`-o`, `--output` [DIR]

Directory in which to find binaries to run.

`-b`, `--build-base-path` [DIR]

Directory in which to place temporary outputs.

`-f`, `--framework` [FRAMEWORK]

Looks for test binaries for a specific framework.

`-r`, `--runtime` [RUNTIME_IDENTIFIER]

Look for test binaries for a for the specified runtime.

`--no-build` 

Do not build the test project prior to running it. 

--parentProcessId

Used by IDEs to specify their process ID. Test will exit if the parent process does.

`--port`

Used by IDEs to specify a port number to listen for a connection.

## EXAMPLES

`dotnet test`

Run the tests in the project in the current directory. 

`dotnet test /projects/test1/project.json`

Run the tests in the test1 project. 

