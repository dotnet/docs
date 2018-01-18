---
title: "LoadTypeLibWithResolver Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "LoadTypeLibWithResolver"
api_location: 
  - "TlbRef.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "LoadTypeLibWithResolver"
helpviewer_keywords: 
  - "LoadTypeLibWithResolver function [.NET Framework]"
ms.assetid: 7123a89b-eb9b-463a-a552-a081e33b0a3a
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LoadTypeLibWithResolver Function
Loads a type library and uses the supplied [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md) to resolve any internally referenced type libraries.  
  
## Syntax  
  
```  
HRESULT LoadTypeLibWithResolver(  
    [in]  LPCOLESTR           szFile,  
    [in]  REGKIND             regkind,  
    [in]  ITypeLibResolver   *pTlbResolver,  
    [out] ITypeLib          **pptlib);  
```  
  
#### Parameters  
 `szFile`  
 [in] The file path of the type library.  
  
 `regkind`  
 [in] A [REGKIND enumeration](https://msdn.microsoft.com/library/windows/desktop/ms221159.aspx) flag that controls how the type library is registered. Its possible values are:  
  
-   `REGKIND_DEFAULT`: Use default registration behavior.  
  
-   `REGKIND_REGISTER`: Register this type library.  
  
-   `REGKIND_NONE`: Do not register this type library.  
  
 `pTlbResolver`  
 [in] A pointer to the implementation of the [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md).  
  
 `pptlib`  
 [out] A reference to the type library that is being loaded.  
  
## Return Value  
 One of the HRESULT values listed in the following table.  
  
|Return value|Meaning|  
|------------------|-------------|  
|`S_OK`|Success.|  
|`E_OUTOFMEMORY`|Out of memory.|  
|`E_POINTER`|One or more of the pointers are invalid.|  
|`E_INVALIDARG`|One or more of the arguments are invalid.|  
|`TYPE_E_IOERROR`|The function could not write to the file.|  
|`TYPE_E_REGISTRYACCESS`|The system registration database could not be opened.|  
|`TYPE_E_INVALIDSTATE`|The type library could not be opened.|  
|`TYPE_E_CANTLOADLIBRARY`|The type library or DLL could not be loaded.|  
  
## Remarks  
 The [Tlbexp.exe (Type Library Exporter)](../../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md) calls the `LoadTypeLibWithResolver` function during the assembly-to-type-library conversion process.  
  
 This function loads the specified type library with minimal access to the registry. The function then examines the type library for internally referenced type libraries, each of which must be loaded and added to the parent type library.  
  
 Before a referenced type library can be loaded, its reference file path must be resolved to a full file path. This is accomplished through the [ResolveTypeLib method](../../../../docs/framework/unmanaged-api/tlbexp/resolvetypelib-method.md) that is provided by the [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md), which is passed in the `pTlbResolver` parameter.  
  
 When the full file path of the referenced type library is known, the `LoadTypeLibWithResolver` function loads and adds the referenced type library to the parent type library, creating a combined master type library.  
  
 After the function resolves and loads all internally referenced type libraries, it returns a reference to the master resolved type library in the `pptlib` parameter.  
  
 The `LoadTypeLibWithResolver` function is generally called by the [Tlbexp.exe (Type Library Exporter)](../../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md), which supplies its own internal [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md) implementation in the `pTlbResolver` parameter.  
  
 If you call `LoadTypeLibWithResolver` directly, you must supply your own [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md) implementation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** TlbRef.h  
  
 **Library:** TlbRef.lib  
  
 **.NET Framework Version:** 3.5, 3.0, 2.0  
  
## See Also  
 [Tlbexp Helper Functions](../../../../docs/framework/unmanaged-api/tlbexp/index.md)  
 [LoadTypeLibEx Function](https://msdn.microsoft.com/library/windows/desktop/ms221249\(v=vs.85\).aspx)
