---
description: "Learn more about: ICLRDebuggingLibraryProvider3 Interface"
title: "ICLRDebuggingLibraryProvider3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDebuggingLibraryProvider3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebuggingLibraryProvider3"
helpviewer_keywords: 
  - "ICLRDebuggingLibraryProvider3 interface [.NET Core debugging]"
ms.assetid: 67739617-6add-41a9-9de5-a3200c3109ce
topic_type: 
  - "apiref"
---
# ICLRDebuggingLibraryProvider3 Interface

Includes the [ProvideLibrary2](iclrdebugginglibraryprovider3-providewindowslibrary-method.md) method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ProvideWindowsLibrary](iclrdebugginglibraryprovider3-providewindowslibrary-method.md)|Allows the debugger to provide a path to a version-specific Windows debugging library.|  
|[ProvideUnixLibrary](iclrdebugginglibraryprovider3-provideunixlibrary-method.md)|Allows the debugger to provide a path to a version-specific debugging Linux or MacOS library.|  
  
## Requirements  

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Versions:** [!INCLUDE[net_core_60](../../../../includes/net-core-60-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
