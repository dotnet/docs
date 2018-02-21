---
title: "XAML Overview (WPF)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "user interfaces [XAML]"
  - "classes [XAML]"
  - "root element [XAML]"
  - "XAML [WPF], about XAML"
  - "base classes [XAML]"
  - "routed events [WPF]"
  - "code-behind files [WPF], XAML"
  - "collection properties [XAML]"
  - "events [XAML]"
  - "property element [XAML]"
  - "content models [XAML]"
  - "Extensible Application Markup Language (see XAML)"
  - "attribute syntax [XAML]"
ms.assetid: a80db4cd-dd0f-479f-a45f-3740017c22e4
caps.latest.revision: 57
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# XAML Overview (WPF)
This topic describes the features of the XAML language and demonstrates how you can use XAML to write [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] applications. This topic specifically describes XAML as implemented by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. XAML itself is a larger language concept than [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
  
  
<a name="what_is_xaml"></a>   
## What is XAML?  
 XAML is a declarative markup language. As applied to the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] programming model, XAML simplifies creating a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] for a [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] application. You can create visible [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements in the declarative XAML markup, and then separate the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] definition from the run-time logic by using code-behind files, joined to the markup through partial class definitions. XAML directly represents the instantiation of objects in a specific set of backing types defined in assemblies. This is unlike most other markup languages, which are typically an interpreted language without such a direct tie to a backing type system. XAML enables a workflow where separate parties can work on the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] and the logic of an application, using potentially different tools.  
  
 When represented as text, XAML files are XML files that generally have the `.xaml` extension. The files can be encoded by any XML encoding, but encoding as UTF-8 is typical.  
  
 The following example shows how you might create a button as part of a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)]. This example is just intended to give you a flavor of how XAML represents common [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] programming metaphors (it is not a complete sample).  
  
 [!code-xaml[XAMLOvwSupport#DirtSimple](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page2.xaml#dirtsimple)]  
  
<a name="xaml_syntax_in_brief"></a>   
## XAML Syntax in Brief  
 The following sections explain the basic forms of XAML syntax, and give a short markup example. These sections are not intended to provide complete information about each syntax form, such as how these are represented in the backing type system. For more information about the specifics of XAML syntax for each of the syntax forms introduced in this topic, see [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
 Much of the material in the next few sections will be elementary to you, if you have previous familiarity with the XML language. This is a consequence of one of the basic design principles of XAML.  The XAML language defines concepts of its own, but these concepts work within the XML language and markup form.  
  
### XAML Object Elements  
 An object element typically declares an instance of a type. That type is defined in the assemblies that provide the backing types for a technology that uses XAML as a language.  
  
 Object element syntax always starts with an opening angle bracket (\<). This is followed by the name of the type where you want to create an instance. (The name can possibly include a prefix, a concept that will be explained later.) After this, you can optionally declare attributes on the object element. To complete the object element tag, end with a closing angle bracket (>). You can instead use a self-closing form that does not have any content, by completing the tag with a forward slash and closing angle bracket in succession (/>). For example, look at the previously shown markup snippet again:  
  
 [!code-xaml[XAMLOvwSupport#DirtSimple](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page2.xaml#dirtsimple)]  
  
 This specifies two object elements: `<StackPanel>` (with content, and a closing tag later), and `<Button .../>` (the self-closing form, with several attributes). The object elements `StackPanel` and `Button` each map to the name of a class that is defined by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and is part of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] assemblies. When you specify an object element tag, you create an instruction for XAML processing to create a new instance. Each instance is created by calling the default constructor of the underlying type when parsing and loading the XAML.  
  
### Attribute Syntax (Properties)  
 Properties of an object can often be expressed as attributes of the object element. An attribute syntax names the property that is being set in attribute syntax, followed by the assignment operator (=). The value of an attribute is always specified as a string that is contained within quotation marks.  
  
 Attribute syntax is the most streamlined property setting syntax and is the most intuitive syntax to use for developers who have used markup languages in the past. For example, the following markup creates a button that has red text and a blue background in addition to display text specified as `Content`.  
  
 [!code-xaml[XAMLOvwSupport#BlueRedButton](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#blueredbutton)]  
  
### Property Element Syntax  
 For some properties of an object element, attribute syntax is not possible, because the object or information necessary to provide the property value cannot be adequately expressed within the quotation mark and string restrictions of attribute syntax. For these cases, a different syntax known as property element syntax can be used.  
  
 The syntax for the property element start tag is `<`*typeName*`.`*propertyName*`>`. Generally, the content of that tag is an object element of the type that the property takes as its value . After specifying content, you must close the property element with an end tag. The syntax for the end tag is `</`*typeName*`.`*propertyName*`>`.  
  
 If an attribute syntax is possible, using the attribute syntax is typically more convenient and enables a more compact markup, but that is often just a matter of style, not a technical limitation. The following example shows the same properties being set as in the previous attribute syntax example, but this time by using property element syntax for all properties of the `Button`.  
  
 [!code-xaml[XAMLOvwSupport#BlueRedButtonPE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#blueredbuttonpe)]  
  
### Collection Syntax  
 The XAML language includes some optimizations that produce more human-readable markup. One such optimization is that if a particular property takes a collection type, then items that you declare in markup as child elements within that property's value become part of the collection. In this case a collection of child object elements is the value being set to the collection property.  
  
 The following example shows collection syntax for setting values of the <xref:System.Windows.Media.GradientBrush.GradientStops%2A> property:  
  
```xaml  
<LinearGradientBrush>  
  <LinearGradientBrush.GradientStops>  
    <!-- no explicit new GradientStopCollection, parser knows how to find or create -->  
    <GradientStop Offset="0.0" Color="Red" />  
    <GradientStop Offset="1.0" Color="Blue" />  
  </LinearGradientBrush.GradientStops>  
</LinearGradientBrush>  
```  
  
### XAML Content Properties  
 XAML specifies a language feature whereby a class can designate exactly one of its properties to be the XAML content property. Child elements of that object element are used to set the value of that content property. In other words, for the content property uniquely, you can omit a property element when setting that property in XAML markup and produce a more visible parent/child metaphor in the markup.  
  
 For example, <xref:System.Windows.Controls.Border> specifies a content property of <xref:System.Windows.Controls.Decorator.Child%2A>. The following two <xref:System.Windows.Controls.Border> elements are treated identically. The first one takes advantage of the content property syntax and omits the `Border.Child` property element. The second one shows `Border.Child` explicitly.  
  
```xaml  
<Border>  
  <TextBox Width="300"/>  
</Border>  
<!--explicit equivalent-->  
<Border>  
  <Border.Child>  
    <TextBox Width="300"/>  
  </Border.Child>  
</Border>  
```  
  
 As a rule of the XAML language, the value of a XAML content property must be given either entirely before or entirely after any other property elements on that object element. For instance, the following markup does not compile:  
  
```  
<Button>I am a   
  <Button.Background>Blue</Button.Background>  
  blue button</Button>  
```  
  
 For more information about this restriction on XAML content properties, see the "XAML Content Properties" section of [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
### Text Content  
 A small number of XAML elements can directly process text as their content. To enable this, one of the following cases must be true:  
  
-   The class must declare a content property, and that content property must be of a type assignable to a string (the type could be <xref:System.Object>). For instance, any <xref:System.Windows.Controls.ContentControl> uses <xref:System.Windows.Controls.ContentControl.Content%2A> as its content property and it is type <xref:System.Object>, and this supports the following usage on a practical <xref:System.Windows.Controls.ContentControl> such as a <xref:System.Windows.Controls.Button>: `<Button>Hello</Button>`.  
  
-   The type must declare a type converter, in which case the text content is used as initialization text for that type converter. For example, `<Brush>Blue</Brush>`. This case is less common in practice.  
  
-   The type must be a known XAML language primitive.  
  
### Content Properties and Collection Syntax Combined  
 Consider this example:  
  
```xaml  
<StackPanel>  
  <Button>First Button</Button>  
  <Button>Second Button</Button>  
</StackPanel>  
```  
  
 Here, each <xref:System.Windows.Controls.Button> is a child element of <xref:System.Windows.Controls.StackPanel>. This is a streamlined and intuitive markup that omits two tags for two different reasons.  
  
-   **Omitted StackPanel.Children property element:** <xref:System.Windows.Controls.StackPanel> derives from <xref:System.Windows.Controls.Panel>. <xref:System.Windows.Controls.Panel> defines <xref:System.Windows.Controls.Panel.Children%2A?displayProperty=nameWithType> as its XAML content property.  
  
-   **Omitted UIElementCollection object element:** The <xref:System.Windows.Controls.Panel.Children%2A?displayProperty=nameWithType> property takes the type <xref:System.Windows.Controls.UIElementCollection>, which implements <xref:System.Collections.IList>. The collection's element tag can be omitted, based on the XAML rules for processing collections such as <xref:System.Collections.IList>. (In this case, <xref:System.Windows.Controls.UIElementCollection> actually cannot be instantiated because it does not expose a default constructor, and that is why the <xref:System.Windows.Controls.UIElementCollection> object element is shown commented out).  
  
```xaml  
<StackPanel>  
  <StackPanel.Children>  
    <!--<UIElementCollection>-->  
    <Button>First Button</Button>  
    <Button>Second Button</Button>  
    <!--</UIElementCollection>-->  
  </StackPanel.Children>  
</StackPanel>  
```  
  
### Attribute Syntax (Events)  
 Attribute syntax can also be used for members that are events rather than properties. In this case, the attribute's name is the name of the event. In the WPF implementation of events for XAML, the attribute's value is the name of a handler that implements that event's delegate. For example, the following markup assigns a handler for the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event to a <xref:System.Windows.Controls.Button> created in markup:  
  
 [!code-xaml[XAMLOvwSupport#ButtonWithCodeBehind](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page3.xaml#buttonwithcodebehind)]  
  
 There is more to events and XAML in WPF than just this example of the attribute syntax. For example, you might wonder what the `ClickHandler` referenced here represents and how it is defined. This will be explained in the upcoming [Events and XAML Code-Behind](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md#events_and_xaml_codebehind) section of this topic.  
  
<a name="case_and_whitespace_in_xaml"></a>   
## Case and Whitespace in XAML  
 XAML is generally speaking case sensitive. For purposes of resolving backing types, WPF XAML is case sensitive by the same rules that the CLR is case sensitive. Object elements, property elements, and attribute names must all be specified by using the sensitive casing when compared by name to the underlying type in the assembly, or to a member of a type. XAML language keywords and primitives are also case sensitive. Values are not always case sensitive. Case sensitivity for values will depend on the type converter behavior associated with the property that takes the value, or the property value type. For example, properties that take the <xref:System.Boolean> type can take either `true` or `True` as equivalent values, but only because the native WPF XAML parser type conversion for string to <xref:System.Boolean> already permits these as equivalents.  
  
 WPF XAML processors and serializers will ignore or drop all nonsignificant whitespace, and will normalize any significant whitespace. This is consistent with the default whitespace behavior recommendations of the XAML specification. This behavior is generally only of consequence when you specify strings within XAML content properties. In simplest terms, XAML converts space, linefeed and tab characters into spaces, and then preserves one space if found at either end of a contiguous string. The full explanation of XAML whitespace handling is not covered in this topic. For details, see [Whitespace Processing in XAML](../../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).  
  
<a name="markup_extensions"></a>   
## Markup Extensions  
 Markup extensions are a XAML language concept. When used to provide the value of an attribute syntax, curly braces (`{` and `}`) indicate a markup extension usage. This usage directs the XAML processing to escape from the general treatment of attribute values as either a literal string or a string-convertible value.  
  
 The most common markup extensions used in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application programming are [Binding](../../../../docs/framework/wpf/advanced/binding-markup-extension.md), used for data binding expressions, and the resource references [StaticResource](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md) and [DynamicResource](../../../../docs/framework/wpf/advanced/dynamicresource-markup-extension.md). By using markup extensions, you can use attribute syntax to provide values for properties even if that property does not support an attribute syntax in general. Markup extensions often use intermediate expression types to enable features such as deferring values or referencing other objects that are only present at run time.  
  
 For example, the following markup sets the value of the <xref:System.Windows.FrameworkElement.Style%2A> property using attribute syntax. The <xref:System.Windows.FrameworkElement.Style%2A> property takes an instance of the <xref:System.Windows.Style> class, which by default could not be instantiated by an attribute syntax string. But in this case, the attribute references a particular markup extension, [StaticResource](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md). When that markup extension is processed, it returns a reference to a style that was previously instantiated as a keyed resource in a resource dictionary.  
  
 [!code-xaml[FEResourceSH_snip#XAMLOvwShortResources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page1.xaml#xamlovwshortresources)]  
[!code-xaml[FEResourceSH_snip#XAMLOvwShortResources2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page1.xaml#xamlovwshortresources2)]  
[!code-xaml[FEResourceSH_snip#XAMLOvwShortResources3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FEResourceSH_snip/CS/page1.xaml#xamlovwshortresources3)]  
  
 For a reference listing of all markup extensions for XAML implemented specifically in WPF, see [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md). For a reference listing of the markup extensions that are defined by System.Xaml and are more widely available for .NET Framework XAML implementations, see [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md). For more information about markup extension concepts, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
<a name="type_converters"></a>   
## Type Converters  
 In the [XAML Syntax in Brief](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md#xaml_syntax_in_brief) section, it was stated that the attribute value must be able to be set by a string. The basic, native handling of how strings are converted into other object types or primitive values is based on the <xref:System.String> type itself, in addition to native processing for certain types such as <xref:System.DateTime> or <xref:System.Uri>. But many [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] types or members of those types extend the basic string attribute processing behavior, in such a way that instances of more complex object types can be specified as strings and attributes.  
  
 The <xref:System.Windows.Thickness> structure is an example of a type that has a type conversion enabled for XAML usages. <xref:System.Windows.Thickness> indicates measurements within a nested rectangle and is used as the value for properties such as <xref:System.Windows.FrameworkElement.Margin%2A>. By placing a type converter on <xref:System.Windows.Thickness>, all properties that use a <xref:System.Windows.Thickness> are easier to specify in XAML because they can be specified as attributes. The following example uses a type conversion and attribute syntax to provide a value for a <xref:System.Windows.FrameworkElement.Margin%2A>:  
  
 [!code-xaml[XAMLOvwSupport#MarginTCE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page7.xaml#margintce)]  
  
 The previous attribute syntax example is equivalent to the following more verbose syntax example, where the <xref:System.Windows.FrameworkElement.Margin%2A> is instead set through property element syntax containing a <xref:System.Windows.Thickness> object element. The four key properties of <xref:System.Windows.Thickness> are set as attributes on the new instance:  
  
 [!code-xaml[XAMLOvwSupport#MarginVerbose](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page7.xaml#marginverbose)]  
  
> [!NOTE]
>  There are also a limited number of objects where the type conversion is the only public way to set a property to that type without involving a subclass, because the type itself does not have a default constructor. An example is <xref:System.Windows.Input.Cursor>.  
  
 For more information on how type conversion and its use for attribute syntax is supported, see [TypeConverters and XAML](../../../../docs/framework/wpf/advanced/typeconverters-and-xaml.md).  
  
<a name="xaml_root_elements_and_xaml_namespaces"></a>   
## XAML Root Elements and XAML Namespaces  
 A XAML file must have only one root element, in order to be both a well-formed [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] file and a valid XAML file. For typical WPF scenarios, you use a root element that has a prominent meaning in the WPF application model (for example, <xref:System.Windows.Window> or <xref:System.Windows.Controls.Page> for a page, <xref:System.Windows.ResourceDictionary> for an external dictionary, or <xref:System.Windows.Application> for the application definition). The following example shows the root element of a typical XAML file for a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page, with the root element of <xref:System.Windows.Controls.Page>.  
  
 [!code-xaml[XAMLOvwSupport#RootOnly](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page2.xaml#rootonly)]  
[!code-xaml[XAMLOvwSupport#RootOnly2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page2.xaml#rootonly2)]  
  
 The root element also contains the attributes `xmlns` and `xmlns:x`. These attributes indicate to a XAML processor which XAML namespaces contain the type definitions for backing types that the markup will reference as elements. The `xmlns` attribute specifically indicates the default XAML namespace. Within the default XAML namespace, object elements in the markup can be specified without a prefix. For most [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application scenarios, and for almost all of the examples given in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] sections of the [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)], the default XAML namespace is mapped to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] namespace [!INCLUDE[TLA#tla_wpfxmlnsv1](../../../../includes/tlasharptla-wpfxmlnsv1-md.md)]. The `xmlns:x` attribute indicates an additional XAML namespace, which maps the XAML language namespace [!INCLUDE[TLA#tla_xamlxmlnsv1](../../../../includes/tlasharptla-xamlxmlnsv1-md.md)].  
  
 This usage of `xmlns` to define a scope for usage and mapping of a namescope is consistent with the XML 1.0 specification. XAML namescopes are different from XML namescopes only in that a XAML namescope also implies something about how the namescope's elements are backed by types when it comes to type resolution and parsing the XAML.  
  
 Note that the `xmlns` attributes are only strictly necessary on the root element of each XAML file. `xmlns` definitions will apply to all descendant elements of the root element (this behavior is again consistent with the XML 1.0 specification for `xmlns`.) `xmlns` attributes are also permitted on other elements underneath the root, and would apply to any descendant elements of the defining element. However, frequent definition or redefinition of XAML namespaces can result in a XAML markup style that is difficult to read.  
  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] implementation of its XAML processor includes an infrastructure that has awareness of the WPF core assemblies. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] core assemblies are known to contain the types that support the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] mappings to the default XAML namespace. This is enabled through configuration that is part of your project build file and the WPF build and project systems. Therefore, declaring the default XAML namespace as the default `xmlns` is all that is necessary in order to reference XAML elements that come from [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] assemblies.  
  
### The x: Prefix  
 In the previous root element example, the prefix `x:` was used to map the XAML namespace [!INCLUDE[TLA#tla_xamlxmlnsv1](../../../../includes/tlasharptla-xamlxmlnsv1-md.md)], which is the dedicated XAML namespace that supports XAML language constructs. This `x:` prefix is used for mapping this XAML namespace in the templates for projects, in examples, and in documentation throughout this [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)]. The XAML namespace for the XAML language contain several programming constructs that you will use very frequently in your XAML. The following is a listing of the most common `x:` prefix programming constructs you will use:  
  
-   [x:Key](../../../../docs/framework/xaml-services/x-key-directive.md): Sets a unique key for each resource in a <xref:System.Windows.ResourceDictionary> (or similar dictionary concepts in other frameworks). `x:Key` will probably account for 90% of the `x:` usages you will see in a typical WPF application's markup.  
  
-   [x:Class](../../../../docs/framework/xaml-services/x-class-directive.md): Specifies the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] namespace and class name for the class that provides code-behind for a XAML page. You must have such a class to support code-behind per the WPF programming model, and therefore you almost always see `x:` mapped, even if there are no resources.  
  
-   [x:Name](../../../../docs/framework/xaml-services/x-name-directive.md): Specifies a run-time object name for the instance that exists in run-time code after an object element is processed. In general, you will frequently use a WPF-defined equivalent property for [x:Name](../../../../docs/framework/xaml-services/x-name-directive.md). Such properties map specifically to a CLR backing property and are thus more convenient for application programming, where you frequently use run time code to find the named elements from initialized XAML. The most common such property is <xref:System.Windows.FrameworkElement.Name%2A?displayProperty=nameWithType>. You might still use [x:Name](../../../../docs/framework/xaml-services/x-name-directive.md) when the equivalent WPF framework-level <xref:System.Windows.FrameworkElement.Name%2A> property is not supported in a particular type. This occurs in certain animation scenarios.  
  
-   [x:Static](../../../../docs/framework/xaml-services/x-static-markup-extension.md): Enables a reference that returns a static value that is not otherwise a XAML-compatible property.  
  
-   [x:Type](../../../../docs/framework/xaml-services/x-type-markup-extension.md): Constructs a <xref:System.Type> reference based on a type name. This is used to specify attributes that take <xref:System.Type>, such as <xref:System.Windows.Style.TargetType%2A?displayProperty=nameWithType>, although frequently the property has native string-to-<xref:System.Type> conversion in such a way that the [x:Type](../../../../docs/framework/xaml-services/x-type-markup-extension.md) markup extension usage is optional.  
  
 There are additional programming constructs in the `x:` prefix/XAML namespace, which are not as common. For details, see [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md).  
  
<a name="custom_prefixes_and_custom_types_in_xaml"></a>   
## Custom Prefixes and Custom Types in XAML  
 For your own custom assemblies, or for assemblies outside the WPF core of PresentationCore, PresentationFramework and WindowsBase, you can specify the assembly as part of a custom `xmlns` mapping. You can then reference types from that assembly in your XAML, so long as that type is correctly implemented to support the XAML usages you are attempting.  
  
 The following is a very basic example of how custom prefixes work in XAML markup. The prefix `custom` is defined in the root element tag, and mapped to a specific assembly that is packaged and available with the application. This assembly contains a type `NumericUpDown`, which is implemented to support general XAML usage as well as using a class inheritance that permits its insertion at this particular point in a WPF XAML content model. An instance of this `NumericUpDown` control is declared as an object element, using the prefix so that a XAML parser knows which XAML namespace contains the type, and therefore where the backing assembly is that contains the type definition.  
  
```  
<Page  
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"   
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"   
    xmlns:custom="clr-namespace:NumericUpDownCustomControl;assembly=CustomLibrary"  
    >  
  <StackPanel Name="LayoutRoot">  
    <custom:NumericUpDown Name="numericCtrl1" Width="100" Height="60"/>  
...  
  </StackPanel>  
</Page>  
```  
  
 For more information about custom types in XAML, see [XAML and Custom Classes for WPF](../../../../docs/framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md).  
  
 For more information about how XML namespaces and the namespaces of the backing code in assemblies are related, see [XAML Namespaces and Namespace Mapping for WPF XAML](../../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md).  
  
<a name="events_and_xaml_codebehind"></a>   
## Events and XAML Code-Behind  
 Most [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications consist of both XAML markup and code-behind. Within a project, the XAML is written as a `.xaml` file, and a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] language such as [!INCLUDE[TLA#tla_visualb](../../../../includes/tlasharptla-visualb-md.md)] or [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)] is used to write a code-behind file. When a XAML file is markup compiled as part of the WPF programming and application models, the location of the XAML code-behind file for a XAML file is identified by specifying a namespace and class as the `x:Class` attribute of the root element of the XAML.  
  
 In the examples so far, you have seen several buttons, but none of these buttons had any logical behavior associated with them yet. The primary application-level mechanism for adding a behavior for an object element is to use an existing event of the element class, and to write a specific handler for that event that is invoked when that event is raised at run time. The event name and the name of the handler to use are specified in the markup, whereas the code that implements your handler is defined in the code-behind.  
  
 [!code-xaml[XAMLOvwSupport#ButtonWithCodeBehind](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page3.xaml#buttonwithcodebehind)]  
  
 [!code-csharp[XAMLOvwSupport#ButtonWithCodeBehindHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page3.xaml.cs#buttonwithcodebehindhandler)]
 [!code-vb[XAMLOvwSupport#ButtonWithCodeBehindHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XAMLOvwSupport/VisualBasic/Page1.xaml.vb#buttonwithcodebehindhandler)]  
  
 Notice that the code-behind file uses the CLR namespace `ExampleNamespace` and declares `ExamplePage` as a partial class within that namespace. This parallels the `x:Class` attribute value of `ExampleNamespace`.`ExamplePage` that was provided in the markup root. The WPF markup compiler will create a partial class for any compiled XAML file, by deriving a class from the root element type. When you provide code-behind that also defines the same partial class, the resulting code is combined within the same namespace and class of the compiled application.  
  
 For more information about requirements for code-behind programming in WPF, see the "Code-behind, Event Handler, and Partial Class Requirements" section of [Code-Behind and XAML in WPF](../../../../docs/framework/wpf/advanced/code-behind-and-xaml-in-wpf.md).  
  
 If you do not want to create a separate code-behind file, you can also inline your code in a XAML file. However, inline code is a less versatile technique that has substantial limitations. For details, see [Code-Behind and XAML in WPF](../../../../docs/framework/wpf/advanced/code-behind-and-xaml-in-wpf.md).  
  
### Routed Events  
 A particular event feature that is fundamental to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is a routed event. Routed events enable an element to handle an event that was raised by a different element, as long as the elements are connected through a tree relationship. When specifying event handling with a XAML attribute, the routed event can be listened for and handled on any element, including elements that do not list that particular event in the class members table. This is accomplished by qualifying the event name attribute with the owning class name. For instance, the parent `StackPanel` in the ongoing `StackPanel` / `Button` example could register a handler for the child element button's <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event by specifying the attribute `Button.Click` on the `StackPanel` object element, with your handler name as the attribute value. For more information about how routed events work, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
<a name="x_name_and_xaml_named_elements"></a>   
## XAML Named Elements  
 By default, the object instance that is created in an object graph by processing a XAML object element does not possess a unique identifier or object reference. In contrast, if you call a constructor in code, you almost always use the constructor result to set a variable to the constructed instance, so that you can reference the instance later in your code. In order to provide standardized access to objects that were created through a markup definition, XAML defines the [x:Name attribute](../../../../docs/framework/xaml-services/x-name-directive.md). You can set the value of the `x:Name` attribute on any object element. In your code-behind, the identifier you choose is equivalent to an instance variable that refers to the constructed instance. In all respects, named elements function as if they were object instances (the name references that instance), and your code-behind can reference the named elements to handle run-time interactions within the application. This connection between instances and variables is accomplished by the WPF XAML markup compiler, and more specifically involve features and patterns such as <xref:System.Windows.Markup.IComponentConnector.InitializeComponent%2A> that will not be discussed in detail in this topic.  
  
 WPF framework-level XAML elements inherit a <xref:System.Windows.FrameworkElement.Name%2A> property, which is equivalent to the XAML defined `x:Name` attribute. Certain other classes also provide property-level equivalents for `x:Name`, which is also generally defined as a `Name` property. Generally speaking, if you cannot find a `Name` property in the members table for your chosen element/type, use `x:Name` instead. The `x:Name` values will provide an identifier to a XAML element that can be used at run time, either by specific subsystems or by utility methods such as <xref:System.Windows.FrameworkElement.FindName%2A>.  
  
 The following example sets <xref:System.Windows.FrameworkElement.Name%2A> on a <xref:System.Windows.Controls.StackPanel> element. Then, a handler on a <xref:System.Windows.Controls.Button> within that <xref:System.Windows.Controls.StackPanel> references the <xref:System.Windows.Controls.StackPanel> through its instance reference `buttonContainer` as set by <xref:System.Windows.FrameworkElement.Name%2A>.  
  
 [!code-xaml[XAMLOvwSupport#NamedE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page7.xaml#namede)]  
[!code-xaml[XAMLOvwSupport#NamedE2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page7.xaml#namede2)]  
  
 [!code-csharp[XAMLOvwSupport#NameCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page7.xaml.cs#namecode)]
 [!code-vb[XAMLOvwSupport#NameCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XAMLOvwSupport/VisualBasic/Page1.xaml.vb#namecode)]  
  
 Just like a variable, the XAML name for an instance is governed by a concept of scope, so that names can be enforced to be unique within a certain scope that is predictable. The primary markup that defines a page denotes one unique XAML namescope, with the XAML namescope boundary being the root element of that page. However, other markup sources can interact with a page at run time, such as styles or templates within styles, and such markup sources often have their own XAML namescopes that do not necessarily connect with the XAML namescope of the page. For more information on `x:Name` and XAML namescopes, see <xref:System.Windows.FrameworkElement.Name%2A>, [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md), or [WPF XAML Namescopes](../../../../docs/framework/wpf/advanced/wpf-xaml-namescopes.md).  
  
<a name="attached_properties_and_attached_events"></a>   
## Attached Properties and Attached Events  
 XAML specifies a language feature that enables certain properties or events to be specified on any element, regardless of whether the property or event exists in the type's definitions for the element it is being set on. The properties version of this feature is called an attached property, the events version is called an attached event. Conceptually, you can think of attached properties and attached events as global members that can be set on any XAML element/object instance. However, that element/class or a larger infrastructure must support a backing property store for the attached values.  
  
 Attached properties in XAML are typically used through attribute syntax. In attribute syntax, you specify an attached property in the form *ownerType*.*propertyName*.  
  
 Superficially, this resembles a property element usage, but in this case the *ownerType* you specify is always a different type than the object element where the attached property is being set. *ownerType* is the type that provides the accessor methods that are required by a XAML processor in order to get or set the attached property value.  
  
 The most common scenario for attached properties is to enable child elements to report a property value to their parent element.  
  
 The following example illustrates the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> attached property. The <xref:System.Windows.Controls.DockPanel> class defines the accessors for <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> and therefore owns the attached property. The <xref:System.Windows.Controls.DockPanel> class also includes logic that iterates its child elements and specifically checks each element for a set value of <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>. If a value is found, that value is used during layout to position the child elements. Use of the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> attached property and this positioning capability is in fact the motivating scenario for the <xref:System.Windows.Controls.DockPanel> class.  
  
 [!code-xaml[XAMLOvwSupport#DockAP](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#dockap)]  
  
 In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], most or all the attached properties are also implemented as dependency properties. For details, see [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md).  
  
 Attached events use a similar *ownerType*.*eventName* form of attribute syntax. Just like the non-attached events, the attribute value for an attached event in XAML specifies the name of the handler method that is invoked when the event is handled on the element. Attached event usages in WPF XAML are less common. For more information, see [Attached Events Overview](../../../../docs/framework/wpf/advanced/attached-events-overview.md).  
  
<a name="base_classes_and_xaml"></a>   
## Base Types and XAML  
 Underlying WPF XAML and its XAML namespace is a collection of types that correspond to [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] objects in addition to markup elements for XAML. However, not all classes can be mapped to elements. Abstract classes, such as <xref:System.Windows.Controls.Primitives.ButtonBase>, and certain nonabstract base classes are used for inheritance in the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] objects model. Base classes, including abstract ones, are still important to XAML development because each of the concrete XAML elements inherits members from some base class in its hierarchy. Often these members include properties that can be set as attributes on the element, or events that can be handled. <xref:System.Windows.FrameworkElement> is the concrete base [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] class of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] at the WPF framework level. When designing [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)], you will use various shape, panel, decorator, or control classes, which all derive from <xref:System.Windows.FrameworkElement>. A related base class, <xref:System.Windows.FrameworkContentElement>, supports document-oriented elements that work well for a flow layout presentation, using [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] that deliberately mirror the [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] in <xref:System.Windows.FrameworkElement>. The combination of attributes at the element level and a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] object model provides you with a set of common properties that are settable on most concrete XAML elements, regardless of the specific XAML element and its underlying type.  
  
<a name="xaml_security"></a>   
## XAML Security  
 XAML is a markup language that directly represents object instantiation and execution. Therefore, elements created in XAML have the same ability to interact with system resources (network access, file system IO, for example) as the equivalent generated code does.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] supports the  [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] security framework [!INCLUDE[TLA#tla_cas](../../../../includes/tlasharptla-cas-md.md)]. This means that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content running in the internet zone has reduced execution permissions. "Loose XAML" (pages of noncompiled XAML interpreted at load time by a XAML viewer) and [!INCLUDE[TLA#tla_xbap](../../../../includes/tlasharptla-xbap-md.md)] are usually run in this internet zone and use the same permission set.  However, XAML loaded in to a fully trusted application has the same access to the system resources as the hosting application does. For more information, see [WPF Partial Trust Security](../../../../docs/framework/wpf/wpf-partial-trust-security.md).  
  
<a name="loading_xaml_from_code"></a>   
## Loading XAML from Code  
 XAML can be used to define all of the UI, but it is sometimes also appropriate to define just a piece of the UI in XAML. This capability could be used to enable partial customization, local storage of information, using XAML to provide a business object, or a variety of possible scenarios. The key to these scenarios is the <xref:System.Windows.Markup.XamlReader> class and its <xref:System.Windows.Markup.XamlReader.Load%2A> method. The input is a XAML file, and the output is an object that represents all of the run-time tree of objects that was created from that markup. You then can insert the object to be a property of another object that already exists in the application. So long as the property is an appropriate property in the content model that has eventual display capabilities and that will notify the execution engine that new content has been added into the application, you can modify a running application's contents very easily by loading in XAML. Note that this capability is generally only available in full-trust applications, because of the obvious security implications of loading files into applications as they run.  
  
<a name="whats_next"></a>   
## What's Next  
 This topic provides a basic introduction to XAML syntax concepts and terminology as it applies to WPF. For more information about the terms used here, see [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
 If you have not already done this, try the exercises in the tutorial topic [Walkthrough: My first WPF desktop application](../../../../docs/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application.md). When you create the markup-centric application described by the tutorial, the exercise will help reinforce many of the concepts described in this topic.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses a particular application model that is based on the <xref:System.Windows.Application> class. For details, see [Application Management Overview](../../../../docs/framework/wpf/app-development/application-management-overview.md).  
  
 [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md) gives you more details about how to build XAML inclusive applications from the command line and with [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)].  
  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md) gives more information about the versatility of properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], and introduces the concept of dependency properties.  
  
## See Also  
 [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md)  
 [XAML and Custom Classes for WPF](../../../../docs/framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md)  
 [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md)  
 [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md)  
 [Base Elements Overview](../../../../docs/framework/wpf/advanced/base-elements-overview.md)  
 [Trees in WPF](../../../../docs/framework/wpf/advanced/trees-in-wpf.md)
