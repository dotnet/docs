---
title: "Making an image easier to debug in .NET"
description: "Learn how to configure an executable image for easier debugging using IDE switches and command-line options."
ms.date: "08/30/2018"
helpviewer_keywords:
  - "images [.NET Framework], debugging"
  - "executable image for debugging"
  - "debugging [.NET Framework], executable images for"
ms.assetid: 7d90ea7a-150f-4f97-98a7-f9c26541b9a3
author: "mairaw"
ms.author: "mairaw"
---

# Making an image easier to debug in .NET

When compiling unmanaged code, you can configure an executable image for debugging by setting IDE switches or command-line options. For example, you can use the /**Zi** command-line option in Visual C++ to ask it to emit debug symbol files (file extension .pdb). Similarly, the /**Od** command-line option tells the compiler to disable optimization. The resulting code runs more slowly, but it's easier to debug, should this be necessary.

When compiling .NET Framework managed code, compilers such as Visual C++, Visual Basic, and C# compile their source program into Microsoft intermediate language (MSIL). MSIL is then JIT-compiled, just before execution, into native machine code. As with unmanaged code, you can configure an executable image for debugging by setting IDE switches or command-line options. You can also configure the JIT compilation for debugging in much the same way.

This JIT configuration has two aspects:

- You can request the JIT compiler to generate tracking information. This makes it possible for the debugger to match up a chain of MSIL with its machine code counterpart, and to track where local variables and function arguments are stored. Starting with the .NET Framework version 2.0, the JIT compiler always generates tracking information, so there is no need to request it.

- You can request the JIT compiler to not optimize the resulting machine code.

Normally, the compiler that generates the MSIL sets these JIT compiler options appropriately, based upon the IDE switches or command-line options you specify, for example, /**Od**.

In some cases, you might want to change the behavior of the JIT compiler so that the machine code it generates is easier to debug. For example, you might want to generate JIT tracking information for a retail build or control optimization. You can do so with an initialization (.ini) file.

For example, if the assembly you want to debug is called *MyApp.exe*, then you can create a text file named *MyApp.ini*, in the same folder as *MyApp.exe*, which contains these three lines:

```ini
[.NET Framework Debugging Control]
GenerateTrackingInfo=1
AllowOptimize=0
```

You can set the value of each option to 0 or 1, and any absent option defaults to 0. Setting `GenerateTrackingInfo` to 1 and `AllowOptimize` to 0 provides the easiest debugging.

Starting with the .NET Framework version 2.0, the JIT compiler always generates tracking information regardless of the value for `GenerateTrackingInfo`; however, the `AllowOptimize` value still has an effect. When using the [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md) to precompile the native image without optimization, the .ini file must be present in the target folder with `AllowOptimize=0` when Ngen.exe executes. If you have precompiled an assembly without optimization, you must remove the precompiled code using NGen.exe **/uninstall** option before rerunning Ngen.exe to precompile the code as optimized. If the .ini file isn't present in the folder, by default Ngen.exe precompiles the code as optimized.

The <xref:System.Diagnostics.DebuggableAttribute?displayProperty=nameWithType> controls the settings for an assembly. **DebuggableAttribute** includes two fields that control whether the JIT compiler should optimize and/or generate tracking information. Starting with the .NET Framework version 2.0, the JIT compiler always generates tracking information.

For a retail build, compilers don't set any **DebuggableAttribute**. By default, the JIT compiler generates the highest performance, hardest to debug machine code. Enabling JIT tracking lowers performance a little, and disabling optimization lowers performance a lot.

The **DebuggableAttribute** applies to a whole assembly at a time, not to individual modules within the assembly. Development tools must therefore attach custom attributes to the assembly metadata token, if an assembly has already been created, or to the class called **System.Runtime.CompilerServices.AssemblyAttributesGoHere**. The ALink tool then promotes these **DebuggableAttribute** attributes from each module to the assembly they become a part of. If there's a conflict, the ALink operation fails.

> [!NOTE]
> In version 1.0 of the .NET Framework, the Microsoft Visual C++ compiler adds the **DebuggableAttribute** when the **/clr** and **/Zi** compiler options are specified. In version 1.1 of the .NET Framework, you must either add the **DebuggableAttribute** manually in your code or use the **/ASSEMBLYDEBUG** linker option.

## See also

- [Debugging, Tracing, and Profiling](../../../docs/framework/debug-trace-profile/index.md)
- [Enabling JIT-Attach Debugging](../../../docs/framework/debug-trace-profile/enabling-jit-attach-debugging.md)
- [Enabling Profiling](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/s5ec0es1(v=vs.100))
