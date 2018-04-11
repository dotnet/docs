---
title: Build .NET Core from source
description: Learn how to build .NET Core and the .NET Core CLI from the source code.
keywords: .NET, .NET Core, source, build
author: bleroy
ms.author: mairaw
ms.date: 06/28/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8b49079c-6ede-429a-92d7-ecd2fda1ab0e
ms.workload: 
  - dotnetcore
---

# Build .NET Core from source

The ability to build .NET Core from its source code is important in multiple ways: it makes it easier to port .NET Core to new platforms, it enables contributions and fixes to the product, and it enables the creation of custom versions of .NET.
This article gives guidance to developers who want to build and distribute their own versions of .NET Core.

## Build the CLR from source

The source code for the .NET CoreCLR can be found in the [dotnet/coreclr](https://github.com/dotnet/coreclr/) repository on GitHub.

The build currently depends on the following prerequisites:
* [Git](https://git-scm.com/)
* [CMake](https://cmake.org/)
* [Python](https://www.python.org/)
* a C++ compiler.

After you've installed these prerequisites are installed, you can build the CLR by invoking the build script (`build.cmd` on Windows, or `build.sh` on Linux and macOS) at the base of the [dotnet/coreclr](https://github.com/dotnet/coreclr/) repository.

Installing the components differ depending on the operating system (OS). See the build instructions for your specific OS:

 * [Windows](https://github.com/dotnet/coreclr/blob/master/Documentation/building/windows-instructions.md)
 * [Linux](https://github.com/dotnet/coreclr/blob/master/Documentation/building/linux-instructions.md)
 * [macOS](https://github.com/dotnet/coreclr/blob/master/Documentation/building/osx-instructions.md)
 * [FreeBSD](https://github.com/dotnet/coreclr/blob/master/Documentation/building/freebsd-instructions.md) 
 * [NetBSD](https://github.com/dotnet/coreclr/blob/master/Documentation/building/netbsd-instructions.md)

There is no cross-building across OS (only for ARM, which is built on X64).  
You have to be on the particular platform to build that platform.  

The build has two main `buildTypes`:

 * Debug (default)- Compiles the runtime with minimal optimizations and additional runtime checks (asserts). This reduction in optimization level and the additional checks slow runtime execution but are valuable for debugging. This is the recommended setting for development and testing environments.
 * Release - Compiles the runtime with full optimizations and without the additional runtime checks. This will yield much faster run time performance but it can take a bit longer to build and can be difficult to debug. Pass `release` to the build script to select this build type.

In addition, by default the build not only creates the runtime executables, but it also builds all the tests.
There are quite a few tests, taking a significant amount of time that isn't necessary if you just want to experiment with changes.
You can skip the tests builds by adding the `skiptests` argument to the build script, like in the following example (replace `.\build` with `./build.sh` on Unix machines):

```bat
    .\build skiptests 
```

The previous example showed how to build the `Debug` flavor, which has development time checks (asserts) enabled and optimizations disabled. To build the release (full speed) flavor, do the following:

```bat 
    .\build release skiptests
```

You can find more build options with build by using the -? or -help qualifier.   

### Using Your Build

The build places all of its generated files under the `bin` directory at the base of the repository.
There is a *bin\Log* directory that contains log files generated during the build (Most useful when the build fails).
The actual output is placed in a *bin\Product\[platform].[CPU architecture].[build type]* directory, such as *bin\Product\Windows_NT.x64.Release*.

While the 'raw' output of the build is sometimes useful, normally you're only interested in the NuGet packages, which are placed in the `.nuget\pkg` subdirectory of the previous output directory.

There are two basic techniques for using your new runtime:

 1. **Use dotnet.exe and NuGet to compose an application**.
    See [Using Your Build](https://github.com/dotnet/coreclr/blob/master/Documentation/workflow/UsingYourBuild.md) for instructions on creating a program that uses your new runtime by using the NuGet packages you just created and the 'dotnet' command-line interface (CLI). This technique is the expected way non-runtime developers are likely to consume your new runtime.    

 2. **Use corerun.exe to run an application using unpackaged DLLs**.
    This repository also defines a simple host called corerun.exe that does NOT take any dependency on NuGet.
    You need to tell the host where to get the required DLLs you actually use, and you have to manually gather them together.
    This technique is used by all the tests in the [dotnet/coreclr](https://github.com/dotnet/coreclr) repo, and is useful for quick local 'edit-compile-debug' loop such as preliminary unit testing.
    See [Executing .NET Core Apps with CoreRun.exe](https://github.com/dotnet/coreclr/blob/master/Documentation/workflow/UsingCoreRun.md) for details on using this technique.

## Build the CLI from source

The source code for the .NET Core CLI can be found in the [dotnet/cli](https://github.com/dotnet/cli/) repository on GitHub.

In order to build the .NET Core CLI, you need the following installed on your machine.

* Windows & Linux:
    - git on the PATH
* macOS:
    - git on the PATH
    - Xcode
    - OpenSSL

In order to build, run `build.cmd` on Windows, or `build.sh` on Linux and macOS from the root. If you don't want to execute tests, run `build.cmd /t:Compile` or `./build.sh /t:Compile`. To build the CLI in macOS Sierra, you need to set the DOTNET_RUNTIME_ID environment variable by running `export DOTNET_RUNTIME_ID=osx.10.11-x64`.

### Using your build

Use the `dotnet` executable from *artifacts/{os}-{arch}/stage2* to try out the newly built CLI. If you want to use the build output when invoking `dotnet` from the current console, you can also add *artifacts/{os}-{arch}/stage2* to the PATH.

## See also

* [.NET Core Common Language Runtime (CoreCLR)](https://github.com/dotnet/coreclr/blob/master/README.md)
* [.NET Core CLI Developer Guide](https://github.com/dotnet/cli/blob/master/Documentation/project-docs/developer-guide.md)
* [.NET Core distribution packaging](./distribution-packaging.md)
