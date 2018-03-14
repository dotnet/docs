---
title: "&lt;GenericParameter&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cbd49732-3615-49a5-a900-f96947cdc3e6
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;GenericParameter&gt; Element (.NET Native)
Applies policy to the parameter type of a generic type or method.  
  
## Syntax  
  
```xml  
<GenericParameter Name="generic_parameter_name"  
                  Activate="policy_type"  
                  Browse="policy_type"  
                  Dynamic="policy_type"  
                  Serialize="policy_type" />  
                  DataContractSerializer="policy_type"  
                  DataContractJsonSerializer="policy_type"  
                  XmlSerializer="policy_type"  
                  MarshalObject="policy_type"  
                  MarshalDelegate="policy_type"  
                  MarshalStructure="policy_type"  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. The name of the generic parameter. For example, for the generic delegate <xref:System.Func%603>, the value of the `Name` attribute is "TResult" to apply runtime policy to the delegate's return value.|  
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
|*generic_parameter_name*|Required attribute. The name of the generic type parameter. For example, for the generic delegate <xref:System.Func%603>, a *generic_parameter_name* value of "TResult" applies runtime policy to the delegate's return value.|  
  
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
|[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|Applies runtime reflection policy to a particular type, such as a class or structure.|  
  
## Remarks  
 The `<GenericParameter>` element is a child of either the [\<Method>](../../../docs/framework/net-native/method-element-net-native.md) or [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) element and is used to apply policy to a particular generic type parameter, which is specified by its name in the generic type or method signature.  
  
 The `<GenericParameter>` element is most useful when used with serializers. The following example uses the `<GenericParameter>` element to apply policy to the type `T` in calls to the NewtonSoft JSON serializer's [JsonConvert.DeserializeObject\<T>(String)](http://james.newtonking.com/json/help/index.html?topic=html/T_Newtonsoft_Json_JsonConvert.htm) method overloads.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Type Name="Newtonsoft.Json.JsonConvert" >  
      <Method Name="DeserializeObject{T}">  
         <GenericParameter Name="T" Serialize="Required All" />  
      </Method>  
   </Type>  
</Directives>  
```  
  
## See Also  
 [\<Method> Element](../../../docs/framework/net-native/method-element-net-native.md)  
 [\<Type> Element](../../../docs/framework/net-native/type-element-net-native.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)
