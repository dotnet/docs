---
title: "Markup Extensions and WPF XAML"
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
  - "brace character [WPF]"
  - "Binding markup extensions [WPF]"
  - "RelativeSource markup extensions [WPF]"
  - "XAML [WPF], markup extensions"
  - "markup extensions [WPF]"
  - "nesting extension syntax [WPF]"
  - "curly brace characters ({})"
  - "TemplateBinding markup extensions [WPF]"
  - "StaticResource markup extensions [WPF]"
  - "literal curly brace characters ({})"
  - "characters [WPF], curly brace"
  - "DynamicResource markup extensions [WPF]"
ms.assetid: 618dc745-8b14-4886-833f-486d2254bb78
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Markup Extensions and WPF XAML
This topic introduces the concept of markup extensions for XAML, including their syntax rules, purpose, and the class object model that underlies them. Markup extensions are a general feature of the XAML language and of the .NET implementation of XAML services. This topic specifically details markup extensions for use in WPF XAML.  
  
  
<a name="XAML_Processors_and_Markup_Extensions"></a>   
## XAML Processors and Markup Extensions  
 Generally speaking, a XAML parser can either interpret an attribute value as a literal string that can be converted to a primitive, or convert it to an object by some means. One such means is by referencing a type converter; this is documented in the topic [TypeConverters and XAML](../../../../docs/framework/wpf/advanced/typeconverters-and-xaml.md). However, there are scenarios where different behavior is required. For example, a XAML processor can be instructed that a value of an attribute should not result in a new object in the object graph. Instead, the attribute should result in an object graph that makes a reference to an already constructed object in another part of the graph, or a static object. Another scenario is that a XAML processor can be instructed to use a syntax that provides non-default arguments to the constructor of an object. These are the types of scenarios where a markup extension can provide the solution.  
  
<a name="Basic_Markup_Extension_Syntax"></a>   
## Basic Markup Extension Syntax  
 A markup extension can be implemented to provide values for properties in an attribute usage, properties in a property element usage, or both.  
  
 When used to provide an attribute value, the syntax that distinguishes a markup extension sequence to a XAML processor is the presence of the opening and closing curly braces ({ and }). The type of markup extension is then identified by the string token immediately following the opening curly brace.  
  
 When used in property element syntax, a markup extension is visually the same as any other element used to provide a property element value: a XAML element declaration that references the markup extension class as an element, enclosed within angle brackets (<>).  
  
<a name="XAML_Defined_Markup_Extensions"></a>   
## XAML-Defined Markup Extensions  
 Several markup extensions exist that are not specific to the WPF implementation of XAML, but are instead implementations of intrinsics or features of XAML as a language. These markup extensions are implemented in the System.Xaml assembly as part of the general .NET Framework XAML services, and are within the XAML language XAML namespace. In terms of common markup usage, these markup extensions are typically identifiable by the `x:` prefix in the usage. The <xref:System.Windows.Markup.MarkupExtension> base class (also defined in System.Xaml) provides the pattern that all markup extensions should use in order to be supported in XAML readers and XAML writers, including in WPF XAML.  
  
-   `x:Type` supplies the <xref:System.Type> object for the named type. This facility is used most frequently in styles and templates. For details, see [x:Type Markup Extension](../../../../docs/framework/xaml-services/x-type-markup-extension.md).  
  
-   `x:Static` produces static values. The values come from value-type code entities that are not directly the type of a target property's value, but can be evaluated to that type. For details, see [x:Static Markup Extension](../../../../docs/framework/xaml-services/x-static-markup-extension.md).  
  
-   `x:Null` specifies `null` as a value for a property and can be used either for attributes or property element values. For details, see [x:Null Markup Extension](../../../../docs/framework/xaml-services/x-null-markup-extension.md).  
  
-   `x:Array` provides support for creation of general arrays in XAML syntax, for cases where the collection support provided by WPF base elements and control models is deliberately not used. For details, see [x:Array Markup Extension](../../../../docs/framework/xaml-services/x-array-markup-extension.md).  
  
> [!NOTE]
>  The `x:` prefix is used for the typical XAML namespace mapping of the XAML language intrinsics, in the root element of a XAML file or production. For example, the [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] templates for WPF applications initiate a XAML file using this `x:` mapping. You could choose a different prefix token in your own XAML namespace mapping, but this documentation will assume the default `x:` mapping as a means of identifying those entities that are a defined part of the XAML namespace for the XAML language, as opposed to the WPF default namespace or other XAML namespaces not related to a specific framework.  
  
