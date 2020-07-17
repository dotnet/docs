---
title: "<TypeInstantiation> Element (.NET Native)"
ms.date: "03/30/2017"
ms.assetid: a5eada64-075b-4162-9655-ded84e4681f2
---
# \<TypeInstantiation> Element (.NET Native)
Applies runtime reflection policy to a constructed generic type.  
  
## Syntax  
  
```xml  
<TypeInstantiation Name="type_name"  
                   Arguments="type_arguments"  
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
|`Arguments`|General|Required attribute. Specifies the generic type arguments. If multiple arguments are present, they are separated by commas.|  
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
|*type_name*|The type name. If this `<TypeInstantiation>` element is the child of a [\<Namespace>](namespace-element-net-native.md) element, a [\<Type>](type-element-net-native.md) element, or another `<TypeInstantiation>` element, *type_name* can specify the name of the type without its namespace. Otherwise, *type_name* must include the fully qualified type name. The type name isn't decorated. For example, for a <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> object, the `<TypeInstantiation>` element might appear as follows:<br /><br /> `\<TypeInstantiation Name=System.Collections.Generic.List Dynamic="Required Public" />`|  
  
## Arguments attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*type_argument*|Specifies the generic type arguments. If multiple arguments are present, they are separated by commas. Each argument must consist of the fully qualified type name.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type for the constructed generic type. Possible values are `All`, `Auto`, `Excluded`, `Public`, `PublicAndInternal`, `Required Public`, `Required PublicAndInternal`, and `Required All`. For more information, see [Runtime Directive Policy Settings](runtime-directive-policy-settings.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Event>](event-element-net-native.md)|Applies reflection policy to an event belonging to this type.|  
|[\<Field>](field-element-net-native.md)|Applies reflection policy to a field belonging to this type.|  
|[\<ImpliesType>](impliestype-element-net-native.md)|Applies policy to a type, if that policy has been applied to the type represented by the containing `<TypeInstantiation>` element.|  
|[\<Method>](method-element-net-native.md)|Applies reflection policy to a method belonging to this type.|  
|[\<MethodInstantiation>](methodinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic method belonging to this type.|  
|[\<Property>](property-element-net-native.md)|Applies reflection policy to a property belonging to this type.|  
|[\<Type>](type-element-net-native.md)|Applies reflection policy to a nested type.|  
|`<TypeInstantiation>`|Applies reflection policy to a nested constructed generic type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Application>](application-element-net-native.md)|Serves as a container for application-wide types and type members whose metadata is available for reflection at run time.|  
|[\<Assembly>](assembly-element-net-native.md)|Applies reflection policy to all the types in a specified assembly.|  
|[\<Library>](library-element-net-native.md)|Defines the assembly that contains types and type members whose metadata is available for reflection at run time.|  
|[\<Namespace>](namespace-element-net-native.md)|Applies reflection policy to all the types in a namespace.|  
|[\<Type>](type-element-net-native.md)|Applies reflection policy to a type and all its members.|  
|`<TypeInstantiation>`|Applies reflection policy to a constructed generic type and all its members.|  
  
## Remarks  
 The reflection, serialization, and interop attributes are all optional. However, at least one must be present.  
  
 If a `<TypeInstantiation>` element is the child of an [\<Assembly>](assembly-element-net-native.md), [\<Namespace>](namespace-element-net-native.md), or [\<Type>](type-element-net-native.md), element, it overrides the policy settings defined by the parent element. If a [\<Type>](type-element-net-native.md) element defines a corresponding generic type definition, the `<TypeInstantiation>` element overrides runtime reflection policy only for instantiations of the specified constructed generic type.  
  
## Example  
 The following example uses reflection to retrieve the generic type definition from a constructed <xref:System.Collections.Generic.Dictionary%602> object. It also uses reflection to display information about <xref:System.Type> objects that represent constructed generic types and generic type definitions. The variable `b` in the example is a <xref:Windows.UI.Xaml.Controls.TextBlock> control.  
  
 [!code-csharp[ProjectN_Reflection#2](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_reflection/cs/makegenerictype1.cs#2)]  
  
 After compilation with the .NET Native tool chain, the example throws a [MissingMetadataException](missingmetadataexception-class-net-native.md) exception on the line that calls the <xref:System.Type.GetGenericTypeDefinition%2A?displayProperty=nameWithType> method. You can eliminate the exception and provide the necessary metadata by adding the following `<TypeInstantiation>` element to the runtime directives file:  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
  <Application>  
    <Assembly Name="*Application*" Dynamic="Required All" />  
     <TypeInstantiation Name="System.Collections.Generic.Dictionary"  
                        Arguments="System.String,GenericType.Example"  
                        Dynamic="Required Public" />  
  </Application>  
</Directives>  
```  
  
## See also

- [Runtime Directives (rd.xml) Configuration File Reference](runtime-directives-rd-xml-configuration-file-reference.md)
- [Runtime Directive Elements](runtime-directive-elements.md)
- [Runtime Directive Policy Settings](runtime-directive-policy-settings.md)
