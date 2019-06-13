---
title: "IMetaDataImport::GetInterfaceImplProps Method"
ms.date: "02/25/2019"
api_name: 
  - "IMetaDataImport.GetInterfaceImplProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetInterfaceImplProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetInterfaceImplProps method [.NET Framework metadata]"
  - "GetInterfaceImpProps method [.NET Framework metadata]"
ms.assetid: be3f5985-b1e4-4036-8602-c16e8508d4af
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::GetInterfaceImplProps Method
Gets a pointer to the metadata tokens for the <xref:System.Type> that implements the specified method, and for the interface that declares that method.
  
## Syntax  
  
```  
HRESULT GetInterfaceImplProps (  
   [in]  mdInterfaceImpl        iiImpl,  
   [out] mdTypeDef              *pClass,  
   [out] mdToken                *ptkIface  
);  
```  
  
## Parameters  
 `iiImpl`  
 [in] The metadata token representing the method to return the class and interface tokens for.  
  
 `pClass`  
 [out] The metadata token representing the class that implements the method.  
  
 `ptkIface`  
 [out] The metadata token representing the interface that defines the implemented method.  

## Remarks

 You obtain the value for `iImpl` by calling the [EnumInterfaceImpls](imetadataimport-enuminterfaceimpls-method.md) method.
 
 For example, suppose that a class has an `mdTypeDef` token value of 0x02000007 and that it implements three
interfaces whose types have tokens: 

- 0x02000003 (TypeDef)
- 0x0100000A (TypeRef)
- 0x0200001C (TypeDef)

Conceptually, this information is stored into an interface implementation table as:

| Row number | Class token | Interface token |
|------------|-------------|-----------------|
| 4          |             |                 |
| 5          | 02000007    | 02000003        |
| 6          | 02000007    | 0100000A        |
| 7          |             |                 |
| 8          | 02000007    | 0200001C        |

Recall, the token is a 4-byte value:

- The lower 3 bytes hold the row number, or RID.
- The upper byte holds the token type – 0x09 for `mdtInterfaceImpl`.

`GetInterfaceImplProps` returns the information held in the row whose token you provide in the `iImpl` argument. 
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
