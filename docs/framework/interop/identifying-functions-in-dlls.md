---
title: "Identifying Functions in DLLs"
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
  - "platform invoke, identifying functions"
  - "COM interop, DLL functions"
  - "unmanaged functions"
  - "COM interop, platform invoke"
  - "interoperation with unmanaged code, DLL functions"
  - "interoperation with unmanaged code, platform invoke"
  - "identifying DLL functions"
  - "DLL functions"
ms.assetid: 3e3f6780-6d90-4413-bad7-ba641220364d
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Identifying Functions in DLLs
The identity of a DLL function consists of the following elements:  
  
-   Function name or ordinal  
  
-   Name of the DLL file in which the implementation can be found  
  
 For example, specifying the **MessageBox** function in the User32.dll identifies the function (**MessageBox**) and its location (User32.dll, User32, or user32). The Microsoft Windows application programming interface (Win32 API) can contain two versions of each function that handles characters and strings: a 1-byte character ANSI version and a 2-byte character Unicode version. When unspecified, the character set, represented by the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet> field, defaults to ANSI. Some functions can have more than two versions.  
  
 **MessageBoxA** is the ANSI entry point for the **MessageBox** function; **MessageBoxW** is the Unicode version. You can list function names for a specific DLL, such as user32.dll, by running a variety of command-line tools. For example, you can use `dumpbin /exports user32.dll` or `link /dump /exports user32.dll` to obtain function names.  
  
 You can rename an unmanaged function to whatever you like within your code as long as you map the new name to the original entry point in the DLL. For instructions on renaming an unmanaged DLL function in managed source code, see the [Specifying an Entry Point](../../../docs/framework/interop/specifying-an-entry-point.md).  
  
 Platform invoke enables you to control a significant portion of the operating system by calling functions in the Win32 API and other DLLs. In addition to the Win32 API, there are numerous other APIs and DLLs available to you through platform invoke.  
  
 The following table describes several commonly used DLLs in the Win32 API.  
  
|DLL|Description of Contents|  
|---------|-----------------------------|  
|GDI32.dll|Graphics Device Interface (GDI) functions for device output, such as those for drawing and font management.|  
|Kernel32.dll|Low-level operating system functions for memory management and resource handling.|  
|User32.dll|Windows management functions for message handling, timers, menus, and communications.|  
  
 For complete documentation on the Win32 API, see the Platform SDK. For examples that demonstrate how to construct .NET-based declarations to be used with platform invoke, see [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md).  
  
## See Also  
 [Consuming Unmanaged DLL Functions](../../../docs/framework/interop/consuming-unmanaged-dll-functions.md)  
 [Specifying an Entry Point](../../../docs/framework/interop/specifying-an-entry-point.md)  
 [Creating a Class to Hold DLL Functions](../../../docs/framework/interop/creating-a-class-to-hold-dll-functions.md)  
 [Creating Prototypes in Managed Code](../../../docs/framework/interop/creating-prototypes-in-managed-code.md)  
 [Calling a DLL Function](../../../docs/framework/interop/calling-a-dll-function.md)
