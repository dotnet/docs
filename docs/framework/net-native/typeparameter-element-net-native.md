---
title: "&lt;TypeParameter&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d37bb1b7-1ddc-4c6d-8ecf-583f804a2479
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;TypeParameter&gt; Element (.NET Native)
Applies policy to the type represented by a Type argument passed to a method.  
  
## Syntax  
  
```xml  
<Parameter Name="parameter_name"  
           Activate="policy_type"  
           Browse="policy_type"  
           Dynamic="policy_type"  
           Serialize="policy_type"  
           DataContractSerializer="policy_type"  
           DataContractJsonSerializer="policy_type"  
           XmlSerializer="policy_type"  
           MarshalObject="policy_type"  
           MarshalDelegate="policy_type"  
           MarshalStructure="policy_type" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. The name of the parameter of type <xref:System.Type>. For example, for the method signature `Type.GetInterfaceMap(Type interfaceType)`, the value of the `Name` attribute is "interfaceType".|  
|`Activate`|Reflection|Optional attribute. Controls runtime access to constructors to enable activation of instances.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about program elements, but does not enable any runtime access.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming.|  
|`Serialize`|Serialization|Optional attribute. Controls runtime access to constructors, fields, and properties, to enable type instances to be serialized and deserialized by libraries such as the Newtonsoft JSON serializer.|  
|`DataContractSerializer`|Serialization|Optional attribute. Controls policy for serialization that uses the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> class.|  
|`DataContractJsonSerializer`|Serialization|Optional attribute. Controls policy for JSON serialization that uses the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer?displayProperty=nameWithType> class.|  
|`XmlSerializer`|Serialization|Optional attribute. Controls policy for XML serialization that uses the <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType> class.|  
|`MarshalObject`|Interop|Optional attribute. Controls policy for marshaling reference types to Windows Runtime and COM.|  
|`MarshalDelegate`|Interop|Optional attribute. Controls policy for marshaling delegate types as function pointers to native code.|  
|`MarshalStructure`|Interop|Optional attribute. Controls policy for marshaling value types to native code.|  
  
## Name attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*parameter_name*|The name of the parameter of type <xref:System.Type>. For example, for the method signature `Type.GetInterfaceMap(Type interfaceType)`, the value of the `Name` attribute is "interfaceType".|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type. Possible values are `All`, `Public`, `PublicAndInternal`, `Required Public`, `Required PublicAndInternal`, and `Required All`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)|Applies runtime reflection policy to a constructor or method.|  
  
## Remarks  
 The `<TypeParameter>` element is similar to the [\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md) element, except that it can be applied only to parameters of type <xref:System.Type>. It applies policy to whatever type is represented at run time by the type argument specified by the `Name` attribute.  
  
 For example, the NewtonSoft JSON serializer includes a static `JsonConvert.DeserializeObject(String value, Type type)` method. The following reflection directives:  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Type Name="Newtonsoft.Json.JsonConvert" >  
      <Method Name="DeserializeObject">  
         <GenericParameter Name="type" Serialize="Required All" />  
      </Method>  
   </Type>  
</Directives>  
```  
  
 specify that metadata for the runtime type represented by the `type` argument should be made available for serialization. If these runtime directives apply to a project that includes the following source code:  
  
```csharp  
Type t = typeof(StockQuote);  
Object obj = JsonConvert.DeserializeObject(data, t);  
```  
  
 the reflection directives make metadata for the `StockQuote` type available for the NewtonSoft JSON serializer at run time.  
  
## See Also  
 [\<Method> Element](../../../docs/framework/net-native/method-element-net-native.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)
