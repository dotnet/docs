---
title: "ISymUnmanagedVariable Interface"
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
  - "ISymUnmanagedVariable"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable"
helpviewer_keywords: 
  - "ISymUnmanagedVariable interface [.NET Framework debugging]"
ms.assetid: 704c69ba-77bc-40d7-8c0c-400061686321
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedVariable Interface
Represents a variable, such as a parameter, a local variable, or a field.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetAddressField1 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddressfield1-method.md)|Gets the first address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressField2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddressfield2-method.md)|Gets the second address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressField3 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddressfield3-method.md)|Gets the third address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressKind Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddresskind-method.md)|Gets the kind of address of this variable.|  
|[GetAttributes Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getattributes-method.md)|Gets the attribute flags for this variable.|  
|[GetEndOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getendoffset-method.md)|Gets the end offset of this variable within its parent.|  
|[GetName Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getname-method.md)|Gets the name of this variable.|  
|[GetSignature Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getsignature-method.md)|Gets the signature of this variable.|  
|[GetStartOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getstartoffset-method.md)|Gets the start offset of this variable within its parent.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)