<a name="WPF_Specific_Markup_Extensions"></a>   
## WPF-Specific Markup Extensions  
 The most common markup extensions used in WPF programming are those that support resource references (`StaticResource` and `DynamicResource`), and those that support data binding (`Binding`).  
  
-   `StaticResource` provides a value for a property by substituting the value of an already defined resource. A `StaticResource` evaluation is ultimately made at XAML load time and does not have access to the object graph at run time. For details, see [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md).  
  
-   `DynamicResource` provides a value for a property by deferring that value to be a run-time reference to a resource. A dynamic resource reference forces a new lookup each time that such a resource is accessed and has access to the object graph at run time. In order to get this access, `DynamicResource` concept is supported by dependency properties in the WPF property system, and evaluated expressions. Therefore you can only use `DynamicResource` for a dependency property target. For details, see [DynamicResource Markup Extension](../../../../docs/framework/wpf/advanced/dynamicresource-markup-extension.md).  
  
-   `Binding` provides a data bound value for a property, using the data context that applies to the parent object at run time. This markup extension is relatively complex, because it enables a substantial inline syntax for specifying a data binding. For details, see [Binding Markup Extension](../../../../docs/framework/wpf/advanced/binding-markup-extension.md).  
  
-   `RelativeSource` provides source information for a <xref:System.Windows.Data.Binding> that can navigate several possible relationships in the run-time object tree. This provides specialized sourcing for bindings that are created in multi-use templates or created in code without full knowledge of the surrounding object tree. For details, see [RelativeSource MarkupExtension](../../../../docs/framework/wpf/advanced/relativesource-markupextension.md).  
  
