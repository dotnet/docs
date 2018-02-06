---
title: "Runtime Exceptions in .NET Native Apps"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5f050181-8fdd-4a4e-9d16-f84c22a88a97
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Exceptions in .NET Native Apps
It is important to test the release builds of your Universal Windows Platform app on their target platforms because the debug and release configurations are completely different. By default, the debug configuration uses the .NET Core runtime to compile your app, but the release configuration uses .NET Native to compile your app to native code.  
  
> [!IMPORTANT]
>  For information on dealing with the [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md), [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md), and [MissingRuntimeArtifactException](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md) exceptions that you may encounter when testing the release versions of your app, see  "Step 4: Manually resolve missing metadata: in the [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md) topic, as well as [Reflection and .NET Native](../../../docs/framework/net-native/reflection-and-net-native.md) and [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
## Debug and release builds  
 When the debug build executes against the .NET Core runtime, it has not been compiled to native code. This makes all of the services ordinarily provided by the runtime available to your app.  
  
 On the other hand, the release build compiles to native code for its target platforms, removes most dependencies on external runtimes and libraries, and heavily optimizes code for maximum performance.  
  
 When you debug release builds that are compiled by using .NET Native:  
  
-   You use the .NET Native debug engine, which is different from the normal .NET debugging tools.  
  
-   The size of your executable is reduced as much as possible. One of the ways that .NET Native reduces the size of an executable is by significantly trimming runtime exception messages, a topic discussed in greater detail in the [Runtime exception messages](#Messages) section.  
  
-   Your code is heavily optimized. This means that inlining is used whenever possible. (Inlining moves code from external routines into the calling routine.)   The fact that .NET Native provides a specialized runtime and implements aggressive inlining  affects the call stack that is displayed when debugging.  For more information, see the [Runtime call stack](#CallStack) section.  
  
> [!NOTE]
>  You can control whether the debug and release builds are compiled with the .NET Native tool chain by checking or unchecking the **Compile with .NET Native tool chain** box.   Note, however, that the Windows Store will always compile the production version of your app with the .NET Native tool chain.  
  
<a name="Messages"></a>   
## Runtime exception messages  
 To minimize application executable size, .NET Native does not include the full text of exception messages. As a result, runtime exceptions thrown in release builds may not display the full text of exception messages. Instead, the text may consist of a substring along with a link to follow for more information. For example, the exception information may appear as:  
  
```  
Exception thrown: '$16_System.AggregateException' in Unknown Module.  
  
Additional information: AggregateException_ctor_DefaultMessage  
  
If there is a handler for this exception, the program may be safely continued.  
```  
  
 If you need the complete exception message,  run the debug build instead. For example, the previous exception information  from the release build might appear as follows in the debug build:  
  
```  
Exception thrown: 'System.AggregateException' in NativeApp.exe.  
  
Additional information: Value does not fall within the expected range.  
```  
  
<a name="CallStack"></a>   
## Runtime call stack  
 Because of inlining and other optimizations, the call stack displayed by an app compiled by the .NET Native tool chain may not help you to  clearly identify the path to a runtime exception.  
  
 To get the full stack, run the debug build instead.  
  
## See Also  
 [Debugging .NET Native Windows Universal Apps](http://blogs.msdn.com/b/visualstudioalm/archive/2015/07/29/debugging-net-native-windows-universal-apps.aspx)  
 [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md)
