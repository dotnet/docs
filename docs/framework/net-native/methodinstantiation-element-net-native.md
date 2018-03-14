---
title: "&lt;MethodInstantiation&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a3355d78-2a88-4109-8521-830d7cae260a
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;MethodInstantiation&gt; Element (.NET Native)
Applies runtime reflection policy to a constructed generic method.  
  
## Syntax  
  
```xml  
<MethodInstantiation Name="method_name"  
                     Signature="method_signature"  
                     Arguments="method_arguments"  
                     Browse="policy_type"  
                     Dynamic="policy_type" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. Specifies the method name.|  
|`Signature`|General|Optional attribute. Specifies named parameters of the method. Multiple named parameters are separated by commas. The `Signature` attribute is used to differentiate overloaded methods.|  
|`Arguments`|General|Required attribute. Specifies the generic type arguments. If multiple arguments are present, they are separated by commas.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about or enumerating a method but does not enable any dynamic invocation at run time.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to a constructor or method to enable dynamic programming. This policy ensures that a member can be invoked dynamically at run time.|  
  
## Name attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_name*|The method name. The type of the method is defined by the parent [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) or [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element.|  
  
## Signature attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_signature*|Specifies the named parameters of the method. If multiple parameters are present, they are separated by commas.|  
  
## Arguments attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_arguments*|Specifies the generic type arguments. If multiple arguments are present, they are separated by commas. Each argument must consist of the fully qualified type name.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type for the method. Possible values are `Auto`, `Excluded`, `Included`, and `Required`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|Applies reflection policy to a type and all its members.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type and all its members.|  
  
## Remarks  
 The `<MethodInstantiation>` element overrides the runtime reflection policy of its corresponding open generic method.  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)  
 [\<Method> Element](../../../docs/framework/net-native/method-element-net-native.md)
