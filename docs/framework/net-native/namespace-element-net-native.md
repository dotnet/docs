---
title: "&lt;Namespace&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 57c614e5-18a9-4e87-bfd5-d0fe3396a192
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Namespace&gt; Element (.NET Native)
Applies runtime reflection policy to all the types in a specified namespace.  
  
## Syntax  
  
```xml  
<Namespace Name="namespace_name"   
           Activate="policy_type"   
           Browse="policy_type" />  
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
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. Specifies the name of the namespace.|  
|`Activate`|Reflection|Optional attribute. Controls runtime access to constructors to enable activation of instances.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about program elements, but does not enable any runtime access.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming.|  
|`Serialize`|Serialization|Optional attribute. Controls runtime access to constructors, fields, and properties, to enable type instances to be serialized and deserialized by libraries such as the Newtonsoft JSON serializer.|  
|`DataContractSerializer`|Serialization|Optional attribute. Controls policy for serialization that uses the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> class.|  
|`DataContractJsonSerializer`|Serialization|Optional attribute. Controls policy for JSON serialization that uses the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer?displayProperty=nameWithType> class.|  
|`XmlSerializer`|Serialization|Optional attribute. Controls policy for XML serialization that uses the <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType> class.|  
|`MarshalObject`|Interop|Optional attribute. Controls policy for marshaling reference types to Windows Runtime and COM.|  
|`MarshalDelegate`|Interop|Optional attribute. Controls policy for marshaling delegate types as function pointers to native code.|  
|`MarshalStructure`|Interop|Optional attribute. Controls policy for marshaling structures to native code.|  
  
## Name attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*namespace_name*|The namespace name. If the \<Namespace> element is a child of an [\<Application>](../../../docs/framework/net-native/application-element-net-native.md), [\<Library>](../../../docs/framework/net-native/library-element-net-native.md), or [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) element, *namespace_name* must be a fully qualified namespace name. If the \<Namespace> element is a child of another \<Namespace> element, *namespace_name* must be a relative namespace name.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type for all types in the namespace. Possible values are `All`, `Auto`, `Excluded`, `Public`, `PublicAndInternal`, `Required Public`, `Required PublicAndInternal`, and `Required All`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`<Namespace>`|Applies runtime reflection policy to all types in a parent namespace.|  
|[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|Applies reflection policy to a type.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|Serves as a container for application-wide types and type members whose metadata is available for reflection at run time. The [\<Application>](../../../docs/framework/net-native/application-element-net-native.md) element can have zero, one, or more [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) elements.|  
|[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|Applies runtime reflection policy to all the types in a specified assembly.|  
|[\<Library>](../../../docs/framework/net-native/library-element-net-native.md)|Defines the assembly that contains types and type members whose metadata is available for reflection at run time. The [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) element can have zero or one [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) element.|  
|`<Namespace>`|Applies reflection policy to all types in a parent namespace.|  
  
## Remarks  
 The `Activate`, `Browse`, `Dynamic`, and `Serialize` attributes are all optional. If none are present, the `<Namespace>` element serves only as a container for child elements. If they are present, the `<Namespace>` element applies runtime reflection policy to all the types in the specified namespace.  
  
 When it is a child of the [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) element, the `<Namespace>` element overrides the runtime reflection policy defined by the  [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md) element.  
  
## See Also  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)
