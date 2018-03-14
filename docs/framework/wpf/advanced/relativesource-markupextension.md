---
title: "RelativeSource MarkupExtension"
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
  - "RelativeSource"
helpviewer_keywords: 
  - "RelativeSource markup extensions [WPF]"
  - "XAML [WPF], RelativeSource markup extension"
ms.assetid: 26be4721-49b5-4717-a92e-7d54ad0d3a81
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# RelativeSource MarkupExtension
Specifies properties of a <xref:System.Windows.Data.RelativeSource> binding source, to be used within a [Binding Markup Extension](../../../../docs/framework/wpf/advanced/binding-markup-extension.md), or when setting the <xref:System.Windows.Data.Binding.RelativeSource%2A> property of a <xref:System.Windows.Data.Binding> element established in XAML.  
  
## XAML Attribute Usage  
  
```xml  
<Binding RelativeSource="{RelativeSource modeEnumValue}" .../>  
```  
  
## XAML Attribute Usage (nested within Binding extension)  
  
```xml  
<object property="{Binding RelativeSource={RelativeSource modeEnumValue} ...}" .../>  
```  
  
## XAML Object Element Usage  
  
```xml  
<Binding>  
  <Binding.RelativeSource>  
    <RelativeSource Mode="modeEnumValue"/>  
  </Binding.RelativeSource>  
</Binding>  
- or   
<Binding>  
  <Binding.RelativeSource>  
    <RelativeSource  
      Mode="FindAncestor"  
      AncestorType="{x:Type typeName}"  
      AncestorLevel="intLevel"  
    />  
  </Binding.RelativeSource>  
</Binding>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`modeEnumValue`|One of the following:<br /><br /> -   The string token `Self`; corresponds to a <xref:System.Windows.Data.RelativeSource> as created with its <xref:System.Windows.Data.RelativeSource.Mode%2A> property set to <xref:System.Windows.Data.RelativeSourceMode.Self>.<br />-   The string token `TemplatedParent`; corresponds to a <xref:System.Windows.Data.RelativeSource> as created with its <xref:System.Windows.Data.RelativeSource.Mode%2A> property set to <xref:System.Windows.Data.RelativeSourceMode.TemplatedParent>.<br />-   The string token `PreviousData`; corresponds to a <xref:System.Windows.Data.RelativeSource> as created with its <xref:System.Windows.Data.RelativeSource.Mode%2A> property set to <xref:System.Windows.Data.RelativeSourceMode.PreviousData>.<br />-   See below for information on `FindAncestor` mode.|  
|`FindAncestor`|The string token `FindAncestor`. Using this token enters a mode whereby a `RelativeSource` specifies an ancestor type and optionally an ancestor level. This corresponds to a <xref:System.Windows.Data.RelativeSource> as created with its <xref:System.Windows.Data.RelativeSource.Mode%2A> property set to <xref:System.Windows.Data.RelativeSourceMode.FindAncestor>.|  
|`typeName`|Required for `FindAncestor` mode. The name of a type, which fills the <xref:System.Windows.Data.RelativeSource.AncestorType%2A> property.|  
|`intLevel`|Optional for `FindAncestor` mode. An ancestor level (evaluated towards the parent direction in the logical tree).|  
  
## Remarks  
 `{RelativeSource TemplatedParent}` binding usages are a key technique that addresses a larger concept of the separation of a control's UI and a control's logic. This enables binding from within the template definition to the templated parent (the run time object instance where the template is applied). For this case, the [TemplateBinding Markup Extension](../../../../docs/framework/wpf/advanced/templatebinding-markup-extension.md) is in fact a shorthand for the following binding expression: `{Binding RelativeSource={RelativeSource TemplatedParent}}`. `TemplateBinding` or `{RelativeSource TemplatedParent}` usages are both only relevant within the XAML that defines a template. For more information, see [TemplateBinding Markup Extension](../../../../docs/framework/wpf/advanced/templatebinding-markup-extension.md)  
  
 `{RelativeSource FindAncestor}` is mainly used in control templates or predictable self-contained UI compositions, for cases where a control is always expected to be in a visual tree of a certain ancestor type. For example, items of an items control might use `FindAncestor` usages to bind to properties of their items control parent ancestor. Or, elements that are part of control composition in a template can use `FindAncestor` bindings to the parent elements in that same composition structure.  
  
 In the object element syntax for `FindAncestor` mode shown in the XAML Syntax sections, the second object element syntax is used specifically for `FindAncestor` mode. `FindAncestor` mode requires an <xref:System.Windows.Data.RelativeSource.AncestorType%2A> value. You must set <xref:System.Windows.Data.RelativeSource.AncestorType%2A> as an attribute using an [x:Type Markup Extension](../../../../docs/framework/xaml-services/x-type-markup-extension.md) reference to the type of ancestor to look for. The <xref:System.Windows.Data.RelativeSource.AncestorType%2A> value is used when the binding request is processed at run-time.  
  
 For `FindAncestor` mode, the optional property <xref:System.Windows.Data.RelativeSource.AncestorLevel%2A> can help disambiguate the ancestor lookup in cases where there is possibly more than one ancestor of that type existing in the element tree.  
  
 For more information on how to use the `FindAncestor` mode, see <xref:System.Windows.Data.RelativeSource>.  
  
 `{RelativeSource Self}` is useful for scenarios where one property of an instance should depend on the value of another property of the same instance, and no general dependency property relationship (such as coercion) already exists between those two properties. Although it is rare that two properties exist on an object such that the values are literally identical (and are identically typed), you can also apply a `Converter` parameter to a binding that has `{RelativeSource Self}`, and use the converter to convert between source and target types. Another scenario for `{RelativeSource Self}` is as part of a <xref:System.Windows.MultiDataTrigger>.  
  
 For example, the following XAML defines a <xref:System.Windows.Shapes.Rectangle> element such that no matter what value is entered for <xref:System.Windows.FrameworkElement.Width%2A>, the <xref:System.Windows.Shapes.Rectangle> is always a square: `<Rectangle Width="200" Height="{Binding RelativeSource={RelativeSource Self}, Path=Width}" .../>`  
  
 `{RelativeSource PreviousData}` is useful either in data templates, or in cases where bindings are using a collection as the data source. You can use `{RelativeSource PreviousData}` to highlight relationships between adjacent data items in the collection. A related technique is to establish a <xref:System.Windows.Data.MultiBinding> between the current and previous items in the data source, and use a converter on that binding to determine the difference between the two items and their properties.  
  
 In the following example, the first <xref:System.Windows.Controls.TextBlock> in the items template displays the current number. The second <xref:System.Windows.Controls.TextBlock> binding is a <xref:System.Windows.Data.MultiBinding> that nominally has two <xref:System.Windows.Data.Binding> consistuents: the current record, and a binding that deliberately uses the previous data record by using `{RelativeSource PreviousData}`. Then, a converter on the <xref:System.Windows.Data.MultiBinding> calculates the difference and returns it to the binding.  
  
```xml  
<ListBox Name="fibolist">  
    <ListBox.ItemTemplate>  
        <DataTemplate>  
            <StackPanel Orientation="Horizontal">  
            <TextBlock Text="{Binding}"/>  
            <TextBlock>, difference = </TextBlock>  
                <TextBlock>  
                    <TextBlock.Text>  
                        <MultiBinding Converter="{StaticResource DiffConverter}">  
                            <Binding/>  
                            <Binding RelativeSource="{RelativeSource PreviousData}"/>  
                        </MultiBinding>  
                    </TextBlock.Text>  
                </TextBlock>  
            </StackPanel>  
        </DataTemplate>  
    </ListBox.ItemTemplate>  
```  
  
 Describing data binding as a concept is not covered here, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
 In the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] XAML processor implementation, the handling for this markup extension is defined by the <xref:System.Windows.Data.RelativeSource> class.  
  
 `RelativeSource` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in XAML use the `{` and `}` characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
## See Also  
 <xref:System.Windows.Data.Binding>  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Binding Declarations Overview](../../../../docs/framework/wpf/data/binding-declarations-overview.md)  
 [x:Type Markup Extension](../../../../docs/framework/xaml-services/x-type-markup-extension.md)
