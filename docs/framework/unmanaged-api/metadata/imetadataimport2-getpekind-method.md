---
description: "Learn more about: IMetaDataImport2::GetPEKind Method"
title: "IMetaDataImport2::GetPEKind Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport2.GetPEKind"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport2::GetPEKind"
helpviewer_keywords: 
  - "GetPEKind method [.NET Framework metadata]"
  - "IMetaDataImport2::GetPEKind method [.NET Framework metadata]"
ms.assetid: d91c3d89-8022-4a4c-a2a2-a8af2c387507
topic_type: 
  - "apiref"
---
# IMetaDataImport2::GetPEKind Method

Gets a value identifying the nature of the code in the portable executable (PE) file, typically a DLL or EXE file, that is defined in the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT GetPEKind (  
   [out] DWORD *pdwPEKind,  
   [out] DWORD *pdwMachine  
);  
```  
  
## Parameters  

 `pdwPEKind`  
 [out] A pointer to a value of the [CorPEKind](corpekind-enumeration.md) enumeration that describes the PE file.  
  
 `pdwMachine`  
 [out] A pointer to a value that identifies the architecture of the machine. See the next section for possible values.  
  
## Remarks  

 The value referenced by the `pdwMachine` parameter can be one of the following.  
  
|Value|Machine architecture|  
|-----------|--------------------------|  
|IMAGE_FILE_MACHINE_I386<br /><br /> 0x014C|x86|  
|IMAGE_FILE_MACHINE_IA64<br /><br /> 0x0200|Intel IPF|  
|IMAGE_FILE_MACHINE_AMD64<br /><br /> 0x8664|x64|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [CorPEKind Enumeration](corpekind-enumeration.md)
