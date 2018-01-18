---
title: "Type Converters for XAML Overview"
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
  - "XAML [XAML Services], type converters"
  - "XAML [XAML Services], TypeConverter"
  - "type conversion for XAML [XAML Services]"
ms.assetid: 51a65860-efcb-4fe0-95a0-1c679cde66b7
caps.latest.revision: 14
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Type Converters for XAML Overview
Type converters supply logic for an object writer that converts from a string in XAML markup into particular objects in an object graph. In .NET Framework XAML Services, the type converter must be a class that derives from <xref:System.ComponentModel.TypeConverter>. Some converters also support the XAML save path and can be used to serialize an object into a string form in serialization markup. This topic describes how and when type converters in XAML are invoked, and provides implementation advice for the method overrides of <xref:System.ComponentModel.TypeConverter>.  
  
<a name="type_conversion_concepts"></a>   
## Type Conversion Concepts  
 The following sections explain basic concepts about how XAML uses strings, and how object writers in .NET Framework XAML Services use type converters to process some of the string values that are encountered in a XAML source.  
  
### XAML and String Values  
 When you set an attribute value in a XAML file, the initial type of that value is a string in a general sense, and a string attribute value in an XML sense. Even other primitives such as <xref:System.Double> are initially strings to a XAML processor.  
  
 In most cases, a XAML processor needs two pieces of information to process an attribute value. The first piece of information is the value type of the property that is being set. Any string that defines an attribute value and that is processed in XAML must ultimately be converted or resolved to a value of that type. If the value is a primitive that is understood by the XAML parser (such as a numeric value), a direct conversion of the string is attempted. If the value for the attribute references an enumeration, the supplied string is checked for a name match to a named constant in that enumeration. If the value is neither a parser-understood primitive nor a constant name from an enumeration, the applicable type must be able to provide a value or reference that is based on a converted string.  
  
> [!NOTE]
>  XAML language directives do not use type converters.  
  
### Type Converters and Markup Extensions  
 Markup extension usages must be handled by a XAML processor before it checks for property type and other considerations. For example, if a property being set as an attribute normally has a type conversion, but in a particular case is set by a markup extension usage, then the markup extension behavior processes first. One common situation where a markup extension is necessary is to make a reference to an object that already exists. For this scenario, a stateless type converter can only generate a new instance, which might not be desirable. For more information about markup extensions, see [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md).  
  
### Native Type Converters  
 In the WPF and .NET XAML services implementations, there are certain CLR types that have native type conversion handling, however, those CLR types are not conventionally thought of as primitives. An example of such a type is <xref:System.DateTime>. One reason for this is how the .NET Framework architecture works: the type <xref:System.DateTime> is defined in mscorlib, the most basic library in .NET. <xref:System.DateTime> is not permitted to be attributed with an attribute that comes from another assembly that introduces a dependency (<xref:System.ComponentModel.TypeConverterAttribute> is from System); therefore, the usual type converter discovery mechanism by attributing cannot be supported. Instead, the XAML parser has a list of types that need native processing, and it processes these types similar to how the true primitives are processed. In the case of <xref:System.DateTime>, this processing involves a call to <xref:System.DateTime.Parse%2A>.  
  
<a name="Implementing_a_Type_Converter"></a>   
## Implementing a Type Converter  
 The following sections discuss the API of the <xref:System.ComponentModel.TypeConverter> class.  
  
### TypeConverter  
 Under .NET Framework XAML Services, all type converters that are used for XAML purposes are classes that derive from the base class <xref:System.ComponentModel.TypeConverter>. The <xref:System.ComponentModel.TypeConverter> class existed in versions of the .NET Framework before XAML existed; one of the original <xref:System.ComponentModel.TypeConverter> scenarios was to provide string conversion for property editors in visual designers.  
  
 For XAML, the role of <xref:System.ComponentModel.TypeConverter> is expanded. For XAML purposes, <xref:System.ComponentModel.TypeConverter> is the base class for providing support for certain to-string and from-string conversions. From-string enables parsing a string attribute value from XAML. To-string might enable processing a run-time value of a particular object property back into an attribute in XAML for serialization.  
  
 <xref:System.ComponentModel.TypeConverter> defines four members that are relevant for converting to-string and from-string for XAML processing purposes:  
  
