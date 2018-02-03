---
title: "&lt;Type&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e88d368-a886-4f1e-8eb6-6127979a9fce
caps.latest.revision: 33
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Type&gt; Element (.NET Native)
Applies runtime policy to a particular type, such as a class or structure.  
  
## Syntax  
  
```xml  
<Type Name="type_name"  
      Activate="policy_type"  
      Browse="policy_type"  
      Dynamic="policy_type"  
      Serialize="policy_type"   
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
|`Name`|General|Required attribute. Specifies the type name.|  
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
|*type_name*|The type name. If this `<Type>` element is the child of either a [\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md) element or another `<Type>` element, *type_name* can include the name of the type without its namespace. Otherwise, *type_name* must include the fully qualified type name.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type. Possible values are `All`, `Auto`, `Excluded`, `Public`, `PublicAndInternal`, `Required Public`, `Required PublicAndInternal`, and `Required All`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<AttributeImplies>](../../../docs/framework/net-native/attributeimplies-element-net-native.md)|If the containing type is an attribute, defines runtime policy for code elements to which the attribute is applied.|  
|[\<Event>](../../../docs/framework/net-native/event-element-net-native.md)|Applies reflection policy to an event belonging to this type.|  
|[\<Field>](../../../docs/framework/net-native/field-element-net-native.md)|Applies reflection policy to a field belonging to this type.|  
|[\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)|Applies policy to the parameter type of a generic type.|  
|[\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)|Applies policy to a type, if that policy has been applied to the type represented by the containing `<Type>` element.|  
|[\<Method>](../../../docs/framework/net-native/method-element-net-native.md)|Applies reflection policy to a method belonging to this type.|  
|[\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic method belonging to this type.|  
|[\<Property>](../../../docs/framework/net-native/property-element-net-native.md)|Applies reflection policy to a property belonging to this type.|  
|[\<Subtypes>](../../../docs/framework/net-native/subtypes-element-net-native.md)|Applies runtime policy to all classes inherited from the containing type.|  
|`<Type>`|Applies reflection policy to a nested type.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|Serves as a container for application-wide types and type members whose metadata is available for reflection at run time.|  
|[\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)|Applies reflection policy to all the types in a specified assembly.|  
|[\<Library>](../../../docs/framework/net-native/library-element-net-native.md)|Defines the assembly that contains types and type members whose metadata is available for reflection at run time.|  
|[\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)|Applies reflection policy to all the types in a namespace.|  
|`<Type>`|Applies reflection policy to a type and all its members.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type and all its members.|  
  
## Remarks  
 The reflection, serialization, and interop attributes are all optional. If none are present, the `<Type>` element serves as a container whose child types define policy for individual members.  
  
 If a `<Type>` element is the child of an [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md), [\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md), `<Type>`, or [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element, it overrides the policy settings defined by the parent element.  
  
 A `<Type>` element of a generic type applies its policy to all instantiations that do not have their own policy. The policy of constructed generic types is defined by the [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element.  
  
 If the type is a generic type, its name is decorated by a grave accent symbol (\`) followed by its number of generic parameters. For example, the `Name` attribute of a `<Type>` element for the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> class appears as `Name="System.Collections.Generic.List`1"`.  
  
## Example  
 The following example uses reflection to display information about the fields, properties, and methods of the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> class. The variable `b` in the example is a [TextBlock](http://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) control. Because the example simply retrieves type information, the availability of metadata is controlled by the `Browse` policy setting.  
  
 [!code-csharp[ProjectN_Reflection#3](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_reflection/cs/browsegenerictype1.cs#3)]  
  
 Because metadata for the <xref:System.Collections.Generic.List%601> class isn't automatically included by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain, the example fails to display the requested member information at run time. To provide the necessary metadata, add the following `<Type>` element to the runtime directives file. Note that, because we've provided a parent [<Namespace\>](../../../docs/framework/net-native/namespace-element-net-native.md) element, we don't have to provide a fully qualified type name in the `<Type>` element.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="*Application*" Dynamic="Required All" />  
      <Namespace Name ="System.Collections.Generic" >  
        <Type Name="List`1" Browse="Required All" />   
     </Namespace>  
   </Application>  
</Directives>  
```  
  
## Example  
 The following example uses reflection to retrieve a <xref:System.Reflection.PropertyInfo> object that represents the <xref:System.String.Chars%2A?displayProperty=nameWithType> property. It then uses the <xref:System.Reflection.PropertyInfo.GetValue%28System.Object%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method to retrieve the value of the seventh character in a string, and to display all the characters in the string. The variable `b` in the example is a [TextBlock](http://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) control.  
  
 [!code-csharp[ProjectN_Reflection#1](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_reflection/cs/propertyinfo1.cs#1)]  
  
 Because metadata for the <xref:System.String> object isn't available, the call to the <xref:System.Reflection.PropertyInfo.GetValue%28System.Object%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method throws a <xref:System.NullReferenceException> exception at run time when compiled with the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain. To eliminate the exception and provide the necessary metadata, add the following `<Type>` element to the runtime directives file:  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
  <Application>  
    <Assembly Name="*Application*" Dynamic="Required All" />  
    <Type Name="System.String" Dynamic="Required Public"/> -->  
  </Application>  
</Directives>  
```  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)
