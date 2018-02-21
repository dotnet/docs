---
title: "XAML and Custom Classes for WPF"
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
  - "custom classes in XAML [WPF]"
  - "XAML [WPF], custom classes"
  - "classes [WPF], custom classes in XAML"
ms.assetid: e7313137-581e-4a64-8453-d44e15a6164a
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# XAML and Custom Classes for WPF
XAML as implemented in [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] frameworks supports the ability to define a custom class or structure in any [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] language, and then access that class using XAML markup. You can use a mixture of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)]-defined types and your custom types within the same markup file, typically by mapping the custom types to a XAML namespace prefix. This topic discusses the requirements that a custom class must satisfy to be usable as a XAML element.  
  
 
  
<a name="Custom_Classes_in_Applications_vs__in_Assemblies"></a>   
## Custom Classes in Applications or Assemblies  
 Custom classes that are used in XAML can be defined in two distinct ways: within the code-behind or other code that produces the primary [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application, or as a class in a separate assembly, such as an executable or DLL used as a class library. Each of these approaches has particular advantages and disadvantages.  
  
-   The advantage of creating a class library is that any such custom classes can be shared across many different possible applications. A separate library also makes versioning issues of applications easier to control, and simplifies creating a class where the intended class usage is as a root element on a XAML page.  
  
-   The advantage of defining the custom classes in the application is that this technique is relatively lightweight and minimizes the deployment and testing issues encountered when you introduce separate assemblies beyond the main application executable.  
  
-   Whether defined in the same or different assembly, custom classes need to be mapped between CLR  namespace and XML  namespace in order to be used in XAML as elements. See [XAML Namespaces and Namespace Mapping for WPF XAML](../../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md).  
  
<a name="Requirements_for_a_Custom_Class_as_a_XAML_Element"></a>   
## Requirements for a Custom Class as a XAML Element  
 In order to be able to be instantiated as an object element, your class must meet the following requirements:  
  
-   Your custom class must be public and support a default (parameterless) public constructor. (See following section for notes regarding structures.)  
  
-   Your custom class must not be a nested class. Nested classes and the "dot" in their general CLR usage syntax interfere with other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and/or XAML features such as attached properties.  
  
 In addition to enabling object element syntax, your object definition also enables property element syntax for any other public properties that take that object as the value type. This is because the object can now be instantiated as an object element and can fill the property element value of such a property.  
  
### Structures  
 Structures that you define as custom types are always able to be constructed in XAML  in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] .This is because the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] compilers implicitly create a default constructor for a structure that initializes all property values to their defaults. In some cases, the default construction behavior and/or object element usage for a structure is not desirable. This might be because the structure is intended to fill values and function conceptually as a union, where the values contained might have mutually exclusive interpretations and thus none of its properties are settable. A [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] example of such a structure is <xref:System.Windows.GridLength>. Generally, such structures should implement a type converter such that the values can be expressed in attribute form, using string conventions that create the different interpretations or modes of the structure's values. The structure should also expose similar behavior for code construction through a non-default constructor.  
  
<a name="Requirements_for_Properties_of_a_Custom_Class_as_XAML"></a>   
## Requirements for Properties of a Custom Class as XAML Attributes  
 Properties must reference a by-value type (such as a primitive), or use a class for type that has either a default constructor or a dedicated type converter that a XAML processor can access. In the CLR XAML implementation, XAML processors either find such converters through native support for language primitives, or through application of <xref:System.ComponentModel.TypeConverterAttribute> to a type or member in backing type definitions  
  
 Alternatively, the property may reference an abstract class type, or an interface. For abstract classes or interfaces, the expectation for XAML parsing is that the property value must be filled with practical class instances that implement the interface, or instances of types that derive from the abstract class.  
  
 Properties can be declared on an abstract class, but can only be set on practical classes that derive from the abstract class. This is because creating the object element for the class at all requires a public default constructor on the class.  
  
