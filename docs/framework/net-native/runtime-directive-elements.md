---
title: "Runtime Directive Elements"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3fe5848c-ecd7-4136-970b-8e48d250bde6
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Directive Elements
The runtime directives (rd.xml) file format supports the following runtime directive elements. See [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md) for a hierarchical representation.  
  
 [\<Application>](../../../docs/framework/net-native/application-element-net-native.md)  
 Applies runtime reflection policy to all types used by the app, and serves as a container for application-wide types and type members whose metadata is available for reflection at run time. This is a child of the [\<Directives>](../../../docs/framework/net-native/directives-element-net-native.md) element.  
  
 [\<Assembly>](../../../docs/framework/net-native/assembly-element-net-native.md)  
 Applies runnntime policy to all the types in an assembly. This is a child of the [\<Application>](../../../docs/framework/net-native/application-element-net-native.md) and [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) elements.  
  
 [\<AttributeImplies>](../../../docs/framework/net-native/attributeimplies-element-net-native.md)  
 If its containing [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) directive is an attribute, applies runtime policy to code elements to which that attribute is applied.  
  
 [\<Directives>](../../../docs/framework/net-native/directives-element-net-native.md)  
 The root element in every runtime directives file for [!INCLUDE[net_native](../../../includes/net-native-md.md)]. Its child elements are [\<Application>](../../../docs/framework/net-native/application-element-net-native.md) and [\<Library>](../../../docs/framework/net-native/library-element-net-native.md).  
  
 [\<Event>](../../../docs/framework/net-native/event-element-net-native.md)  
 Applies runtime policy to an event. This is a child of the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) and [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) elements.  
  
 [\<Field>](../../../docs/framework/net-native/field-element-net-native.md)  
 Applies runtime policy to a field. This is a child of the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) and [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) elements.  
  
 [\<GenericParameter>](../../../docs/framework/net-native/genericparameter-element-net-native.md)  
 Applies runtime policy to the parameter type of a generic type or method.  
  
 [\<ImpliesType>](../../../docs/framework/net-native/impliestype-element-net-native.md)  
 Applies runtime policy to a type, if that policy has been applied to the containing type or method.  
  
 [\<Library>](../../../docs/framework/net-native/library-element-net-native.md)  
 Applies runtime policy to all the types in an assembly. This is a child of the [\<Application>](../../../docs/framework/net-native/application-element-net-native.md) and [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) elements.  
  
 [\<Method>](../../../docs/framework/net-native/method-element-net-native.md)  
 Applies runtime policy to a method. This is a child of the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) and [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) elements.  
  
 [\<MethodInstantiation>](../../../docs/framework/net-native/methodinstantiation-element-net-native.md)  
 Applies runtime policy to a constructed generic method. This is a child of the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) and [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) elements.  
  
 [\<Namespace>](../../../docs/framework/net-native/namespace-element-net-native.md)  
 Applies runtime policy to all the types in a namespace.  
  
 [\<Parameter>](../../../docs/framework/net-native/parameter-element-net-native.md)  
 Applies runtime policy to the type of the argument passed to a method.  
  
 [\<Property>](../../../docs/framework/net-native/property-element-net-native.md)  
 Applies runtime policy to a property. This is a child of the [\<Type>](../../../docs/framework/net-native/type-element-net-native.md) and [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) elements.  
  
 [\<Subtypes>](../../../docs/framework/net-native/subtypes-element-net-native.md)  
 Applies runtime policy to all classes inherited from the containing type.  
  
 [\<Type>](../../../docs/framework/net-native/type-element-net-native.md)  
 Applies runtime policy to a type.  
  
 [\<TypeInstantiation>](../../../docs/framework/net-native/typeinstantiation-element-net-native.md)  
 Applies runtime policy to a constructed generic type.  
  
 [\<TypeParameter>](../../../docs/framework/net-native/typeparameter-element-net-native.md)  
 Applies runtime policy to the type represented by a <xref:System.Type> argument passed to a method.  
  
## See Also  
 [rd.xml Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)
