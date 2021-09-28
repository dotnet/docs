---
description: "Learn more about: EmitManifest Method"
title: "EmitManifest Method"
ms.date: "03/30/2017"
api_name: 
  - "EmitManifest"
  - "IALink.EmitManifest"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmitManifest"
helpviewer_keywords: 
  - "EmitManifest method"
ms.assetid: fdebc1f3-b62e-4d9e-b775-8ccaa8ecb250
topic_type: 
  - "apiref"
---
# EmitManifest Method

Emits the final manifest. Call this method after importing all other files and setting all options. Do not call this method for unbound modules.  
  
## Syntax  
  
```cpp  
HRESULT EmitManifest(  
    mdAssembly   AssemblyID,  
    DWORD*       pdwReserveSize,  
    mdAssembly*  ptkManifest  
) PURE;  
```  
  
## Parameters  

 `AssemblyID`  
 ID of the assembly.  
  
 `pdwReserveSize`  
 Receives the size to reserve in the assembly file, retrieved from [StrongNameSignatureSize Function](../strong-naming/strongnamesignaturesize-function.md).  
  
 `ptkManifest`  
 Optionally receives the assembly manifest token.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h.  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
