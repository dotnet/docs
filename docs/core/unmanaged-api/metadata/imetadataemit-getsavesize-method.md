---
description: "Learn more about: IMetaDataEmit::GetSaveSize Method"
title: "IMetaDataEmit::GetSaveSize Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.GetSaveSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::GetSaveSize"
helpviewer_keywords: 
  - "IMetaDataEmit::GetSaveSize method [.NET Framework metadata]"
  - "GetSaveSize method [.NET Framework metadata]"
ms.assetid: 8aea2e2c-23a3-4cda-9a06-e19f97383830
topic_type: 
  - "apiref"
---
# IMetaDataEmit::GetSaveSize Method

Gets the estimated binary size of the assembly and its metadata in the current scope.  
  
## Syntax  
  
```cpp  
HRESULT GetSaveSize (  
    [in]  CorSaveSize fSave,  
    [out] DWORD       *pdwSaveSize  
);  
```  
  
## Parameters  

 `fSave`  
 [in] A value of the [CorSaveSize](corsavesize-enumeration.md) enumeration that specifies whether to get an accurate or approximate size. Only three values are valid: cssAccurate, cssQuick, and cssDiscardTransientCAs:  
  
- cssAccurate returns the exact save size but takes longer to calculate.  
  
- cssQuick returns a size, padded for safety, but takes less time to calculate.  
  
- cssDiscardTransientCAs tells `GetSaveSize` that it can throw away discardable custom attributes.  
  
 `pdwSaveSize`  
 [out] A pointer to the size that is required to save the file.  
  
## Remarks  

 `GetSaveSize` calculates the space required, in bytes, to save the assembly and all its metadata in the current scope. (A call to the [IMetaDataEmit::SaveToStream](imetadataemit-savetostream-method.md) method would emit this number of bytes.)  
  
 If the caller implements the [IMapToken](imaptoken-interface.md) interface (through [IMetaDataEmit::SetHandler](imetadataemit-sethandler-method.md) or [IMetaDataEmit::Merge](imetadataemit-merge-method.md)), `GetSaveSize` will perform two passes over the metadata to optimize and compress it. Otherwise, no optimizations are performed.  
  
 If optimization is performed, the first pass simply sorts the metadata structures to tune the performance of import-time searches. This step typically results in moving records around, with the side effect that tokens retained by the tool for future reference are invalidated. The metadata does not inform the caller of these token changes until after the second pass, however. In the second pass, various optimizations are performed that are intended to reduce the overall size of the metadata, such as optimizing away (early binding) `mdTypeRef` and `mdMemberRef` tokens when the reference is to a type or member that is declared in the current metadata scope. In this pass, another round of token mapping occurs. After this pass, the metadata engine notifies the caller, through its `IMapToken` interface, of any changed token values.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
