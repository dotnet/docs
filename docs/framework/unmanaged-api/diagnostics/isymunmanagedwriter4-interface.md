---
description: "Learn more about: ISymUnmanagedWriter4 Interface"
title: "ISymUnmanagedWriter4 Interface"
ms.date: "03/30/2017"
ms.assetid: 4af5e8c0-987d-405e-b934-8b9e70fcae6e
---
# ISymUnmanagedWriter4 Interface

ISymUnmanagedWriter4 interface.  
  
## Syntax  
  
```idl  
[object,uuid(BC7E3F53-F458-4C23-9DBD-A189E6E96594),pointer_default(unique)]interface ISymUnmanagedWriter4 : ISymUnmanagedWriter3  
```  
  
## Methods  

 This interface contains the following methods:  
  
|Method|Description|  
|------------|-----------------|  
|[GetDebugInfoWithPadding Method](isymunmanagedwriter4-getdebuginfowithpadding-method.md)|Functions the same as [GetDebugInfo Method](isymunmanagedwriter-getdebuginfo-method.md) except that the path string is padded with zeros following the terminating null character to make the string data a fixed size of `MAX_PATH`. Padding is only given if the path string length itself is less than `MAX_PATH`.<br /><br /> This makes it easier to write tools that difference PE files.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedWriter3 Interface](isymunmanagedwriter3-interface.md)
