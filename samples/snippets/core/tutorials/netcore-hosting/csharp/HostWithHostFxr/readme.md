# .NET Core Hosting Sample

This project demonstrates a way for a native process to host .NET Core using the `nethost` and `hostfxr` libraries. Documentation on the `nethost` and `hostfxr` APIs can be found [here](https://github.com/dotnet/runtime/blob/main/docs/design/features/native-hosting.md).

This sample is part of the [.NET Core hosting tutorial](https://docs.microsoft.com/dotnet/core/tutorials/netcore-hosting). Please see that topic for a more detailed explanation of the sample and the steps necessary to host .NET Core.

The host is small and bypasses a lot of complexity (thorough error checking, etc.) that a real host would have. Hopefully by remaining simple, though, it will be useful for demonstrating the core concepts of hosting managed .NET Core code in a native process.

## Key Features

Demonstrates how to locate and initialize .NET Core runtime from a non-.NET Core process and subsequently load and call into a .NET Core assembly.

The `nethost` header and library are part of the `Microsoft.NETCore.DotNetAppHost` package and are also installed as a runtime pack by the .NET Core SDK. The library should be deployed alongside the host. This sample uses the files installed with the .NET Core SDK.  
*Note: The `Microsoft.NETCore.DotNetAppHost` package is a [metapackage](https://docs.microsoft.com/dotnet/core/packages#metapackages) that doesn't actually contain the files. It only references RID-specific packages that contain the files. For example, the package with the actual files for `linux-x64` is `runtime.linux-x64.Microsoft.NETCore.DotNetAppHost`.*

The `coreclr_delegates.h` and `hostfxr.h` files are copied from the [dotnet/runtime](https://github.com/dotnet/runtime) repo - [coreclr_delegates.h](https://github.com/dotnet/runtime/blob/main/src/installer/corehost/cli/coreclr_delegates.h) and [hostfxr.h](https://github.com/dotnet/runtime/blob/main/src/installer/corehost/cli/hostfxr.h).

Additional comments are contained in source and project files.

## Prerequisites

* [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download) or a later version

* C++ compiler
  * Windows: `cl.exe`
  * Linux/OSX: `g++`

## Build and Run

1. In order to build and run, all prerequisites must be installed. The following are also required:

    * On Linux/macOS, the C++ compiler (`g++`) must be on the path.
    * The C++ compiler (`cl.exe` or `g++`) and `dotnet` must be the same bitness (32-bit versus 64-bit).
      * On Windows, the sample is set up to use the bitness of `dotnet` to find the corresponding `cl.exe`

1. Navigate to the root directory.

1. Run the samples. Do one of the following:

    * Use `dotnet run` (which will build and run at the same time).
    * Use `dotnet build` to build the executable. The executable will be in `bin` under a subdirectory for the configuration (`Debug` is the default).
        * Windows: `bin\Debug\nativehost.exe`
        * Non-Windows: `bin/Debug/nativehost`

The expected output will come from the `DotNetLib` class library and include the arguments passed to the managed library from the host:

```console
Hello, world! from Lib [count: 1]
-- message: from host!
-- number: 0
Hello, world! from Lib [count: 2]
-- message: from host!
-- number: 1
Hello, world! from Lib [count: 3]
-- message: from host!
-- number: 2
Hello, world! from CustomEntryPoint in Lib
-- message: from host!
-- number: -1
```

Note: The way the sample is built is relatively complicated. The goal is that it's possible to build and run the sample with simple `dotnet run` with minimal requirements on pre-installed tools. Typically, real-world projects that have both managed and native components will use different build systems for each; for example, msbuild/dotnet for managed and CMake for native.

## Visual Studio support

The `src\HostWithHostFxr.sln` solution file can be used to open the sample in Visual Studio 2019. To run the sample, set the startup project to `build/NativeHost`.
Note that with mixed mode debugging (that is, a debugger that can see both native and managed code at the same time), there's a known limitation where no breakpoints will be hit before the runtime starts. So it is not possible to debug the parts of the sample before (and including) the call to `load_assembly_and_get_function_pointer` like that. To debug those, start the process from a native-only debugger.