-   `TemplateBinding` enables a control template to use values for templated properties that come from object-model-defined properties of the class that will use the template. In other words, the property within the template definition can access a context that only exists once the template is applied. For details, see [TemplateBinding Markup Extension](../../../../docs/framework/wpf/advanced/templatebinding-markup-extension.md). For more information on the practical use of `TemplateBinding`, see [Styling with ControlTemplates Sample](http://go.microsoft.com/fwlink/?LinkID=160041).  
  
-   `ColorConvertedBitmap` supports a relatively advanced imaging scenario. For details, see [ColorConvertedBitmap Markup Extension](../../../../docs/framework/wpf/advanced/colorconvertedbitmap-markup-extension.md).  
  
-   `ComponentResourceKey` and `ThemeDictionary` support aspects of resource lookup, particularly for resources and themes that are packaged with custom controls. For more information, see [ComponentResourceKey Markup Extension](../../../../docs/framework/wpf/advanced/componentresourcekey-markup-extension.md), [ThemeDictionary Markup Extension](../../../../docs/framework/wpf/advanced/themedictionary-markup-extension.md), or [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
<a name="StarExtension"></a>   
## *Extension Classes  
 For both the general XAML language and WPF-specific markup extensions, the behavior of each markup extension is identified to a XAML processor through a `*Extension` class that derives from <xref:System.Windows.Markup.MarkupExtension>, and provides an implementation of the <xref:System.Windows.Markup.StaticExtension.ProvideValue%2A> method. This method on each extension provides the object that is returned when the markup extension is evaluated. The returned object is typically evaluated based on the various string tokens that are passed to the markup extension.  
  
 For example, the <xref:System.Windows.StaticResourceExtension> class provides the surface implementation of actual resource lookup so that its <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A> implementation returns the object that is requested, with the input of that particular implementation being a string that is used to look up the resource by its `x:Key`. Much of this implementation detail is unimportant if you are using an existing markup extension.  
  
 Some markup extensions do not use string token arguments. This is either because they return a static or consistent value, or because context for what value should be returned is available through one of the services passed through the `serviceProvider` parameter.  
  
 The `*Extension` naming pattern is for convenience and consistency. It is not necessary in order for a XAML processor to identify that class as support for a markup extension. So long as your codebase includes System.Xaml and uses .NET Framework XAML Services implementations, all that is necessary to be recognized as a XAML markup extension is to derive from <xref:System.Windows.Markup.MarkupExtension> and to support a construction syntax. WPF defines markup extension-enabling classes that do not follow the `*Extension` naming pattern, for example <xref:System.Windows.Data.Binding>. Typically the reason for this is that the class supports scenarios beyond pure markup extension support. In the case of <xref:System.Windows.Data.Binding>, that class supports run-time access to methods and properties of the object for scenarios that have nothing to do with XAML.  
  
### Extension Class Interpretation of Initialization Text  
 The string tokens following the markup extension name and still within the braces are interpreted by a XAML processor in one of the following ways:  
  
-   A comma always represents the separator or delimiter of individual tokens.  
  
-   If the individual separated tokens do not contain any equals signs, each token is treated as a constructor argument. Each constructor parameter must be given as the type expected by that signature, and in the proper order expected by that signature.  
  
    > [!NOTE]
    >  A XAML processor must call the constructor that matches the argument count of the number of pairs. For this reason, if you are implementing a custom markup extension, do not provide multiple parameters with the same argument count. The behavior for how a XAML processor behaves if more than one markup extension constructor path with the same parameter count exists is not defined, but you should anticipate that a XAML processor is permitted to throw an exception on usage if this situation exists in the markup extension type definitions.  
  
-   If the individual separated tokens contain equals signs, then a XAML processor first calls the default constructor for the markup extension. Then, each name=value pair is interpreted as a property name that exists on the markup extension, and a value to assign to that property.  
  
-   If there is a parallel result between the constructor behavior and the property setting behavior in a markup extension, it does not matter which behavior you use. It is more common usage to use the *property*`=`*value* pairs for markup extensions that have more than one settable property, if only because it makes your markup more intentional and you are less likely to accidentally transpose constructor parameters. (When you specify property=value pairs, those properties may be in any order.) Also, there is no guarantee that a markup extension supplies a constructor parameter that sets every one of its settable properties. For example, <xref:System.Windows.Data.Binding> is a markup extension, with many properties that are settable through the extension in *property*`=`*value* form, but <xref:System.Windows.Data.Binding> only supports two constructors: a default constructor, and one that sets an initial path.  
  
-   A literal comma cannot be passed to a markup extension without escapement.  
  
<a name="EscapeSequences"></a>   
## Escape Sequences and Markup Extensions  
 Attribute handling in a XAML processor uses the curly braces as indicators of a markup extension sequence. It is also possible to produce a literal curly brace character attribute value if necessary, by entering an escape sequence using an empty curly brace pair followed by the literal curly brace. See [{} Escape Sequence - Markup Extension](../../xaml-services/escape-sequence-markup-extension.md).  
  
<a name="Nesting"></a>   
## Nesting Markup Extensions in XAML Usage  
 Nesting of multiple markup extensions is supported, and each markup extension will be evaluated deepest first. For example, consider the following usage:  
  
```  
<Setter Property="Background"  
  Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}" />  
```  
  
 In this usage, the `x:Static` statement is evaluated first and returns a string. That string is then used as the argument for `DynamicResource`.  
  
## Markup Extensions and Property Element Syntax  
 When used as an object element that fills a property element value, a markup extension class is visually indistinguishable from a typical type-backed object element that can be used in XAML. The practical difference between a typical object element and a markup extension is that the markup extension is either evaluated to a typed value or deferred as an expression. Therefore the mechanisms for any possible type errors of property values for the markup extension will be different, similar to how a late-bound property is treated in other programming models. An ordinary object element will be evaluated for type match against the target property it is setting when the XAML is parsed.  
  
 Most markup extensions, when used in object element syntax to fill a property element, would not have content or any further property element syntax within. Thus you would close the object element tag, and provide no child elements. Whenever any object element is encountered by a XAML processor, the constructor for that class is called, which instantiates the object created from the parsed element. A markup extension class is no different: if you want your markup extension to be usable in object element syntax, you must provide a default constructor. Some existing markup extensions have at least one required property value that must be specified for effective initialization. If so, that property value is typically given as a property attribute on the object element. In the [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md) and [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md) reference pages, markup extensions that have required properties (and the names of required properties) will be noted. Reference pages will also note if either object element syntax or attribute syntax is disallowed for particular markup extensions. A notable case is [x:Array Markup Extension](../../../../docs/framework/xaml-services/x-array-markup-extension.md), which cannot support attribute syntax because the contents of that array must be specified within the tagging as content. The array contents are handled as general objects, therefore no default type converter for the attribute is feasible. Also, [x:Array Markup Extension](../../../../docs/framework/xaml-services/x-array-markup-extension.md) requires a `type` parameter.  
  
## See Also  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md)  
 [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md)  
 [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md)  
 [Binding Markup Extension](../../../../docs/framework/wpf/advanced/binding-markup-extension.md)  
 [DynamicResource Markup Extension](../../../../docs/framework/wpf/advanced/dynamicresource-markup-extension.md)  
 [x:Type Markup Extension](../../../../docs/framework/xaml-services/x-type-markup-extension.md)