### TypeConverter Enabled Attribute Syntax  
 If you provide a dedicated, attributed type converter at the class level, the applied type conversion enables attribute syntax for any property that needs to instantiate that type. A type converter does not enable object element usage of the type; only the presence of a default constructor for that type enables object element usage. Therefore, properties that are type-converter enabled are generally speaking not usable in property syntax, unless the type itself also supports object element syntax. The exception to this is that you can specify a property element syntax, but have the property element contain a string. That usage is really essentially equivalent to an attribute syntax usage, and such a usage is not common unless there is a need for more robust whitespace handling of the attribute value. For example, the following is a property element usage that takes a string, and the attribute usage equivalent:  
  
 [!code-xaml[XamlOvwSupport#GoofyTCPE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#goofytcpe)]  
  
 [!code-xaml[XamlOvwSupport#GoofyTCPE2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#goofytcpe2)]  
  
 Examples of properties where attribute syntax is allowed but property element syntax that contains an object element is disallowed through XAML are various properties that take the <xref:System.Windows.Input.Cursor> type. The <xref:System.Windows.Input.Cursor> class has a dedicated type converter <xref:System.Windows.Input.CursorConverter>, but does not expose a default constructor, so the <xref:System.Windows.FrameworkElement.Cursor%2A> property can only be set through attribute syntax even though the actual <xref:System.Windows.Input.Cursor> type is a reference type.  
  
### Per-Property Type Converters  
 Alternatively, the property itself may declare a type converter at the property level. This enables a "mini language" that instantiates objects of the type of the property inline, by processing incoming string values of the attribute as input for a <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> operation based on the appropriate type. Typically this is done to provide a convenience accessor, and not as the sole means to enable setting a property in XAML. However, it is also possible to use type converters for attributes where you want to use existing [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] types that do not supply either a default constructor or an attributed type converter. Examples from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] API are certain properties that take the <xref:System.Globalization.CultureInfo> type. In this case, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] used the existing [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] <xref:System.Globalization.CultureInfo> type to better address compatibility and migration scenarios that were used in earlier versions of frameworks, but the <xref:System.Globalization.CultureInfo> type did not support the necessary constructors or type-level type conversion to be usable as a XAML property value directly.  
  
 Whenever you expose a property that has a XAML usage, particularly if you are a control author, you should strongly consider backing that property with a dependency property. This is particularly true if you use the existing [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] implementation of the XAML processor, because you can improve performance by using <xref:System.Windows.DependencyProperty> backing. A dependency property will expose property system features for your property that users will come to expect for a XAML accessible property. This includes features such as animation, data binding, and style support. For more information, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md) and [XAML Loading and Dependency Properties](../../../../docs/framework/wpf/advanced/xaml-loading-and-dependency-properties.md).  
  
### Writing and Attributing a Type Converter  
 You occasionally will need to write a custom <xref:System.ComponentModel.TypeConverter> derived class to provide type conversion for your property type. For instructions on how to derive from and create a type converter that can support XAML usages, and how to apply the <xref:System.ComponentModel.TypeConverterAttribute>, see [TypeConverters and XAML](../../../../docs/framework/wpf/advanced/typeconverters-and-xaml.md).  
  
<a name="Requirements_for_Events_of_a_Custom_Class_as_XAML"></a>   
## Requirements for XAML Event Handler Attribute Syntax on Events of a Custom Class  
 To be usable as a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] event, the event must be exposed as a public event on a class that supports a default constructor, or on an abstract class where the event can be accessed on derived classes. In order to be used conveniently as a routed event, your [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] event should implement explicit `add` and `remove` methods, which add and remove handlers for the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] event signature and forward those handlers to the <xref:System.Windows.UIElement.AddHandler%2A> and <xref:System.Windows.UIElement.RemoveHandler%2A> methods. These methods add or remove the handlers to the routed event handler store on the instance that the event is attached to.  
  
> [!NOTE]
>  It is possible to register handlers directly for routed events using <xref:System.Windows.UIElement.AddHandler%2A>, and to deliberately not define a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] event that exposes the routed event. This is not generally recommended because the event will not enable XAML attribute syntax for attaching handlers, and your resulting class will offer a less transparent XAML view of that type's capabilities.  
  
<a name="Collection_Properties"></a>   
## Writing Collection Properties  
 Properties that take a collection type have a XAML syntax that enables you to specify objects that are added to the collection. This syntax has two notable features.  
  
-   The object that is the collection object does not need to be specified in object element syntax. The presence of that collection type is implicit whenever you specify a property in XAML that takes a collection type.  
  
