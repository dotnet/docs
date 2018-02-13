---
title: "Binding Markup Extension"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "Binding"
helpviewer_keywords: 
  - "Binding markup extensions [WPF]"
  - "XAML [WPF], Binding markup extension"
ms.assetid: 83d6e2a4-1b0c-4fc8-bd96-b5e98800ab63
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Binding Markup Extension
Defers a property value to be a data-bound value, creating an intermediate expression object and interpreting the data context that applies to the element and its binding at run time.  
  
## Binding Expression Usage  
  
```  
<object property="{Binding}" .../>  
-or-  
<object property="{Binding  bindProp1=value1[, bindPropN=valueN]*}" ...  
/>  
-or-  
<object property="{Binding path}" .../>  
-or  
<object property="{Binding path[, bindPropN=valueN]*}" .../>  
```  
  
## Syntax Notes  
 In these syntaxes, the `[]` and `*` are not literals. They are part of a notation to indicate that zero or more *bindProp*`=`*value* pairs can be used, with a `,` separator between them and preceding *bindProp*`=`*value* pairs.  
  
 Any of the properties listed in the "Binding Properties That Can Be Set with the Binding Extension" section could instead be set using attributes of a <xref:System.Windows.Data.Binding> object element. However, that is not truly the markup extension usage of <xref:System.Windows.Data.Binding>, it is just the general XAML processing of attributes that set properties of the CLR <xref:System.Windows.Data.Binding> class. In other words, `<Binding` *bindProp1*`="`*value1*`"[` *bindPropN*`="`*valueN*`"]*/>` is an equivalent syntax for attributes of <xref:System.Windows.Data.Binding> object element usage instead of a `Binding` expression usage. To learn about the XAML attribute usage of specific properties of <xref:System.Windows.Data.Binding>, see the "XAML Attribute Usage" section of the relevant property of <xref:System.Windows.Data.Binding> in the .NET Framework Class Library.  
  
## XAML Values  
  
|||  
|-|-|  
|`bindProp1, bindPropN`|The name of the <xref:System.Windows.Data.Binding> or <xref:System.Windows.Data.BindingBase> property to set. Not all <xref:System.Windows.Data.Binding> properties can be set with the `Binding` extension, and some properties are settable within a `Binding` expression only by using further nested markup extensions. See "Binding Properties That Can Be Set with the Binding Extension" section.|  
|`value1, valueN`|The value to set the property to. The handling of the attribute value is ultimately specific to the type and logic of the specific <xref:System.Windows.Data.Binding> property being set.|  
|`path`|The path string that sets the implicit <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType> property. See also [PropertyPath XAML Syntax](../../../../docs/framework/wpf/advanced/propertypath-xaml-syntax.md).|  
  
## Unqualified {Binding}  
 The `{Binding}` usage shown in "Binding Expression Usage" creates a <xref:System.Windows.Data.Binding> object with default values, which includes an initial <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType> of `null`. This is still useful in many scenarios, because the created <xref:System.Windows.Data.Binding> might be relying on key data binding properties such as <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType> and <xref:System.Windows.Data.Binding.Source%2A?displayProperty=nameWithType> being set in the run-time data context. For more information on the concept of data context, see [Data Binding](../../../../docs/framework/wpf/data/data-binding-wpf.md).  
  
## Implicit Path  
 The `Binding` markup extension uses <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType> as a conceptual "default property", where `Path=` does not need to appear in the expression. If you specify a `Binding` expression with an implicit path, the implicit path must appear first in the expression, prior to any other `bindProp`=`value` pairs where the <xref:System.Windows.Data.Binding> property is specified by name. For example: `{Binding PathString}`, where `PathString` is a string that is evaluated to be the value of <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType> in the <xref:System.Windows.Data.Binding> created by the markup extension usage. You can append an implicit path with other named properties after the comma separator, for example, `{Binding LastName, Mode=TwoWay}`.  
  
