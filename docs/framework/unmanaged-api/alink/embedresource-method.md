---
description: "Learn more about: EmbedResource Method"
title: "EmbedResource Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.EmbedResource"
  - "EmbedResource"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmbedResource"
helpviewer_keywords: 
  - "EmbedResource method"
ms.assetid: 667bd954-6dc6-4020-a3cb-0e8224179993
topic_type: 
  - "apiref"
---
# EmbedResource Method

Declares an embedded resource. This method does not actually embed the resource.  
  
## Syntax  
  
```cpp  
HRESULT EmbedResource(  
    mdAssembly  AssemblyID,  
    mdToken     FileToken,  
    LPCWSTR     pszResourceName,  
    DWORD       dwOffset,  
    DWORD       dwFlags  
) PURE;  
```  
  
## Parameters  

 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 File token or assembly ID of file that contains the resource.  
  
 `pszResourceName`  
 Name of the resource.  
  
 `dwOffset`  
 Offset of resource from RVA.  
  
 `dwFlags`  
 Accessibility flags such as `mrPublic` and `mrPrivate`. These flags may be passed to [DefineExportedType Method](../metadata/imetadataassemblyemit-defineexportedtype-method.md).  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h.  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
