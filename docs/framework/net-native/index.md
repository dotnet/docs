---
title: "Compiling Apps with .NET Native"
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
  - "native compilation"
  - ".NET and native code"
  - "compilation with .NET Native"
  - ".NET Native"
  - "C# and native compilation"
ms.assetid: 47cd5648-9469-4b1d-804c-43cc04384045
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Compiling Apps with .NET Native
[!INCLUDE[net_native](../../../includes/net-native-md.md)] is a precompilation technology for building and deploying Windows apps that is included with Visual Studio 2015 and later versions. It automatically compiles the release version of apps that are written in managed code (C# or Visual Basic) and that target the .NET Framework and Windows 10 to native code.  
  
 Typically, apps that target the .NET Framework are compiled to intermediate language (IL). At run time, the just-in-time (JIT) compiler translates the IL to native code. In contrast, [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiles Windows apps directly to native code. For developers, this means:  
  
-   Your apps feature the performance of native code. Usually, performance will be superior to code that is first compiled to IL and then compiled to native code by the JIT compiler. 
  
-   You can continue to program in C# or Visual Basic.  
  
-   You can continue to take advantage of the resources provided by the .NET Framework, including its class library, automatic memory management and garbage collection, and exception handling.  
  
 For users of your apps, [!INCLUDE[net_native](../../../includes/net-native-md.md)] offers these advantages:  
  
-   Faster execution times for the majority of apps and scenarios.
  
-   Faster startup times for the majority of apps and scenarios. 
  
-   Low deployment and update costs.  
  
-   Optimized app memory usage.  

> [!IMPORTANT]
> For the vast majority of apps and scenarios, .NET Native offers significantly faster startup times and superior performance when compared to an app compiled to IL or to an NGEN image. However, your results may vary. To ensure that your app has benefited from the performance enhancements of .NET Native, you should compare its performance with that of the non-.NET Native version of your app. For more information, see [Performance Session Overview](https://docs.microsoft.com/visualstudio/profiling/performance-session-overview).
 
But [!INCLUDE[net_native](../../../includes/net-native-md.md)] involves more than a compilation to native code. It transforms the way that .NET Framework apps are built and executed. In particular:  
  
-   During precompilation, required portions of the .NET Framework are statically linked into your app. This allows the app to run with app-local libraries of the .NET Framework, and the compiler to perform global analysis to deliver performance wins. As a result, apps launch consistently faster even after .NET Framework updates.  
  
-   The [!INCLUDE[net_native](../../../includes/net-native-md.md)] runtime is optimized for static precompilation and in the vast majority of cases offers superior performance. At the same time, it retains the core reflection features that developers find so productive.  
  
-   [!INCLUDE[net_native](../../../includes/net-native-md.md)] uses the same back end as the C++ compiler, which is optimized for static precompilation scenarios.  
  
 [!INCLUDE[net_native](../../../includes/net-native-md.md)] is able to bring the performance benefits of C++ to managed code developers because it uses the same or similar tools as C++ under the hood, as shown in this table.  
  
||[!INCLUDE[net_native](../../../includes/net-native-md.md)]|C++|  
|-|----------------------------------------------------------------|-----------|  
|Libraries|The .NET Framework + Windows Runtime|Win32 + Windows Runtime|  
|Compiler|UTC optimizing compiler|UTC optimizing compiler|  
|Deployed|Ready-to-run binaries|Ready-to-run binaries (ASM)|  
|Runtime|MRT.dll (Minimal CLR Runtime)|CRT.dll (C Runtime)|  
  
 For Windows apps for Windows 10, you upload .NET Native Code Compilation binaries in app packages (.appx files) to the Windows Store.  
  
## In This Section  
 For more information about developing apps with .NET Native Code Compilation, see these topics:  
  
-   [Getting Started with .NET Native Code Compilation: The Developer Experience Walkthrough](../../../docs/framework/net-native/getting-started-with-net-native.md)  
  
-   [.NET Native and Compilation:](../../../docs/framework/net-native/net-native-and-compilation.md) How .NET Native compiles your project to native code.  
  
-   [Reflection and .NET Native](../../../docs/framework/net-native/reflection-and-net-native.md)  
  
    -   [APIs That Rely on Reflection](../../../docs/framework/net-native/apis-that-rely-on-reflection.md)  
  
    -   [Reflection API Reference](../../../docs/framework/net-native/net-native-reflection-api-reference.md)  
  
    -   [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
  
-   [Serialization and Metadata](../../../docs/framework/net-native/serialization-and-metadata.md)  
  
-   [Migrating Your Windows Store App to .NET Native](../../../docs/framework/net-native/migrating-your-windows-store-app-to-net-native.md)  
  
-   [.NET Native General Troubleshooting](../../../docs/framework/net-native/net-native-general-troubleshooting.md)  
  
## See Also  
 [.NET Native FAQ](http://msdn.microsoft.com/vstudio/dn642499.aspx)
