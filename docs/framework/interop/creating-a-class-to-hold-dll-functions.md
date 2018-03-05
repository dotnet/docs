---
title: "Creating a Class to Hold DLL Functions"
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
  - "COM interop, DLL functions"
  - "unmanaged functions"
  - "COM interop, platform invoke"
  - "interoperation with unmanaged code, DLL functions"
  - "interoperation with unmanaged code, platform invoke"
  - "platform invoke, creating class for functions"
  - "DLL functions"
ms.assetid: e08e4c34-0223-45f7-aa55-a3d8dd979b0f
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating a Class to Hold DLL Functions
Wrapping a frequently used DLL function in a managed class is an effective approach to encapsulate platform functionality. Although it is not mandatory to do so in every case, providing a class wrapper is convenient because defining DLL functions can be cumbersome and error-prone. If you are programming in Visual Basic or C#, you must declare DLL functions within a class or Visual Basic module.  
  
 Within a class, you define a static method for each DLL function you want to call. The definition can include additional information, such as the character set or the calling convention used in passing method arguments; by omitting this information, you select the default settings. For a complete list of declaration options and their default settings, see [Creating Prototypes in Managed Code](../../../docs/framework/interop/creating-prototypes-in-managed-code.md).  
  
 Once wrapped, you can call the methods on the class as you call static methods on any other class. Platform invoke handles the underlying exported function automatically.  
  
 When designing a managed class for platform invoke, consider the relationships between classes and DLL functions. For example, you can:  
  
-   Declare DLL functions within an existing class.  
  
-   Create an individual class for each DLL function, keeping functions isolated and easy to find.  
  
-   Create one class for a set of related DLL functions to form logical groupings and reduce overhead.  
  
 You can name the class and its methods as you please. For examples that demonstrate how to construct .NET-based declarations to be used with platform invoke, see [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md).  
  
## See Also  
 [Consuming Unmanaged DLL Functions](../../../docs/framework/interop/consuming-unmanaged-dll-functions.md)  
 [Identifying Functions in DLLs](../../../docs/framework/interop/identifying-functions-in-dlls.md)  
 [Creating Prototypes in Managed Code](../../../docs/framework/interop/creating-prototypes-in-managed-code.md)  
 [Calling a DLL Function](../../../docs/framework/interop/calling-a-dll-function.md)
