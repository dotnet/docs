---
description: "Learn more about: ISymUnmanagedVariable Interface"
title: "ISymUnmanagedVariable Interface"
ms.date: "03/30/2017"
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
---
# ISymUnmanagedVariable Interface

Represents a variable, such as a parameter, a local variable, or a field.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetAddressField1 Method](isymunmanagedvariable-getaddressfield1-method.md)|Gets the first address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressField2 Method](isymunmanagedvariable-getaddressfield2-method.md)|Gets the second address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressField3 Method](isymunmanagedvariable-getaddressfield3-method.md)|Gets the third address field for this variable. Its meaning depends on the kind of address.|  
|[GetAddressKind Method](isymunmanagedvariable-getaddresskind-method.md)|Gets the kind of address of this variable.|  
|[GetAttributes Method](isymunmanagedvariable-getattributes-method.md)|Gets the attribute flags for this variable.|  
|[GetEndOffset Method](isymunmanagedvariable-getendoffset-method.md)|Gets the end offset of this variable within its parent.|  
|[GetName Method](isymunmanagedvariable-getname-method.md)|Gets the name of this variable.|  
|[GetSignature Method](isymunmanagedvariable-getsignature-method.md)|Gets the signature of this variable.|  
|[GetStartOffset Method](isymunmanagedvariable-getstartoffset-method.md)|Gets the start offset of this variable within its parent.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