## Binding Properties That Can Be Set with the Binding Extension  
 The syntax shown in this topic uses the generic `bindProp`=`value` approximation, because there are many read/write properties of <xref:System.Windows.Data.BindingBase> or <xref:System.Windows.Data.Binding> that can be set through the `Binding` markup extension / expression syntax. They can be set in any order, with the exception of an implicit <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType>. (You do have the option to explicitly specify `Path=`, in which case it can be set in any order). Basically, you can set zero or more of the properties in the list below, using `bindProp`=`value` pairs separated by commas.  
  
 Several of these property values require object types that do not support a native type conversion from a text syntax in XAML, and thus require markup extensions in order to be set as an attribute value. Check the XAML Attribute Usage section in the .NET Framework Class Library for each property for more information; the string you use for XAML attribute syntax with or without further markup extension usage is basically the same as the value you specify in a `Binding` expression, with the exception that you do not place quotation marks around each `bindProp`=`value` in the `Binding` expression.  
  
-   <xref:System.Windows.Data.BindingBase.BindingGroupName%2A>: a string that identifies a possible binding group. This is a relatively advanced binding concept; see reference page for <xref:System.Windows.Data.BindingBase.BindingGroupName%2A>.  
  
-   <xref:System.Windows.Data.Binding.BindsDirectlyToSource%2A>: Boolean, can be either `true` or `false`. The default is `false`.  
  
-   <xref:System.Windows.Data.Binding.Converter%2A>: can be set as a `bindProp`=`value` string in the expression, but to do so requires an object reference for the value, such as a [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md). The value in this case is an instance of a custom converter class.  
  
-   <xref:System.Windows.Data.Binding.ConverterCulture%2A>: settable in the expression as a standards-based identifier; see the reference topic for <xref:System.Windows.Data.Binding.ConverterCulture%2A>.  
  
-   <xref:System.Windows.Data.Binding.ConverterParameter%2A>: can be set as a `bindProp`=`value` string in the expression, but this is dependent on the type of the parameter being passed. If passing a reference type for the value, this usage requires an object reference such as a nested [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md).  
  
