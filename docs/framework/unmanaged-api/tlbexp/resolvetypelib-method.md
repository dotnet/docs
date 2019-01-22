---
title: "ResolveTypeLib Method"
ms.date: "03/30/2017"
api_name: 
  - "ResolveTypeLib"
api_location: 
  - "tlbref.dll"
f1_keywords: 
  - "ResolveTypeLib"
helpviewer_keywords: 
  - "ITypeLibResolver::ResolveTypeLib method [.NET Framework]"
  - "ResolveTypeLib method [.NET Framework]"
ms.assetid: 95d2aa0d-8eeb-4a9f-a216-5249f7e2c167
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ResolveTypeLib Method
Resolves the simple name of a type library by returning its fully qualified path.  
  
## Syntax  
  
```  
HRESULT ResolveTypeLib(  
    [in]  BSTR      bstrSimpleName,  
    [in]  GUID      tlbid,  
    [in]  LCID      lcid,  
    [in]  USHORT    wMajorVersion,  
    [in]  USHORT    wMinorVersion,  
    [in]  SYSKIND   syskind,  
    [out] BSTR     *pbstrResolvedTlbName);  
```  
  
#### Parameters  
 `bstrSimpleName`  
 [in] A [BSTR](https://docs.microsoft.com/previous-versions/windows/desktop/automat/bstr) that contains the simple name of the type library.  
  
 `tlbid`  
 [in] The GUID assigned to the type library in the registry.  
  
 `lcid`  
 [in] The localization ID of the type library.  
  
 `wMajorVersion`  
 [in] The major version number of the type library. For example, for version *x.y*, the major version number is *x*.  
  
 `wMinorVersion`  
 [in] The minor version number of the type library. For example, for version *x.y*, the minor version number is *y*.  
  
 `syskind`  
 [in] A [SYSKIND](https://docs.microsoft.com/previous-versions/windows/desktop/api/oaidl/ne-oaidl-tagsyskind) flag that identifies the operating environment. Common values are SYS_WIN32 and SYS_WIN64.  
  
 `pbstrResolvedTlbName`  
 [out] A pointer to a [BSTR](https://docs.microsoft.com/previous-versions/windows/desktop/automat/bstr) that contains the full path of the type library named in the `bstrSimpleName` parameter.  
  
## Remarks  
 The `ResolveTypeLib` method is called by the [LoadTypeLibWithResolver function](../../../../docs/framework/unmanaged-api/tlbexp/loadtypelibwithresolver-function.md) during [Tlbexp.exe (Type Library Exporter)](../../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md) processing.  
  
 Custom implementations of this interface must return a [BSTR](https://docs.microsoft.com/previous-versions/windows/desktop/automat/bstr) that contains the full path of the type library named in the `bstrSimpleName` parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** TlbRef.idl, TlbRef.h  
  
 **Library:** TlbRef.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [Tlbexp Helper Functions](../../../../docs/framework/unmanaged-api/tlbexp/index.md)
- [LoadTypeLibEx](https://docs.microsoft.com/previous-versions/windows/desktop/api/oleauto/nf-oleauto-loadtypelibex)
