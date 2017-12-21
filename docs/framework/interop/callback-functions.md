---
title: "Callback Functions"
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
  - "callback function"
  - "platform invoke, calling unmanaged functions"
ms.assetid: c0aa8533-3b3b-42e8-9f60-84919793098c
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Callback Functions
A callback function is code within a managed application that helps an unmanaged DLL function complete a task. Calls to a callback function pass indirectly from a managed application, through a DLL function, and back to the managed implementation. Some of the many DLL functions called with platform invoke require a callback function in managed code to run properly.  
  
 To call most DLL functions from managed code, you create a managed definition of the function and then call it. The process is straightforward.  
  
 Using a DLL function that requires a callback function has some additional steps. First, you must determine whether the function requires a callback by looking at the documentation for the function. Next, you have to create the callback function in your managed application. Finally, you call the DLL function, passing a pointer to the callback function as an argument. The following illustration summarizes these steps.  
  
 ![Platform invoke callback](../../../docs/framework/interop/media/pinvokecallback.gif "pinvokecallback")  
Callback function and implementation  
  
 Callback functions are ideal for use in situations in which a task is performed repeatedly. Another common usage is with enumeration functions, such as **EnumFontFamilies**, **EnumPrinters**, and **EnumWindows** in the Win32 API. The **EnumWindows** function enumerates through all existing windows on your computer, calling the callback function to perform a task on each window. For instructions and an example, see [How to: Implement Callback Functions](../../../docs/framework/interop/how-to-implement-callback-functions.md).  
  
## See Also  
 [How to: Implement Callback Functions](../../../docs/framework/interop/how-to-implement-callback-functions.md)  
 [Calling a DLL Function](../../../docs/framework/interop/calling-a-dll-function.md)
