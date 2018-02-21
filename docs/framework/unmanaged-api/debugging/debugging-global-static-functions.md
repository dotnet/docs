---
title: "Debugging Global Static Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "global static functions [.NET Framework debugging]"
  - "debugging global static functions [.NET Framework]"
  - "unmanaged global static functions [.NET Framework], debugging"
ms.assetid: efc64414-77c3-48d0-881a-8594ed416aad
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Debugging Global Static Functions
This section describes the unmanaged global static functions that the debugging API uses.  
  
## In This Section  
 [_EFN_GetManagedExcepStack Function](../../../../docs/framework/unmanaged-api/debugging/efn-getmanagedexcepstack-function.md)  
 Given a managed exception object address, returns a string version of the stack trace contained inside.  
  
 [_EFN_GetManagedObjectFieldInfo Function](../../../../docs/framework/unmanaged-api/debugging/efn-getmanagedobjectfieldinfo-function.md)  
 Gets the offset from the start of an object to a field and the field's value, using the provided object pointer and field name.  
  
 [_EFN_GetManagedObjectName Function](../../../../docs/framework/unmanaged-api/debugging/efn-getmanagedobjectname-function.md)  
 Gets the name of a type by using the provided managed object pointer.  
  
 [_EFN_StackTrace Function](../../../../docs/framework/unmanaged-api/debugging/efn-stacktrace-function.md)  
 Provides a text representation of a managed stack trace and an array of `CONTEXT` records, one for each transition between unmanaged and managed code.  
  
 [CLRDataCreateInstance Function](../../../../docs/framework/unmanaged-api/debugging/clrdatacreateinstance-function.md)  
 Called by the common language runtime (CLR) data access services to create the specified interface object for the specified target process.  
  
 [PFN_CLRDataCreateInstance Function Pointer](../../../../docs/framework/unmanaged-api/debugging/pfn-clrdatacreateinstance-function-pointer.md)  
 Points to a function that is called by the CLR data access services to create the specified interface object for the specified target process.  
  
## Related Sections  
 [Debugging Coclasses](../../../../docs/framework/unmanaged-api/debugging/debugging-coclasses.md)  
  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)  
  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
