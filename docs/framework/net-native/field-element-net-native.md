---
title: "<Field> Element (.NET Native)"
ms.date: "03/30/2017"
ms.assetid: 6a14125f-1a8d-41a1-8a32-659ca0ad12de
author: "rpetrusha"
ms.author: "ronpet"
---
# \<Field> Element (.NET Native)
Applies runtime reflection policy to a field.  
  
## Syntax  
  
```xml  
<Field Name="field_name"  
       Browse="policy_type"  
       Dynamic="policy_type"  
       Serialize="policy_type" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. Specifies the field name.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about or enumerating the field but does not enable any dynamic access at run time.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to the field to enable dynamic programming. This policy ensures that a field can be set or retrieved dynamically at run time.|  
|`Serialize`|Serialization|Optional attribute. Controls runtime access to a field to enable type instances to be serialized by libraries such as the Newtonsoft JSON serializer or to be used for data binding.|  
  
## Name attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_name*|The field name. The type of the field is defined by the parent [\<Type>](type-element-net-native.md) or [\<TypeInstantiation>](typeinstantiation-element-net-native.md) element.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type for the field. Possible values are `Auto`, `Excluded`, `Included`, and `Required`. For more information, see [Runtime Directive Policy Settings](runtime-directive-policy-settings.md).|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Type>](type-element-net-native.md)|Applies reflection policy to a type and all its members.|  
|[\<TypeInstantiation>](typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type and all its members.|  
  
## Remarks  
 If a field's policy is not explicitly defined, it inherits the runtime policy of its parent element.  
  
## See also

- [Runtime Directive Elements](runtime-directive-elements.md)
- [Runtime Directives (rd.xml) Configuration File Reference](runtime-directives-rd-xml-configuration-file-reference.md)
- [Runtime Directive Policy Settings](runtime-directive-policy-settings.md)
