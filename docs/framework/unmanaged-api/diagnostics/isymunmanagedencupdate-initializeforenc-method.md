---
description: "Learn more about: ISymUnmanagedENCUpdate::InitializeForEnc Method"
title: "ISymUnmanagedENCUpdate::InitializeForEnc Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedENCUpdate.InitializeForEnc"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::InitializeForEnc"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate::InitializeForEnc method [.NET Framework debugging]"
  - "InitializeForEnc method [.NET Framework debugging]"
ms.assetid: 796b2154-b53c-4d07-9e67-80fd6064725a
topic_type: 
  - "apiref"
---
# ISymUnmanagedENCUpdate::InitializeForEnc Method

Allows method boundaries to be computed before the first call to the [ISymUnmanagedENCUpdate::UpdateSymbolStore2](isymunmanagedencupdate-updatesymbolstore2-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT InitializeForEnc();  
```  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedENCUpdate Interface](isymunmanagedencupdate-interface.md)
