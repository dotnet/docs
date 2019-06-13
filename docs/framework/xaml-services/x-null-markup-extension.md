---
title: "x:Null Markup Extension"
ms.date: "03/30/2017"
f1_keywords: 
  - "NullExtension"
  - "x:NullExtension"
  - "x:Null"
  - "Null"
  - "xNull"
helpviewer_keywords: 
  - "Null markup extension in XAML [XAML Services]"
  - "x:Null markup extension [XAML Services]"
  - "XAML [XAML Services], x:Null markup extension"
ms.assetid: 2e3ccc21-4996-481d-91b5-3910d8b3bfa3
---
# x:Null Markup Extension
Specifies `null` as a value for a XAML member.  
  
## XAML Attribute Usage  
  
```xaml  
<object property="{x:Null}" .../>  
```  
  
## Remarks  
 The keyword for a null reference in C# and [!INCLUDE[TLA#tla_cpp](../../../includes/tlasharptla-cpp-md.md)] is null. The Microsoft Visual Basic keyword for a null reference is `Nothing`, but you always use `{x:Null}` as the XAML usage regardless which code-behind language you associate with the XAML.  
  
 The `x:Null` markup extension has no settable properties.  
  
 A null usage is often associated with the XAML member exposure of a CLR <xref:System.Nullable%601> value.  
  
 The `x:Null` markup extension, like all XAML markup extensions, uses the braces (`{,}`) for escaping the handling of attribute values to be other than literals or event-handler references. Attribute syntax is the syntax most frequently used with this markup extension. An object element syntax `<x:Null />` is technically possible, but is rarely used because the `x:Null` markup extension has no positional parameters or construction arguments.  
  
 For information about markup extensions, see [Markup Extensions and WPF XAML](../wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
 In .NET Framework XAML Services, the handling for this markup extension is defined by the <xref:System.Windows.Markup.NullExtension> class.  
  
## WPF Usage Notes  
 Note that `null` is not necessarily the initial unset value for a reference-type dependency property. The initial default value can vary for each dependency property and can be based on property-specific metadata. Many dependency properties do not accept `null` as a value, either through markup or code because of their validation callback implementations. For more information about dependency properties, see [Dependency Properties Overview](../wpf/advanced/dependency-properties-overview.md).  
  
## See also

- <xref:System.Windows.DependencyProperty.UnsetValue>
- [XAML Overview (WPF)](../wpf/advanced/xaml-overview-wpf.md)
- [Markup Extensions and WPF XAML](../wpf/advanced/markup-extensions-and-wpf-xaml.md)
