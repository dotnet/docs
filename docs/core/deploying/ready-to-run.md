---
title: Ready to Run
description: Learn what ReadyToRun is and why you should consider using it as part of the deployment.
author: davidwr
ms.author: davidwr
ms.date: 09/21/2020
---
# ReadyToRun Compilation
Startup time and application latency can be improved by compiling your application assemblies as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation.

R2R binaries improve startup performance by reducing the amount of work the just-in-time (JIT) compiler needs to do as your application loads. The binaries contain similar native code compared to what the JIT would produce. However, R2R binaries are larger because they contain both intermediate language (IL) code, which is still needed for some scenarios, and the native version of the same code. R2R is only available when you publish an app that targets specific runtime environments (RID) such as Linux x64 or Windows x64.

To compile your project as ReadyToRun, do the following:

01. Add the `<PublishReadyToRun>` setting to your project:

    ```xml
    <PropertyGroup>
      <PublishReadyToRun>true</PublishReadyToRun>
    </PropertyGroup>
    ```

02. Publish an application. For example, this command creates an app for the 64-bit version of Windows:

    ```dotnetcli
    dotnet publish -c Release -r win-x64

    ```

## Impact of using the ReadyToRun feature

### General impact
Ahead of time compilation has somewhat complex and unpredictable performance impacts on application performance. In general the size of an assembly will grow to between 2 to 3 times larger. This increase in the physical size of the file may reduce the performance of loading the assembly from disk, and increase working set of the process. However, in return the number of methods compiled is typically reduced substantially. The result is that most applications that consist of a substantial amount of code receive large performance benefits from enabling ReadyToRun. Applications which have small amounts of code will likely not experience a significant improvement from enabling ReadyToRun, as the .NET framework assemblies have already been precompiled with ReadyToRun.

Note that the startup improvement discussed here applies not only to application startup, but also to the first use of any code in the application. For instance, ReadyToRun can be used to reduce the response latency of the first use  of a WebAPI in an ASP.NET application.

### Interaction with tiered compilation
Ahead of time code generation quality is generally slightly worse than the quality of code produced by the JIT. To address this issue, tiered compilation will replace commonly used ReadyToRun methods with JIT generated methods.

## How is the set of precompiled assemblies chosen?
The SDK will precompile the assemblies that are distributed with the application. For self-contained applications this will include recompiling the framework. C++/CLI binaries are not eligible for ReadyToRun compilation.

## How is the set of methods to precompile chosen?
The compiler will attempt to pre-compile as many methods as it can. However various reasons it is not expected that using the ReadyToRun feature will result in preventing the JIT from executing.

Such reasons may include, but are not limited to:

- Use of generic types defined in separate assemblies
- Interop with native code
- Use of hardware intrinsics which the compiler cannot prove are safe to use at publish time
- Certain unusual IL patterns
- Dynamic method creation via reflection, or LINQ

#### Cross platform/architecture restrictions

The ReadyToRun compiler does not support completely general purpose cross-compilation. Supported compilation targets are described below.

| SDK platform | Supported target platforms |
| ------------ | --------------------------- |
| Windows X64  | Windows X86, Windows X64, Windows ARM32, Windows ARM64 |
| Windows X86  | Windows X86, Windows ARM32 |
| Linux X64    | Linux X86, Linux X64, Linux ARM32, Linux ARM64 |
| Linux ARM32  | Linux ARM32 |
| Linux ARM64  | Linux ARM64 |
| macOS X64    | macOS X64 |