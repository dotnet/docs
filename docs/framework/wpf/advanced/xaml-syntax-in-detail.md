---
title: "XAML Syntax In Detail"
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
  - "XML [WPF], namespaces"
  - "XAML [WPF], parsing of attributes"
  - "parsing of attributes [WPF]"
  - "XAML [WPF], markup extensions"
  - "attached properties [WPF]"
  - "tag syntax [XAML]"
  - "markup extensions [WPF]"
  - "XAML [WPF], object element syntax"
  - "XAML [WPF], syntax terminology"
  - "attached events [WPF]"
  - "lookup semantics [WPF]"
  - "XAML [WPF], attached events"
  - "XAML [WPF], content syntax"
  - "XAML [WPF], lookup semantics"
  - "content syntax [WPF]"
  - "object element syntax [WPF]"
  - "syntax terminology [XAML]"
  - "XAML [WPF], attached properties"
  - "attributes [XAML], parsing"
  - "XAML [WPF], tag syntax"
  - "XAML [WPF], attribute syntax"
  - "property element syntax [WPF]"
  - "terminology [XAML]"
  - "namespaces [WPF], XML"
  - "attribute syntax [XAML]"
  - "XAML [WPF], property element syntax"
ms.assetid: 67cce290-ca26-4c41-a797-b68aabc45479
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# XAML Syntax In Detail
This topic defines the terms that are used to describe the elements of XAML syntax. These terms are used frequently throughout the remainder of this documentation, both for WPF documentation specifically and for the other frameworks that use XAML or the basic XAML concepts enabled by the XAML language support at the System.Xaml level. This topic expands on the basic terminology introduced in the topic [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md).  
  

  
<a name="the_xaml_language_specification"></a>   
## The XAML Language Specification  
 The XAML syntax terminology defined here is also defined or referenced within the XAML language specification. XAML is a language based on XML and follows or expands upon XML structural rules. Some of the terminology is shared from or is based on the terminology commonly used when describing the XML language or the XML document object model.  
  
 For more information about the XAML language specification, download [\[MS-XAML\]](http://go.microsoft.com/fwlink/?LinkId=114525) from the Microsoft Download Center.  
  
<a name="xaml_and_clr"></a>   
## XAML and CLR  
 XAML is a markup language. The [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)], as implied by its name, enables runtime execution. XAML is not by itself one of the common languages that is directly consumed by the CLR runtime. Instead, you can think of XAML as supporting its own type system. The particular XAML parsing system that is used by WPF is built on the CLR and the CLR type system. XAML types are mapped to CLR types to instantiate a run time representation when the XAML for WPF is parsed. For this reason, the remainder of discussion of syntax in this document will include references to the CLR type system, even though the equivalent syntax discussions in the XAML language specification do not. (Per the XAML language specification level, XAML types could be mapped to any other type system, which does not have to be the CLR, but that would require the creation and use of a different XAML parser.)  
  
#### Members of Types and Class Inheritance  
 Properties and events as they appear as XAML members of a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] type are often inherited from base types. For example, consider this example: `<Button Background="Blue" .../>`. The <xref:System.Windows.Controls.Control.Background%2A> property is not an immediately declared property on the <xref:System.Windows.Controls.Button> class, if you were to look at the class definition, reflection results, or the documentation. Instead, <xref:System.Windows.Controls.Control.Background%2A> is inherited from the base <xref:System.Windows.Controls.Control> class.  
  
 The class inheritance behavior of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] XAML elements is a significant departure from a schema-enforced interpretation of XML markup. Class inheritance can become complex, particularly when intermediate base classes are abstract, or when interfaces are involved. This is one reason that the set of XAML elements and their permissible attributes is difficult to represent accurately and completely using the schema types that are typically used for [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] programming, such as DTD or XSD format. Another reason is that extensibility and type-mapping features of the XAML language itself preclude completeness of any fixed representation of the permissible types and members.  
  
