---
title: "x:Key Directive"
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
  - "xKey"
  - "Key"
  - "x:Key"
helpviewer_keywords: 
  - "x:Key attribute [XAML Services]"
  - "Key attribute in XAML [XAML Services]"
  - "XAML [XAML Services], x:Key attribute"
ms.assetid: 1985cd45-f197-42d5-b75e-886add64b248
caps.latest.revision: 25
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Key Directive
Uniquely identifies elements that are created and referenced in a XAML-defined dictionary. Adding an `x:Key` value to a XAML object element is the most common way to identify a resource in a resource dictionary, for example in a WPF <xref:System.Windows.ResourceDictionary>.  
  
## XAML Attribute Usage  
  
```  
<object x:Key="stringKeyValue".../>  
-or-  
<object x:Key="{markupExtensionUsage}".../>  
```  
  
## XAML Attribute Usage (WPF-specific)  
  
```  
<object.Resources>  
  <object x:Key="stringKeyValue".../>  
</object.Resources>  
-or-  
<object.Resources>  
  <object x:Key="{markupExtensionUsage}".../>  
</object.Resources>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`stringKeyValue`|A text string to use as a key. The text string must conform to the [XamlName Grammar](../../../docs/framework/xaml-services/xamlname-grammar.md).|  
|`markupExtensionUsage`|Within the markup extension delimiters {}, a markup extension usage that provides an object to use as a key. See Remarks.|  
  
## Remarks  
 `x:Key` supports the XAML resource dictionary concept. XAML as a language doesn't define a resource dictionary implementation, that is left to specific UI frameworks. To learn more about how XAML resource dictionaries are implemented in WPF, see [XAML Resources](../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
 In XAML 2006 and WPF, `x:Key` must be provided as an attribute. You can still use nonstring keys, but this requires a markup extension usage in order to provide the nonstring value in attribute form. If you are using XAML 2009, `x:Key` can be specified as an element, to explicitly support dictionaries keyed by object types other than strings without requiring a markup extension intermediate. See the "XAML 2009" section in this topic. The remainder of the Remarks section applies specifically to the XAML 2006 implementation.  
  
 The attribute value of `x:Key` can be any string defined in the [XamlName Grammar](../../../docs/framework/xaml-services/xamlname-grammar.md) or can be an object evaluated through a markup extension. See "WPF Usage Notes" for an example from WPF.  
  
 Child elements of a parent element that is an <xref:System.Collections.IDictionary> implementation must typically include an `x:Key` attribute that specifies a unique key value within that dictionary. Frameworks might implement aliased key properties to substitute for `x:Key` on particular types; types that define such properties should be attributed with <xref:System.Windows.Markup.DictionaryKeyPropertyAttribute>.  
  
 The code equivalent of specifying `x:Key` is the key that is used for the underlying <xref:System.Collections.IDictionary>. For example, an `x:Key` that is applied in markup for a resource in WPF is equivalent to the value of the `key` parameter of <xref:System.Windows.ResourceDictionary.Add%2A?displayProperty=nameWithType> when you add the resource to a WPF <xref:System.Windows.ResourceDictionary> in code.  
  
## WPF Usage Notes  
 Child objects of a parent object that is an <xref:System.Collections.IDictionary> implementation, such as the WPF <xref:System.Windows.ResourceDictionary>, must typically include an `x:Key` attribute, and the key value must be unique within that dictionary. There are two notable exceptions:  
  
-   Some WPF types declare an implicit key for dictionary usage. For example, a <xref:System.Windows.Style> with a <xref:System.Windows.Style.TargetType%2A>, or a <xref:System.Windows.DataTemplate> with a <xref:System.Windows.DataTemplate.DataType%2A>, can be  in a <xref:System.Windows.ResourceDictionary> and use the implicit key.  
  
-   WPF supports a merged resource dictionary concept. Keys can be shared between the merged dictionaries, and the shared key behavior can be accessed using <xref:System.Windows.FrameworkContentElement.FindResource%2A>. For more information, see [Merged Resource Dictionaries](../../../docs/framework/wpf/advanced/merged-resource-dictionaries.md).  
  
 In the overall WPF XAML implementation and application model, key uniqueness is not checked by the XAML markup compiler. Instead, missing or nonunique `x:Key` values cause load-time XAML parser errors. However, [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] handling of dictionaries for WPF can often note such errors in the design phase.  
  
 Note that in the syntax shown, the <xref:System.Windows.ResourceDictionary> object is implicit in how the WPF XAML processor produces a collection to populate a <xref:System.Windows.FrameworkElement.Resources%2A> collection. A <xref:System.Windows.ResourceDictionary> is not typically provided explicitly as an element in markup, although it can be in some cases if wanted for clarity (it would be a collection object element between the <xref:System.Windows.FrameworkElement.Resources%2A> property element and the items within that populate the dictionary). For information about why a collection object is almost always an implicit element in markup, see [XAML Syntax In Detail](../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
 In the WPF XAML implementation, the handling for resource dictionary keys is defined by the <xref:System.Windows.ResourceKey> abstract class. However the WPF XAML processor produces different underlying extension types for keys based on their usages. For example, the key for a <xref:System.Windows.DataTemplate> or any derived class is handled separately, and produces a distinct <xref:System.Windows.DataTemplateKey> object.  
  
 Keys and names use different directives and language elements (`x:Key` versus `x:Name`) in the basic XAML definition. Keys and names are also used in different situations by the WPF definition and application of these concepts. For details, see [WPF XAML Namescopes](../../../docs/framework/wpf/advanced/wpf-xaml-namescopes.md).  
  
 As stated previously, the value of a key can be supplied through a markup extension and can be other than a string value. An example WPF scenario is that the value of `x:Key` may be a[ComponentResourceKey](../../../docs/framework/wpf/advanced/componentresourcekey-markup-extension.md). Certain controls expose a style key of that type for a custom style resource that influences part of the appearance and behavior of that control without totally replacing the style. An example of such a key is <xref:System.Windows.Controls.ToolBar.ButtonStyleKey%2A>.  
  
 The WPF merged dictionary feature introduces additional considerations for key uniqueness and key lookup behavior. For more information, see [Merged Resource Dictionaries](../../../docs/framework/wpf/advanced/merged-resource-dictionaries.md).  
  
## XAML 2009  
 XAML 2009 relaxes the restriction that `x:Key` always be provided in attribute form.  
  
 In WPF, you can use XAML 2009 features, but only for XAML that is not markup-compiled. Markup-compiled XAML for WPF and the BAML form of XAML do not currently support the XAML 2009 keywords and features.  
  
 Under XAML 2009, you can specify `x:Key` elements through the following usage:  
  
### XAML Element Usage (XAML 2009 only)  
  
```  
<object>  
  <x:Key>  
