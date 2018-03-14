---
title: "x:Name Directive"
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
  - "x:Name"
  - "xName"
  - "Name"
helpviewer_keywords: 
  - "x:Name attribute [XAML Services]"
  - "XAML [XAML Services], x:Name attribute"
  - "Name attribute in XAML [XAML Services]"
ms.assetid: b7e61222-e8cf-48d2-acd0-6df3b7685d48
caps.latest.revision: 27
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Name Directive
Uniquely identifies XAML-defined elements in a XAML namescope. XAML namescopes and their uniqueness models can be applied to the instantiated objects, when frameworks provide APIs or implement behaviors that access the XAML-created object graph at run time.  
  
## XAML Attribute Usage  
  
```xaml  
<object x:Name="XAMLNameValue".../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`XAMLNameValue`|A string that conforms to the restrictions of the [XamlName Grammar](../../../docs/framework/xaml-services/xamlname-grammar.md).|  
  
## Remarks  
 After `x:Name` is applied to a framework's backing programming model, the name is equivalent to the variable that holds an object reference or an instance as returned by a constructor.  
  
 The value of an `x:Name` directive usage must be unique within a XAML namescope. By default when used by .NET Framework XAML Services API, the primary XAML namescope is defined at the XAML root element of a single XAML production, and encompasses the elements that are contained in that XAML production. Additional discrete XAML namescopes that might occur within a single XAML production can be defined by frameworks to address specific scenarios. For example, in WPF, new XAML namescopes are defined and created by any template that is also defined on that XAML production. For more information about XAML namescopes (written for WPF but relevant for many XAML namescope concepts), see [WPF XAML Namescopes](../../../docs/framework/wpf/advanced/wpf-xaml-namescopes.md).  
  
 In general, `x:Name` should not be applied in situations that also use `x:Key`. XAML implementations by specific existing frameworks have introduced substitution concepts between `x:Key` and `x:Name`, but that is not a recommended practice. .NET Framework XAML Services does not support such substitution concepts when handling name/key information such as <xref:System.Windows.Markup.INameScope> or <xref:System.Windows.Markup.DictionaryKeyPropertyAttribute>.  
  
 Rules for permittance of `x:Name` as well as the name uniqueness enforcement are potentially defined by specific implementing frameworks. However, to be usable with .NET Framework XAML Services, the framework definitions of XAML namescope uniqueness should be consistent with the definition of <xref:System.Windows.Markup.INameScope> information in this documentation, and should use the same rules regarding where the information is applied. For example, the [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] implementation divides various markup elements into separate <xref:System.Windows.NameScope> ranges, such as resource dictionaries, the logical tree created by the page-level XAML, templates, and other deferred content, and then enforces XAML name uniqueness within each of those XAML namescopes.  
  
 For custom types that use .NET Framework XAML Services XAML object writers, a property that maps to `x:Name` on a type can be established or changed. You define this behavior by referencing the name of the property to map with the <xref:System.Windows.Markup.RuntimeNamePropertyAttribute> in the type definition code.  <xref:System.Windows.Markup.RuntimeNamePropertyAttribute> is a type-level attribute.  
  
 Using.NET Framework XAML Services, the backing logic for XAML namescope support can be defined in a framework-neutral way by implementing the <xref:System.Windows.Markup.INameScope> interface.  
  
## WPF Usage Notes  
 Under the standard build configuration for a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] application that uses XAML, partial classes, and code-behind, the specified `x:Name` becomes the name of a field that is created in the underlying code when [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] is processed by a markup compilation build task, and that field holds a reference to the object. By default, the created field is internal. You can change field access by specifying the [x:FieldModifier attribute](../../../docs/framework/xaml-services/x-fieldmodifier-directive.md). In WPF and Silverlight, the sequence is that the markup compile defines and names the field in a partial class, but the value is initially empty. Then, a generated method named `InitializeComponent` is called from within the class constructor. `InitializeComponent` consists of `FindName` calls using each of the `x:Name` values that exist in the XAML-defined part of the partial class as input strings. The return values are then assigned to the like-named field reference to fill the field values with objects that were created from XAML parsing. The execution of `InitializeComponent` make it possible to reference the run time object graph using the `x:Name` / field name directly, rather than having to call `FindName` explicitly any time you need a reference to a XAML-defined object.  
  
 For a WPF application that uses the [!INCLUDE[TLA#tla_visualb](../../../includes/tlasharptla-visualb-md.md)] targets and includes XAML files with `Page` build action, a separate reference property is created during compilation that adds the `WithEvents` keyword to all elements that have an `x:Name`, to support `Handles` syntax for event handler delegates. This property is always public. For more information, see [Visual Basic and WPF Event Handling](../../../docs/framework/wpf/advanced/visual-basic-and-wpf-event-handling.md).  
  
 `x:Name` is used by the WPF XAML processor to register a name into a XAML namescope at load time, even for cases where the page is not markup-compiled by build actions (for example, loose XAML of a resource dictionary). One reason for this behavior is because the `x:Name` is potentially needed for <xref:System.Windows.Data.Binding.ElementName%2A> binding. For details, see [Data Binding Overview](../../../docs/framework/wpf/data/data-binding-overview.md).  
  
 As mentioned previously, `x:Name` (or `Name`) should not be applied in situations that also use `x:Key`. The [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.ResourceDictionary> has a special behavior of defining itself as a XAML namescope but returning Not Implemented or null values for <xref:System.Windows.Markup.INameScope> APIs as a way to enforce this behavior. If the WPF XAML parser encounters `Name` or `x:Name` in a XAML-defined <xref:System.Windows.ResourceDictionary>, the name is not added to any XAML namescope. Attempting to find that name from any XAML namescope and the `FindName` methods will not return valid results.  
  
### x:Name and Name  
 Many WPF application scenarios can avoid any use of the `x:Name` attribute, because the `Name` dependency property as specified in the default XAML namespace for several of the important base classes such as <xref:System.Windows.FrameworkElement> and <xref:System.Windows.FrameworkContentElement> satisfies this same purpose. There are still some common XAML and WPF scenarios where code access to an element with no `Name` property at the framework level is important. For example, certain animation and storyboard support classes do not support a `Name` property, but they often need to be referenced in code in order to control the animation. You should specify `x:Name` as an attribute on timelines and transforms that are created in XAML, if you intend to reference them from code later.  
  
 If <xref:System.Windows.FrameworkElement.Name%2A> is available as a property on the class, <xref:System.Windows.FrameworkElement.Name%2A> and `x:Name` can be used interchangeably as attributes, but a parse exception will result if both are specified on the same element. If the XAML is markup compiled, the exception will occur on the markup compile, otherwise it occurs on load.  
  
 <xref:System.Windows.FrameworkElement.Name%2A> can be set using XAML attribute syntax, and in code using <xref:System.Windows.DependencyObject.SetValue%2A>; note however that setting the <xref:System.Windows.FrameworkElement.Name%2A> property in code does not create the representative field reference within the XAML namescope in most circumstances where the XAML is already loaded. Instead of attempting to set <xref:System.Windows.FrameworkElement.Name%2A> in code, use <xref:System.Windows.NameScope> methods from code, against the appropriate namescope.  
  
 <xref:System.Windows.FrameworkElement.Name%2A> can also be set using property element syntax with inner text, but that is uncommon. In contrast, `x:Name` cannot be set in XAML property element syntax, or in code using <xref:System.Windows.DependencyObject.SetValue%2A>; it can only be set using attribute syntax on objects because it is a directive.  
  
## Silverlight Usage Notes  
 `x:Name` for Silverlight is documented separately. For more information, see [XAML Namespace (x:) Language Features (Silverlight)](http://go.microsoft.com/fwlink/?LinkId=199081).  
  
## See Also  
 <xref:System.Windows.FrameworkElement.Name%2A?displayProperty=nameWithType>  
 <xref:System.Windows.FrameworkContentElement.Name%2A?displayProperty=nameWithType>  
 [Trees in WPF](../../../docs/framework/wpf/advanced/trees-in-wpf.md)
