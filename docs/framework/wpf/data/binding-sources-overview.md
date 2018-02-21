---
title: "Binding Sources Overview"
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
  - "binding data [WPF], binding sources"
  - "data binding [WPF], binding source"
  - "binding sources [WPF]"
ms.assetid: 2df2cd11-6aac-4bdf-ab7b-ea5f464cd5ca
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Binding Sources Overview
In data binding, the binding source object refers to the object you obtain data from. This topic discusses the types of objects you can use as the binding source.  
  
  
  
<a name="binding_sources"></a>   
## Binding Source Types  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] data binding supports the following binding source types:  
  
|Binding Source|Description|  
|--------------------|-----------------|  
|[!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] objects|You can bind to public properties, sub-properties, as well as indexers, of any [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] object. The binding engine uses [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] reflection to get the values of the properties. Alternatively, objects that implement <xref:System.ComponentModel.ICustomTypeDescriptor> or have a registered <xref:System.ComponentModel.TypeDescriptionProvider> also work with the binding engine.<br /><br /> For more information about how to implement a class that can serve as a binding source, see [Implementing a Class for the Binding Source](#classes) later in this topic.|  
|dynamic objects|You can bind to available properties and indexers of an object that implements the <xref:System.Dynamic.IDynamicMetaObjectProvider> interface. If you can access the member in code, you can bind to it. For example, if a dynamic object enables you to access a member in code via `someObjet.AProperty`, you can bind to it by setting the binding path to `AProperty`.|  
|[!INCLUDE[TLA#tla_adonet](../../../../includes/tlasharptla-adonet-md.md)] objects|You can bind to [!INCLUDE[TLA2#tla_adonet](../../../../includes/tla2sharptla-adonet-md.md)] objects, such as <xref:System.Data.DataTable>. The [!INCLUDE[TLA2#tla_adonet](../../../../includes/tla2sharptla-adonet-md.md)] <xref:System.Data.DataView> implements the <xref:System.ComponentModel.IBindingList> interface, which provides change notifications that the binding engine listens for.|  
|[!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] objects|You can bind to and run `XPath` queries on an <xref:System.Xml.XmlNode>, <xref:System.Xml.XmlDocument>, or <xref:System.Xml.XmlElement>. A convenient way to access [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data that is the binding source in markup is to use an <xref:System.Windows.Data.XmlDataProvider> object. For more information, see [Bind to XML Data Using an XMLDataProvider and XPath Queries](../../../../docs/framework/wpf/data/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md).<br /><br /> You can also bind to an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument>, or bind to the results of queries run on objects of these types by using LINQ to XML. A convenient way to use LINQ to XML to access XML data that is the binding source in markup is to use an <xref:System.Windows.Data.ObjectDataProvider> object. For more information, see [Bind to XDocument, XElement, or LINQ for XML Query Results](../../../../docs/framework/wpf/data/how-to-bind-to-xdocument-xelement-or-linq-for-xml-query-results.md).|  
|<xref:System.Windows.DependencyObject> objects|You can bind to dependency properties of any <xref:System.Windows.DependencyObject>. For an example, see [Bind the Properties of Two Controls](../../../../docs/framework/wpf/data/how-to-bind-the-properties-of-two-controls.md).|  
  
<a name="classes"></a>   
## Implementing a Class for the Binding Source  
 You can create your own binding sources. This section discusses the things you need to know if you are implementing a class to serve as a binding source.  
  
### Providing Change Notifications  
 If you are using either <xref:System.Windows.Data.BindingMode.OneWay> or <xref:System.Windows.Data.BindingMode.TwoWay> binding (because you want your [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] to update when the binding source properties change dynamically), you must implement a suitable property changed notification mechanism. The recommended mechanism is for the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] or dynamic class to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. For more information, see [Implement Property Change Notification](../../../../docs/framework/wpf/data/how-to-implement-property-change-notification.md).  
  
 If you create a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] object that does not implement <xref:System.ComponentModel.INotifyPropertyChanged>, then you must arrange for your own notification system to make sure that the data used in a binding stays current. You can provide change notifications by supporting the `PropertyChanged` pattern for each property that you want change notifications for. To support this pattern, you define a *PropertyName*Changed event for each property, where *PropertyName* is the name of the property. You raise the event every time the property changes.  
  
 If your binding source implements one of these notification mechanisms, target updates happen automatically. If for any reason your binding source does not provide the proper property changed notifications, you have the option to use the <xref:System.Windows.Data.BindingExpression.UpdateTarget%2A> method to update the target property explicitly.  
  
### Other Characteristics  
 The following list provides other important points to note:  
  
-   If you want to create the object in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], the class must have a default constructor. In some [!INCLUDE[TLA2#tla_net](../../../../includes/tla2sharptla-net-md.md)] languages, such as [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)], the default constructor might be created for you.  
  
-   The properties you use as binding source properties for a binding must be public properties of your class. Explicitly defined interface properties cannot be accessed for binding purposes, nor can protected, private, internal, or virtual properties that have no base implementation.  
  
-   You cannot bind to public fields.  
  
-   The type of the property declared in your class is the type that is passed to the binding. However, the type ultimately used by the binding depends on the type of the binding target property, not of the binding source property. If there is a difference in type, you might want to write a converter to handle how your custom property is initially passed to the binding. For more information, see <xref:System.Windows.Data.IValueConverter>.  
  
<a name="objects"></a>   
## Using Entire Objects as a Binding Source  
 You can use an entire object as a binding source. You can specify a binding source by using the <xref:System.Windows.Data.Binding.Source%2A> or the <xref:System.Windows.FrameworkElement.DataContext%2A> property, and then provide a blank binding declaration: `{Binding}`. Scenarios in which this is useful include binding to objects that are of type string, binding to objects with multiple properties you are interested in, or binding to collection objects. For an example of binding to an entire collection object, see [Use the Master-Detail Pattern with Hierarchical Data](../../../../docs/framework/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data.md).  
  
 Note that you may need to apply custom logic so that the data is meaningful to your bound target property. The custom logic may be in the form of a custom converter (if default type conversion does not exist) or a <xref:System.Windows.DataTemplate>. For more information about converters, see the Data Conversion section of [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md). For more information about data templates, see [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md).  
  
<a name="collections"></a>   
## Using Collection Objects as a Binding Source  
 Often, the object you want to use as the binding source is a collection of custom objects. Each object serves as the source for one instance of a repeated binding. For example, you might have a `CustomerOrders` collection that consists of `CustomerOrder` objects, where your application iterates over the collection to determine how many orders exist and the data contained in each.  
  
 You can enumerate over any collection that implements the <xref:System.Collections.IEnumerable> interface. However, to set up dynamic bindings so that insertions or deletions in the collection update the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] automatically, the collection must implement the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface. This interface exposes an event that must be raised whenever the underlying collection changes.  
  
 The <xref:System.Collections.ObjectModel.ObservableCollection%601> class is a built-in implementation of a data collection that exposes the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface. The individual data objects within the collection must satisfy the requirements described in the preceding sections. For an example, see [Create and Bind to an ObservableCollection](../../../../docs/framework/wpf/data/how-to-create-and-bind-to-an-observablecollection.md). Before implementing your own collection, consider using <xref:System.Collections.ObjectModel.ObservableCollection%601> or one of the existing collection classes, such as <xref:System.Collections.Generic.List%601>, <xref:System.Collections.ObjectModel.Collection%601>, and <xref:System.ComponentModel.BindingList%601>, among many others.  
  
 WPF never binds directly to a collection. If you specify a collection as a binding source, WPF actually binds to the collection's default view. For information about default views, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
 If you have an advanced scenario and you want to implement your own collection, consider using the <xref:System.Collections.IList> interface. <xref:System.Collections.IList> provides a non-generic collection of objects that can be individually accessed by index, which can improve performance.  
  
<a name="permissions"></a>   
## Permission Requirements in Data Binding  
 When data binding, you must consider the trust level of the application. The following table summarizes what property types can be bound to in an application that is executing in either full trust or partial trust:  
  
|Property type<br /><br /> (all access modifiers)|Dynamic object property|Dynamic object property|CLR property|CLR property|Dependency property|Dependency property|  
|------------------------------------------------|-----------------------------|-----------------------------|------------------|------------------|-------------------------|-------------------------|  
|**Trust level**|**Full trust**|**Partial trust**|**Full trust**|**Partial trust**|**Full trust**|**Partial trust**|  
|Public class|Yes|Yes|Yes|Yes|Yes|Yes|  
|Non-public class|Yes|No|Yes|No|Yes|Yes|  
  
 This table describes the following important points about permission requirements in data binding:  
  
-   For [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] properties, data binding works as long as the binding engine is able to access the binding source property using reflection. Otherwise, the binding engine issues a warning that the property cannot be found and uses the fallback value or the default value, if it is available.  
  
-   You can bind to properties on dynamic objects that are defined at compile time or run time.  
  
-   You can always bind to dependency properties.  
  
 The permission requirement for [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] binding is similar. In a partial-trust sandbox, <xref:System.Windows.Data.XmlDataProvider> fails when it does not have permissions to access the specified data.  
  
 Objects with an anonymous type are internal. You can bind to properties of anonymous types only when running in full trust. For more information about anonymous types, see [Anonymous Types (C# Programming Guide)](~/docs/csharp/programming-guide/classes-and-structs/anonymous-types.md) or [Anonymous Types (Visual Basic)](~/docs/visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md) (Visual Basic).  
  
 For more information about partial-trust security, see [WPF Partial Trust Security](../../../../docs/framework/wpf/wpf-partial-trust-security.md).  
  
## See Also  
 <xref:System.Windows.Data.ObjectDataProvider>  
 <xref:System.Windows.Data.XmlDataProvider>  
 [Specify the Binding Source](../../../../docs/framework/wpf/data/how-to-specify-the-binding-source.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)  
 [WPF Data Binding with LINQ to XML Overview](/visualstudio/designers/wpf-data-binding-with-linq-to-xml-overview)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)