keyObject  
  </x:Key>  
...  
</object>  
```  
  
### XAML Values  
  
|||  
|-|-|  
|`keyObject`|Object element for the object that is used as the key for a given `object` in a specialized dictionary.|  
  
-   The container/parent for this kind of use is not shown here. `object` is expected to be a child of an object element that represents a specialized dictionary implementation. `keyObject` is expected to be an object instance (or a value of a value type) that is appropriate as the key for that particular specialized dictionary implementation.  
  
-   WPF does not implement dictionaries that require this usage. Object keys is more a general feature of the XAML language, possibly useful for certain custom dictionary scenarios where creating the dictionary in XAML is desirable. For WPF features such as implicit styles that use non-string keys for resources, other techniques for establishing or specifying the keys exist, so using an object key is not necessary.  
  
-   *keyObject* could also be a markup extension usage in object element form, rather than a direct object instance.  
  
## Silverlight Usage Notes  
 `x:Key` for Silverlight is documented separately. For more information, see [XAML Namespace (x:) Language Features (Silverlight)](http://go.microsoft.com/fwlink/?LinkId=199081).  
  
## See Also  
 [XAML Resources](../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Resources and Code](../../../docs/framework/wpf/advanced/resources-and-code.md)  
 [StaticResource Markup Extension](../../../docs/framework/wpf/advanced/staticresource-markup-extension.md)
