---
title: "Runtime Directive Elements"
ms.date: "03/30/2017"
ms.assetid: 3fe5848c-ecd7-4136-970b-8e48d250bde6
---
# Runtime Directive Elements
The runtime directives (rd.xml) file format supports the following runtime directive elements. See [Runtime Directives (rd.xml) Configuration File Reference](runtime-directives-rd-xml-configuration-file-reference.md) for a hierarchical representation.  
  
 [\<Application>](application-element-net-native.md)  
 Applies runtime reflection policy to all types used by the app, and serves as a container for application-wide types and type members whose metadata is available for reflection at run time. This is a child of the [\<Directives>](directives-element-net-native.md) element.  
  
 [\<Assembly>](assembly-element-net-native.md)  
 Applies runtime policy to all the types in an assembly. This is a child of the [\<Application>](application-element-net-native.md) and [\<Library>](library-element-net-native.md) elements.  
  
 [\<AttributeImplies>](attributeimplies-element-net-native.md)  
 If its containing [\<Type>](type-element-net-native.md) directive is an attribute, applies runtime policy to code elements to which that attribute is applied.  
  
 [\<Directives>](directives-element-net-native.md)  
 The root element in every runtime directives file for .NET Native. Its child elements are [\<Application>](application-element-net-native.md) and [\<Library>](library-element-net-native.md).  
  
 [\<Event>](event-element-net-native.md)  
 Applies runtime policy to an event. This is a child of the [\<Type>](type-element-net-native.md) and [\<TypeInstantiation>](typeinstantiation-element-net-native.md) elements.  
  
 [\<Field>](field-element-net-native.md)  
 Applies runtime policy to a field. This is a child of the [\<Type>](type-element-net-native.md) and [\<TypeInstantiation>](typeinstantiation-element-net-native.md) elements.  
  
 [\<GenericParameter>](genericparameter-element-net-native.md)  
 Applies runtime policy to the parameter type of a generic type or method.  
  
 [\<ImpliesType>](impliestype-element-net-native.md)  
 Applies runtime policy to a type, if that policy has been applied to the containing type or method.  
  
 [\<Library>](library-element-net-native.md)  
 Applies runtime policy to all the types in an assembly. This is a child of the [\<Application>](application-element-net-native.md) and [\<Library>](library-element-net-native.md) elements.  
  
 [\<Method>](method-element-net-native.md)  
 Applies runtime policy to a method. This is a child of the [\<Type>](type-element-net-native.md) and [\<TypeInstantiation>](typeinstantiation-element-net-native.md) elements.  
  
 [\<MethodInstantiation>](methodinstantiation-element-net-native.md)  
 Applies runtime policy to a constructed generic method. This is a child of the [\<Type>](type-element-net-native.md) and [\<TypeInstantiation>](typeinstantiation-element-net-native.md) elements.  
  
 [\<Namespace>](namespace-element-net-native.md)  
 Applies runtime policy to all the types in a namespace.  
  
 [\<Parameter>](parameter-element-net-native.md)  
 Applies runtime policy to the type of the argument passed to a method.  
  
 [\<Property>](property-element-net-native.md)  
 Applies runtime policy to a property. This is a child of the [\<Type>](type-element-net-native.md) and [\<TypeInstantiation>](typeinstantiation-element-net-native.md) elements.  
  
 [\<Subtypes>](subtypes-element-net-native.md)  
 Applies runtime policy to all classes inherited from the containing type.  
  
 [\<Type>](type-element-net-native.md)  
 Applies runtime policy to a type.  
  
 [\<TypeInstantiation>](typeinstantiation-element-net-native.md)  
 Applies runtime policy to a constructed generic type.  
  
 [\<TypeParameter>](typeparameter-element-net-native.md)  
 Applies runtime policy to the type represented by a <xref:System.Type> argument passed to a method.  
  
## See also

- [rd.xml Configuration File Reference](runtime-directives-rd-xml-configuration-file-reference.md)
