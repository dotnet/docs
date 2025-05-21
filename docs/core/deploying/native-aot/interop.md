---
title: Native code interop with Native AOT
description: Learn about native code interop with Native AOT.
author: MichalStrehovsky
ms.author: michals
ms.date: 05/17/2023
ms.topic: article
---
# Native code interop with Native AOT

Native code interop is a technology that allows you to access unmanaged libraries from managed code, or expose managed libraries to unmanaged code (the opposite direction).

While native code interop works similarly in Native AOT and non-AOT deployments, there are some specifics that differ when publishing as Native AOT.

## Direct P/Invoke calls

The P/Invoke calls in AOT-compiled binaries are bound lazily at run time by default, for better compatibility. You can configure the AOT compiler to generate direct calls for selected P/Invoke methods that are bound during startup by the dynamic loader that comes with the operating system. The unmanaged libraries and entry points referenced via direct calls must always be available at run time, otherwise the native binary fails to start.

The benefits of direct P/Invoke calls are:

- They have *better steady state performance*.
- They make it possible to *link the unmanaged dependencies statically*.

You can configure the direct P/Invoke generation using `<DirectPInvoke>` items in the project file. The item name can be either *\<modulename>*, which enables direct calls for all entry points in the module, or *\<modulename!entrypointname>*, which enables a direct call for the specific module and entry point only.

To specify a list of entry points in an external file, use `<DirectPInvokeList>` items in the project file. A list is useful when the number of direct P/Invoke calls is large and it's unpractical to specify them using individual `<DirectPInvoke>` items. The file can contain empty lines and comments starting with `#`.

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

On Windows, Native AOT uses a prepopulated list of direct P/Invoke methods that are available on all supported versions of Windows.

> [!WARNING]
> Because direct P/Invoke methods are resolved by the operating system dynamic loader and not by the Native AOT runtime library, direct P/Invoke methods will not respect the <xref:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute>. The library search order will follow the dynamic loader rules as defined by the operating system. Some operating systems and loaders offer ways to control dynamic loading through linker flags (such as `/DEPENDENTLOADFLAG` on Windows or `-rpath` on Linux). For more information on how to specify linker flags, see the [Linking](#linking) section.

### Linking

To statically link against an unmanaged library, you need to specify `<NativeLibrary Include="filename" />` pointing to a `.lib` file on Windows and a `.a` file on Unix-like systems.

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

To specify additional flags to the native linker, use the `<LinkerArg>` item.

Examples:

```xml
<ItemGroup>
  <!-- link.exe is used as the linker on Windows -->
  <LinkerArg Include="/DEPENDENTLOADFLAG:0x800" Condition="$(RuntimeIdentifier.StartsWith('win'))" />

  <!-- Native AOT invokes clang/gcc as the linker, so arguments need to be prefixed with "-Wl," -->
  <LinkerArg Include="-Wl,-rpath,'/bin/'" Condition="$(RuntimeIdentifier.StartsWith('linux'))" />
</ItemGroup>
```

## Native exports

The Native AOT compiler exports methods annotated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> with a nonempty `EntryPoint` property as
public C entry points. This makes it possible to either dynamically or statically link the AOT compiled modules into external
programs. Only methods marked `UnmanagedCallersOnly` in the published assembly are considered. Methods in project references or NuGet packages won't be exported.
For more information, see [NativeLibrary sample](https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary/README.md).