-   Child elements of the collection property in markup are processed to become members of the collection. Ordinarily, the code access to the members of a collection is performed through list/dictionary methods such as `Add`, or through an indexer. But XAML syntax does not support methods or indexers (exception: XAML 2009 can support methods, but using XAML 2009 restricts the possible WPF usages; see [XAML 2009 Language Features](../../../../docs/framework/xaml-services/xaml-2009-language-features.md)). Collections are obviously a very common requirement for building a tree of elements, and you need some way to populate these collections in declarative XAML. Therefore, child elements of a collection property are processed by adding them to the collection that is the collection property type value.  
  
 The .NET Framework XAML Services implementation and thus the WPF XAML processor uses the following definition for what constitutes a collection property. The property type of the property must implement one of the following:  
  
-   Implements <xref:System.Collections.IList>.  
  
-   Implements <xref:System.Collections.IDictionary> or the generic equivalent (<xref:System.Collections.Generic.IDictionary%602>).  
  
-   Derives from <xref:System.Array> (for more information about arrays in XAML, see [x:Array Markup Extension](../../../../docs/framework/xaml-services/x-array-markup-extension.md).)  
  
-   Implements <xref:System.Windows.Markup.IAddChild> (an interface defined by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]).  
  
 Each of these types in CLR has an `Add` method, which is used by the XAML processor to add items to the underlying collection when creating the object graph.  
  
> [!NOTE]
>  The generic `List` and `Dictionary` interfaces (<xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IDictionary%602>) are not supported for collection detection by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] XAML processor. However, you can use the <xref:System.Collections.Generic.List%601> class as a base class, because it implements <xref:System.Collections.IList> directly, or <xref:System.Collections.Generic.Dictionary%602> as a base class, because it implements <xref:System.Collections.IDictionary> directly.  
  
 When you declare a property that takes a collection, be cautious about how that property value is initialized in new instances of the type. If you are not implementing the property as a dependency property, then having the property use a backing field that calls the collection type constructor is adequate. If your property is a dependency property, then you may need to initialize the collection property as part of the default type constructor. This is because a dependency property takes its default value from metadata, and you typically do not want the initial value of a collection property to be a static, shared collection. There should be a collection instance per each containing type instance. For more information, see [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
 You can implement a custom collection type for your collection property. Because of implicit collection property treatment, the custom collection type does not need to provide a default constructor in order to be used in XAML implicitly. However, you can optionally provide a default constructor for the collection type. This can be a worthwhile practice. Unless you do provide a default constructor, you cannot explicitly declare the collection as an object element. Some markup authors might prefer to see the explicit collection as a matter of markup style. Also, a default constructor can simplify the initialization requirements when you create new objects that use your collection type as a property value.  
  
<a name="XAMLCONtent"></a>   
## Declaring XAML Content Properties  
 The XAML language defines the concept of a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] content property. Each class that is usable in object syntax can have exactly one XAML content property. To declare a property to be the XAML content property for your class, apply the <xref:System.Windows.Markup.ContentPropertyAttribute> as part of the class definition. Specify the name of the intended XAML content property as the <xref:System.Windows.Markup.ContentPropertyAttribute.Name%2A> in the attribute. The property is specified as a string by name, not as a reflection construct such as <xref:System.Reflection.PropertyInfo>.  
  
 You can specify a collection property to be the XAML content property. This results in a usage for that property whereby the object element can have one or more child elements, without any intervening collection object elements or property element tags. These elements are then treated as the value for the XAML content property and added to the backing collection instance.  
  
 Some existing XAML content properties use the property type of `Object`. This enables a XAML content property that can take primitive values such as a <xref:System.String> as well as taking a single reference object value. If you follow this model, your type is responsible for type determination as well as the handling of possible types. The typical reason for an <xref:System.Object> content type is to support both a simple means of adding object content as a string (which receives a default presentation treatment), or an advanced means of adding object content that specifies a non-default presentation or additional data.  
  
<a name="Serializing"></a>   
## Serializing XAML  
 For certain scenarios, such as if you are a control author, you may also want to assure that any object representation that can be instantiated in XAML can also be serialized back to equivalent XAML markup. Serialization requirements are not described in this topic. See [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md) and [Element Tree and Serialization](../../../../docs/framework/wpf/advanced/element-tree-and-serialization.md).  
  
## See Also  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md)  
 [Base Elements Overview](../../../../docs/framework/wpf/advanced/base-elements-overview.md)  
 [XAML Loading and Dependency Properties](../../../../docs/framework/wpf/advanced/xaml-loading-and-dependency-properties.md)
