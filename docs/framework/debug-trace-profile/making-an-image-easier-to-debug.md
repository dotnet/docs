---
title: "Making an Image Easier to Debug"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "images [.NET Framework], debugging"
  - "executable image for debugging"
  - "debugging [.NET Framework], executable images for"
ms.assetid: 7d90ea7a-150f-4f97-98a7-f9c26541b9a3
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Making an Image Easier to Debug
When compiling unmanaged code, you can configure an executable image for debugging by setting IDE switches or command-line options. For example, you can use the /**Zi** command-line option in Visual C++ to ask it to emit debug symbol files (file extension .pdb). Similarly, the /**Od** command-line option tells the compiler to disable optimization. The resulting code runs more slowly, but is easier to debug, should this be necessary.  
  
 When compiling .NET Framework managed code, compilers such as Visual C++, Visual Basic, and C# compile their source program into Microsoft Intermediate Language (MSIL). MSIL is subsequently JIT-compiled, just before execution, into native machine code. As with unmanaged code, you can configure an executable image for debugging by setting IDE switches or command-line options. In addition, you can configure the JIT compilation for debugging in much the same way.  
  
 This JIT configuration has two aspects:  
  
-   You can request the JIT-compiler to generate tracking information. This makes it possible for the debugger to match up a chain of MSIL with its machine code counterpart, and to track where local variables and function arguments are stored.  In the .NET Framework version 2.0, the JIT compiler will always generate tracking information, so there is no need to request it.  
  
-   You can request the JIT-compiler to not optimize the resulting machine code.  
  
 Normally, the compiler that generates the MSIL sets these JIT-compiler options appropriately, based upon the IDE switches or command-line options you specify, for example, /**Od**.  
  
 In some cases, you might want to change the behavior of the JIT compiler so that the machine code it generates is easier to debug. For example, you might want to generate JIT tracking information for a retail build or control optimization. You can do so with an initialization (.ini) file.  
  
 For example, if the assembly you want to debug is called MyApp.exe, then you can create a text file named MyApp.ini, in the same folder as MyApp.exe, which contains these three lines:  
  
```  
[.NET Framework Debugging Control]  
GenerateTrackingInfo=1  
AllowOptimize=0  
```  
  
 You can set the value of each option to 0 or 1, and any absent option defaults to 0. Setting `GenerateTrackingInfo` to 1 and `AllowOptimize` to 0 provides the easiest debugging.  
  
> [!NOTE]
>  In the .NET Framework version 2.0, the JIT compiler always generates tracking information regardless of the value for `GenerateTrackingInfo`; however, the `AllowOptimize` value still has an effect. When using the [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md) to precompile the native image without optimization, the .ini file must be present in the target folder with `AllowOptimize=0` when Ngen.exe executes. If you have precompiled an assembly without optimization, you must remove the precompiled code using the NGen.exe **/uninstall** option before rerunning Ngen.exe to precompile the code as optimized. If the .ini file is not present in the folder, by default Ngen.exe precompiles the code as optimized.  
  
> [!NOTE]
>  The <xref:System.Diagnostics.DebuggableAttribute?displayProperty=nameWithType> controls the settings for an assembly. **DebuggableAttribute** includes two fields that record the settings for whether the JIT compiler should optimize, and/or generate tracking information. In the .NET Framework version 2.0, the JIT compiler will always generate tracking information.  
  
> [!NOTE]
>  For a retail build, compilers do not set any **DebuggableAttribute**. The JIT-compiler default behavior is to generate the highest performance, hardest to debug machine code. Enabling JIT tracking lowers performance a little, and disabling optimization lowers performance a lot.  
  
> [!NOTE]
>  The **DebuggableAttribute** applies to a whole assembly at a time, not to individual modules within the assembly. Development tools must therefore attach custom attributes to the assembly metadata token, if an assembly has already been created, or to the class called **System.Runtime.CompilerServices.AssemblyAttributesGoHere**. The ALink tool will then promote these **DebuggableAttribute** attributes from each module to the assembly they become a part of. If there is a conflict, the ALink operation will fail.  
  
> [!NOTE]
>  In version 1.0 of the .NET Framework, the Microsoft Visual C++ compiler adds the **DebuggableAttribute** when the **/clr** and **/Zi** compiler options are specified. In version 1.1 of the .NET Framework, you must either add the **DebugabbleAttribute** manually in your code or use the **/ASSEMBLYDEBUG** linker option.  
  
## See Also  
 [Debugging, Tracing, and Profiling](../../../docs/framework/debug-trace-profile/index.md)  
 [Enabling JIT-Attach Debugging](../../../docs/framework/debug-trace-profile/enabling-jit-attach-debugging.md)  
 [Enabling Profiling](http://msdn.microsoft.com/library/3b669676-f0e0-4ebf-8674-68986dd2020d)
