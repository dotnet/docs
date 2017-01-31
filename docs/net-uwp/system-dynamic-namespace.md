---
title: "System.Dynamic namespace | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f2539cbd-a679-4d9d-aa75-ecbe3c0c06ef
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Dynamic namespace
The `System.Dynamic` namespace provides classes and interfaces that support the dynamic language runtime (DLR).  
  
 This topic displays the types in the `System.Dynamic` namespace that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Dynamic namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Dynamic.BinaryOperationBinder>|Represents the binary dynamic operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.BindingRestrictions>|Represents a set of binding restrictions on the DynamicMetaObject under which the dynamic binding is valid.|  
|<xref:System.Dynamic.CallInfo>|Describes arguments in the dynamic binding process.|  
|<xref:System.Dynamic.ConvertBinder>|Represents the convert dynamic operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.CreateInstanceBinder>|Represents the dynamic create operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.DeleteIndexBinder>|Represents the dynamic delete index operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.DeleteMemberBinder>|Represents the dynamic delete member operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.DynamicMetaObject>|Represents the dynamic binding and a binding logic of an object participating in the dynamic binding.|  
|<xref:System.Dynamic.DynamicMetaObjectBinder>|Represents the dynamic call site binder that participates in the DynamicMetaObject binding protocol.|  
|<xref:System.Dynamic.DynamicObject>|Provides a base class for specifying dynamic behavior at run time. This class must be inherited from; you cannot instantiate it directly.|  
|<xref:System.Dynamic.ExpandoObject>|Represents an object whose members can be dynamically added and removed at run time.|  
|<xref:System.Dynamic.GetIndexBinder>|Represents the dynamic get index operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.GetMemberBinder>|Represents the dynamic get member operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.IDynamicMetaObjectProvider>|Represents a dynamic object, that can have its operations bound at runtime.|  
|<xref:System.Dynamic.IInvokeOnGetBinder>|Represents information about a dynamic get member operation that indicates if the get member should invoke properties when they perform the get operation.|  
|<xref:System.Dynamic.InvokeBinder>|Represents the invoke dynamic operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.InvokeMemberBinder>|Represents the invoke member dynamic operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.SetIndexBinder>|Represents the dynamic set index operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.SetMemberBinder>|Represents the dynamic set member operation at the call site, providing the binding semantic and the details about the operation.|  
|<xref:System.Dynamic.UnaryOperationBinder>|Represents the unary dynamic operation at the call site, providing the binding semantic and the details about the operation.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)