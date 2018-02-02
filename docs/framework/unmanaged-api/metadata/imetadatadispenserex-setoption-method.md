---
title: "IMetaDataDispenserEx::SetOption Method"
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
  - "IMetaDataDispenserEx.SetOption"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenserEx::SetOption"
helpviewer_keywords: 
  - "IMetaDataDispenserEx::SetOption method [.NET Framework metadata]"
  - "SetOption method [.NET Framework metadata]"
ms.assetid: 9f1c7ccd-7fb2-41d8-aa00-24b823376527
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenserEx::SetOption Method
Sets the specified option to a given value for the current metadata scope. The option controls how calls to the current metadata scope are handled.  
  
## Syntax  
  
```  
HRESULT SetOption (  
    [in] REFGUID optionId,   
    [in] const VARIANT *pValue  
);  
```  
  
#### Parameters  
 `optionId`  
 [in] A pointer to a GUID that specifies the option to be set.  
  
 `pValue`  
 [in] The value to use to set the option. The type of this value must be a variant of the specified option's type.  
  
## Remarks  
 The following table lists the available GUIDs that the `optionId` parameter can point to and the corresponding valid values for the `pValue` parameter.  
  
|GUID|Description|`pValue` Parameter|  
|----------|-----------------|------------------------|  
|MetaDataCheckDuplicatesFor|Controls which items are checked for duplicates. Each time you call an [IMetaDataEmit](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md) method that creates a new item, you can ask the method to check whether the item already exists in the current scope. For example, you can check for the existence of `mdMethodDef` items; in this case, when you call [IMetaDataEmit::DefineMethod](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-definemethod-method.md), it will check that the method does not already exist in the current scope. This check uses the key that uniquely identifies a given method: parent type, name, and signature.|Must be a variant of type UI4, and must contain a combination of the values of the [CorCheckDuplicatesFor](../../../../docs/framework/unmanaged-api/metadata/corcheckduplicatesfor-enumeration.md) enumeration.|  
|MetaDataRefToDefCheck|Controls which referenced items are converted to definitions. By default, the metadata engine will optimize the code by converting a referenced item to its definition if the referenced item is actually defined in the current scope.|Must be a variant of type UI4, and must contain a combination of the values of the [CorRefToDefCheck](../../../../docs/framework/unmanaged-api/metadata/correftodefcheck-enumeration.md) enumeration.|  
|MetaDataNotificationForTokenMovement|Controls which token remaps occurring during a metadata merge generate callbacks. Use the [IMetaDataEmit::SetHandler](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-sethandler-method.md) method to establish your [IMapToken](../../../../docs/framework/unmanaged-api/metadata/imaptoken-interface.md) interface.|Must be a variant of type UI4, and must contain a combination of the values of the [CorNotificationForTokenMovement](../../../../docs/framework/unmanaged-api/metadata/cornotificationfortokenmovement-enumeration.md) enumeration.|  
|MetaDataSetENC|Controls the behavior of edit-and-continue (ENC). Only one mode of behavior can be set at a time.|Must be a variant of type UI4, and must contain a value of the [CorSetENC](../../../../docs/framework/unmanaged-api/metadata/corsetenc-enumeration.md) enumeration. The value is not a bitmask.|  
|MetaDataErrorIfEmitOutOfOrder|Controls which emitted-out-of-order errors generate callbacks. Emitting metadata out of order is not fatal; however, if you emit metadata in an order that is favored by the metadata engine, the metadata is more compact and therefore can be more efficiently searched. Use the `IMetaDataEmit::SetHandler` method to establish your [IMetaDataError](../../../../docs/framework/unmanaged-api/metadata/imetadataerror-interface.md) interface.|Must be a variant of type UI4, and must contain a combination of the values of the [CorErrorIfEmitOutOfOrder](../../../../docs/framework/unmanaged-api/metadata/corerrorifemitoutoforder-enumeration.md) enumeration.|  
|MetaDataImportOption|Controls which kinds of items that were deleted during an ENC are retrieved by an enumerator.|Must be a variant of type UI4, and must contain a combination of the values of the [CorImportOptions Enumeration](../../../../docs/framework/unmanaged-api/metadata/corimportoptions-enumeration.md) enumeration.|  
|MetaDataThreadSafetyOptions|Controls whether the metadata engine obtains reader/writer locks, thereby ensuring thread safety. By default, the engine assumes that access is single-threaded by the caller, so no locks are obtained. Clients are responsible for maintaining proper thread synchronization when using the metadata API.|Must be a variant of type UI4, and must contain a value of the [CorThreadSafetyOptions](../../../../docs/framework/unmanaged-api/metadata/corthreadsafetyoptions-enumeration.md) enumeration. The value is not a bitmask.|  
|MetaDataGenerateTCEAdapters|Controls whether the type library importer should generate the tightly coupled event (TCE) adapters for COM connection point containers.|Must be a variant of type BOOL. If `pValue` is set to `true`, the type library importer generates the TCE adapters.|  
|MetaDataTypeLibImportNamespace|Specifies a non-default namespace for the type library that is being imported.|Must be either a null value or a variant of type BSTR. If `pValue` is a null value, the current namespace is set to null; otherwise, the current namespace is set to the string that is held in the variant's BSTR type.|  
|MetaDataLinkerOptions|Controls whether the linker should generate an assembly or a .NET Framework module file.|Must be a variant of type UI4, and must contain a combination of the values of the [CorLinkerOptions](../../../../docs/framework/unmanaged-api/metadata/corlinkeroptions-enumeration.md) enumeration.|  
|MetaDataRuntimeVersion|Specifies the version of the common language runtime against which this image was built. The version is stored as a string, such as "v1.0.3705".|Must be a null value, a VT_EMPTY value, or a variant of type BSTR. If `pValue` is null, the runtime version is set to null. If `pValue` is VT_EMPTY, the version is set to a default value, which is drawn from the version of Mscorwks.dll within which the metadata code is running. Otherwise, the runtime version is set to the string that is held in the variant's BSTR type.|  
|MetaDataMergerOptions|Specifies options for merging metadata.|Must be a variant of type UI4, and must contain a combination of the values of the `MergeFlags` enumeration, which is described in the CorHdr.h file.|  
|MetaDataPreserveLocalRefs|Disables optimizing local references into definitions.|Must contain a combination of the values of the [CorLocalRefPreservation](../../../../docs/framework/unmanaged-api/metadata/corlocalrefpreservation-enumeration.md) enumeration.|  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 [IMetaDataDispenser Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md)
