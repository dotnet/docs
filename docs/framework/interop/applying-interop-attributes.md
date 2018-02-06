---
title: "Applying Interop Attributes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "design-time attributes"
  - ".NET Framework, exposing components to COM"
  - "attributes [.NET Framework], design-time functionality"
  - "conversion-tool attributes"
  - "attributes [.NET Framework], interop-specific"
  - "attributes [.NET Framework], conversion-tool"
  - "interoperation with unmanaged code, applying attributes"
  - "interoperation with unmanaged code, exposing .NET Framework components"
  - "COM interop, exposing COM components"
  - "COM interop, applying attributes"
ms.assetid: b6014613-641c-4912-9e2f-83a99210a037
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Applying Interop Attributes
The <xref:System.Runtime.InteropServices> namespace provides three categories of interop-specific attributes: those applied by you at design time, those applied by COM interop tools and APIs during the conversion process, and those applied either by you or COM interop.  
  
 If you are unfamiliar with the task of applying attributes to managed code, see [Extending Metadata Using Attributes](../../../docs/standard/attributes/index.md). Like other custom attributes, you can apply interop-specific attributes to types, methods, properties, parameters, fields, and other members.  
  
## Design-Time Attributes  
 You can adjust the outcome of the conversion process performed by COM interop tools and APIs by using design-time attributes. The following table describes the attributes that you can apply to your managed source code. COM interop tools, on occasion, might also apply the attributes described in this table.  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.Runtime.InteropServices.AutomationProxyAttribute>|Specifies whether the type should be marshaled using the Automation marshaler or a custom proxy and stub.|  
|<xref:System.Runtime.InteropServices.ClassInterfaceAttribute>|Controls the type of interface generated for a class.|  
|<xref:System.Runtime.InteropServices.CoClassAttribute>|Identifies the CLSID of the original coclass imported from a type library.<br /><br /> COM interop tools typically apply this attribute.|  
|<xref:System.Runtime.InteropServices.ComImportAttribute>|Indicates that a coclass or interface definition was imported from a COM type library. The runtime uses this flag to know how to activate and marshal the type. This attribute prohibits the type from being exported back to a type library.<br /><br /> COM interop tools typically apply this attribute.|  
|<xref:System.Runtime.InteropServices.ComRegisterFunctionAttribute>|Indicates that a method should be called when the assembly is registered for use from COM, so that user-written code can be executed during the registration process.|  
|<xref:System.Runtime.InteropServices.ComSourceInterfacesAttribute>|Identifies interfaces that are sources of events for the class.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.ComUnregisterFunctionAttribute>|Indicates that a method should be called when the assembly is unregistered from COM, so that user-written code can execute during the process.|  
|<xref:System.Runtime.InteropServices.ComVisibleAttribute>|Renders types invisible to COM when the attribute value equals **false**. This attribute can be applied to an individual type or to an entire assembly to control COM visibility. By default, all managed, public types are visible; the attribute is not needed to make them visible.|  
|<xref:System.Runtime.InteropServices.DispIdAttribute>|Specifies the COM dispatch identifier (DISPID) of a method or field. This attribute contains the DISPID for the method, field, or property it describes.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.FieldOffsetAttribute>|Indicates the physical position of each field within a class when used with the **StructLayoutAttribute**, and the **LayoutKind** is set to Explicit.|  
|<xref:System.Runtime.InteropServices.GuidAttribute>|Specifies the globally unique identifier (GUID) of a class, interface, or an entire type library. The string passed to the attribute must be a format that is an acceptable constructor argument for the type **System.Guid**.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.IDispatchImplAttribute>|Indicates which **IDispatch** interface implementation the common language runtime uses when exposing dual interfaces and dispinterfaces to COM.|  
|<xref:System.Runtime.InteropServices.InAttribute>|Indicates that data should be marshaled in to the caller. Can be used to attribute parameters.|  
|<xref:System.Runtime.InteropServices.InterfaceTypeAttribute>|Controls how a managed interface is exposed to COM clients (Dual, IUnknown-derived, or IDispatch only).<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.LCIDConversionAttribute>|Indicates that an unmanaged method signature expects an LCID parameter.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.MarshalAsAttribute>|Indicates how the data in fields or parameters should be marshaled between managed and unmanaged code. The attribute is always optional because each data type has default marshaling behavior.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.OptionalAttribute>|Indicates that a parameter is optional.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.OutAttribute>|Indicates that the data in a field or parameter must be marshaled from a called object back to its caller.|  
|<xref:System.Runtime.InteropServices.PreserveSigAttribute>|Suppresses the HRESULT or retval signature transformation that normally takes place during interoperation calls. The attribute affects marshaling as well as type library exporting.<br /><br /> COM interop tools can apply this attribute.|  
|<xref:System.Runtime.InteropServices.ProgIdAttribute>|Specifies the ProgID of a .NET Framework class. Can be used to attribute classes.|  
|<xref:System.Runtime.InteropServices.StructLayoutAttribute>|Controls the physical layout of the fields of a class.<br /><br /> COM interop tools can apply this attribute.|  
  
## Conversion-Tool Attributes  
 The following table describes attributes that COM interop tools apply during the conversion process. You do not apply these attributes at design time.  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.Runtime.InteropServices.ComAliasNameAttribute>|Indicates the COM alias for a parameter or field type. Can be used to attribute parameters, fields, or return values.|  
|<xref:System.Runtime.InteropServices.ComConversionLossAttribute>|Indicates that information about a class or interface was lost when it was imported from a type library to an assembly.|  
|<xref:System.Runtime.InteropServices.ComEventInterfaceAttribute>|Identifies the source interface and the class that implements the methods of the event interface.|  
|<xref:System.Runtime.InteropServices.ImportedFromTypeLibAttribute>|Indicates that the assembly was originally imported from a COM type library. This attribute contains the type library definition of the original type library.|  
|<xref:System.Runtime.InteropServices.TypeLibFuncAttribute>|Contains the **FUNCFLAGS** that were originally imported for this function from the COM type library.|  
|<xref:System.Runtime.InteropServices.TypeLibTypeAttribute>|Contains the **TYPEFLAGS** that were originally imported for this type from the COM type library.|  
|<xref:System.Runtime.InteropServices.TypeLibVarAttribute>|Contains the **VARFLAGS** that were originally imported for this variable from the COM type library.|  
  
## See Also  
 <xref:System.Runtime.InteropServices>  
 [Exposing .NET Framework Components to COM](../../../docs/framework/interop/exposing-dotnet-components-to-com.md)  
 [Attributes](../../../docs/standard/attributes/index.md)  
 [Qualifying .NET Types for Interoperation](../../../docs/framework/interop/qualifying-net-types-for-interoperation.md)  
 [Packaging an Assembly for COM](../../../docs/framework/interop/packaging-an-assembly-for-com.md)
