---
title: "TemplateBinding Markup Extension"
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
  - "TemplateBinding"
  - "TemplateBindingExtension"
helpviewer_keywords: 
  - "XAML [WPF], TemplateBinding markup extension"
  - "TemplateBinding markup extensions [WPF]"
ms.assetid: 1d25bbfc-dbc2-499d-9f12-419d23d4ac6a
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TemplateBinding Markup Extension
Links the value of a property in a control template to be the value of another property on the templated control.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{TemplateBinding sourceProperty}" .../>  
```  
  
## XAML Attribute Usage (for Setter property in template or style)  
  
```xml  
<Setter Property="propertyName" Value="{TemplateBinding sourceProperty}" .../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`propertyName`|<xref:System.Windows.DependencyProperty.Name%2A?displayProperty=nameWithType> of the property being set in the setter syntax.|  
|`sourceProperty`|Another dependency property that exists on the type being templated, specified by its <xref:System.Windows.DependencyProperty.Name%2A?displayProperty=nameWithType>.<br /><br /> - or -<br /><br /> A "dotted-down" property name that is defined by a different type than the target type being templated. This is actually a <xref:System.Windows.PropertyPath>. See [PropertyPath XAML Syntax](../../../../docs/framework/wpf/advanced/propertypath-xaml-syntax.md).|  
  
## Remarks  
 A `TemplateBinding` is an optimized form of a [Binding](../../../../docs/framework/wpf/advanced/binding-markup-extension.md) for template scenarios, analogous to a `Binding` constructed with `{Binding RelativeSource={RelativeSource TemplatedParent}}`. A `TemplateBinding` is always a one-way binding, even if properties involved default to two-way binding. Both properties involved must be dependency properties.  
  
 [RelativeSource](../../../../docs/framework/wpf/advanced/relativesource-markupextension.md) is another markup extension that is sometimes used in conjunction with or instead of `TemplateBinding` in order to perform relative property binding within a template.  
  
 Describing control templates as a concept is not covered here; for more information, see [Control Styles and Templates](../../../../docs/framework/wpf/controls/control-styles-and-templates.md).  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `TemplateBinding` identifier string is assigned as the <xref:System.Windows.TemplateBindingExtension.Property%2A> value of the underlying <xref:System.Windows.TemplateBindingExtension> extension class.  
  
 Object element syntax is possible, but it is not shown because it has no realistic application. `TemplateBinding` is used to fill values within setters, using evaluated expressions, and using object element syntax for `TemplateBinding` to fill `<Setter.Property>` property element syntax is unnecessarily verbose.  
  
 `TemplateBinding` can also be used in a verbose attribute usage that specifies the <xref:System.Windows.TemplateBindingExtension.Property%2A> property as a property=value pair:  
  
```xml  
<object property="{TemplateBinding Property=sourceProperty}" .../>  
```  
  
 The verbose usage is often useful for extensions that have more than one settable property, or if some properties are optional. Because `TemplateBinding` has only one settable property, which is required, this verbose usage is not typical.  
  
 In the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] XAML processor implementation, the handling for this markup extension is defined by the <xref:System.Windows.TemplateBindingExtension> class.  
  
 `TemplateBinding` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in XAML use the `{` and `}` characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
## See Also  
 <xref:System.Windows.Style>  
 <xref:System.Windows.Controls.ControlTemplate>  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [RelativeSource MarkupExtension](../../../../docs/framework/wpf/advanced/relativesource-markupextension.md)  
 [Binding Markup Extension](../../../../docs/framework/wpf/advanced/binding-markup-extension.md)
