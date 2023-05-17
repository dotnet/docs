---
title: Native code interop
description: Learn about native code interop with native AOT.
author: MichalStrehovsky
ms.author: michals
ms.date: 05/17/2023
---
# Native code interop

Native code interop is a technology that allows you to access unmanaged libraries from managed code, or expose managed libraries to unmanaged code (the opposite direction).

While native code interop works similarly to non-AOT deployments, there are some specifics that differ when publishing as native AOT.

## Direct P/Invoke calls

The P/Invoke calls in AOT compiled binaries are bound lazily at runtime by default for better compatibility. The AOT compiler can be configured to generate direct calls for selected P/Invoke methods that are bound during startup by the dynamic loader that comes with the operating system. The unmanaged libraries and entry points referenced via direct calls always have to be available at runtime, otherwise the native binary fails to start.

The benefits of direct PInvoke calls are:

- Direct PInvoke calls have *better steady state performance*
- Direct PInvoke calls make it possible to *link the unmanaged dependencies statically*

The direct PInvoke generation can be configured using `<DirectPInvoke>` items in the project file. The item name can be either `modulename`, which enables direct calls for all module entry points, or `modulename!entrypointname`, which enables a direct call for the specific module and entry point only.

`<DirectPInvokeList>filename</DirectPInvokeList>` items in the project file allow specifying a list of entry points in an external file. This is useful when the specification of direct PInvoke calls is long and it is not practical to specify them using individual `<DirectPInvoke>` items. The file can contain empty lines and comments starting with `#`.

Examples:

```xml
<ItemGroup>
  <!-- Generate direct PInvoke calls for everything in __Internal -->
  <!-- This option replicates Mono AOT behavior that generates direct PInvoke calls for __Internal -->
  <DirectPInvoke Include="__Internal" />
  <!-- Generate direct PInvoke calls for everything in libc (also matches libc.so on Linux or libc.dylib on macOS) --> 
  <DirectPInvoke Include="libc" />
  <!-- Generate direct PInvoke calls for Sleep in kernel32 (also matches kernel32.dll on Windows) -->
  <DirectPInvoke Include="kernel32!Sleep" />
  <!-- Generate direct PInvoke for all APIs listed in DirectXAPIs.txt -->
  <DirectPInvokeList Include="DirectXAPIs.txt" />
</ItemGroup>
```

On Windows, native AOT uses a pre-populated list of direct P/Invoke methods that are available on all supported versions of Windows.

> [!WARNING]
> Because direct P/Invoke methods are resolved by the operating system dynamic loader and not by the native AOT runtime library, direct P/Invoke methods will not respect the <xref:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute>. The library search order will follow the dynamic loader rules as defined by the operating system. Some operating systems and loaders offer ways to control dynamic loading through linker flags (such as `/DEPENDENTLOADFLAG` on Windows or `-rpath` on Linux). See details below on how to specify linker flags.

### Linking

To statically link against an unmanaged library, you'll need to specify `<NativeLibrary Include="filename" />` pointing to a `.lib` file on Windows and a `.a` file on Unix.

Examples:

```xml
<ItemGroup>
  <!-- Generate direct PInvokes for Dependency -->
  <DirectPInvoke Include="Dependency" />
  <!-- Specify library to link against -->
  <NativeLibrary Include="Dependency.lib" Condition="$(RuntimeIdentifier.StartsWith('win'))" />
  <NativeLibrary Include="Dependency.a" Condition="!$(RuntimeIdentifier.StartsWith('win'))" />
</ItemGroup>
```

To specify additional flags to the native linker, use the `<LinkerArg Include="-argument" />` item.

Examples:

```xml
<ItemGroup>
  <!-- link.exe is used as the linker on Windows -->
  <LinkerArg Include="/DEPENDENTLOADFLAG:0x800" Condition="$(RuntimeIdentifier.StartsWith('win'))" />

  <!-- Native AOT invokes clang/gcc as the linker, so arguments need to be prefixed with "-Wl," -->
  <LinkerArg Include="-Wl,-rpath,'/bin/'" Condition="$(RuntimeIdentifier.StartsWith('linux'))" />
</ItemGroup>
```

## Native Exports

The native AOT compiler will export methods annotated with `UnmanagedCallersOnlyAttribute` and an explicitly specified name as
public C entry points. This makes it possible to either dynamically or statically link the AOT compiled modules into external
programs. More details can be found in [NativeLibrary Sample](https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary/README.md).
