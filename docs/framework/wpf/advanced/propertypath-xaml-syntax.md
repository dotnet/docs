---
title: "PropertyPath XAML Syntax"
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
  - "PropertyPath object [WPF]"
  - "XAML [WPF], PropertyPath object"
ms.assetid: 0e3cdf07-abe6-460a-a9af-3764b4fd707f
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# PropertyPath XAML Syntax
The <xref:System.Windows.PropertyPath> object supports a complex inline [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] syntax for setting various properties that take the <xref:System.Windows.PropertyPath> type as their value. This topic documents the <xref:System.Windows.PropertyPath> syntax as applied to binding and animation syntaxes.  
    
  
<a name="where"></a>   
## Where PropertyPath Is Used  
 <xref:System.Windows.PropertyPath> is a common object that is used in several [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] features. Despite using the common <xref:System.Windows.PropertyPath> to convey property path information, the usages for each feature area where <xref:System.Windows.PropertyPath> is used as a type vary. Therefore, it is more practical to document the syntaxes on a per-feature basis.  
  
 Primarily, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses <xref:System.Windows.PropertyPath> to describe object-model paths for traversing the properties of an object data source, and to describe the target path for targeted animations.  
  
 Some style and template properties such as <xref:System.Windows.Setter.Property%2A?displayProperty=nameWithType> take a qualified property name that superficially resembles a <xref:System.Windows.PropertyPath>. But this is not a true <xref:System.Windows.PropertyPath>; instead it is a qualified *owner.property* string format usage that is enabled by the WPF [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor in combination with the type converter for <xref:System.Windows.DependencyProperty>.  
  
<a name="databinding_s"></a>   
## PropertyPath for Objects in Data Binding  
 Data binding is a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] feature whereby you can bind to the target value of any dependency property. However, the source of such a data binding need not be a dependency property; it can be any property type that is recognized by the applicable data provider. Property paths are particularly used for the <xref:System.Windows.Data.ObjectDataProvider>, which is used for obtaining binding sources from [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] objects and their properties.  
  
 Note that data binding to [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] does not use <xref:System.Windows.PropertyPath>, because it does not use <xref:System.Windows.Data.Binding.Path%2A> in the <xref:System.Windows.Data.Binding>. Instead, you use <xref:System.Windows.Data.Binding.XPath%2A> and specify valid XPath syntax into the [!INCLUDE[TLA#tla_xmldom](../../../../includes/tlasharptla-xmldom-md.md)] of the data. <xref:System.Windows.Data.Binding.XPath%2A> is also specified as a string, but is not documented here; see [Bind to XML Data Using an XMLDataProvider and XPath Queries](../../../../docs/framework/wpf/data/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md).  
  
 A key to understanding property paths in data binding is that you can target the binding to an individual property value, or you can instead bind to target properties that take lists or collections. If you are binding collections, for instance binding a <xref:System.Windows.Controls.ListBox> that will expand depending on how many data items are in the collection, then your property path should reference the collection object, not individual collection items. The data binding engine will match the collection used as the data source to the type of the binding target automatically, resulting in behavior such as populating a <xref:System.Windows.Controls.ListBox> with an items array.  
  
<a name="singlecurrent"></a>   
### Single Property on the Immediate Object as Data Context  
  
```xml  
<Binding Path="propertyName" .../>  
```  
  
 *propertyName* must resolve to be the name of a property that is in the current <xref:System.Windows.FrameworkElement.DataContext%2A> for a <xref:System.Windows.Data.Binding.Path%2A> usage. If your binding updates the source, that property must be read/write and the source object must be mutable.  
  
<a name="singleindex"></a>   
### Single Indexer on the Immediate Object as Data Context  
  
```xml  
<Binding Path="[key]" .../>  
```  
  
 `key` must be either the typed index to a dictionary or hash table, or the integer index of an array. Also, the value of the key must be a type that is directly bindable to the property where it is applied. For instance, a hash table that contains string keys and string values can be used this way to bind to Text for a <xref:System.Windows.Controls.TextBox>. Or, if the key points to a collection or subindex, you could use this syntax to bind to a target collection property. Otherwise, you need to reference a specific property, through a syntax such as `<Binding Path="[``key``].``propertyName``" .../>`.  
  
 You can specify the type of the index if necessary. For details on this aspect of an indexed property path, see <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType>.  
  
<a name="multipleindirect"></a>   
### Multiple Property (Indirect Property Targeting)  
  
```xml  
<Binding Path="propertyName.propertyName2" .../>  
```  
  
 `propertyName` must resolve to be the name of a property that is the current <xref:System.Windows.FrameworkElement.DataContext%2A>. The path properties `propertyName` and `propertyName2` can be any properties that exist in a relationship, where `propertyName2` is a property that exists on the type that is the value of `propertyName`.  
  
<a name="singleattached"></a>   
### Single Property, Attached or Otherwise Type-Qualified  
  
```xml  
<object property="(ownerType.propertyName)" .../>  
```  
  
 The parentheses indicate that this property in a <xref:System.Windows.PropertyPath> should be constructed using a partial qualification. It can use an XML namespace to find the type with an appropriate mapping. The `ownerType` searches types that a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor has access to, through the <xref:System.Windows.Markup.XmlnsDefinitionAttribute> declarations in each assembly. Most applications have the default XML namespace mapped to the [!INCLUDE[TLA#tla_wpfxmlnsv1](../../../../includes/tlasharptla-wpfxmlnsv1-md.md)] namespace, so a prefix is usually only necessary for custom types or types otherwise outside that namespace.  `propertyName` must resolve to be the name of a property existing on the `ownerType`. This syntax is generally used for one of the following cases:  
  
-   The path is specified in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] that is in a style or template that does not have a specified Target Type. A qualified usage is generally not valid for cases other than this, because in non-style, non-template cases, the property exists on an instance, not a type.  
  
-   The property is an attached property.  
  
-   You are binding to a static property.  
  
 For use as storyboard target, the property specified as `propertyName` must be a <xref:System.Windows.DependencyProperty>.  
  
<a name="sourcetraversal"></a>   
### Source Traversal (Binding to Hierarchies of Collections)  
  
```xml  
<object Path="propertyName/propertyNameX" .../>  
```  
  
 The / in this syntax is used to navigate within a hierarchical data source object, and multiple steps into the hierarchy with successive / characters are supported. The source traversal accounts for the current record pointer position, which is determined by synchronizing the data with the UI of its view. For details on binding with hierarchical data source objects, and the concept of current record pointer in data binding, see [Use the Master-Detail Pattern with Hierarchical Data](../../../../docs/framework/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data.md) or [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
> [!NOTE]
>  Superficially, this syntax resembles [!INCLUDE[TLA2#tla_xpath](../../../../includes/tla2sharptla-xpath-md.md)]. A true [!INCLUDE[TLA2#tla_xpath](../../../../includes/tla2sharptla-xpath-md.md)] expression for binding to an [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data source is not used as a <xref:System.Windows.Data.Binding.Path%2A> value and should instead be used for the mutually exclusive <xref:System.Windows.Data.Binding.XPath%2A> property.  
  
### Collection Views  
 To reference a named collection view, prefix the collection view name with the hash character (`#`).  
  
### Current Record Pointer  
 To reference the current record pointer for a collection view or master detail data binding scenario, start the path string with a forward slash (`/`). Any path past the forward slash is traversed starting from the current record pointer.  
  
### Multiple Indexers  
  
```  
<object Path="[index1,index2...]" .../>  
or  
<object Path="propertyName[index,index2...]" .../>  
```  
  
 If a given object supports multiple indexers, those indexers can be specified in order, similar to an array referencing syntax. The object in question can be either the current context or the value of a property that contains a multiple index object.  
  
 By default, the indexer values are typed by using the characteristics of the underlying object. You can specify the type of the index if necessary. For details on typing the indexers, see <xref:System.Windows.Data.Binding.Path%2A?displayProperty=nameWithType>.  
  
<a name="mixing"></a>   
### Mixing Syntaxes  
 Each of the syntaxes shown above can be interspersed. For instance, the following is an example that creates a property path to the color at a particular x,y of a `ColorGrid` property that contains a pixel grid array of <xref:System.Windows.Media.SolidColorBrush> objects:  
  
```xml  
<Rectangle Fill="{Binding ColorGrid[20,30].SolidColorBrushResult}" .../>  
```  
  
### Escapes for Property Path Strings  
 For certain business objects, you might encounter a case where the property path string requires an escape sequence in order to parse correctly. The need to escape should be rare, because many of these characters have similar naming-interaction issues in languages that would typically be used to define the business object.  
  
-   Inside indexers ([ ]), the caret character (^) escapes the next character.  
  
-   You must escape (using XML entities) certain characters that are special to the XML language definition. Use `&` to escape the character "&". Use `>` to escape the end tag ">".  
  
-   You must escape (using backslash `\`) characters that are special to the WPF XAML parser behavior for processing a markup extension.  
  
    -   Backslash (`\`) is the escape character itself.  
  
    -   The equal sign (`=`) separates property name from property value.  
  
    -   Comma (`,`) separates properties.  
  
    -   The right curly brace (`}`) is the end of a markup extension.  
  
> [!NOTE]
>  Technically, these escapes work for a storyboard property path also, but you are usually traversing object models for existing WPF objects, and escaping should be unnecessary.  
  
<a name="databinding_sa"></a>   
## PropertyPath for Animation Targets  
 The target property of an animation must be a dependency property that takes either a <xref:System.Windows.Freezable> or a primitive type. However, the targeted property on a type and the eventual animated property can exist on different objects. For animations, a property path is used to define the connection between the named animation target object's property and the intended target animation property, by traversing object-property relationships in the property values.  
  
<a name="general"></a>   
### General Object-Property Considerations for Animations  
 For more information on animation concepts in general, see [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md) and [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 The value type or the property being animated must be either a <xref:System.Windows.Freezable> type or a primitive. The property that starts the path must resolve to be the name of a dependency property that exists on the specified <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> type.  
  
 In order to support cloning for animating a <xref:System.Windows.Freezable> that is already frozen, the object specified by <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> must be a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> derived class.  
  
<a name="singlestepanim"></a>   
### Single Property on the Target Object  
  
```xml  
<animation Storyboard.TargetProperty="propertyName" .../>  
```  
  
 `propertyName` must resolve to be the name of a dependency property that exists on the specified <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> type.  
  
<a name="indirectanim"></a>   
### Indirect Property Targeting  
  
```xml  
<animation Storyboard.TargetProperty="propertyName.propertyName2" .../>  
```  
  
 `propertyName` must be a property that is either a <xref:System.Windows.Freezable> value type or a primitive, which exists on the specified <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> type.  
  
 `propertyName2` must be the name of a dependency property that exists on the object that is the value of `propertyName`. In other words, `propertyName2` must exist as a dependency property on the type that is the `propertyName` <xref:System.Windows.DependencyProperty.PropertyType%2A>.  
  
 Indirect targeting of animations is necessary because of applied styles and templates. In order to target an animation, you need a <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> on a target object, and that name is established by [x:Name](../../../../docs/framework/xaml-services/x-name-directive.md) or <xref:System.Windows.FrameworkElement.Name%2A>. Although template and style elements also can have names, those names are only valid within the namescope of the style and template. (If templates and styles did share namescopes with application markup, names couldn't be unique. The styles and templates are literally shared between instances and would perpetuate duplicate names.) Thus, if the individual properties of an element that you might wish to animate came from a style or template, you need to start with a named element instance that is not from a style template, and then target into the style or template visual tree to arrive at the property you wish to animate.  
  
 For instance, the <xref:System.Windows.Controls.Panel.Background%2A> property of a <xref:System.Windows.Controls.Panel> is a complete <xref:System.Windows.Media.Brush> (actually a <xref:System.Windows.Media.SolidColorBrush>) that came from a theme template. To animate a <xref:System.Windows.Media.Brush> completely, there would need to be a BrushAnimation (probably one for every <xref:System.Windows.Media.Brush> type) and there is no such type. To animate a Brush, you instead animate properties of a particular <xref:System.Windows.Media.Brush> type. You need to get from <xref:System.Windows.Media.SolidColorBrush> to its <xref:System.Windows.Media.SolidColorBrush.Color%2A> to apply a <xref:System.Windows.Media.Animation.ColorAnimation> there. The property path for this example would be `Background.Color`.  
  
<a name="attachedanim"></a>   
### Attached Properties  
  
```xml  
<animation Storyboard.TargetProperty="(ownerType.propertyName)" .../>  
```  
  
 The parentheses indicate that this property in a <xref:System.Windows.PropertyPath> should be constructed using a partial qualification. It can use an XML namespace to find the type. The `ownerType` searches types that a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor has access to, through the <xref:System.Windows.Markup.XmlnsDefinitionAttribute> declarations in each assembly. Most applications have the default XML namespace mapped to the [!INCLUDE[TLA#tla_wpfxmlnsv1](../../../../includes/tlasharptla-wpfxmlnsv1-md.md)] namespace, so a prefix is usually only necessary for custom types or types otherwise outside that namespace. `propertyName` must resolve to be the name of a property existing on the `ownerType`. The property specified as `propertyName` must be a <xref:System.Windows.DependencyProperty>. (All [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] attached properties are implemented as dependency properties, so this issue is only of concern for custom attached properties.)  
  
<a name="indexanim"></a>   
### Indexers  
  
```xml  
<animation Storyboard.TargetProperty="propertyName.propertyName2[index].propertyName3" .../>  
```  
  
 Most dependency properties or <xref:System.Windows.Freezable> types do not support an indexer. Therefore, the only usage for an indexer in an animation path is at an intermediate position between the property that starts the chain on the named target and the eventual animated property. In the provided syntax, that is `propertyName2`. For instance, an indexer usage might be necessary if the intermediate property is a collection such as <xref:System.Windows.Media.TransformGroup>, in a property path such as `RenderTransform.Children[1].Angle`.  
  
<a name="ppincode"></a>   
## PropertyPath in Code  
 Code usage for <xref:System.Windows.PropertyPath>, including how to construct a <xref:System.Windows.PropertyPath>, is documented in the reference topic for <xref:System.Windows.PropertyPath>.  
  
 In general, <xref:System.Windows.PropertyPath> is designed to use two different constructors, one for the binding usages and simplest animation usages, and one for the complex animation usages. Use the <xref:System.Windows.PropertyPath.%23ctor%28System.Object%29> signature for binding usages, where the object is a string. Use the <xref:System.Windows.PropertyPath.%23ctor%28System.Object%29> signature for one-step animation paths, where the object is a <xref:System.Windows.DependencyProperty>. Use the <xref:System.Windows.PropertyPath.%23ctor%28System.String%2CSystem.Object%5B%5D%29> signature for complex animations. This latter constructor uses a token string for the first parameter and an array of objects that fill positions in the token string to define a property path relationship.  
  
## See Also  
 <xref:System.Windows.PropertyPath>  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md)
