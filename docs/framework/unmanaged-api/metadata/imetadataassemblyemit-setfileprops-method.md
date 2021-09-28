---
description: "Learn more about: IMetaDataAssemblyEmit::SetFileProps Method"
title: "IMetaDataAssemblyEmit::SetFileProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyEmit.SetFileProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::SetFileProps"
helpviewer_keywords: 
  - "IMetaDataAssemblyEmit::SetFileProps method [.NET Framework metadata]"
  - "SetFileProps method [.NET Framework metadata]"
ms.assetid: 85667d38-611c-45a9-938d-930ac7a7b681
topic_type: 
  - "apiref"
---
# IMetaDataAssemblyEmit::SetFileProps Method

Modifies the specified `File` metadata structure.  
  
## Syntax  
  
```cpp  
HRESULT SetFileProps (  
    [in] mdFile        file,  
    [in] const void    *pbHashValue,
    [in] ULONG         cbHashValue,  
    [in] DWORD         dwFileFlags  
);  
```  
  
## Parameters  

 `file`  
 [in] The metadata token that specifies the `File` metadata structure to be modified.  
  
 `pbHashValue`  
 [in] A pointer to the hash data associated with the file.  
  
 `cbHashValue`  
 [in] The size in bytes of `pbHashValue`.  
  
 `dwFileFlags`  
 [in] A bitwise combination of [CorFileFlags](corfileflags-enumeration.md) values that specify various attributes of the file.  
  
## Remarks  

 To create a `File` metadata structure, use the [IMetaDataAssemblyEmit::DefineFile](imetadataassemblyemit-definefile-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
