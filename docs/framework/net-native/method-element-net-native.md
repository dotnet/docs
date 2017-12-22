---
title: "&lt;Method&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 348b49e5-589d-4eb2-a597-d6ff60ab52d1
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Method&gt; Element (.NET Native)
Applies runtime reflection policy to a constructor or method.  
  
## Syntax  
  
```xml  
<Method Name="method_name"  
        Signature="method_signature"  
        Browse="policy_type"  
        Dynamic="policy_type" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Attribute type|Description|  
|---------------|--------------------|-----------------|  
|`Name`|General|Required attribute. Specifies the method name.|  
|`Signature`|General|Optional attribute. Specifies the method signature. If multiple parameters are present, they are separated by commas. For example, the following `<Method>` element defines policy for the <xref:System.DateTimeOffset.ToString%28System.String%2CSystem.IFormatProvider%29> method.<br /><br /> `<Type Name="System.DateTime">    <Method Name="ToString" Signature="System.String,System.IFormatProvider"            Dynamic="Required" /> </Type>`<br /><br /> If the attribute is absent, the runtime directive applies to all overloads of the method.|  
|`Browse`|Reflection|Optional attribute. Controls querying for information about or enumerating a method but does not enable any dynamic invocation at run time.|  
|`Dynamic`|Reflection|Optional attribute. Controls runtime access to a constructor or method to enable dynamic programming. This policy ensures that a member can be invoked dynamically at run time.|  
  
## Name attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_name*|The method name. The type of the method is defined by the parent [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) or [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element.|  
  
## Signature attribute  
  
|Value|Description|  
|-----------|-----------------|  
|*method_signature*|The parameter types that form the method signature. Multiple parameters are separated by commas, for example, `"System.String,System.Int32,System.Int32)"`. Parameter type names should be fully qualified.|  
  
## All other attributes  
  
|Value|Description|  
|-----------|-----------------|  
|*policy_setting*|The setting to apply to this policy type. Possible values are `Auto`, `Excluded`, `Included`, and `Required`. For more information, see [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md)|Applies policy to the type of the argument passed to a method.|  
|[\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)|Applies policy to the parameter type of a generic type or method.|  
|[\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)|Applies policy to a type, if that policy has been applied to the method represented by the containing `<Method>` element.|  
|[\<TypeParameter>](../../../docs/framework/net-native/typeparameter-element-net-native.md)|Applies policy to the type represented by a <xref:System.Type> argument passed to a method.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Type>](../../../docs/framework/net-native/type-element-net-native.md)|Applies reflection policy to a type and all its members.|  
|[\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)|Applies reflection policy to a constructed generic type and all its members.|  
  
## Remarks  
 A `<Method>` element of a generic method applies its policy to all instantiations that do not have their own policy.  
  
 You can use the `Signature` attribute to specify policy for a particular method overload. Otherwise, if the `Signature` attribute is absent, the runtime directive applies to all overloads of the method.  
  
 You cannot define the runtime reflection policy for a constructor by using the `<Method>` element. Instead, use the `Activate` attribute of the  [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md), [\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md), [\<Type>](../../../docs/framework/net-native/type-element-net-native.md), or [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) element.  
  
## Example  
 The `Stringify` method in the following example is a general-purpose formatting method that uses reflection to convert an object to its string representation. In addition to calling the object's default `ToString` method, the method can produce a formatted result string by passing an object's `ToString` method a format string, an <xref:System.IFormatProvider> implementation, or both. It can also call one of the <xref:System.Convert.ToString%2A?displayProperty=nameWithType> overloads that converts a number to its binary, hexadecimal, or octal representation.  
  
 [!code-csharp[ProjectN_Reflection#7](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_reflection/cs/method1.cs#7)]  
  
 The `Stringify` method can be called by code like the following:  
  
 [!code-csharp[ProjectN_Reflection#7](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_reflection/cs/method1.cs#7)]  
  
 However, when compiled with .NET Native, the example can throw an number of exceptions at runtime, including <xref:System.NullReferenceException> and [MissingRuntimeArtifactException](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md) exceptions, This occurs because the `Stringify` method is intended primarily to support dynamically formatting the primitive types in the .NET Framework Class Library. However, their metadata is not made available by the default directives file. Even when their metadata is made available, however, the example throws [MissingRuntimeArtifactException](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md) exceptions because the appropriate `ToString` implementations have not been include in the native code.  
  
 These exceptions can all be eliminated by using the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) element to define the types whose metadata must be present, and by adding `<Method>` elements to ensure that the implementation of method overloads that can be called dynamically is also present. The following is the default.rd.xml file that eliminates these exceptions and allows the example to execute without error.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
  <Application>  
     <Assembly Name="*Application*" Dynamic="Required All" />  
  
     <Type Name = "System.Convert" Browse="Required Public" Dynamic="Required Public" >  
        <Method Name="ToString"    Dynamic ="Required" />  
     </Type>  
     <Type Name="System.Double" Browse="Required Public">  
        <Method Name="ToString" Dynamic="Required" />  
     </Type>  
     <Type Name ="System.Int32" Browse="Required Public" >  
        <Method Name="ToString" Dynamic="Required" />  
     </Type>  
     <Type Name ="System.Int64" Browse="Required Public" >  
        <Method Name="ToString" Dynamic="Required" />  
     </Type>  
     <Namespace Name="System" >  
        <Type Name="Byte" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="DateTime" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="Decimal" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="Guid" Browse ="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="Int16" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="SByte" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="Single" Browse="Required Public" >  
          <Method Name="ToString" Dynamic="Required" />           
        </Type>  
        <Type Name="TimeSpan" Browse="Required Public" >  
          <Method Name="ToString" Dynamic="Required" />           
        </Type>  
        <Type Name="UInt16" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="UInt32" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
        <Type Name="UInt64" Browse="Required Public" >  
           <Method Name="ToString" Dynamic="Required" />  
        </Type>  
     </Namespace>  
  </Application>  
</Directives>  
```  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)  
 [Runtime Directive Policy Settings](../../../docs/framework/net-native/runtime-directive-policy-settings.md)  
 [\<MethodInstantiation> Element](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)
