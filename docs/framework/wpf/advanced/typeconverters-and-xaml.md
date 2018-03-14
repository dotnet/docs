---
title: "TypeConverters and XAML"
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
  - "XAML [WPF], TypeConverter class"
ms.assetid: f6313e4d-e89d-497d-ac87-b43511a1ae4b
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TypeConverters and XAML
This topic introduces the purpose of type conversion from string as a general XAML language feature. In the .NET Framework, the <xref:System.ComponentModel.TypeConverter> class serves a particular purpose as part of the implementation for a managed custom class that can be used as a property value in XAML attribute usage. If you write a custom class, and you want instances of your class to be usable as XAML settable attribute values, you might need to apply a <xref:System.ComponentModel.TypeConverterAttribute> to your class, write a custom <xref:System.ComponentModel.TypeConverter> class, or both.  
  

  
## Type Conversion Concepts  
  
### XAML and String Values  
 When you set an attribute value in a XAML file, the initial type of that value is a string in pure text. Even other primitives such as <xref:System.Double> are initially text strings to a XAML processor.  
  
 A XAML processor needs two pieces of information in order to process an attribute value. The first piece of information is the value type of the property that is being set. Any string that defines an attribute value and that is processed in XAML must ultimately be converted or resolved to a value of that type. If the value is a primitive that is understood by the XAML parser (such as a numeric value), a direct conversion of the string is attempted. If the value is an enumeration, the string is used to check for a name match to a named constant in that enumeration. If the value is neither a parser-understood primitive nor an enumeration, then the type in question must be able to provide an instance of the type, or a value, based on a converted string. This is done by indicating a type converter class. The type converter is effectively a helper class for providing values of another class, both for the XAML scenario and also potentially for code calls in .NET code.  
  
### Using Existing Type Conversion Behavior in XAML  
 Depending on your familiarity with the underlying XAML concepts, you may already be using type conversion behavior in basic application XAML without realizing it. For instance, WPF defines literally hundreds of properties that take a value of type <xref:System.Windows.Point>. A <xref:System.Windows.Point> is a value that describes a coordinate in a two-dimensional coordinate space, and it really just has two important properties: <xref:System.Windows.Point.X%2A> and <xref:System.Windows.Point.Y%2A>. When you specify a point in XAML, you specify it as a string with a delimiter (typically a comma) between the <xref:System.Windows.Point.X%2A> and <xref:System.Windows.Point.Y%2A> values you provide. For example: `<LinearGradientBrush StartPoint="0,0" EndPoint="1,1">`.  
  
 Even this simple type of <xref:System.Windows.Point> and its simple usage in XAML involve a type converter. In this case that is the class <xref:System.Windows.PointConverter>.  
  
 The type converter for <xref:System.Windows.Point> defined at the class level streamlines the markup usages of all properties that take <xref:System.Windows.Point>. Without a type converter here, you would need the following much more verbose markup for the same example shown previously:  
  
 `<LinearGradientBrush>`  
  
 `<LinearGradientBrush.StartPoint>`  
  
 `<Point X="0" Y="0"/>`  
  
 `</LinearGradientBrush.StartPoint>`  
  
 `<LinearGradientBrush.EndPoint>`  
  
 `<Point X="1" Y="1"/>`  
  
 `</LinearGradientBrush.EndPoint>`  
  
 `<LinearGradientBrush>`  
  
 Whether to use the type conversion string or a more verbose equivalent syntax is generally a coding style choice. Your XAML tooling workflow might also influence how values are set. Some XAML tools tend to emit the most verbose form of the markup because it is easier to round-trip to designer views or its own serialization mechanism.  
  
 Existing type converters can generally be discovered on WPF and .NET Framework types by checking a class (or property) for the presence of an applied <xref:System.ComponentModel.TypeConverterAttribute>. This attribute will name the class that is the supporting type converter for values of that type, for XAML purposes as well as potentially other purposes.  
  
