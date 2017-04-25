---
title: Building .NET Core from source
description: Building .NET Core from source
keywords: .NET, .NET Core, source, build
author: beleroy
ms.author: mairaw
ms.date: 03/29/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8b49079c-6ede-429a-92d7-ecd2fda1ab0e
---

# Building .NET Core from source

The ability for anyone to build .NET Core from its source code is important in multiple ways: it makes it easier to port .NET Core to new platforms, it enables contributions and fixes to the product, and it enables the creation of custom versions of .NET.
This section of the documentation gives guidance to developers who want to build and distribute their own versions of .NET Core.

## How to build from source

### Building the CLR

The build currently depends on Git, CMake, Python and a C++ compiler.
Once these prerequisites are installed, the CLR is built by invoking the 'build' script (`build.cmd` or `build.sh`) at the base of the 
repository.

The details of installing the components differ depending on the operating system.  See the following
pages based on your OS.  There is no cross-building across OS (only for ARM, which is built on X64).  
You have to be on the particular platform to build that platform.  

 * [Windows Build Instructions](https://github.com/dotnet/coreclr/blob/master/Documentation/building/windows-instructions.md)
 * [Linux Build Instructions](https://github.com/dotnet/coreclr/blob/master/Documentation/building/linux-instructions.md)
 * [macOS Build Instructions](https://github.com/dotnet/coreclr/blob/master/Documentation/building/osx-instructions.md)
 * [FreeBSD Build Instructions](https://github.com/dotnet/coreclr/blob/master/Documentation/building/freebsd-instructions.md) 
 * [NetBSD Build Instructions](https://github.com/dotnet/coreclr/blob/master/Documentation/building/netbsd-instructions.md)

The build has two main 'buildTypes':

 * Debug (default)- This compiles the runtime with additional runtime checks (asserts).  These checks slow 
   runtime execution but are really valuable for debugging, and is recommended for normal development and testing.  
 * Release - This compiles without any development time runtime checks.  This is what end users will use but 
   can be difficult to debug.   Passing 'release' to the build script select this.  

In addition, by default the build will not only create the runtime executables, but it will also 
build all the tests.   There are quite a few tests so this does take a significant amount of time
that is not necessary if you want to experiment with changes.
You can submit the building of the tests with the 'skiptests' argument to the build script.

In order to get a build as quickly as possible type the following (using `\` as the directory separator, use `/` on Unix machines)
```bat
    .\build skiptests 
```
which will build the Debug flavor which has development time checks (asserts), or 
```bat 
    .\build release skiptests
```
to build the release (full speed) flavor.  You can find more build options with build by using the -? or -help qualifier.   

#### Using Your Build

The build places all of its generated files under the `bin` directory at the base of the repository.   There 
is a `bin\Log` directory that contains log files generated during the build (Most useful when the build fails).
The actual output is placed in a `bin\Product\[platform].[CPU architecture].[build type]` directory, such as `bin\Product\Windows_NT.x64.Release`.

While the 'raw' output of the build is sometimes useful, normally you are only interested in the Nuget packages, which are placed in the `.nuget\pkg` subdirectory of the above output directory.

There are two basic techniques for using your new runtime.

 1. **Use dotnet.exe and Nuget to compose an application**.
    See [Using Your Build](https://github.com/dotnet/coreclr/blob/master/Documentation/workflow/UsingYourBuild.md) for instructions on creating a program that uses your new runtime by using the NuGet packages you just created and the'dotnet' command line interface.  This is the expected way non-runtime developers are likely to consume your new runtime.    

 2. **Use corerun.exe to run an application using unpackaged Dlls**.
    This repository also defines a simple host called corerun.exe that does NOT take any dependency on NuGet.
    This host has to be told where to get the necessary DLLs you actually use, and you have to manually gather them together.
    This is the technique that all the tests in the repo use, and is useful for quick local 'edit-compile-debug' loop (e.g. preliminary unit testing).
    See [Executing .NET Core Apps with CoreRun.exe](https://github.com/dotnet/coreclr/blob/master/Documentation/workflow/UsingCoreRun.md) for details on using this technique.

### Building the CLI

## Prerequisites

In order to build .NET Command Line Interface, you need the following installed on you machine.

* Windows & Linux:
    - git on the PATH
* macOS:
    - git on the PATH
    - Xcode
    - OpenSSL

In order to build, run `build.cmd` or `build.sh` from the root depending on your OS. If you don't want to execute tests, run `build.cmd /t:Compile` or `./build.sh /t:Compile`. To build the CLI in macOS Sierra, you need to set the DOTNET_RUNTIME_ID environment variable by running `export DOTNET_RUNTIME_ID=osx.10.11-x64`.

#### Using your build

Use `artifacts/{RID}/stage2/dotnet` to try out the `dotnet` command. You can also add `artifacts/{os}-{arch}/stage2` to the PATH if you want to use the build output when invoking `dotnet` from the current console.

## See also

* [.NET Core Common Language Runtime (CoreCLR)](https://github.com/dotnet/coreclr/blob/master/README.md)
* [.NET Core CLI Developer Guide](https://github.com/dotnet/cli/blob/master/Documentation/project-docs/developer-guide.md)
* [.NET Core distribution packaging](./distribution-packaging.md)