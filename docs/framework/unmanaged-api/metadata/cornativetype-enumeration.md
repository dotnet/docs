---
title: "CorNativeType Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorNativeType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorNativeType"
helpviewer_keywords: 
  - "CorNativeType enumeration [.NET Framework metadata]"
ms.assetid: e47a72f1-9609-48ed-bb34-97170d7f6890
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorNativeType Enumeration
Contains values that describe native unmanaged types.  
  
## Syntax  
  
```  
typedef enum CorNativeType {  
  
    NATIVE_TYPE_END                  = 0x0,  
    NATIVE_TYPE_VOID                 = 0x1,  
    NATIVE_TYPE_BOOLEAN              = 0x2,  
    NATIVE_TYPE_I1                   = 0x3,  
    NATIVE_TYPE_U1                   = 0x4,  
    NATIVE_TYPE_I2                   = 0x5,  
    NATIVE_TYPE_U2                   = 0x6,  
    NATIVE_TYPE_I4                   = 0x7,  
    NATIVE_TYPE_U4                   = 0x8,  
    NATIVE_TYPE_I8                   = 0x9,  
    NATIVE_TYPE_U8                   = 0xa,  
    NATIVE_TYPE_R4                   = 0xb,  
    NATIVE_TYPE_R8                   = 0xc,  
    NATIVE_TYPE_SYSCHAR              = 0xd,  
    NATIVE_TYPE_VARIANT              = 0xe,  
    NATIVE_TYPE_CURRENCY             = 0xf,  
    NATIVE_TYPE_PTR                  = 0x10,  
  
    NATIVE_TYPE_DECIMAL              = 0x11,  
    NATIVE_TYPE_DATE                 = 0x12,  
    NATIVE_TYPE_BSTR                 = 0x13,  
    NATIVE_TYPE_LPSTR                = 0x14,  
    NATIVE_TYPE_LPWSTR               = 0x15,  
    NATIVE_TYPE_LPTSTR               = 0x16,  
    NATIVE_TYPE_FIXEDSYSSTRING       = 0x17,  
    NATIVE_TYPE_OBJECTREF            = 0x18,  
    NATIVE_TYPE_IUNKNOWN             = 0x19,  
    NATIVE_TYPE_IDISPATCH            = 0x1a,  
    NATIVE_TYPE_STRUCT               = 0x1b,  
    NATIVE_TYPE_INTF                 = 0x1c,  
    NATIVE_TYPE_SAFEARRAY            = 0x1d,  
    NATIVE_TYPE_FIXEDARRAY           = 0x1e,  
    NATIVE_TYPE_INT                  = 0x1f,  
    NATIVE_TYPE_UINT                 = 0x20,  
  
    NATIVE_TYPE_NESTEDSTRUCT         = 0x21,  
    NATIVE_TYPE_BYVALSTR             = 0x22,  
    NATIVE_TYPE_ANSIBSTR             = 0x23,  
    NATIVE_TYPE_TBSTR                = 0x24,  
    NATIVE_TYPE_VARIANTBOOL          = 0x25,  
    NATIVE_TYPE_FUNC                 = 0x26,  
  
    NATIVE_TYPE_ASANY                = 0x28,  
    NATIVE_TYPE_ARRAY                = 0x2a,  
    NATIVE_TYPE_LPSTRUCT             = 0x2b,  
    NATIVE_TYPE_CUSTOMMARSHALER      = 0x2c,  
    NATIVE_TYPE_IINSPECTABLE         = 0x2e,  
    NATIVE_TYPE_HSTRING              = 0x2f,  
  
    NATIVE_TYPE_ERROR                = 0x2d,   
  
    NATIVE_TYPE_MAX                  = 0x50  
  
} CorNativeType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`NATIVE_TYPE_END`|Obsolete.|  
|`NATIVE_TYPE_VOID`|Obsolete.|  
|`NATIVE_TYPE_BOOLEAN`|A 4-byte Boolean value, where TRUE is non-zero and FALSE is zero.|  
|`NATIVE_TYPE_I1`|A signed 8-bit integer value.|  
|`NATIVE_TYPE_U1`|An unsigned 8-bit integer value.|  
|`NATIVE_TYPE_I2`|A signed 16-bit integer value.|  
|`NATIVE_TYPE_U2`|An unsigned 16-bit integer value.|  
|`NATIVE_TYPE_I4`|A signed 32-bit integer value.|  
|`NATIVE_TYPE_U4`|An unsigned 32-bit integer value.|  
|`NATIVE_TYPE_I8`|A signed 64-bit integer value.|  
|`NATIVE_TYPE_U8`|An unsigned 64-bit integer value.|  
|`NATIVE_TYPE_R4`|A 4-byte floating-point numeric value.|  
|`NATIVE_TYPE_R8`|An 8-byte floating-point numeric value.|  
|`NATIVE_TYPE_SYSCHAR`|Obsolete.|  
|`NATIVE_TYPE_VARIANT`|Obsolete.|  
|`NATIVE_TYPE_CURRENCY`|A numeric COM type that corresponds to the managed <xref:System.Decimal> type.|  
|`NATIVE_TYPE_PTR`|Obsolete.|  
|`NATIVE_TYPE_DECIMAL`|Obsolete.|  
|`NATIVE_TYPE_DATE`|Obsolete.|  
|`NATIVE_TYPE_BSTR`|COM Interop.|  
|`NATIVE_TYPE_LPSTR`|An LPSTR string value.|  
|`NATIVE_TYPE_LPWSTR`|An LPWSTR string value.|  
|`NATIVE_TYPE_LPTSTR`|An LPTSTR string value.|  
|`NATIVE_TYPE_FIXEDSYSSTRING`|A fixed, system-defined string value.|  
|`NATIVE_TYPE_OBJECTREF`|Obsolete.|  
|`NATIVE_TYPE_IUNKNOWN`|COM Interop.|  
|`NATIVE_TYPE_IDISPATCH`|COM Interop.|  
|`NATIVE_TYPE_STRUCT`|A native structure value.|  
|`NATIVE_TYPE_INTF`|COM Interop.|  
|`NATIVE_TYPE_SAFEARRAY`|COM Interop.|  
|`NATIVE_TYPE_FIXEDARRAY`|A fixed-length array value.|  
|`NATIVE_TYPE_INT`|A native 16-bit signed integer value.|  
|`NATIVE_TYPE_UINT`|A native 16-bit unsigned integer value.|  
|`NATIVE_TYPE_NESTEDSTRUCT`|Obsolete.<br /><br /> Use NATIVE_TYPE_STRUCT.|  
|`NATIVE_TYPE_BYVALSTR`|COM Interop.|  
|`NATIVE_TYPE_ANSIBSTR`|COM Interop.|  
|`NATIVE_TYPE_TBSTR`|COM Interop.<br /><br /> Select BSTR or ANSIBSTR depending on the platform.|  
|`NATIVE_TYPE_VARIANTBOOL`|A 2-byte Boolean value, where TRUE is -1 and FALSE is zero.|  
|`NATIVE_TYPE_FUNC`|A function pointer.|  
|`NATIVE_TYPE_ASANY`|A reference to any native type.|  
|`NATIVE_TYPE_ARRAY`|A reference to an array with members of an unspecified type.|  
|`NATIVE_TYPE_LPSTRUCT`|A 32-bit integer pointer to a structure.|  
|`NATIVE_TYPE_CUSTOMMARSHALER`|A custom marshaler native type.<br /><br /> This must be followed by a string of the following format: "Native type name/0Custom marshaler type name/0Optional cookie/0" or "{Native type GUID}/0Custom marshaler type name/0Optional cookie/0"|  
|`NATIVE_TYPE_ERROR`|COM Interop.<br /><br /> With ELEMENT_TYPE_I4 this type maps to VT_HRESULT.|  
|`NATIVE_TYPE_IINSPECTABLE`|A native `IInspectable` type.|  
|`NATIVE_TYPE_HSTRING`|A native `HString`.|  
|`NATIVE_TYPE_MAX`|An invalid value.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 <xref:System.Runtime.InteropServices.UnmanagedType>  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
