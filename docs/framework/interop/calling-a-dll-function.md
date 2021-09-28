---
title: "Calling a DLL Function"
description: Review issues about calling a DLL function that can seem confusing. The function calling process differs depending on if the return type is blittable.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "unmanaged functions, calling"
  - "unmanaged functions"
  - "COM interop, platform invoke"
  - "platform invoke, calling unmanaged functions"
  - "interoperation with unmanaged code, platform invoke"
  - "DLL functions"
ms.assetid: 113646de-7ea0-4f0e-8df0-c46dab3e8733
---
# Calling a DLL Function

Although calling unmanaged DLL functions is nearly identical to calling other managed code, there are differences that can make DLL functions seem confusing at first. This section introduces topics that describe some of the unusual calling-related issues.  
  
 Structures that are returned from platform invoke calls must be data types that have the same representation in managed and unmanaged code. Such types are called *blittable types* because they do not require conversion (see [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)). To call a function that has a non-blittable structure as its return type, you can define a blittable helper type of the same size as the non-blittable type and convert the data after the function returns.  
  
## In This Section  

 [Passing Structures](passing-structures.md)  
 Identifies the issues of passing data structures with a predefined layout.  
  
 [Callback Functions](callback-functions.md)  
 Provides basic information about callback functions.  
  
 [How to: Implement Callback Functions](how-to-implement-callback-functions.md)  
 Describes how to implement callback functions in managed code.  
  
## Related Sections  

 [Consuming Unmanaged DLL Functions](consuming-unmanaged-dll-functions.md)  
 Describes how to call unmanaged DLL functions using platform invoke.  
  
 [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md)  
 Describes how to declare method parameters and pass arguments to functions exported by unmanaged libraries.
