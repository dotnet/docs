# .NET Core Hosting Sample

This project demonstrates a way for a native process to host .NET Core using the `nethost` and `hostfxr` libraries. Documentation on the `nethost` and `hostfxr` APIs can be found [here](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/native-hosting.md).

## Key Features

Demonstrates how to locate and initialize .NET Core 3.0 from a non-.NET Core process and subsequently load and call into  a .NET Core assembly.

The `nethost` header and library are part of the Microsoft.NETCore.DotNetAppHost package and are also installed as a runtime pack by the .NET SDK. The library should be deployed alongside the host. This sample uses the files installed with the .NET SDK.

The `coreclr_delegates.h` and `hostfxr.h` files are copied from the [core-setup](https://github.com/dotnet/core-setup) repo.

Additional comments are contained in source and project files.

## Prerequisites

* .NET Core 3.0 (at least Preview 7) - [https://dot.net](https://github.com/dotnet/core-sdk#installers-and-binaries)

* C++ compiler
  * Windows: `cl.exe`
  * Linux/OSX: `g++`

## Build and Run

1. In order to build and run, all prerequisites must be installed. The following are also required:

    * The C++ compiler (`cl.exe` or `g++`) must be on the path.
      * On Windows, a [Developer Command Prompt for Visual Studio](https://docs.microsoft.com/cpp/build/building-on-the-command-line#developer_command_prompt_shortcuts) should be used.
    * The C++ compiler (`cl.exe` or `g++`) and `dotnet` must be the same bitness (32-bit or 64-bit).
      * On Windows, the default developer command prompt for VS uses the 32-bit compilers, but `dotnet` is typically 64-bit by default. Make sure to select the "x64 Native Tools Command Prompt for VS 2019" (or 2017).

1. Navigate to the root directory.

1. Run the samples. Do one of the following:

    * Use `dotnet run` (which will build and run at the same time).
    * Use `dotnet build` to build the executable. The executable will be in `bin` under a subdirectory for the configuration (`Debug` is the default).
        * Windows: `bin\Debug\nativehost.exe`
        * Non-Windows: `bin/Debug/nativehost`

The expected output will come from the `DotNetLib` class library and include the arguments passed to the managed library from the host:

```output
Hello, world! from Lib [count: 1]
-- message: from host!
-- number: 0
Hello, world! from Lib [count: 2]
-- message: from host!
-- number: 1
Hello, world! from Lib [count: 3]
-- message: from host!
-- number: 2
```

Note: The way the sample is built is relatively complicated. The goal is that it's possible to build and run the sample with simple `dotnet run` with minimal requirements on pre-installed tools. Typically, real-world projects that have both managed and native components will use different build systems for each; for example, msbuild/dotnet for managed and CMake for native.

## Visual Studio support

The `src\HostWithHostFxr.sln` solution file can be used to open the sample in Visual Studio 2019. In order to be able to build from Visual Studio, though, it has to be started from the correct developer environment. From the developer environment console, start it with `devenv src\HostWithHostFxr.sln`. With that, the solution can be built. To run it, set the startup project to `build/NativeHost`.
Note that with mixed mode debugging (that is, a debugger that can see both native and managed code at the same time), there's a known limitation where no breakpoints will be hit before the runtime starts. So it is not possible to debug the parts of the sample before (and including) the call to `load_assembly_and_get_function_pointer` like that. To debug those, start the process from a native-only debugger.