### Type Converters and Markup Extensions  
 Markup extensions and type converters fill orthogonal roles in terms of XAML processor behavior and the scenarios that they are applied to. Although context is available for markup extension usages, type conversion behavior of properties where a markup extension provides a value is generally is not checked in the markup extension implementations. In other words, even if a markup extension returns a text string as its `ProvideValue` output, type conversion behavior on that string as applied to a specific property or property value type is not invoked, Generally, the purpose of a markup extension is to process a string and return an object without any type converter involved.  
  
 One common situation where a markup extension is necessary rather than a type converter is to make a reference to an object that already exists. At best, a stateless type converter could only generate a new instance, which might not be desirable. For more information on markup extensions, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
### Native Type Converters  
 In the WPF and .NET Framework implementation of the XAML parser, there are certain types that have native type conversion handling, yet are not types that might conventionally be thought of as primitives. An example of such a type is <xref:System.DateTime>. The reason for this is based on how the .NET Framework architecture works: the type <xref:System.DateTime> is defined in mscorlib, the most basic library in .NET. <xref:System.DateTime> is not permitted to be attributed with an attribute that comes from another assembly that introduces a dependency (<xref:System.ComponentModel.TypeConverterAttribute> is from System) so the usual type converter discovery mechanism by attributing cannot be supported. Instead, the XAML parser has a list of types that need such native processing and processes these similarly to how the true primitives are processed. (In the case of <xref:System.DateTime> this involves a call to <xref:System.DateTime.Parse%2A>.)  
  
<a name="Implementing_a_Type_Converter"></a>   
## Implementing a Type Converter  
  
### TypeConverter  
 In the <xref:System.Windows.Point> example given previously, the class <xref:System.Windows.PointConverter> was mentioned. For .NET implementations of XAML, all type converters that are used for XAML purposes are classes that derive from the base class <xref:System.ComponentModel.TypeConverter>. The <xref:System.ComponentModel.TypeConverter> class existed in versions of .NET Framework that precede the existence of XAML; one of its original usages was to provide string conversion for property dialogs in visual designers. For XAML, the role of <xref:System.ComponentModel.TypeConverter> is expanded to include being the base class for to-string and from-string conversions that enable parsing a string attribute value, and possibly processing a run-time value of a particular object property back into a string for serialization as an attribute.  
  
 <xref:System.ComponentModel.TypeConverter> defines four members that are relevant for converting to and from strings for XAML processing purposes:  
  
-   <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A>  
  
 Of these, the most important method is <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A>. This method converts the input string to the required object type. Strictly speaking, the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> method could be implemented to convert a much wider range of types into the converter's intended destination type, and thus serve purposes that extend beyond XAML such as supporting run-time conversions, but for XAML purposes it is only the code path that can process a <xref:System.String> input that matters.  
  
 The next most important method is <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>. If an application is converted to a markup representation (for instance, if it is saved to XAML as a file), <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> is responsible for producing a markup representation. In this case, the code path that matters for XAML is when you pass a `destinationType` of <xref:System.String> .  
  
 <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> and <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A> are support methods that are used when a service queries the capabilities of the <xref:System.ComponentModel.TypeConverter> implementation. You must implement these methods to return `true` for type-specific cases that the equivalent conversion methods of your converter support. For XAML purposes, this generally means the <xref:System.String> type.  
  
