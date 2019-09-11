---
title: "CreateHistoryReader Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateHistoryReader"
api_location: 
  - "fusion.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateHistoryReader"
helpviewer_keywords: 
  - "CreateHistoryReader function [.NET Framework fusion]"
ms.assetid: 66a89acf-8c32-44c0-8787-960c99c7b3ec
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CreateHistoryReader Function
Creates a history reader for the specified file.  
  
## Syntax  
  
```cpp  
HRESULT CreateHistoryReader (  
    [in]  LPCWSTR        wzFilePath,  
    [out] IHistoryReader **ppHistoryReader  
 );  
```  
  
## Parameters  
 `wzFilePath`  
 [in] The file path.  
  
 `ppHistoryReader`  
 [out] On successful completion, contains a pointer to the history reader.  
  
## Return Value  
 This method returns standard COM error codes as defined in WinError.h, in addition to the values described in the following table.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|Indicates that the method completed successfully.|  
|E_INVALIDARG|Indicates that `wzFilePath` or `ppHistoryReader` are set to a null reference.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Library:** Fusion.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Fusion Global Static Functions](fusion-global-static-functions.md)
