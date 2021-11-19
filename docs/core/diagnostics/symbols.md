---
title: Symbols in .NET
description: An introduction to symbols and portable PDBs in .NET
ms.date: 02/08/2021
---

# Symbols

Symbols are useful for debugging and other diagnostic tools. The contents of symbol files vary between languages, compilers, and platforms. At a very high level symbols are a mapping between the source code and the binary produced by the compiler. These mappings are used by tools like [Visual Studio](/visualstudio/debugger/what-is-debugging) and [Visual Studio Code](https://code.visualstudio.com/Docs/editor/debugging) to resolve source line number information or local variable names.

The [Windows documentation on symbols](/windows/win32/dxtecharts/debugging-with-symbols) contain more detailed information on symbols for Windows, although many of the concepts apply to other platforms as well.

## Learn about .NET's Portable PDB format

.NET Core introduces a new symbol file (PDB) format - the portable PDB. Unlike traditional PDBs which are Windows-only, portable PDBs can be created and read on all platforms.

### What is a PDB?

A PDB file is an auxiliary file produced by a compiler to provide other tools, especially debuggers, information about what is in the main executable file and how it was produced. For example, a debugger reads a PDB to map foo.cs line 12 to the right executable location so that it can set a breakpoint. The Windows PDB format has been around a long time, and it evolved from other native debugging symbol formats which were even older. It started out its life as a format for native (C/C++) programs. For the first release of the .NET Framework, the Windows PDB format was extended to support .NET.

## Use the correct PDB format for your scenario

Neither portable PDBs nor Windows PDBs are supported everywhere, so you need to consider where your project will want to be used and debugged to decide which format to use. If you have a project that you want to be able to use and debug in both formats, you can use different build configurations and build the project twice to support both types of consumer.

### Support for Portable PDBs

Portable PDBs can be read on any operating systems and is the recommended symbol format for managed code, but there are a number of legacy tools and applications where they aren't supported:

* Applications targeting .NET Framework 4.7.1 or earlier: printing stack traces with mappings back to line numbers (such as in an ASP.NET error page). The name of methods is unaffected, only the source file names and line numbers are unsupported.

* Using .NET decompilers such as ildasm or .NET reflector and expecting to see source line mappings or local parameter names.

* The latest versions of [DIA](/visualstudio/debugger/debug-interface-access/debug-interface-access-sdk) and tools using it for reading symbols, such as WinDBG support Portable PDBs, but older version do not.

* There may be older versions of profilers that do not support portable PDBs.

To use portable PDBs on tools that do not support them, you can try using [Pdb2Pdb](https://github.com/dotnet/symreader-converter#pdb2pdb) which converts between Portable PDBs and Windows PDBs.

### Support for Windows PDBs

Windows PDBs can only be written or read on Windows. Using Windows PDBs for managed code is obsolete and is only needed for legacy tools. It is recommended that you use portable PDBs instead of Windows PDBs as some newer compiler features that are implemented for only portable PDBs.

## See also

* [dotnet-symbol](./dotnet-symbol.md) can be used to download symbol files for framework binaries
* [Windows documentation on symbols](/windows/win32/dxtecharts/debugging-with-symbols)
