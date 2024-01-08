---
title: System.Collections.ObjectModel.ObservableCollection\<T> class
description: Learn about the System.Collections.ObjectModel.ObservableCollection\<T> class through these additional API remarks.
ms.date: 01/02/2024
---
# System.Collections.ObjectModel.ObservableCollection\<T> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Collections.ObjectModel.ObservableCollection%601> class represents a dynamic data collection that provides notifications when items get added or removed, or when the whole list is refreshed.

In many cases, the data that you work with is a collection of objects. For example, a common scenario in data binding is to use an <xref:System.Windows.Controls.ItemsControl> such as a <xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.ListView>, or <xref:System.Windows.Controls.TreeView> to display a collection of records.

You can enumerate over any collection that implements the <xref:System.Collections.IEnumerable> interface. However, to set up dynamic bindings so that insertions or deletions in the collection update the UI automatically, the collection must implement the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface. This interface exposes the <xref:System.Collections.Specialized.INotifyCollectionChanged.CollectionChanged> event, an event that should be raised whenever the underlying collection changes.

The <xref:System.Collections.ObjectModel.ObservableCollection%601> class is a data collection type that implements the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface.

Before implementing your own collection, consider using <xref:System.Collections.ObjectModel.ObservableCollection%601> or one of the existing collection classes, such as <xref:System.Collections.Generic.List%601>, <xref:System.Collections.ObjectModel.Collection%601>, and <xref:System.ComponentModel.BindingList%601>, among many others. If you have an advanced scenario and want to implement your own collection, consider using <xref:System.Collections.IList>, which provides a non-generic collection of objects that can be individually accessed by index. Implementing <xref:System.Collections.IList> provides the best performance with the data binding engine.

> [!NOTE]
> To fully support transferring data values from binding source objects to binding targets, each object in your collection that supports bindable properties must implement an appropriate property changed notification mechanism such as the <xref:System.ComponentModel.INotifyPropertyChanged> interface.

For more information, see "Binding to Collections" in [Data Binding Overview](/dotnet/framework/wpf/data/data-binding-overview).

## Notes on XAML usage

<xref:System.Collections.ObjectModel.ObservableCollection%601> can be used as a XAML object element in Windows Presentation Foundation (WPF), in versions 3.0 and 3.5. However, the usage has substantial limitations.

- <xref:System.Collections.ObjectModel.ObservableCollection%601> must be the root element, because the `x:TypeArguments` attribute that must be used to specify the constrained type of the generic <xref:System.Collections.ObjectModel.ObservableCollection%601> is only supported on the object element for the root element.

- You must declare an `x:Class` attribute (which entails that the build action for this XAML file must be `Page` or some other build action that compiles the XAML).

- <xref:System.Collections.ObjectModel.ObservableCollection%601> is in a namespace and assembly that are not initially mapped to the default XML namespace. You must map a prefix for the namespace and assembly, and then use that prefix on the object element tag for <xref:System.Collections.ObjectModel.ObservableCollection%601>.

A more straightforward way to use <xref:System.Collections.ObjectModel.ObservableCollection%601> capabilities from XAML in an application is to declare your own non-generic custom collection class that derives from <xref:System.Collections.ObjectModel.ObservableCollection%601>, and constrains it to a specific type. Then map the assembly that contains this class, and reference it as an object element in your XAML.
