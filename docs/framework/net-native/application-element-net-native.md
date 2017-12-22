---
title: "&lt;Application&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b4e9b37a-059b-4076-8f56-cb3f9cef0cd9
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Application&gt; Element (.NET Native)
Serves as a container for application-wide types and type members whose metadata is available for reflection at run time, and applies runtime reflection policy to all the program elements in an app.  
  
 \<Directives> Element  
\<Application> Element (rd.xml)  
  
## Syntax  
  
```xml  
<Application Activate="policy_setting"  
             Browse="policy_setting"  
             Dynamic="policy_setting"  
             Serialize="policy_setting"  
             DataContractSerializer="policy_setting"  
             DataContractJsonSerializer="policy_setting"  
             XmlSerializer="policy_setting"  
             MarshalObject="policy_setting"  
             MarshalDelegate="policy_setting"  
             MarshalStructure="policy_setting" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements. In the Child Elements table, policy refers to the kind of metadata that is made available for particular program elements at run time.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Activate`|Reflection|Optional attribute. Controls runtime access to constructors to enable activation of instances.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about or enumerating the types, but does not enable any dynamic access at run time.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming.|  
|`Serialize`|Serialization|Optional attribute. Controls runtime access to constructors, fields, and properties, to enable type instances to be serialized and deserialized by libraries such as the Newtonsoft JSON serializer.|  
|`DataContractSerializer`|Serialization|Optional Attribute. Controls policy for serialization that uses the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> class.|  
|`DataContractJsonSerializer`|Serialization|Optional Attribute. Controls policy for JSON serialization that uses the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer?displayProperty=nameWithType> class.|  
|`XmlSerializer`|Serialization|Optional Attribute. Controls policy for XML serialization that uses the <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType> class.|  
|`MarshalObject`|Interop|Optional Attribute. Controls policy for marshaling reference types to Windows Runtime and COM.|  
|`MarshalDelegate`|Interop|Optional Attribute. Controls policy for marshaling delegate types as function pointers to native code.|  
|`MarshalStructure`|Interop|Optional Attribute. Controls policy for marshaling structures to native code.|  
  
## All attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting for this policy to apply to the types in the app. Possible values are `All`, `Auto`, `Excluded`, `Public`, `PublicAndInternal`, `Required Public`, `Required PublicAndInternal`, and `Required All`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|Applies policy to all the types in a particular assembly.|  
|[\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)|Applies policy to all the types in a particular namespace.|  
|[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|Applies policy to a particular type, such as a class or structure.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies policy to a constructed generic type. For example, a [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element could be used to define policy for a `List<String>` type.|  
|[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)|Applies policy to a method on a particular type.|  
|[\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)|Applies policy to a constructed generic method.|  
|[\<Property>](../../../docs/framework/net-native/property-element-net-native.md)|Applies policy to a property on a particular type.|  
|[\<Field>](../../../docs/framework/net-native/field-element-net-native.md)|Applies policy to a field on a particular type.|  
|[\<Event>](../../../docs/framework/net-native/event-element-net-native.md)|Applies policy to an event on a particular type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Directives>](../../../docs/framework/net-native/directives-element-net-native.md)|The root element of a runtime directives file.|  
  
## Remarks  
 The [\<Directives>](../../../docs/framework/net-native/directives-element-net-native.md) element can contain zero or one `<Application>` element. Multiple `<Application>` elements in a single reflection directives file are not supported.  
  
 The `<Application>` element can be used in one of two ways:  
  
-   As a container to define the program elements whose metadata is needed at run time. In this case, the `<Application>` element need not have any attributes. At compile time, compiler tools search all libraries, including .NET Framework core libraries, for program elements identified by child elements of the `<Application>` element. In contrast, compiler tools search only the library designated by the [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) element for program elements identified by the child elements of [\<Library>](../../../docs/framework/net-native/library-element-net-native.md).  
  
-   As an element that sets application-wide policy for reflection, serialization, and interop. The attributes of the `<Application>` element define application-wide policy, which may be overridden by the child elements defined by the `<Application>` or [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) element.  
  
## See Also  
 [\<Library> Element](../../../docs/framework/net-native/library-element-net-native.md)  
 [\<Directives> Element](../../../docs/framework/net-native/directives-element-net-native.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)
