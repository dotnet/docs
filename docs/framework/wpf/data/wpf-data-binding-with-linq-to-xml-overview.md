---
title: WPF data binding with LINQ to XML
ms.date: 10/22/2019
ms.topic: conceptual
---
# Overview of WPF data binding with LINQ to XML

This article introduces the dynamic data binding features in the <xref:System.Xml.Linq> namespace. These features can be used as a data source for user interface (UI) elements in Windows Presentation Foundation (WPF) apps. This scenario relies upon special *dynamic properties* of <xref:System.Xml.Linq.XAttribute?displayProperty=fullName> and <xref:System.Xml.Linq.XElement?displayProperty=fullName>.

## XAML and LINQ to XML

The Extensible Application Markup Language (XAML) is an XML dialect created by Microsoft to support .NET technologies. It is used in WPF to represent user interface elements and related features, such as events and data binding. In Windows Workflow Foundation, XAML is used to represent program structure, such as program control (*workflows*). XAML enables the declarative aspects of a technology to be separated from the related procedural code that defines the more individualized behavior of a program.

There are two broad ways that XAML and LINQ to XML can interact:

- Because XAML files are well-formed XML, they can be queried and manipulated through XML technologies such as LINQ to XML.

- Because LINQ to XML queries represent a source of data, these queries can be used as a data source for data binding for WPF UI elements.

This documentation describes the second scenario.

## Data binding in the Windows Presentation Foundation

WPF data binding enables a UI element to associate one of its properties with a data source. A simple example of this is a <xref:System.Windows.Controls.Label> whose text presents the value of a public property in a user-defined object. WPF data binding relies on the following components:

|Component|Description|
|---------------|-----------------|
|Binding target|The UI element to be associated with the data source. Visual elements in WPF are derived from the <xref:System.Windows.UIElement> class.|
|Target property|The *dependency property* of the binding target that reflects the value of the data-binding source. Dependency properties are directly supported by the <xref:System.Windows.DependencyObject> class, which <xref:System.Windows.UIElement> derives from.|
|Binding source|The source object for one or more values that are supplied to the UI element for presentation. WPF automatically supports the following types as binding sources: CLR objects, ADO.NET data objects, XML data (from XPath or LINQ to XML queries), or another <xref:System.Windows.DependencyObject>.|
|Source path|The property of the binding source that resolves to the value or set of values that is to be bound.|

A dependency property is a concept specific to WPF that represent a dynamically computed property of a UI element. For example, dependency properties often have default values or values that are provided by a parent element. These special properties are backed by instances of the <xref:System.Windows.DependencyProperty> class (and not fields as with standard properties). For more information, see [Dependency Properties Overview](/dotnet/framework/wpf/advanced/dependency-properties-overview).

### Dynamic data binding in WPF

By default, data binding occurs only when the target UI element is initialized. This is called *one-time* binding. For most purposes, this is insufficient; typically, a data-binding solution requires that the changes be dynamically propagated at run time using one of the following:

- *One-way* binding causes the changes to one side to be propagated automatically. Most commonly, changes to the source are reflected in the target, but the reverse can sometimes be useful.

- In *two-way* binding, changes to the source are automatically propagated to the target, and changes to the target are automatically propagated to the source.

For one-way or two-way binding to occur, the source must implement a change notification mechanism, for example by implementing the <xref:System.ComponentModel.INotifyPropertyChanged> interface or by using a *PropertyNameChanged* pattern for each property supported.

For more information about data binding in WPF, see [Data Binding (WPF)](/dotnet/framework/wpf/data/data-binding-wpf).

## Dynamic properties in LINQ to XML classes

Most LINQ to XML classes do not qualify as proper WPF dynamic data sources. Some of the most useful information is available only through methods, not properties, and properties in these classes do not implement change notifications. To support WPF data binding, LINQ to XML exposes a set of *dynamic properties*.

These dynamic properties are special run-time properties that duplicate the functionality of existing methods and properties in the <xref:System.Xml.Linq.XAttribute> and <xref:System.Xml.Linq.XElement> classes. They were added to these classes solely to enable them to act as dynamic data sources for WPF. To meet this need, all these dynamic properties implement change notifications. A detailed reference for these dynamic properties is provided in the next section, [LINQ to XML Dynamic Properties](linq-to-xml-dynamic-properties.md).

> [!NOTE]
> Many of the standard public properties, found in the various classes in the <xref:System.Xml.Linq> namespace, can be used for one-time data binding. However, remember that neither the source nor the target will be dynamically updated under this scheme.

### Access dynamic properties

The dynamic properties in the <xref:System.Xml.Linq.XAttribute> and <xref:System.Xml.Linq.XElement> classes cannot be accessed like standard properties. For example, in CLR-compliant languages such as C#, they cannot be:

- Accessed directly at compile time. Dynamic properties are invisible to the compiler and to Visual Studio IntelliSense.

- Discovered or accessed at run time using .NET reflection. Even at run time, they are not properties in the basic CLR sense.

In C#, dynamic properties can only be accessed at run time through facilities provided by the <xref:System.ComponentModel> namespace.

In contrast, however, in an XML source dynamic properties can be accessed through a straightforward notation in the following form:

```xml
<object>.<dynamic-property>
```

The dynamic properties for these two classes either resolve to a value that can be used directly, or to an indexer that must be supplied with an index to obtain the resulting value or collection of values. The latter syntax takes the form:

```xml
<object>.<dynamic-property>[<index-value>]
```

For more information, see [LINQ to XML Dynamic Properties](linq-to-xml-dynamic-properties.md).

To implement WPF dynamic binding, dynamic properties will be used with facilities provided by the <xref:System.Windows.Data> namespace, most notably the <xref:System.Windows.Data.Binding> class.

## See also

- [WPF Data Binding with LINQ to XML](wpf-data-binding-with-linq-to-xml-overview.md)
- [LINQ to XML Dynamic Properties](linq-to-xml-dynamic-properties.md)
- [XAML in WPF](/dotnet/framework/wpf/advanced/xaml-in-wpf)
- [Data Binding (WPF)](/dotnet/framework/wpf/data/data-binding-wpf)
- [Using Workflow Markup](http://go.microsoft.com/fwlink/?LinkId=98685)
