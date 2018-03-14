---
title: "Defining Custom Types for Use with .NET Framework XAML Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "defining custom types [XAML Services]"
ms.assetid: c2667cbd-2f46-4a7f-9dfc-53696e35e8e4
caps.latest.revision: 11
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Defining Custom Types for Use with .NET Framework XAML Services
When you define custom types that are business objects or are types that do not have a dependency on specific frameworks, there are certain best practices for XAML you can follow. If you follow these practices, .NET Framework XAML Services and its XAML readers and XAML writers can discover the XAML characteristics of your type and give it appropriate representation in a XAML node stream using the XAML type system. This topic describes best practices for type definitions, member definitions, and CLR attributing of types or members.  
  
## Constructor Patterns and Type Definitions for XAML  
 To be instantiated as an object element in XAML, a custom class must meet the following requirements:  
  
-   The custom class must be public and must expose a default (parameterless) public constructor. (See following section for notes regarding structures.)  
  
-   The custom class must not be a nested class. The extra "dot" in the full-name path makes the class-namespace division ambiguous, and interferes with other XAML features such as attached properties.  
  
 If an object can be instantiated as an object element, the created object can fill the property element form of any properties that take the object as their underlying type.  
  
 You can still provide object values for types that do not meet these criteria, if you enable a value converter. For more information, see [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
### Structures  
 Structures are always able to be constructed in XAML, by CLR definition. This is because a CLR compiler implicitly creates a default constructor for a structure. This constructor initializes all property values to their defaults.  
  
 In some cases, the default construction behavior for a structure is not desirable. This might be because the structure is intended to fill values and function conceptually as a union. As a union, the contained values might have mutually exclusive interpretations, and therefore, none of its properties are settable. An example of such a structure in the WPF vocabulary is <xref:System.Windows.GridLength>. Such structures should implement a type converter so that the values can be expressed in attribute form, by using string conventions that create the different interpretations or modes of the structure values. The structure should also expose similar behavior for code construction through a non-default constructor.  
  
### Interfaces  
 Interfaces can be used as underlying types of members. The XAML type system checks the assignable list and expects that the object that is provided as the value can be assigned to the interface. There is no concept of how the interface must be presented as a XAML type as long as a relevant assignable type supports the XAML construction requirements.  
  
### Factory Methods  
 Factory methods are a XAML 2009 feature. They modify the XAML principle that objects must have default constructors. Factory methods are not documented in this topic. See [x:FactoryMethod Directive](../../../docs/framework/xaml-services/x-factorymethod-directive.md).  
  
## Enumerations  
 Enumerations have XAML native type conversion behavior. Enumeration constant names specified in XAML are resolved against the underlying enumeration type, and return the enumeration value to a XAML object writer.  
  
 XAML supports a flags-style usage for enumerations with <xref:System.FlagsAttribute> applied. For more information, see [XAML Syntax In Detail](../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md). ([XAML Syntax In Detail](../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md) is written for the WPF audience, but most of the information in that topic is relevant for XAML that is not specific to a particular implementing framework.)  
  
## Member Definitions  
 Types can define members for XAML usage. It is possible for types that define members that are XAML-usable even if that specific type is not XAML-usable. This is possible because of CLR inheritance. So long as some type that inherits the member supports XAML usage as a type, and the member supports XAML usage for its underlying type or has a native XAML syntax available, that member is XAML-usable.  
  
### Properties  
 If you define properties as a public CLR property using the typical CLR `get` and `set` accessor patterns and language-appropriate keywording, the XAML type system can report the property as a member with appropriate information provided for <xref:System.Xaml.XamlMember> properties, such as <xref:System.Xaml.XamlMember.IsReadPublic%2A> and <xref:System.Xaml.XamlMember.IsWritePublic%2A>.  
  
 Specific properties can enable a text syntax by applying <xref:System.ComponentModel.TypeConverterAttribute>. For more information, see [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
 In the absence of a text syntax or native XAML conversion and in the absence of further indirection, such as a markup extension usage, the type of a property (<xref:System.Xaml.XamlMember.TargetType%2A> in the XAML type system) must be able to return an instance to a XAML object writer by treating the target type as a CLR type.  
  
 If using XAML 2009, [x:Reference Markup Extension](../../../docs/framework/xaml-services/x-reference-markup-extension.md) can be used to provide values if the previous considerations are not met; however, that is more of a usage issue than a type definition issue.  
  
### Events  
 If you define events as a public CLR event, the XAML type system can report the event as a member with <xref:System.Xaml.XamlMember.IsEvent%2A> as `true`. Wiring the event handlers is not within the scope of .NET Framework XAML Services capabilities; this is left to specific frameworks and implementations.  
  
### Methods  
 Inline code for methods is not a default XAML capability. In most cases you do not directly reference method members from XAML, and the role of methods in XAML is only to provide support for specific XAML patterns. [x:FactoryMethod Directive](../../../docs/framework/xaml-services/x-factorymethod-directive.md) is an exception.  
  
### Fields  
 CLR design guidelines discourage nonstatic fields. For static fields, you can access static field values only through [x:Static Markup Extension](../../../docs/framework/xaml-services/x-static-markup-extension.md); in this case you are not doing anything special in the CLR definition to expose a field for [x:Static](../../../docs/framework/xaml-services/x-static-markup-extension.md) usages.  
  
## Attachable Members  
 Attachable members are exposed to XAML through an accessor method pattern on a defining type. The defining type itself does not need to be XAML-usable as an object. In fact, a common pattern is to declare a service class whose role is to own the attachable member and implement the related behaviors, but serve no other function such as a UI representation. For the following sections, the placeholder *PropertyName* represents the name of your attachable member. That name must be valid in the [XamlName Grammar](../../../docs/framework/xaml-services/xamlname-grammar.md).  
  
 Be cautious of name collisions between these patterns and other methods of a type. If a member exists that matches one of the patterns, it can be interpreted as an attachable member usage pathway by a XAML processor even if that was not your intention.  
  
#### The GetPropertyName Accessor  
 The signature for the `Get`*PropertyName* accessor must be:  
  
 `public static object Get` *PropertyName* `(object`  `target` `)`  
  
-   The `target` object can be specified as a more specific type in your implementation. You can use this to scope the usage of your attachable member; usages outside your intended scope will throw invalid cast exceptions that are then surfaced by a XAML parse error. The parameter name `target` is not a requirement, but is named `target` by convention in most implementations.  
  
-   The return value can be specified as a more specific type in your implementation.  
  
 To support a <xref:System.ComponentModel.TypeConverter> enabled text syntax for attribute usage of the attachable member, apply <xref:System.ComponentModel.TypeConverterAttribute> to the `Get`*PropertyName* accessor. Applying to the `get` instead of the `set` may seem nonintuitive; however, this convention can support the concept of read-only attachable members that are serializable, which is useful in designer scenarios.  
  
#### The SetPropertyName Accessor  
 The signature for the Set*PropertyName* accessor must be:  
  
 `public static void Set` *PropertyName* `(object`  `target` `, object`  `value` `)`  
  
-   The `target` object can be specified as a more specific type in your implementation, with same logic and consequences as described in the previous section.  
  
-   The `value` object can be specified as a more specific type in your implementation.  
  
 Remember that the value for this method is the input coming from the XAML usage, typically in attribute form. From attribute form there must be value converter support for a text syntax, and you attribute on the `Get`*PropertyName* accessor.  
  
### Attachable Member Stores  
 The accessor methods are typically not enough to provide a means to place attachable member values into an object graph, or to retrieve values out of the object graph and serialize them properly. To provide this functionality, the `target` objects in the previous accessor signatures must be capable of storing values. The storage mechanism should be consistent with the attachable member principle that the member is attachable to targets where the attachable member is not in the members list. .NET Framework XAML Services provides an implementation technique for attachable member stores through the APIs <xref:System.Xaml.IAttachedPropertyStore> and <xref:System.Xaml.AttachablePropertyServices>. <xref:System.Xaml.IAttachedPropertyStore> is used by the XAML writers to discover the store implementation, and should be implemented on the type that is the `target` of the accessors. The static <xref:System.Xaml.AttachablePropertyServices> APIs are used within the body of the accessors, and refer to the attachable member by its <xref:System.Xaml.AttachableMemberIdentifier>.  
  
## XAML-Related CLR Attributes  
 Correctly attributing your types, members, and assemblies is important in order to report XAML type system information to .NET Framework XAML Services. This is relevant if you intend your types for use with XAML systems that are directly based on .NET Framework XAML Services XAML readers and XAML writers, or if you define or use a XAML-utilizing framework that is based on those XAML readers and XAML writers.  
  
 For a listing of each XAML-related attribute that is relevant for XAML support of your custom types, see [XAML-Related CLR Attributes for Custom Types and Libraries](../../../docs/framework/xaml-services/xaml-related-clr-attributes-for-custom-types-and-libraries.md).  
  
## Usage  
 Usage of custom types requires that the markup author must map a prefix for the assembly and CLR namespace that contain the custom type. This procedure is not documented in this topic.  
  
## Access Level  
 XAML provides a means to load and instantiate types that have an `internal` access level. This capability is provided so that user code can define its own types, and then instantiate those classes from markup that is also part of the same user code scope.  
  
 An example from WPF is whenever user code defines a <xref:System.Windows.Controls.UserControl> that is intended as a way to refactor a UI behavior, but not as part of any possible extension mechanism that might be implied by declaring the supporting class with `public` access level. Such a <xref:System.Windows.Controls.UserControl> can be declared with `internal` access if the backing code is compiled into the same assembly from which it is referenced as a XAML type.  
  
 For an application that loads XAML under full trust and uses <xref:System.Xaml.XamlObjectWriter>, loading classes with `internal` access level is always enabled.  
  
 For an application that loads XAML under partial trust, you can control the access level characteristics by using the <xref:System.Xaml.Permissions.XamlAccessLevel> API. Also, deferral mechanisms (such as the WPF template system) must be able to propagate any access level permissions and preserve them for the eventual run time evaluations; this is handled internally by passing the <xref:System.Xaml.Permissions.XamlAccessLevel> information.  
  
### WPF Implementation  
 WPF XAML uses a partial-trust access model where if BAML is loaded under partial trust, access is restricted to <xref:System.Xaml.Permissions.XamlAccessLevel.AssemblyAccessTo%2A> for the assembly that is the BAML source. For deferral, WPF uses <xref:System.Xaml.IXamlObjectWriterFactory.GetParentSettings%2A?displayProperty=nameWithType> as a mechanism for passing the access level information.  
  
 In WPF XAML terminology, an *internal type* is a type that is defined by the same assembly that also includes the referencing XAML. Such a type can be mapped through a XAML namespace that deliberately omits the assembly= portion of a mapping, for example, `xmlns:local="clr-namespace:WPFApplication1"`.  If BAML references an internal type and that type has `internal` access level, this generates a `GeneratedInternalTypeHelper` class for the assembly. If you want to avoid `GeneratedInternalTypeHelper`, you either must use `public` access level, or must factor the relevant class into a separate assembly and make that assembly dependent.  
  
## See Also  
 [XAML-Related CLR Attributes for Custom Types and Libraries](../../../docs/framework/xaml-services/xaml-related-clr-attributes-for-custom-types-and-libraries.md)  
 [XAML Services](../../../docs/framework/xaml-services/index.md)
