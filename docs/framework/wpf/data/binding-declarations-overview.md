---
title: "Binding Declarations Overview"
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
  - "markup extensions [WPF]"
  - "data binding [WPF], declarations"
  - "object element syntax [WPF]"
  - "binding data [WPF], declarations"
  - "syntax [WPF], object elements"
  - "binding declarations [WPF]"
ms.assetid: b97fd626-4c0d-4761-872a-2bca5820da2c
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Binding Declarations Overview
This topic discusses the different ways you can declare a binding.  
  
 
  
<a name="Prereq"></a>   
## Prerequisites  
 Before reading this topic, it is important that you are familiar with the concept and usage of markup extensions. For more information about markup extensions, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
 This topic does not cover data binding concepts. For a discussion of data binding concepts, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
<a name="BindinginXAML"></a>   
## Declaring a Binding in XAML  
 This section discusses how to declare a binding in XAML.  
  
<a name="MarkupExtensionSyntax"></a>   
### Markup Extension Usage  
 <xref:System.Windows.Data.Binding> is a markup extension. When you use the binding extension to declare a binding, the declaration consists of a series of clauses following the `Binding` keyword and separated by commas (,). The clauses in the binding declaration can be in any order and there are many possible combinations. The clauses are *Name*=*Value* pairs where *Name* is the name of the <xref:System.Windows.Data.Binding> property and *Value* is the value you are setting for the property.  
  
 When creating binding declaration strings in markup, they must be attached to the specific dependency property of a target object. The following example shows how to bind the <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> property using the binding extension, specifying the <xref:System.Windows.Data.Binding.Source%2A> and <xref:System.Windows.Data.Binding.Path%2A> properties.  
  
 [!code-xaml[SimpleBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SimpleBinding/CSharp/Page1.xaml#L37-L37)]  
  
 You can specify most of the properties of the <xref:System.Windows.Data.Binding> class this way. For more information about the binding extension as well as for a list of <xref:System.Windows.Data.Binding> properties that cannot be set using the binding extension, see the [Binding Markup Extension](../../../../docs/framework/wpf/advanced/binding-markup-extension.md) overview.  
  
<a name="ObjectElementSyntax"></a>   
### Object Element Syntax  
 Object element syntax is an alternative to creating the binding declaration. In most cases, there is no particular advantage to using either the markup extension or the object element syntax. However, in cases which the markup extension does not support your scenario, such as when your property value is of a non-string type for which no type conversion exists, you need to use the object element syntax.  
  
 The following is an example of both the object element syntax and the markup extension usage:  
  
 [!code-xaml[BindConversionMarkup#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindConversionMarkup/CSharp/Page1.xaml#1)]  
  
 The example binds the <xref:System.Windows.Controls.TextBlock.Foreground%2A> property by declaring a binding using the extension syntax. The binding declaration for the <xref:System.Windows.Controls.TextBlock.Text%2A> property uses the object element syntax.  
  
 For more information about the different terms, see [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
<a name="MBandPB"></a>   
### MultiBinding and PriorityBinding  
 <xref:System.Windows.Data.MultiBinding> and <xref:System.Windows.Data.PriorityBinding> do not support the XAML extension syntax. Therefore, you must use the object element syntax if you are declaring a <xref:System.Windows.Data.MultiBinding> or a <xref:System.Windows.Data.PriorityBinding> in XAML.  
  
<a name="BindinginCode"></a>   
## Creating a Binding in Code  
 Another way to specify a binding is to set properties directly on a <xref:System.Windows.Data.Binding> object in code. The following example shows how to create a <xref:System.Windows.Data.Binding> object and specify the properties in code.  In this example, `TheConverter` is an object that implements the <xref:System.Windows.Data.IValueConverter> interface.  
  
 [!code-csharp[BindConversion#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindConversion/CSharp/Window1.xaml.cs#1)]
 [!code-vb[BindConversion#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/BindConversion/visualbasic/window1.xaml.vb#1)]  
  
 If the object you are binding is a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.FrameworkContentElement> you can call the `SetBinding` method on your object directly instead of using <xref:System.Windows.Data.BindingOperations.SetBinding%2A?displayProperty=nameWithType>. For an example, see [Create a Binding in Code](../../../../docs/framework/wpf/data/how-to-create-a-binding-in-code.md).  
  
<a name="Path_Syntax"></a>   
## Binding Path Syntax  
 Use the <xref:System.Windows.Data.Binding.Path%2A> property to specify the source value you want to bind to:  
  
-   In the simplest case, the <xref:System.Windows.Data.Binding.Path%2A> property value is the name of the property of the source object to use for the binding, such as `Path=PropertyName`.  
  
-   Subproperties of a property can be specified by a similar syntax as in [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)]. For instance, the clause `Path=ShoppingCart.Order` sets the binding to the subproperty `Order` of the object or property `ShoppingCart`.  
  
-   To bind to an attached property, place parentheses around the attached property. For example, to bind to the attached property <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>, the syntax is `Path=(DockPanel.Dock)`.  
  
-   Indexers of a property can be specified within square brackets following the property name where the indexer is applied. For instance, the clause `Path=ShoppingCart[0]` sets the binding to the index that corresponds to how your property's internal indexing handles the literal string "0". Nested indexers are also supported.  
  
-   Indexers and subproperties can be mixed in a `Path` clause; for example, `Path=ShoppingCart.ShippingInfo[MailingAddress,Street].`  
  
-   Inside indexers you can have multiple indexer parameters separated by commas (,). The type of each parameter can be specified with parentheses. For example, you can have `Path="[(sys:Int32)42,(sys:Int32)24]"`, where `sys` is mapped to the `System` namespace.  
  
-   When the source is a collection view, the current item can be specified with a slash (/). For example, the clause `Path=/` sets the binding to the current item in the view. When the source is a collection, this syntax specifies the current item of the default collection view.  
  
-   Property names and slashes can be combined to traverse properties that are collections. For example, `Path=/Offices/ManagerName` specifies the current item of the source collection, which contains an `Offices` property that is also a collection. Its current item is an object that contains a `ManagerName` property.  
  
-   Optionally, a period (.) path can be used to bind to the current source. For example, `Text="{Binding}"` is equivalent to `Text="{Binding Path=.}"`.  
  
### Escaping Mechanism  
  
-   Inside indexers ([ ]), the caret character (^) escapes the next character.  
  
-   If you set <xref:System.Windows.Data.Binding.Path%2A> in XAML, you also need to escape (using XML entities) certain characters that are special to the XML language definition:  
  
    -   Use `&` to escape the character "&".  
  
    -   Use `>` to escape the end tag ">".  
  
-   Additionally, if you describe the entire binding in an attribute using the markup extension syntax, you need to escape (using backslash \\) characters that are special to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] markup extension parser:  
  
    -   Backslash (\\) is the escape character itself.  
  
    -   The equal sign (=) separates property name from property value.  
  
    -   Comma (,) separates properties.  
  
    -   The right curly brace (}) is the end of a markup extension.  
  
<a name="Default"></a>   
## Default Behaviors  
 The default behavior is as follows if not specified in the declaration.  
  
-   A default converter is created that tries to do a type conversion between the binding source value and the binding target value. If a conversion cannot be made, the default converter returns `null`.  
  
-   If you do not set <xref:System.Windows.Data.Binding.ConverterCulture%2A>, the binding engine uses the `Language` property of the binding target object. In XAML, this defaults to "en-US" or inherits the value from the root element (or any element) of the page, if one has been explicitly set.  
  
-   As long as the binding already has a data context (for instance, the inherited data context coming from a parent element), and whatever item or collection being returned by that context is appropriate for binding without requiring further path modification, a binding declaration can have no clauses at all: `{Binding}` This is often the way a binding is specified for data styling, where the binding acts upon a collection. For more information, see the "Entire Objects Used as a Binding Source" section in the [Binding Sources Overview](../../../../docs/framework/wpf/data/binding-sources-overview.md).  
  
-   The default <xref:System.Windows.Data.Binding.Mode%2A> varies between one-way and two-way depending on the dependency property that is being bound. You can always declare the binding mode explicitly to ensure that your binding has the desired behavior. In general, user-editable control properties, such as <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> and <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A?displayProperty=nameWithType>, default to two-way bindings, whereas most other properties default to one-way bindings.  
  
-   The default <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> value varies between <xref:System.Windows.Data.UpdateSourceTrigger.PropertyChanged> and <xref:System.Windows.Data.UpdateSourceTrigger.LostFocus> depending on the bound dependency property as well. The default value for most dependency properties is <xref:System.Windows.Data.UpdateSourceTrigger.PropertyChanged>, while the <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> property has a default value of <xref:System.Windows.Data.UpdateSourceTrigger.LostFocus>.  
  
## See Also  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [PropertyPath XAML Syntax](../../../../docs/framework/wpf/advanced/propertypath-xaml-syntax.md)
