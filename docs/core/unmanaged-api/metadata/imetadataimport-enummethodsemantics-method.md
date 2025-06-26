---
description: "Learn more about: IMetaDataImport::EnumMethodSemantics Method"
title: "IMetaDataImport::EnumMethodSemantics Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumMethodSemantics"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumMethodSemantics"
helpviewer_keywords: 
  - "EnumMethodSemantics method [.NET Framework metadata]"
  - "IMetaDataImport::EnumMethodSemantics method [.NET Framework metadata]"
ms.assetid: e7e3c630-9691-46d6-94df-b5593a7bb08a
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumMethodSemantics Method

Enumerates the properties and the property-change events to which the specified method is related.  
  
## Syntax  
  
```cpp  
HRESULT EnumMethodSemantics (  
   [in, out] HCORENUM    *phEnum,  
   [in]  mdMethodDef     mb,
   [out] mdToken         rEventProp[],  
   [in]  ULONG           cMax,  
   [out] ULONG           *pcEventProp  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `mb`  
 [in] A MethodDef token that limits the scope of the enumeration.  
  
 `rEventProp`  
 [out] The array used to store the events or properties.  
  
 `cMax`  
 [in] The maximum size of the `rEventProp` array.  
  
 `pcEventProp`  
 [out] The number of events or properties returned in `rEventProp`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumMethodSemantics` returned successfully.|  
|`S_FALSE`|There are no events or properties to enumerate. In that case, `pcEventProp` is zero.|  
  
## Remarks  

 Many common language runtime types define *Property*`Changed` events and `On`*Property*`Changed` methods related to their properties. For example, the <xref:System.Windows.Forms.Control?displayProperty=nameWithType> type defines a <xref:System.Windows.Forms.Control.Font%2A> property, a <xref:System.Windows.Forms.Control.FontChanged> event, and an <xref:System.Windows.Forms.Control.OnFontChanged%2A> method. The set accessor method of the <xref:System.Windows.Forms.Control.Font%2A> property calls <xref:System.Windows.Forms.Control.OnFontChanged%2A> method, which in turn raises the <xref:System.Windows.Forms.Control.FontChanged> event. You would call `EnumMethodSemantics` using the MethodDef for <xref:System.Windows.Forms.Control.OnFontChanged%2A> to get references to the <xref:System.Windows.Forms.Control.Font%2A> property and the <xref:System.Windows.Forms.Control.FontChanged> event.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