### Culture Information and Type Converters for XAML  
 Each <xref:System.ComponentModel.TypeConverter> implementation can have its own interpretation of what constitutes a valid string for a conversion, and can also use or ignore the type description passed as parameters. There is an important consideration with regard to culture and XAML type conversion. Using localizable strings as attribute values is entirely supported by XAML. But using that localizable string as type converter input with specific culture requirements is not supported, because type converters for XAML attribute values involve a necessarily fixed-language parsing behavior, using `en-US` culture. For more information on the design reasons for this restriction, you should consult the XAML language specification ([\[MS-XAML\]](http://go.microsoft.com/fwlink/?LinkId=114525)).  
  
 As an example where culture can be an issue, some cultures use a comma as their decimal point delimiter for numbers. This will collide with the behavior that many of the WPF XAML type converters have, which is to use a comma as a delimiter (based on historical precedents such as the common X,Y form, or comma delimited lists). Even passing a culture in the surrounding XAML (setting `Language` or `xml:lang` to the `sl-SI` culture, an example of a culture that uses a comma for decimal in this way) does not solve the issue.  
  
### Implementing ConvertFrom  
 To be usable as a <xref:System.ComponentModel.TypeConverter> implementation that supports XAML, the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> method for that converter must accept a string as the `value` parameter. If the string was in valid format, and can be converted by the <xref:System.ComponentModel.TypeConverter> implementation, then the returned object must support a cast to the type expected by the property. Otherwise, the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> implementation must return `null`.  
  
 Each <xref:System.ComponentModel.TypeConverter> implementation can have its own interpretation of what constitutes a valid string for a conversion, and can also use or ignore the type description or culture contexts passed as parameters. However, the WPF XAML processing might not pass values to the type description context in all cases, and also might not pass culture based on `xml:lang`.  
  
> [!NOTE]
>  Do not use the curly brace characters, particularly {, as a possible element of your string format. These characters are reserved as the entry and exit for a markup extension sequence.  
  
### Implementing ConvertTo  
 <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> is potentially used for serialization support. Serialization support through <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> for your custom type and its type converter is not an absolute requirement. However, if you are implementing a control, or using serialization of as part of the features or design of your class, you should implement <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>.  
  
 To be usable as a <xref:System.ComponentModel.TypeConverter> implementation that supports XAML, the <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> method for that converter must accept an instance of the type (or a value) being supported as the `value` parameter. When the `destinationType` parameter is the type <xref:System.String>, then the returned object must be able to be cast as <xref:System.String>. The returned string must represent a serialized value of `value`. Ideally, the serialization format you choose should be capable of generating the same value if that string were passed to the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> implementation of the same converter, without significant loss of information.  
  
 If the value cannot be serialized, or the converter does not support serialization, the <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> implementation must return `null`, and is permitted to throw an exception in this case. But if you do throw exceptions, you should report the inability to use that conversion as part of your <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> implementation so that the best practice of checking with <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> first to avoid exceptions is supported.  
  
 If `destinationType` parameter is not of type <xref:System.String>, you can choose your own converter handling. Typically, you would revert to base implementation handling, which in the basemost <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> raises a specific exception.  
  
### Implementing CanConvertTo  
 Your <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> implementation should return `true` for `destinationType` of type <xref:System.String>, and otherwise defer to the base implementation.  
  
### Implementing CanConvertFrom  
 Your <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A> implementation should return `true` for `sourceType` of type <xref:System.String>, and otherwise defer to the base implementation.  
  
<a name="Applying_the_TypeConverterAttribute"></a>   
## Applying the TypeConverterAttribute  
 In order for your custom type converter to be used as the acting type converter for a custom class by a XAML processor, you must apply the [!INCLUDE[TLA#tla_netframewkattr](../../../../includes/tlasharptla-netframewkattr-md.md)] <xref:System.ComponentModel.TypeConverterAttribute> to your class definition. The <xref:System.ComponentModel.TypeConverterAttribute.ConverterTypeName%2A> that you specify through the attribute must be the type name of your custom type converter. With this attribute applied, when a XAML processor handles values where the property type uses your custom class type, it can input strings and return object instances.  
  
 You can also provide a type converter on a per-property basis. Instead of applying a [!INCLUDE[TLA#tla_netframewkattr](../../../../includes/tlasharptla-netframewkattr-md.md)] <xref:System.ComponentModel.TypeConverterAttribute> to the class definition, apply it to a property definition (the main definition, not the `get`/`set` implementations within it). The type of the property must match the type that is processed by your custom type converter. With this attribute applied, when a XAMLprocessor handles values of that property, it can process input strings and return object instances. The per-property type converter technique is particularly useful if you choose to use a property type from [!INCLUDE[TLA#tla_netframewk](../../../../includes/tlasharptla-netframewk-md.md)] or from some other library where you cannot control the class definition and cannot apply a <xref:System.ComponentModel.TypeConverterAttribute> there.  
  
## See Also  
 <xref:System.ComponentModel.TypeConverter>  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md)