-   <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>  
  
-   <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A>  
  
 Of these members, the most important method is <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A>, which converts the input string to the required object type. The <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> method can be implemented to convert a wider range of types into the intended destination type of the converter. Therefore, it can serve purposes that extend beyond XAML, such as supporting run-time conversions. However, for XAML use, only the code path that can process a <xref:System.String> input is important.  
  
 The second most important method is <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>. If an application is converted to a markup representation (for example, if it is saved to XAML as a file), <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> is involved in the larger scenario of a XAML text writers produce a markup representation. In this case, the important code path for XAML is when the caller passes a `destinationType` of <xref:System.String>.  
  
 <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> and <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A> are support methods that are used when a service queries the capabilities of the <xref:System.ComponentModel.TypeConverter> implementation. You must implement these methods to return `true` for type-specific cases that the equivalent conversion methods of your converter support. For XAML purposes, this generally means the <xref:System.String> type.  
  
### Culture Information and Type Converters for XAML  
 Each <xref:System.ComponentModel.TypeConverter> implementation can uniquely interpret what is a valid string for a conversion, and it can also use or ignore the type description that is passed as parameters. An important consideration for culture and XAML type conversion is the following: although using localizable strings as attribute values is supported by XAML, you cannot use these localizable strings as type converter input with specific culture requirements. This limitation is because type converters for XAML attribute values involve a necessarily fixed-language XAML-processing behavior that uses `en-US` culture. For more information about the design reasons for this restriction, see the XAML language specification ([\[MS-XAML\]](http://go.microsoft.com/fwlink/?LinkId=114525)) or [WPF Globalization and Localization Overview](../../../docs/framework/wpf/advanced/wpf-globalization-and-localization-overview.md).  
  
 As an example where culture can be an issue, some cultures use a comma instead of a period as the decimal point delimiter for numbers in string form. This use collides with the behavior that many existing type converters have, which is to use a comma as a delimiter. Passing a culture through `xml:lang` in the surrounding XAML does not solve the issue.  
  
### Implementing ConvertFrom  
 To be usable as a <xref:System.ComponentModel.TypeConverter> implementation that supports XAML, the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> method for that converter must accept a string as the `value` parameter. If the string is in a valid format and can be converted by the <xref:System.ComponentModel.TypeConverter> implementation, the returned object must support a cast to the type that is expected by the property. Otherwise, the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> implementation must return `null`.  
  
 Each <xref:System.ComponentModel.TypeConverter> implementation can uniquely interpret what constitutes a valid string for a conversion, and it can also use or ignore the type description or culture contexts that are passed as parameters. However, the WPF XAML processing might not pass values to the type description context in all cases and also might not pass culture based on `xml:lang`.  
  
> [!NOTE]
>  Do not use the braces ({}), specifically the opening brace ({), as an element of your string format. These characters are reserved as the entry and exit for a markup extension sequence.  
  
 It is appropriate to throw an exception when your type converter must have access to a XAML service from the .NET Framework XAML Services object writer, but the <xref:System.IServiceProvider.GetService%2A> call that is made against the context does not return that service.  
  
### Implementing ConvertTo  
 <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> is potentially used for serialization support. Serialization support through <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> for your custom type and its type converter is not an absolute requirement. However, if you are implementing a control, or using serialization of as part of the features or design of your class, you should implement <xref:System.ComponentModel.TypeConverter.ConvertTo%2A>.  
  
 To be usable as a <xref:System.ComponentModel.TypeConverter> implementation that supports XAML, the <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> method for that converter must accept an instance of the type (or a value) that is supported as the `value` parameter. When the `destinationType` parameter is of type <xref:System.String>, the returned object must be able to be cast as <xref:System.String>. The returned string must represent a serialized value of `value`. Ideally, the serialization format that you choose should be able to generate the same value as if that string were passed to the <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A> implementation of the same converter, without significant loss of information.  
  
 If the value cannot be serialized or the converter does not support serialization, the <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> implementation must return `null` and can throw an exception. However, if you do throw exceptions, you should report the inability to use that conversion as part of your <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> implementation so that the best practice of checking with <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> first to avoid exceptions is supported.  
  
 If the `destinationType` parameter is not of type <xref:System.String>, you can choose your own converter handling. Typically, you revert to base implementation handling, which in the base <xref:System.ComponentModel.TypeConverter.ConvertTo%2A> raises a specific exception.  
  
 It is appropriate to throw an exception when your type converter must have access to a XAML service from the .NET Framework XAML Services object writer, but the <xref:System.IServiceProvider.GetService%2A> call that is made against the context does not return that service.  
  
### Implementing CanConvertFrom  
 Your <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A> implementation should return `true` for `sourceType` of type <xref:System.String> and otherwise, defer to the base implementation. Do not throw exceptions from <xref:System.ComponentModel.TypeConverter.CanConvertFrom%2A>.  
  
### Implementing CanConvertTo  
 Your <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A> implementation should return `true` for `destinationType` of type <xref:System.String>, and otherwise defer to the base implementation. Do not throw exceptions from <xref:System.ComponentModel.TypeConverter.CanConvertTo%2A>.  
  
<a name="Applying_the_TypeConverterAttribute"></a>   
## Applying the TypeConverterAttribute  
 For your custom type converter to be used as the acting type converter for a custom class by .NET Framework XAML Services, you must apply the [!INCLUDE[TLA#tla_netframewkattr](../../../includes/tlasharptla-netframewkattr-md.md)] <xref:System.ComponentModel.TypeConverterAttribute> to your class definition. The <xref:System.ComponentModel.TypeConverterAttribute.ConverterTypeName%2A> that you specify through the attribute must be the type name of your custom type converter. If you apply this attribute, when a XAML processor handles values where the property type uses your custom class type, it can input strings and return object instances.  
  
 You can also provide a type converter on a per-property basis. Instead of applying a [!INCLUDE[TLA#tla_netframewkattr](../../../includes/tlasharptla-netframewkattr-md.md)] <xref:System.ComponentModel.TypeConverterAttribute> to the class definition, apply it to a property definition (the main definition, not the `get`/`set` implementations within it). The type of the property must match the type that is processed by your custom type converter. With this attribute applied, when a XAML processor handles values of that property, it can process input strings and return object instances. The per-property type converter technique is particularly useful if you choose to use a property type from [!INCLUDE[TLA#tla_netframewk](../../../includes/tlasharptla-netframewk-md.md)] or from some other library where you cannot control the class definition and cannot apply a <xref:System.ComponentModel.TypeConverterAttribute> there.  
  
 To supply a type conversion behavior for a custom attached member, apply <xref:System.ComponentModel.TypeConverterAttribute> to the `Get` accessor method of the implementation pattern for the attached member.  
  
<a name="accessing_service_provider_context_from_a_markup_extension_implementation"></a>   
## Accessing Service Provider Context from a Markup Extension Implementation  
 The available services are the same for any value converter. The difference is in how each value converter receives the service context. Accessing services and the services available are documented in the topic [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
<a name="type_converters_in_the_xaml_node_stream"></a>   
## Type Converters in the XAML Node Stream  
 If you are working with a XAML node stream, the action or end result of a type converter is not yet executed. In a load path, the attribute string that eventually needs to be type-converted in order to load remains as a text value within a start member and end member. The type converter that is eventually needed for this operation can be determined by using the <xref:System.Xaml.XamlMember.TypeConverter%2A?displayProperty=nameWithType> property. However, obtaining a valid value from <xref:System.Xaml.XamlMember.TypeConverter%2A?displayProperty=nameWithType> relies on having a XAML schema context, which can access such information through the underlying member, or the type of the object value that the member uses. Invoking the type conversion behavior also requires the XAML schema context because that requires type-mapping and creating a converter instance.  
  
## See Also  
 <xref:System.ComponentModel.TypeConverterAttribute>  
 [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md)  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