<a name="object_element_syntax"></a>   
## Object Element Syntax  
 *Object element syntax* is the XAML markup syntax that instantiates a CLR class or structure by declaring an XML element. This syntax resembles the element syntax of other markup languages such as HTML. Object element syntax begins with a left angle bracket (\<), followed immediately by the type name of the class or structure being instantiated. Zero or more spaces can follow the type name, and zero or more attributes may also be declared on the object element, with one or more spaces separating each attribute name="value" pair. Finally, one of the following must be true:  
  
-   The element and tag must be closed by a forward slash (/) followed immediately by a right angle bracket (>).  
  
-   The opening tag must be completed by a right angle bracket (>). Other object elements, property elements, or inner text, can follow the opening tag. Exactly what content may be contained here is typically constrained by the object model of the element. The equivalent closing tag for the object element must also exist, in proper nesting and balance with other opening and closing tag pairs.  
  
 XAML as implemented by .NET has a set of rules that map object elements into types, attributes into properties or events, and XAML namespaces to CLR namespaces plus assembly. For WPF and the .NET Framework, XAML object elements map to [!INCLUDE[TLA#tla_net](../../../../includes/tlasharptla-net-md.md)] types as defined in referenced assemblies, and the attributes map to members of those types. When you reference a CLR type in XAML, you have access to the inherited members of that type as well.  
  
 For example, the following example is object element syntax that instantiates a new instance of the <xref:System.Windows.Controls.Button> class, and also specifies a <xref:System.Windows.FrameworkElement.Name%2A> attribute and a value for that attribute:  
  
 [!code-xaml[XAMLOvwSupport#SyntaxOE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#syntaxoe)]  
  
 The following example is object element syntax that also includes XAML content property syntax. The inner text contained within will be used to set the <xref:System.Windows.Controls.TextBox> XAML content property, <xref:System.Windows.Controls.TextBox.Text%2A>.  
  
 [!code-xaml[XAMLOvwSupport#ThisIsATextBox](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#thisisatextbox)]  
  
### Content Models  
 A class might support a usage as a XAML object element in terms of the syntax, but that element will only function properly in an application or page when it is placed in an expected position of an overall content model or element tree. For example, a <xref:System.Windows.Controls.MenuItem> should typically only be placed as a child of a <xref:System.Windows.Controls.Primitives.MenuBase> derived class such as <xref:System.Windows.Controls.Menu>. Content models for specific elements are documented as part of the remarks on the class pages for controls and other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes that can be used as XAML elements.  
  
<a name="properties_of_object_elements"></a>   
## Properties of Object Elements  
 Properties in XAML are set by a variety of possible syntaxes. Which syntax can be used for a particular property will vary, based on the underlying type system characteristics of the property that you are setting.  
  
 By setting values of properties, you add features or characteristics to objects as they exist in the run time object graph. The initial state of the created object from a object element is based on the default constructor behavior. Typically, your application will use something other than a completely default instance of any given object.  
  
<a name="attribute_syntax_properties"></a>   
## Attribute Syntax (Properties)  
 Attribute syntax is the XAML markup syntax that sets a value for a property by declaring an attribute on an existing object element. The attribute name must match the CLR member name of the property of the class that backs the relevant object element. The attribute name is followed by an assignment operator (=). The attribute value must be a string enclosed within quotes.  
  
> [!NOTE]
>  You can use alternating quotes to place a literal quotation mark within an attribute. For instance you can use single quotes as a means to declare a string that contains a double quote character within it. Whether you use single or double quotes, you should use a matching pair for opening and closing the attribute value string. There are also escape sequences or other techniques available for working around character restrictions imposed by any particular XAML syntax. See [XML Character Entities and XAML](../../../../docs/framework/xaml-services/xml-character-entities-and-xaml.md).  
  
 In order to be set through attribute syntax, a property must be public and must be writeable. The value of the property in the backing type system must be a value type, or must be a reference type that can be instantiated or referenced by a XAML processor when accessing the relevant backing type.  
  
 For WPF XAML events, the event that is referenced as the attribute name must be public and have a public delegate.  
  
 The property or event must be a member of the class or structure that is instantiated by the containing object element.  
  
### Processing of Attribute Values  
 The string value contained within the opening and closing quotation marks is processed by a XAML processor. For properties, the default processing behavior is determined by the type of the underlying CLR property.  
  
 The attribute value is filled by one of the following, using this processing order:  
  
1.  If the XAML processor encounters a curly brace, or an object element that derives from <xref:System.Windows.Markup.MarkupExtension>, then the referenced markup extension is evaluated first rather than processing the value as a string, and the object returned by the markup extension is used as the value. In many cases the object returned by a markup extension will be a reference to an existing object, or an expression that defers evaluation until run time, and is not a newly instantiated object.  
  
2.  If the property is declared with an attributed <xref:System.ComponentModel.TypeConverter>, or the value type of that property is declared with an attributed <xref:System.ComponentModel.TypeConverter>, the string value of the attribute is submitted to the type converter as a conversion input, and the converter will return a new object instance.  
  
3.  If there is no <xref:System.ComponentModel.TypeConverter>, a direct conversion to the property type is attempted. This final level is a direct conversion at the parser-native value between XAML language primitive types, or a check for the names of named constants in an enumeration (the parser then accesses the matching values).  
  
#### Enumeration Attribute Values  
 Enumerations in XAML are processed intrinsically by XAML parsers, and the members of an enumeration should be specified by specifying the string name of one of the enumeration's named constants.  
  
 For nonflag enumeration values, the native behavior is to process the string of an attribute value and resolve it to one of the enumeration values. You do not specify the enumeration in the format *Enumeration*.*Value*, as you do in code. Instead, you specify only *Value*, and *Enumeration* is inferred by the type of the property you are setting. If you specify an attribute in the *Enumeration*.*Value* form, it will not resolve correctly.  
  
 For flagwise enumerations, the behavior is based on the <xref:System.Enum.Parse%2A?displayProperty=nameWithType> method. You can specify multiple values for a flagwise enumeration by separating each value with a comma. However, you cannot combine enumeration values that are not flagwise. For instance, you cannot use the comma syntax to attempt to create a <xref:System.Windows.Trigger> that acts on multiple conditions of a nonflag enumeration:  
  
```  
<!--This will not compile, because Visibility is not a flagwise enumeration.-->  
...  
<Trigger Property="Visibility" Value="Collapsed,Hidden">  
  <Setter ... />  
</Trigger>  
...  
```  
  
 Flagwise enumerations that support attributes that are settable in XAML are rare in WPF. However, one such enumeration is <xref:System.Windows.Media.StyleSimulations>. You could, for instance, use the comma-delimited flagwise attribute syntax to modify the example provided in the Remarks for the <xref:System.Windows.Documents.Glyphs> class; `StyleSimulations = "BoldSimulation"` could become `StyleSimulations = "BoldSimulation,ItalicSimulation"`. <xref:System.Windows.Input.KeyBinding.Modifiers%2A?displayProperty=nameWithType> is another property where more than one enumeration value can be specified. However, this property happens to be a special case, because the <xref:System.Windows.Input.ModifierKeys> enumeration supports its own type converter. The type converter for modifiers uses a plus sign (+) as a delimiter rather than a comma (,). This conversion supports the more traditional syntax to represent key combinations in Microsoft Windows programming, such as "Ctrl+Alt".  
  
### Properties and Event Member Name References  
 When specifying an attribute, you can reference any property or event that exists as a member of the CLR type you instantiated for the containing object element.  
  
 Or, you can reference an attached property or attached event, independent of the containing object element. (Attached properties are discussed in an upcoming section.)  
  
 You can also name any event from any object that is accessible through the default namespace by using a *typeName*.*event* partially qualified name; this syntax supports attaching handlers for routed events where the handler is intended to handle events routing from child elements, but the parent element does not also have that event in its members table. This syntax resembles an attached event syntax, but the event here is not a true attached event. Instead, you are referencing an event with a qualified name. For more information, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
 For some scenarios, property names are sometimes provided as the value of an attribute, rather than the attribute name. That property name can also include qualifiers, such as the property specified in the form *ownerType*.*dependencyPropertyName*. This scenario is common when writing styles or templates in XAML. The processing rules for property names provided as an attribute value are different, and are governed by the type of the property being set or by the behaviors of particular WPF subsystems. For details, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
 Another usage for property names is when an attribute value describes a property-property relationship. This feature is used for data binding and for storyboard targets, and is enabled by the <xref:System.Windows.PropertyPath> class and its type converter. For a more complete description of the lookup semantics, see [PropertyPath XAML Syntax](../../../../docs/framework/wpf/advanced/propertypath-xaml-syntax.md).  
  
<a name="property_element_syntax"></a>   
## Property Element Syntax  
 *Property element syntax* is a syntax that diverges somewhat from the basic XML syntax rules for elements. In XML, the value of an attribute is a de facto string, with the only possible variation being which string encoding format is being used. In XAML, you can assign other object elements to be the value of a property. This capability is enabled by the property element syntax. Instead of the property being specified as an attribute within the element tag, the property is specified using an opening element tag in *elementTypeName*.*propertyName* form, the value of the property is specified within, and then the property element is closed.  
  
 Specifically, the syntax begins with a left angle bracket (\<), followed immediately by the type name of the class or structure that the property element syntax is contained within. This is followed immediately by a single dot (.), then by the name of a property, then by a right angle bracket (>). As with attribute syntax, that property must exist within the declared public members of the specified type. The value to be assigned to the property is contained within the property element. Typically, the value is given as one or more object elements, because specifying objects as values is the scenario that property element syntax is intended to address. Finally, an equivalent closing tag specifying the same *elementTypeName*.*propertyName* combination must be provided, in proper nesting and balance with other element tags.  
  
 For example, the following is property element syntax for the <xref:System.Windows.FrameworkElement.ContextMenu%2A> property of a <xref:System.Windows.Controls.Button>.  
  
 [!code-xaml[XAMLOvwSupport#ContextMenu](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#contextmenu)]  
  
 The value within a property element can also be given as inner text, in cases where the property type being specified is a primitive value type, such as <xref:System.String>, or an enumeration where a name is specified. These two usages are somewhat uncommon, because each of these cases could also use a simpler attribute syntax. One scenario for filling a property element with a string is for properties that are not the XAML content property but still are used for representation of UI text, and particular whitespace elements such as linefeeds are required to appear in that UI text. Attribute syntax cannot preserve linefeeds, but property element syntax can, so long as significant whitespace preservation is active (for details, see [Whitespace Processing in XAML](../../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md)). Another scenario is so that [x:Uid Directive](../../../../docs/framework/xaml-services/x-uid-directive.md) can be applied to the property element and thus mark the value within as a value that should be localized in the WPF output BAML or by other techniques.  
  
 A property element is not represented in the WPF logical tree. A property element is just a particular syntax for setting a property, and is not an element that has an instance or object backing it. (For details on the logical tree concept, see [Trees in WPF](../../../../docs/framework/wpf/advanced/trees-in-wpf.md).)  
  
 For properties where both attribute and property element syntax are supported, the two syntaxes generally have the same result, although subtleties such as whitespace handling can vary slightly between syntaxes.  
  
<a name="collection_syntax"></a>   
## Collection Syntax  
 The XAML specification requires XAML processor implementations to identify properties where the value type is a collection. The general XAML processor implementation in .NET is based on managed code and the CLR, and it identifies collection types through one of the following:  
  
-   Type implements <xref:System.Collections.IList>.  
  
-   Type implements <xref:System.Collections.IDictionary>.  
  
-   Type derives from <xref:System.Array> (for more information about arrays in XAML, see [x:Array Markup Extension](../../../../docs/framework/xaml-services/x-array-markup-extension.md).)  
  
 If the type of a property is a collection, then the inferred collection type does not need to be specified in the markup as an object element. Instead, the elements that are intended to become the items in the collection are specified as one or more child elements of the property element. Each such item is evaluated to an object during loading and added to the collection by calling the `Add` method of the implied collection. For example, the <xref:System.Windows.Style.Triggers%2A> property of <xref:System.Windows.Style> takes the specialized collection type <xref:System.Windows.TriggerCollection>, which implements <xref:System.Collections.IList>. It is not necessary to instantiate a <xref:System.Windows.TriggerCollection> object element in the markup. Instead, you specify one or more <xref:System.Windows.Trigger> items as elements within the `Style.Triggers` property element, where <xref:System.Windows.Trigger> (or a derived class) is the type expected as the item type for the strongly typed and implicit <xref:System.Windows.TriggerCollection>.  
  
 [!code-xaml[XAMLOvwSupport#SyntaxPECollection](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/Page1.xaml#syntaxpecollection)]  
  
 A property may be both a collection type and the XAML content property for that type and derived types, which is discussed in the next section of this topic.  
  
 An implicit collection element creates a member in the logical tree representation, even though it does not appear in the markup as an element. Usually the constructor of the parent type performs the instantiation for the collection that is one of its properties, and the initially empty collection becomes part of the object tree.  
  
> [!NOTE]
>  The generic list and dictionary interfaces (<xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IDictionary%602>) are not supported for collection detection. However, you can use the <xref:System.Collections.Generic.List%601> class as a base class, because it implements <xref:System.Collections.IList> directly, or <xref:System.Collections.Generic.Dictionary%602> as a base class, because it implements <xref:System.Collections.IDictionary> directly.  
  
 In the .NET Reference pages for collection types, this syntax with the deliberate omission of the object element for a collection is occasionally noted in the XAML syntax sections as Implicit Collection Syntax.  
  
 With the exception of the root element, every object element in a XAML file that is nested as a child element of another element is really an element that is one or both of the following cases: a member of an implicit collection property of its parent element, or an element that specifies the value of the XAML content property for the parent element (XAML content properties will be discussed in an upcoming section). In other words, the relationship of parent elements and child elements in a markup page is really a single object at the root, and every object element beneath the root is either a single instance that provides a property value of the parent, or one of the items within a collection that is also a collection-type property value of the parent. This single-root concept is common with XML, and is frequently reinforced in the behavior of APIs that load XAML such as <xref:System.Windows.Markup.XamlReader.Load%2A>.  
  
 The following example is a syntax with the object element for a collection (<xref:System.Windows.Media.GradientStopCollection>) specified explicitly.  
  
```xaml  
<LinearGradientBrush>  
  <LinearGradientBrush.GradientStops>  
    <GradientStopCollection>  
      <GradientStop Offset="0.0" Color="Red" />  
      <GradientStop Offset="1.0" Color="Blue" />  
    </GradientStopCollection>  
  </LinearGradientBrush.GradientStops>  
</LinearGradientBrush>  
```  
  
 Note that it is not always possible to explicitly declare the collection. For instance, attempting to declare <xref:System.Windows.TriggerCollection> explicitly in the previously shown <xref:System.Windows.Style.Triggers%2A> example would fail. Explicitly declaring the collection requires that the collection class must support a default constructor, and <xref:System.Windows.TriggerCollection> does not have a default constructor.  
  
<a name="xaml_content_properties"></a>   
## XAML Content Properties  
 XAML content syntax is a syntax that is only enabled on classes that specify the <xref:System.Windows.Markup.ContentPropertyAttribute> as part of their class declaration. The <xref:System.Windows.Markup.ContentPropertyAttribute> references the property name that is the content property for that type of element (including derived classes). When processed by a XAML processor, any child elements or inner text that are found between the opening and closing tags of the object element will be assigned to be the value of the XAML content property for that object. You are permitted to specify explicit property elements for the content property, but this usage is not generally shown in the XAML syntax sections in the .NET reference. The explicit/verbose technique has occasional value for markup clarity or as a matter of markup style, but usually the intent of a content property is to streamline the markup so that elements that are intuitively related as parent-child can be nested directly. Property element tags for other properties on an element are not assigned as "content" per a strict XAML language definition; they are processed previously in the XAML parser's processing order and are not considered to be "content".  
  
### XAML Content Property Values Must Be Contiguous  
 The value of a XAML content property must be given either entirely before or entirely after any other property elements on that object element. This is true whether the value of a XAML content property is specified as a string, or as one or more objects. For example, the following markup does not parse:  
  
```  
<Button>I am a   
  <Button.Background>Blue</Button.Background>  
  blue button</Button>  
```  
  
 This is illegal essentially because if this syntax were made explicit by using property element syntax for the content property, then the content property would be set twice:  
  
```xml  
<Button>  
  <Button.Content>I am a </Button.Content>  
  <Button.Background>Blue</Button.Background>  
  <Button.Content> blue button</Button.Content>  
</Button>  
```  
  
 A similarly illegal example is if the content property is a collection, and child elements are interspersed with property elements:  
  
```xml  
<StackPanel>  
  <Button>This example</Button>  
  <StackPanel.Resources>  
    <SolidColorBrush x:Key="BlueBrush" Color="Blue"/>  
  </StackPanel.Resources>  
  <Button>... is illegal XAML</Button>  
</StackPanel>  
```  
  
<a name="content_properties_and_collection_syntax_combined"></a>   
## Content Properties and Collection Syntax Combined  
 In order to accept more than a single object element as content, the type of the content property must specifically be a collection type. Similar to property element syntax for collection types, a XAML processor must identify types that are collection types. If an element has a XAML content property and the type of the XAML content property is a collection, then the implied collection type does not need to be specified in the markup as an object element and the XAML content property does not need to be specified as a property element. Therefore the apparent content model in the markup can now have more than one child element assigned as the content. The following is content syntax for a <xref:System.Windows.Controls.Panel> derived class. All <xref:System.Windows.Controls.Panel> derived classes establish the XAML content property to be <xref:System.Windows.Controls.Panel.Children%2A>, which requires a value of type <xref:System.Windows.Controls.UIElementCollection>.  
  
 [!code-xaml[XAMLOvwSupport#SyntaxContent](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page5.xaml#syntaxcontent)]  
  
 Note that neither the property element for <xref:System.Windows.Controls.Panel.Children%2A> nor the element for the <xref:System.Windows.Controls.UIElementCollection> is required in the markup. This is a design feature of XAML so that recursively contained elements that define a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] are more intuitively represented as a tree of nested elements with immediate parent-child element relationships, without intervening property element tags or collection objects. In fact, <xref:System.Windows.Controls.UIElementCollection> cannot be specified explicitly in markup as an object element, by design. Because its only intended use is as an implicit collection, <xref:System.Windows.Controls.UIElementCollection> does not expose a public default constructor and thus cannot be instantiated as an object element.  
  
### Mixing Property Elements and Object Elements in an Object with a Content Property  
 The XAML specification declares that a XAML processor can enforce that object elements that are used to fill the XAML content property within an object element must be contiguous, and must not be mixed. This restriction against mixing property elements and content is enforced by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] XAML processors.  
  
 You can have a child object element as the first immediate markup within an object element. Then you can introduce property elements. Or, you can specify one or more property elements, then content, then more property elements. But once a property element follows content, you cannot introduce any further content, you can only add property elements.  
  
 This content / property element order requirement does not apply to inner text used as content. However, it is still a good markup style to keep inner text contiguous, because significant whitespace will be difficult to detect visually in the markup if property elements are interspersed with inner text.  
  
<a name="xaml_namespaces"></a>   
## XAML Namespaces  
 None of the preceding syntax examples specified a XAML namespace other than the default XAML namespace. In typical [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications, the default XAML namespace is specified to be the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] namespace. You can specify XAML namespaces other than the default XAML namespace and still use similar syntax. But then, anywhere where a class is named that is not accessible within the default XAML namespace, that class name must be preceded with the prefix of the XAML namespace as mapped to the corresponding CLR namespace. For example, `<custom:Example/>` is object element syntax to instantiate an instance of the `Example` class, where the CLR namespace containing that class (and possibly the external assembly information that contains backing types) was previously mapped to the `custom` prefix.  
  
 For more information about XAML namespaces, see [XAML Namespaces and Namespace Mapping for WPF XAML](../../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md).  
  
<a name="markup_extensions"></a>   
## Markup Extensions  
 XAML defines a markup extension programming entity that enables an escape from the normal XAML processor handling of string attribute values or object elements, and defers the processing to a backing class. The character that identifies a markup extension to a XAML processor when using attribute syntax is the opening curly brace ({), followed by any character other than a closing curly brace (}). The first string following the opening curly brace must reference the class that provides the particular extension behavior, where the reference may omit the substring "Extension" if that substring is part of the true class name. Thereafter, a single space may appear, and then each succeeding character is used as input by the extension implementation, up until the closing curly brace is encountered.  
  
 The .NET XAML implementation uses the <xref:System.Windows.Markup.MarkupExtension> abstract class as the basis for all of the markup extensions supported by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] as well as other frameworks or technologies. The markup extensions that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] specifically implements are often intended to provide a means to reference other existing objects, or to make deferred references to objects that will be evaluated at run time. For example, a simple WPF data binding is accomplished by specifying the `{Binding}` markup extension in place of the value that a particular property would ordinarily take. Many of the WPF markup extensions enable an attribute syntax for properties where an attribute syntax would not otherwise be possible. For example, a <xref:System.Windows.Style> object is a relatively complex type that contains a nested series of objects and properties. Styles in WPF are typically defined as a resource in a <xref:System.Windows.ResourceDictionary>, and then referenced through one of the two WPF markup extensions that request a resource. The markup extension defers the evaluation of the property value to a resource lookup and enables providing the value of the <xref:System.Windows.FrameworkElement.Style%2A> property, taking type <xref:System.Windows.Style>, in attribute syntax as in the following example:  
  
 `<Button Style="{StaticResource MyStyle}">My button</Button>`  
  
 Here, `StaticResource` identifies the <xref:System.Windows.StaticResourceExtension> class providing the markup extension implementation. The next string `MyStyle` is used as the input for the non-default <xref:System.Windows.StaticResourceExtension> constructor, where the parameter as taken from the extension string declares the requested <xref:System.Windows.ResourceKey>. `MyStyle` is expected to be the [x:Key](../../../../docs/framework/xaml-services/x-key-directive.md) value of a <xref:System.Windows.Style> defined as a resource. The [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md) usage requests that the resource be used to provide the <xref:System.Windows.Style> property value through static resource lookup logic at load time.  
  
 For more information about markup extensions, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md). For a reference of markup extensions and other XAML programming features enabled in the general .NET XAML implementation, see [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md). For WPF-specific markup extensions, see [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md).  
  
<a name="attached_properties"></a>   
## Attached Properties  
 Attached properties are a programming concept introduced in XAML whereby properties can be owned and defined by a particular type, but set as attributes or property elements on any element. The primary scenario that attached properties are intended for is to enable child elements in a markup structure to report information to a parent element without requiring an extensively shared object model across all elements. Conversely, attached properties can be used by parent elements to report information to child elements. For more information on the purpose of attached properties and how to create your own attached properties, see [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md).  
  
 Attached properties use a syntax that superficially resembles property element syntax, in that you also specify a *typeName*.*propertyName* combination. There are two important differences:  
  
-   You can use the *typeName*.*propertyName* combination even when setting an attached property through attribute syntax. Attached properties are the only case where qualifying the property name is a requirement in an attribute syntax.  
  
-   You can also use property element syntax for attached properties. However, for typical property element syntax, the *typeName* you specify is the object element that contains the property element. If you are referring to an attached property, then the *typeName* is the class that defines the attached property, not the containing object element.  
  
<a name="attached_events"></a>   
## Attached Events  
 Attached events are another programming concept introduced in XAML where events can be defined by a specific type, but handlers may be attached on any object element. In the WOF implementation, often the type that defines an attached event is a static type that defines a service, and sometimes those attached events are exposed by a routed event alias in types that expose the service. Handlers for attached events are specified through attribute syntax. As with attached events, the attribute syntax is expanded for attached events to allow a *typeName*.*eventName* usage, where *typeName* is the class that provides `Add` and `Remove` event handler accessors for the attached event infrastructure, and *eventName* is the event name.  
  
<a name="anatomy_of_a_xaml_page_root_element"></a>   
## Anatomy of a XAML Root Element  
 The following table shows a typical XAML root element broken down, showing the specific attributes of a root element:  
  
|||  
|-|-|  
|`<Page`|Opening object element of the root element|  
|`xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"`|The default ([!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]) XAML namespace|  
|`xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`|The XAML language XAML namespace|  
|`x:Class="ExampleNamespace.ExampleCode"`|The partial class declaration that connects markup to any code-behind defined for the partial class|  
|`>`|End of object element for the root. Object is not closed yet because the element contains child elements|  
  
<a name="optional_and_nonrecommended_xaml_usages"></a>   
## Optional and Nonrecommended XAML Usages  
 The following sections describe XAML usages that are technically supported by XAML processors, but that produce verbosity or other aesthetic issues that interfere with XAML files remaining human-readable when your develop applications that contain XAML sources.  
  
### Optional Property Element Usages  
 Optional property element usages include explicitly writing out element content properties that the XAML processor considers implicit. For example, when you declare the contents of a <xref:System.Windows.Controls.Menu>, you could choose to explicitly declare the <xref:System.Windows.Controls.ItemsControl.Items%2A> collection of the <xref:System.Windows.Controls.Menu> as a `<Menu.Items>` property element tag, and place each <xref:System.Windows.Controls.MenuItem> within `<Menu.Items>`, rather than using the implicit XAML processor behavior that all child elements of a <xref:System.Windows.Controls.Menu> must be a <xref:System.Windows.Controls.MenuItem> and are placed in the <xref:System.Windows.Controls.ItemsControl.Items%2A> collection. Sometimes the optional usages can help to visually clarify the object structure as represented in the markup. Or sometimes an explicit property element usage can avoid markup that is technically functional but visually confusing, such as nested markup extensions within an attribute value.  
  
### Full typeName.memberName Qualified Attributes  
 The *typeName*.*memberName* form for an attribute actually works more universally than just the routed event case. But in other situations that form is superfluous and you should avoid it, if only for reasons of markup style and readability. In the following example, each of the three references to the <xref:System.Windows.Controls.Control.Background%2A> attribute are completely equivalent:  
  
 [!code-xaml[XAMLOvwSupport#TypeNameProp](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#typenameprop)]  
  
 `Button.Background` works because the qualified lookup for that property on <xref:System.Windows.Controls.Button> is successful (<xref:System.Windows.Controls.Control.Background%2A> was inherited from Control) and <xref:System.Windows.Controls.Button> is the class of the object element or a base class. `Control.Background` works because the <xref:System.Windows.Controls.Control> class actually defines <xref:System.Windows.Controls.Control.Background%2A> and <xref:System.Windows.Controls.Control> is a <xref:System.Windows.Controls.Button> base class.  
  
 However, the following *typeName*.*memberName* form example does not work and is thus shown commented:  
  
 [!code-xaml[XAMLOvwSupport#TypeNameBadProp](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#typenamebadprop)]  
  
 <xref:System.Windows.Controls.Label> is another derived class of <xref:System.Windows.Controls.Control>, and if you had specified `Label.Background` within a <xref:System.Windows.Controls.Label> object element, this usage would have worked. However, because <xref:System.Windows.Controls.Label> is not the class or base class of <xref:System.Windows.Controls.Button>, the specified XAML processor behavior is to then process `Label.Background` as an attached property. `Label.Background` is not an available attached property, and this usage fails.  
  
### baseTypeName.memberName Property Elements  
 In an analogous way to how the *typeName*.*memberName* form works for attribute syntax, a *baseTypeName*.*memberName* syntax works for property element syntax. For instance, the following syntax works:  
  
 [!code-xaml[XAMLOvwSupport#GoofyPE](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page8.xaml#goofype)]  
  
 Here, the property element was given as `Control.Background` even though the property element was contained in `Button`.  
  
 But just like *typeName*.*memberName* form for attributes, *baseTypeName*.*memberName* is poor style in markup, and you should avoid it.  
  
## See Also  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [XAML Namespace (x:) Language Features](../../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md)  
 [WPF XAML Extensions](../../../../docs/framework/wpf/advanced/wpf-xaml-extensions.md)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [TypeConverters and XAML](../../../../docs/framework/wpf/advanced/typeconverters-and-xaml.md)  
 [XAML and Custom Classes for WPF](../../../../docs/framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md)