-   <xref:System.Windows.Data.Binding.ElementName%2A>: mutually exclusive versus <xref:System.Windows.Data.Binding.RelativeSource%2A> and <xref:System.Windows.Data.Binding.Source%2A>; each of these binding properties represents a particular binding methodology. See [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
-   <xref:System.Windows.Data.BindingBase.FallbackValue%2A>: can be set as a `bindProp`=`value` string in the expression, but this is dependent on the type of the value being passed. If passing a reference type, requires an object reference such as a nested [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md).  
  
-   <xref:System.Windows.Data.Binding.IsAsync%2A>: Boolean, can be either `true` or `false`. The default is `false`.  
  
-   <xref:System.Windows.Data.Binding.Mode%2A>: *value* is a constant name from the <xref:System.Windows.Data.BindingMode> enumeration. For example, `{Binding Mode=OneWay}`.  
  
-   <xref:System.Windows.Data.Binding.NotifyOnSourceUpdated%2A>: Boolean, can be either `true` or `false`. The default is `false`.  
  
-   <xref:System.Windows.Data.Binding.NotifyOnTargetUpdated%2A>: Boolean, can be either `true` or `false`. The default is `false`.  
  
-   <xref:System.Windows.Data.Binding.NotifyOnValidationError%2A>: Boolean, can be either `true` or `false`. The default is `false`.  
  
-   <xref:System.Windows.Data.Binding.Path%2A>: a string that describes a path into a data object or a general object model. The format provides several different conventions for traversing an object model that cannot be adequately described in this topic. See [PropertyPath XAML Syntax](../../../../docs/framework/wpf/advanced/propertypath-xaml-syntax.md).  
  
-   <xref:System.Windows.Data.Binding.RelativeSource%2A>: mutually exclusive versus with <xref:System.Windows.Data.Binding.ElementName%2A> and <xref:System.Windows.Data.Binding.Source%2A>; each of these binding properties represents a particular binding methodology. See [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md). Requires a nested [RelativeSource MarkupExtension](../../../../docs/framework/wpf/advanced/relativesource-markupextension.md) usage to specify the value.  
  
-   <xref:System.Windows.Data.Binding.Source%2A>: mutually exclusive versus <xref:System.Windows.Data.Binding.RelativeSource%2A> and <xref:System.Windows.Data.Binding.ElementName%2A>; each of these binding properties represents a particular binding methodology. See [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md). Requires a nested extension usage, typically a [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md) that refers to an object data source from a keyed resource dictionary.  
  
-   <xref:System.Windows.Data.BindingBase.StringFormat%2A>: a string that describes a string format convention for the bound data. This is a relatively advanced binding concept; see reference page for <xref:System.Windows.Data.BindingBase.StringFormat%2A>.  
  
-   <xref:System.Windows.Data.BindingBase.TargetNullValue%2A>: can be set as a `bindProp`=`value` string in the expression, but this is dependent on the type of the parameter being passed. If passing a reference type for the value, requires an object reference such as a nested [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md).  
  
-   <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A>: *value* is a constant name from the <xref:System.Windows.Data.UpdateSourceTrigger> enumeration. For example, `{Binding UpdateSourceTrigger=LostFocus}`. Specific controls potentially have different default values for this binding property. See <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A>.  
  
-   <xref:System.Windows.Data.Binding.ValidatesOnDataErrors%2A>: Boolean, can be either `true` or `false`. The default is `false`. See Remarks.  
  
-   <xref:System.Windows.Data.Binding.ValidatesOnExceptions%2A>: Boolean, can be either `true` or `false`. The default is `false`. See Remarks.  
  
-   <xref:System.Windows.Data.Binding.XPath%2A>: a string that describes a path into the XMLDOM of an XML data source. See [Bind to XML Data Using an XMLDataProvider and XPath Queries](../../../../docs/framework/wpf/data/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md).  
  
 The following are properties of <xref:System.Windows.Data.Binding> that cannot be set using the `Binding` markup extension/`{Binding}` expression form.  
  
-   <xref:System.Windows.Data.Binding.UpdateSourceExceptionFilter%2A>: this property expects a reference to a callback implementation. Callbacks/methods other than event handlers cannot be referenced in XAML syntax.  
  
-   <xref:System.Windows.Data.Binding.ValidationRules%2A>: the property takes a generic collection of <xref:System.Windows.Controls.ValidationRule> objects. This could be expressed as a property element in a <xref:System.Windows.Data.Binding> object element, but has no readily available attribute-parsing technique for usage in a `Binding` expression. See reference topic for <xref:System.Windows.Data.Binding.ValidationRules%2A>.  
  
-   <xref:System.Windows.Data.Binding.XmlNamespaceManager%2A>  
  
## Remarks  
  
> [!IMPORTANT]
>  In terms of dependency property precedence, a `Binding` expression is equivalent to a locally set value. If you set a local value for a property that previously had a `Binding` expression, the `Binding` is completely removed. For details, see [Dependency Property Value Precedence](../../../../docs/framework/wpf/advanced/dependency-property-value-precedence.md).  
  
 Describing data binding at a basic level is not covered in this topic. See [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
> [!NOTE]
>  <xref:System.Windows.Data.MultiBinding> and <xref:System.Windows.Data.PriorityBinding> do not support a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] extension syntax. You would instead use property elements. See reference topics for <xref:System.Windows.Data.MultiBinding> and <xref:System.Windows.Data.PriorityBinding>.  
  
 Boolean values for XAML are case insensitive. For example you could specify either `{Binding NotifyOnValidationError=true}` or `{Binding NotifyOnValidationError=True}`.  
  
 Bindings that involve data validation are typically specified by an explicit `Binding` element rather than as a `{Binding ...}` expression, and setting <xref:System.Windows.Data.Binding.ValidatesOnDataErrors%2A> or <xref:System.Windows.Data.Binding.ValidatesOnExceptions%2A> in an expression is uncommon. This is because the companion property <xref:System.Windows.Data.Binding.ValidationRules%2A> cannot be readily set in the expression form. For more information, see [Implement Binding Validation](../../../../docs/framework/wpf/data/how-to-implement-binding-validation.md).  
  
 `Binding` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than type converters attributed on certain types or properties. All markup extensions in XAML use the `{` and `}` characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the string contents. For more information, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
 `Binding` is an atypical markup extension in that the <xref:System.Windows.Data.Binding> class that implements the extension functionality for WPF's XAML implementation also implements several other methods and properties that are not related to XAML. The other members are intended to make <xref:System.Windows.Data.Binding> a more versatile and self-contained class that can address many data binding scenarios in addition to functioning as a XAML markup extension.  
  
## See Also  
 <xref:System.Windows.Data.Binding>  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)
