---
title: "Runtime Directive Policy Settings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cb52b1ef-47fd-4609-b69d-0586c818ac9e
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Directive Policy Settings
> [!NOTE]
>  This topic refers to the .NET Native Developer Preview, which is pre-release software. You can download the preview from the [Microsoft Connect website](http://go.microsoft.com/fwlink/?LinkId=394611) (requires registration).  
  
 Runtime directive policy settings for .NET Native determine the availability of metadata for types and type members at run time. Without the necessary metadata, operations that rely on reflection, serialization and deserialization, or marshaling of .NET Framework types to COM or the Windows Runtime can fail and throw an exception. Most common exceptions are [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) and (in the case of interop) [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md).  
  
 Runtime policy settings are controlled by a runtime directives (.rd.xml) file. Each runtime directive defines policy for a particular program element, such as an assembly (the [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) element), a type (the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) element), or a method (the [\<Method>](../../../docs/framework/net-native/method-element-net-native.md) element). The directive includes one or more attributes that define the reflection policy types, the serialization policy types, and the interop policy types discussed in the next section. The value of the attribute defines the policy setting.  
  
## Policy types  
 Runtime directives files recognize three categories of policy types: reflection, serialization, and interop.  
  
-   Reflection policy types determine which metadata is made available at run time for reflection:  
  
    -   `Activate` controls runtime access to constructors, to enable activation of instances.  
  
    -   `Browse` controls querying for information about program elements.  
  
    -   `Dynamic` controls runtime access to all types and members to enable dynamic programming.  
  
     The following table lists the reflection policy types and the program elements with which they can be used.  
  
    |Element|Activate|Browse|Dynamic|  
    |-------------|--------------|------------|-------------|  
    |[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|✓|✓|✓|  
    |[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|✓|✓|✓|  
    |[\<AttributeImplies>](../../../docs/framework/net-native/attributeimplies-element-net-native.md)|✓|✓|✓|  
    |[\<Event>](../../../docs/framework/net-native/event-element-net-native.md)||✓|✓|  
    |[\<Field>](../../../docs/framework/net-native/field-element-net-native.md)||✓|✓|  
    |[\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)|✓|✓|✓|  
    |[\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)|✓|✓|✓|  
    |[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)||✓|✓|  
    |[\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)||✓|✓|  
    |[\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)|✓|✓|✓|  
    |[\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md)|✓|✓|✓|  
    |[\<Property>](../../../docs/framework/net-native/property-element-net-native.md)||✓|✓|  
    |[\<Subtypes>](../../../docs/framework/net-native/subtypes-element-net-native.md)|✓|✓|✓|  
    |[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|✓|✓|✓|  
    |[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|✓|✓|✓|  
    |[\<TypeParameter>](../../../docs/framework/net-native/typeparameter-element-net-native.md)|✓|✓|✓|  
  
-   Serialization policy types determine which metadata is made available at run time for serialization and deserialization:  
  
    -   `Serialize` controls runtime access to constructors, fields, and properties, to enable type instances to be serialized by third-party libraries such as the Newtonsoft JSON serializer.  
  
    -   `DataContractSerializer` controls runtime access to constructors, fields, and properties, to enable type instances to be serialized by the <xref:System.Runtime.Serialization.DataContractSerializer> class.  
  
    -   `DataContractJsonSerializer` controls runtime access to constructors, fields, and properties, to enable type instances to be serialized by the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> class.  
  
    -   `XmlSerializer` controls runtime access to constructors, fields, and properties, to enable type instances to be serialized by the <xref:System.Xml.Serialization.XmlSerializer> class.  
  
     The following table lists the serialization policy types and the program elements with which they can be used.  
  
    |Element|Serialize|DataContractSerializer|DataContractJsonSerializer|XmlSerializer|  
    |-------------|---------------|----------------------------|--------------------------------|-------------------|  
    |[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|✓|✓|✓|✓|  
    |[\<AttributeImplies>](../../../docs/framework/net-native/attributeimplies-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Event>](../../../docs/framework/net-native/event-element-net-native.md)|||||  
    |[\<Field>](../../../docs/framework/net-native/field-element-net-native.md)|✓||||  
    |[\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)|✓|✓|✓|✓|  
    |[\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)|||||  
    |[\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)|||||  
    |[\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Property>](../../../docs/framework/net-native/property-element-net-native.md)|✓||||  
    |[\<Subtypes>](../../../docs/framework/net-native/subtypes-element-net-native.md)|✓|✓|✓|✓|  
    |[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|✓|✓|✓|✓|  
    |[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|✓|✓|✓|✓|  
    |[\<TypeParameter>](../../../docs/framework/net-native/typeparameter-element-net-native.md)|✓|✓|✓|✓|  
  
-   Interop policy types determine which metadata is made available at run time to pass references types, value types, and function pointers to COM and the Windows Runtime:  
  
    -   `MarshalObject` controls native marshaling to COM and the Windows Runtime for reference types.  
  
    -   `MarshalDelegate` controls native marshaling of delegate types as function pointers.  
  
    -   `MarshalStructure` controls native marshaling to COM and the Windows Runtime for value types.  
  
     The following table lists the interop policy types and the program elements with which they can be used.  
  
    |Element|MarshalObject|MarshalDelegate|MarshalStructure|  
    |-------------|-------------------|---------------------|----------------------|  
    |[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|✓|✓|✓|  
    |[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|✓|✓|✓|  
    |[\<AttributeImplies>](../../../docs/framework/net-native/attributeimplies-element-net-native.md)|✓|✓|✓|  
    |[\<Event>](../../../docs/framework/net-native/event-element-net-native.md)||||  
    |[\<Field>](../../../docs/framework/net-native/field-element-net-native.md)||||  
    |[\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)|✓|✓|✓|  
    |[\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)|✓|✓|✓|  
    |[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)||||  
    |[\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)||||  
    |[\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)|✓|✓|✓|  
    |[\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md)|✓|✓|✓|  
    |[\<Property>](../../../docs/framework/net-native/property-element-net-native.md)||||  
    |[\<Subtypes>](../../../docs/framework/net-native/subtypes-element-net-native.md)|✓|✓|✓|  
    |[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|✓|✓|✓|  
    |[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|✓|✓|✓|  
    |[\<TypeParameter>](../../../docs/framework/net-native/typeparameter-element-net-native.md)|✓|✓|✓|  
  
## Policy settings  
 Each policy type can be set to one of the values listed in the following table. Note that elements that represent type members support a different set of policy settings than other elements.  
  
|Policy setting|Description|`Assembly`, `Namespace`, `Type`, and `TypeInstantiation` elements|`Event`, `Field`, `Method`, `MethodInstantiation`, and `Property` elements|  
|--------------------|-----------------|-----------------------------------------------------------------------|--------------------------------------------------------------------------------|  
|`All`|Enables the policy for all types and members that the .NET Native tool chain doesn't remove.|✓||  
|`Auto`|Specifies that the default policy should be used for the policy type for that program element. This is identical to omitting a policy for that policy type. `Auto` is typically used to indicate that policy is inherited from a parent element.|✓|✓|  
|`Excluded`|Specifies that the policy is disabled for a particular program element. For example, the runtime directive:<br /><br /> `<Type Name="BusinessClasses.Person" Browse="Excluded" Dynamic="Excluded" />`<br /><br /> specifies that metadata for the `BusinessClasses.Person` class isn't available either to browse or to dynamically instantiate and modify `Person` objects.|✓|✓|  
|`Included`|Enables a policy if metadata for the parent type is available.||✓|  
|`Public`|Enables the policy for public types or members, unless the tool chain determines that the type or member is unnecessary and therefore removes it. This setting differs from `Required Public`, which ensures that metadata for public types and members is always available even if the tool chain determines that it's unnecessary.|✓||  
|`PublicAndInternal`|Enables the policy for public and internal types or members, unless the tool chain determines that the type or member is unnecessary and therefore removes it. This setting differs from `Required PublicAndInternal`, which ensures that metadata for public and internal types and members is always available even if the tool chain determines that it's unnecessary.|✓||  
|`Required`|Specifies that the policy for a member is enabled and that metadata will be available even if the member appears to be used.||✓|  
|`Required Public`|Enables the policy for public types or members, and ensures that metadata for public types and members is always available. This setting differs from `Public`, which makes metadata for public types and members available only if the tool chain determines that it's necessary.|✓||  
|`Required PublicAndInternal`|Enables the policy for public and internal types or members, and ensures that metadata for public and internal types and members is always available. This setting differs from `PublicAndInternal`, which makes metadata for public and internal types and members available only if the tool chain determines that it's necessary.|✓||  
|`Required All`|Requires the tool chain to keep all types and members whether or not they're used, and enables policy for them.|✓||  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)
