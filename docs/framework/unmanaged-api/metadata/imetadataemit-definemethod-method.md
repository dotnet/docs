---
title: "IMetaDataEmit::DefineMethod Method"
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
  - "IMetaDataEmit.DefineMethod"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineMethod"
helpviewer_keywords: 
  - "DefineMethod method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineMethod method [.NET Framework metadata]"
ms.assetid: 3e2102c5-48b7-4c0e-b805-7e2b5e156e3d
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineMethod Method
Creates a definition for a method or global function with the specified signature, and returns a token to that method definition.  
  
## Syntax  
  
```  
HRESULT DefineMethod (      
    [in]  mdTypeDef         td,   
    [in]  LPCWSTR           szName,   
    [in]  DWORD             dwMethodFlags,   
    [in]  PCCOR_SIGNATURE   pvSigBlob,   
    [in]  ULONG             cbSigBlob,   
    [in]  ULONG             ulCodeRVA,   
    [in]  DWORD             dwImplFlags,   
    [out] mdMethodDef      *pmd  
);  
```  
  
#### Parameters  
 `td`  
 [in] The `mdTypedef` token of the parent class or parent interface of the method. Set `td` to `mdTokenNil`, if you are defining a global function.  
  
 `szName`  
 [in] The member name in Unicode.  
  
 `dwMethodFlags`  
 [in] A value of the [CorMethodAttr](../../../../docs/framework/unmanaged-api/metadata/cormethodattr-enumeration.md) enumeration that specifies the attributes of the method or global function.  
  
 `pvSigBlob`  
 [in] The method signature. The signature is persisted as supplied. If you need to specify additional information for any parameters, use the [IMetaDataEmit::SetParamProps](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-setparamprops-method.md) method.  
  
 `cbSigBlob`  
 [in] The count of bytes in `pvSigBlob`.  
  
 `ulCodeRVA`  
 [in] The address of the code.  
  
 `dwImplFlags`  
 [in] A value of the [CorMethodImpl](../../../../docs/framework/unmanaged-api/metadata/cormethodimpl-enumeration.md) enumeration that specifies the implementation features of the method.  
  
 `pmd`  
 [out] The member token.  
  
## Remarks  
 The metadata API guarantees to persist methods in the same order as the caller emits them for a given enclosing class or interface, which is specified in the `td` parameter.  
  
 Additional information regarding the use of `DefineMethod` and particular parameter settings is given below.  
  
## Slots in the V-table  
 The runtime uses method definitions to set up v-table slots. In the case where one or more slots need to be skipped, such as to preserve parity with a COM interface layout, a dummy method is defined to take up the slot or slots in the v-table; set the `dwMethodFlags` to the `mdRTSpecialName` value of the [CorMethodAttr](../../../../docs/framework/unmanaged-api/metadata/cormethodattr-enumeration.md) enumeration and specify the name as:  
  
 _VtblGap\<*SequenceNumber*>\<\_*CountOfSlots*>  
  
 where *SequenceNumber* is the sequence number of the method and *CountOfSlots* is the number of slots to skip in the v-table. If *CountOfSlots* is omitted, 1 is assumed. These dummy methods are not callable from either managed or unmanaged code and any attempt to call them, from either managed or unmanaged code, generates an exception. Their only purpose is to take up space in the v-table that the runtime generates for COM integration.  
  
## Duplicate Methods  
 You should not define duplicate methods. That is, you should not call `DefineMethod` with a duplicate set of values in the `td`, `wzName`, and `pvSig` parameters. (These three parameters together uniquely define the method.). However, you can use a duplicate triple provided that, for one of the method definitions, you set the `mdPrivateScope` bit in the `dwMethodFlags` parameter. (The `mdPrivateScope` bit means that the compiler will not emit a reference to this method definition.)  
  
## Method Implementation Information  
 Information about the method implementation is often not known at the time the method is declared. Therefore, you do not need to pass values in the `ulCodeRVA` and `dwImplFlags` parameters when calling `DefineMethod`. The values can be supplied later through [IMetaDataEmit::SetMethodImplFlags](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-setmethodimplflags-method.md) or [IMetaDataEmit::SetRVA](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-setrva-method.md), as appropriate.  
  
 In some situations, such as platform invocation (PInvoke) or COM interop scenarios, the method body will not be supplied, and `ulCodeRVA` should be set to zero. In these situations, the method should not be tagged as abstract, because the runtime will locate the implementation.  
  
## Defining a Method for PInvoke  
 For each unmanaged function to be called through PInvoke, you must define a managed method that represents the target unmanaged function. To define the managed method, use `DefineMethod` with some of the parameters set to certain values, depending on the way in which PInvoke is used:  
  
-   True PInvoke - involves invocation of an external unmanaged method that resides in an unmanaged DLL.  
  
-   Local PInvoke - involves invocation of a native unmanaged method that is embedded in the current managed module.  
  
 The parameter settings are given in the following table.  
  
|Parameter|Values for true PInvoke|Values for local PInvoke|  
|---------------|-----------------------------|------------------------------|  
|`dwMethodFlags`||Set `mdStatic`; clear `mdSynchronized` and `mdAbstract`.|  
|`pvSigBlob`|A valid common language runtime (CLR) method signature with parameters that are valid managed types.|A valid CLR method signature with parameters that are valid managed types.|  
|`ulCodeRVA`||0|  
|`dwImplFlags`|Set `miCil` and `miManaged`.|Set `miNative` and `miUnmanaged`.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
