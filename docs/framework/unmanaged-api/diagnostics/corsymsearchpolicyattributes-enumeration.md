---
description: "Learn more about: CorSymSearchPolicyAttributes Enumeration"
title: "CorSymSearchPolicyAttributes Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorSymSearchPolicyAttributes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorSymSearchPolicyAttributes"
helpviewer_keywords: 
  - "CorSymSearchPolicyAttributes enumeration [.NET Framework debugging]"
ms.assetid: 03abde84-930a-49d3-bac3-23abb34a0184
topic_type: 
  - "apiref"
---
# CorSymSearchPolicyAttributes Enumeration

Specifies the policy to be used when doing a search for a symbol reader. These constants are used by the [ISymUnmanagedBinder2::GetReaderForFile2](isymunmanagedbinder2-getreaderforfile2-method.md) and [ISymUnmanagedBinder3::GetReaderFromCallback](isymunmanagedbinder3-getreaderfromcallback-method.md) methods.  
  
> [!IMPORTANT]
> It is a security risk to open a program database (PDB) file from an untrusted source.  
  
## Syntax  
  
```cpp  
typedef enum CorSymSearchPolicyAttributes  
{  
    AllowRegistryAccess      = 0x1,
    AllowSymbolServerAccess  = 0x2,  
    AllowOriginalPathAccess  = 0x4,     //
    AllowReferencePathAccess = 0x8  
} CorSymSearchPolicyAttributes;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`AllowRegistryAccess`|Queries the registry for symbol search paths.|  
|`AllowSymbolServerAccess`|Accesses a symbol server.|  
|`AllowOriginalPathAccess`|Searches the path specified in the Debug directory.|  
|`AllowReferencePathAccess`|Searches for the PDB in the place where the .exe file is.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Enumerations](diagnostics-symbol-store-enumerations.md)
