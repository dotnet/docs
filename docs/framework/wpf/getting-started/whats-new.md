---
title: "What&#39;s New in WPF Version 4.5"
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
  - "Windows Presentation Foundation [WPF], what's new"
  - "WPF [WPF], what's new"
ms.assetid: db086ae4-70bb-4862-95db-2eaca5216bc3
caps.latest.revision: 55
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# What&#39;s New in WPF Version 4.5
<a name="introduction"></a> This topic contains information about new and enhanced features in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] version 4.5.  
  
 This topic contains the following sections:  
  
-   [Ribbon control](#ribbon_control)  
  
-   [Improved performance when displaying large sets of grouped data](#grouped_virtualization)  
  
-   [New features for the VirtualizingPanel](#VirtualizingPanel)  
  
-   [Binding to static properties](#static_properties)  
  
-   [Accessing collections on non-UI Threads](#xthread_access)  
  
-   [Synchronously and Asynchronously validating data](#INotifyDataErrorInfo)  
  
-   [Automatically updating the source of a data binding](#delay)  
  
-   [Binding to types that Implement ICustomTypeProvider](#ICustomTypeProvider)  
  
-   [Retrieving data binding information from a binding expression](#binding_state)  
  
-   [Checking for a valid DataContext object](#DisconnectedSource)  
  
-   [Repositioning data as the data's values change (Live shaping)](#live_shaping)  
  
-   [Improved Support for Establishing a Weak Reference to an Event](#weak_event_pattern)  
  
-   [New methods for the Dispatcher class](#async)  
  
-   [Markup Extensions for Events](#events_markup_extenions)  
  
<a name="ribbon_control"></a>   
## Ribbon control  
 WPF 4.5 ships with a <xref:System.Windows.Controls.Ribbon.Ribbon> control that hosts a Quick Access Toolbar, Application Menu, and tabs.  For more information, see the [Ribbon Overview](/visualstudio/vsto/ribbon-overview).  
  
<a name="grouped_virtualization"></a>   
## Improved performance when displaying large sets of grouped data  
 UI virtualization occurs when  a subset of user interface (UI) elements are generated from a larger number of data items based on which items are visible on the screen. The <xref:System.Windows.Controls.VirtualizingPanel> defines the <xref:System.Windows.Controls.VirtualizingPanel.IsVirtualizingWhenGrouping%2A> attached property that enables UI Virtualization for grouped data.  For more information about grouping data, see How to: Sort and Group Data Using a View in XAML.  For more information about virtualizing grouped data, see the <xref:System.Windows.Controls.VirtualizingPanel.IsVirtualizingWhenGrouping%2A> attached property.  
  
<a name="VirtualizingPanel"></a>   
## New features for the VirtualizingPanel  
  
1.  You can specify whether a <xref:System.Windows.Controls.VirtualizingPanel>, such as the <xref:System.Windows.Controls.VirtualizingStackPanel>, displays partial items by using the <xref:System.Windows.Controls.VirtualizingPanel.ScrollUnit%2A> attached property. If <xref:System.Windows.Controls.VirtualizingPanel.ScrollUnit%2A> is set to <xref:System.Windows.Controls.ScrollUnit.Item>, the <xref:System.Windows.Controls.VirtualizingPanel> will only display items that are completely visible. If <xref:System.Windows.Controls.VirtualizingPanel.ScrollUnit%2A> is set to <xref:System.Windows.Controls.ScrollUnit.Pixel>, the <xref:System.Windows.Controls.VirtualizingPanel> can display partially visible items.  
  
2.  You can specify the  size of the cache before and after the viewport when the <xref:System.Windows.Controls.VirtualizingPanel> is virtualizing by using the <xref:System.Windows.Controls.VirtualizingPanel.CacheLength%2A> attached property.  The cache is the amount of space above or below the viewport in which items are not virtualized.  Using a cache to avoid generating UI elements as they’re scrolled into view can improve performance. The cache is populated at a lower priority so that the application does not become unresponsive during the operation. The <xref:System.Windows.Controls.VirtualizingPanel.CacheLengthUnit%2A?displayProperty=nameWithType> property determines the unit of measurement that is used by <xref:System.Windows.Controls.VirtualizingPanel.CacheLength%2A?displayProperty=nameWithType>.  
  
<a name="static_properties"></a>   
## Binding to static properties  
 You can use static properties as the source of a data binding. The data binding engine recognizes when the property's value changes if a static event is raised.  For example, if the class `SomeClass` defines a static property called `MyProperty`, `SomeClass` can define a static event that is raised when the value of `MyProperty` changes.  The static event can use either of the following signatures.  
  
-   `public static event EventHandler MyPropertyChanged;`  
  
-   `public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;`  
  
 Note that in the first case, the class exposes a static event named *PropertyName*`Changed` that passes <xref:System.EventArgs> to the event handler.  In the second case, the class exposes a static event named `StaticPropertyChanged` that passes <xref:System.ComponentModel.PropertyChangedEventArgs> to the event handler. A class that implements the static property can choose to raise property-change notifications using either method.  
  
<a name="xthread_access"></a>   
## Accessing collections on non-UI Threads  
 WPF enables you to access and modify data collections on threads other than the one that created the collection.  This enables you to use a background thread to receive data from an external source, such as a database, and display the data on the UI thread.  By using another thread to modify the collection, your user interface remains responsive to user interaction.  
  
<a name="INotifyDataErrorInfo"></a>   
## Synchronously and Asynchronously validating data  
 The <xref:System.ComponentModel.INotifyDataErrorInfo> interface enables data entity classes to implement custom validation rules and expose validation results asynchronously. This interface also supports custom error objects, multiple errors per property, cross-property errors, and entity-level errors.  For more information, see <xref:System.ComponentModel.INotifyDataErrorInfo>.  
  
<a name="delay"></a>   
## Automatically updating the source of a data binding  
 If you use a data binding to update a data source, you can use the <xref:System.Windows.Data.BindingBase.Delay%2A> property to specify an amount of time to pass after the property changes on the target before the source updates.  For example, suppose that you have a <xref:System.Windows.Controls.Slider> that has its <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> property data two-way bound to a property of a data object and the <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> property is set to <xref:System.Windows.Data.UpdateSourceTrigger.PropertyChanged>.  In this example, when the user moves the <xref:System.Windows.Controls.Slider>, the source updates for each pixel that the <xref:System.Windows.Controls.Slider> moves.  The source object typically needs the value of the slider only when the slider's <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> stops changing.  To prevent updating the source too often, use <xref:System.Windows.Data.BindingBase.Delay%2A> to specify that the source should not be updated until a certain amount of time elapses after the thumb stops moving.  
  
<a name="ICustomTypeProvider"></a>   
## Binding to types that Implement ICustomTypeProvider  
 WPF supports data binding to objects that implement <xref:System.Reflection.ICustomTypeProvider>, also known as custom types.  You can use custom types in the following cases.  
  
1.  As a <xref:System.Windows.PropertyPath> in a data binding. For example, the <xref:System.Windows.Data.Binding.Path%2A> property of a <xref:System.Windows.Data.Binding> can reference a property of a custom type.  
  
2.  As the value of the <xref:System.Windows.DataTemplate.DataType%2A> property.  
  
3.  As a type that determines the automatically generated columns in a <xref:System.Windows.Controls.DataGrid>.  
  
<a name="binding_state"></a>   
## Retrieving data binding information from a binding expression  
 In certain cases, you might get the <xref:System.Windows.Data.BindingExpression> of a <xref:System.Windows.Data.Binding> and need information about the source and target objects of the binding.  New APIs have been added to enable you to get the source or target object or the associated property.  When you have a <xref:System.Windows.Data.BindingExpression>, use the following APIs to get information about the target and source.  
  
|To find this value of the binding|Use this API|  
|---------------------------------------|------------------|  
|The target object|<xref:System.Windows.Data.BindingExpressionBase.Target%2A?displayProperty=nameWithType>|  
|The target property|<xref:System.Windows.Data.BindingExpressionBase.TargetProperty%2A?displayProperty=nameWithType>|  
|The source object|<xref:System.Windows.Data.BindingExpression.ResolvedSource%2A?displayProperty=nameWithType>|  
|The source property|<xref:System.Windows.Data.BindingExpression.ResolvedSourcePropertyName%2A?displayProperty=nameWithType>|  
|Whether the <xref:System.Windows.Data.BindingExpression> belongs to a <xref:System.Windows.Data.BindingGroup>|<xref:System.Windows.Data.BindingExpressionBase.BindingGroup%2A?displayProperty=nameWithType>|  
|The owner of a <xref:System.Windows.Data.BindingGroup>|<xref:System.Windows.Data.BindingGroup.Owner%2A>|  
  
<a name="DisconnectedSource"></a>   
## Checking for a valid DataContext object  
 There are cases where the <xref:System.Windows.FrameworkElement.DataContext%2A> of an item container in an <xref:System.Windows.Controls.ItemsControl> becomes disconnected.  An item container is the UI element that displays an item in an <xref:System.Windows.Controls.ItemsControl>.  When an <xref:System.Windows.Controls.ItemsControl> is data bound to a collection, an item container is generated for each item. In some cases, item containers are removed from the visual tree. Two typical cases where an item container is removed are when an item is removed from the underlying collection and when virtualization is enabled on the <xref:System.Windows.Controls.ItemsControl>. In these cases, the <xref:System.Windows.FrameworkElement.DataContext%2A> property of the item container will be set to the sentinel object that is returned by the <xref:System.Windows.Data.BindingOperations.DisconnectedSource%2A?displayProperty=nameWithType> static property.  You should check whether the <xref:System.Windows.FrameworkElement.DataContext%2A> is equal to the <xref:System.Windows.Data.BindingOperations.DisconnectedSource%2A> object before accessing the <xref:System.Windows.FrameworkElement.DataContext%2A> of an item container.  
  
<a name="live_shaping"></a>   
## Repositioning data as the data's values change (Live shaping)  
 A collection of data can be grouped, sorted, or filtered. WPF 4.5 enables the data to be rearranged when the data is modified. For example, suppose that an application uses a <xref:System.Windows.Controls.DataGrid> to list stocks in a stock market and the stocks are sorted by stock value. If live sorting is enabled on the stocks' <xref:System.Windows.Data.CollectionView>, a stock's position in the <xref:System.Windows.Controls.DataGrid> moves when the value of the stock becomes greater or less than another stock's value.   For more information, see the <xref:System.ComponentModel.ICollectionViewLiveShaping> interface.  
  
<a name="weak_event_pattern"></a>   
## Improved Support for Establishing a Weak Reference to an Event  
 Implementing the weak event pattern is now easier because subscribers to events can participate in it without implementing an extra interface.  The generic <xref:System.Windows.WeakEventManager> class also enables subscribers to participate in the weak event pattern if a dedicated <xref:System.Windows.WeakEventManager> does not exist for a certain event.  For more information, see [Weak Event Patterns](../../../../docs/framework/wpf/advanced/weak-event-patterns.md).  
  
<a name="async"></a>   
## New methods for the Dispatcher class  
 The Dispatcher class defines new methods for synchronous and asynchronous operations.  The synchronous <xref:System.Windows.Threading.Dispatcher.Invoke%2A> method defines overloads that take an <xref:System.Action> or <xref:System.Func%601> parameter. The new asynchronous method, <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A>, also takes an <xref:System.Action> or <xref:System.Func%601> as the callback parameter and returns a <xref:System.Windows.Threading.DispatcherOperation> or <xref:System.Windows.Threading.DispatcherOperation%601>.   The <xref:System.Windows.Threading.DispatcherOperation> and <xref:System.Windows.Threading.DispatcherOperation%601> classes define a <xref:System.Threading.Tasks.Task> property.  When you call <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A>, you can use the `await` keyword with either the <xref:System.Windows.Threading.DispatcherOperation> or the associated <xref:System.Threading.Tasks.Task>. If you need to wait synchronously for the <xref:System.Threading.Tasks.Task> that is returned by a <xref:System.Windows.Threading.DispatcherOperation> or <xref:System.Windows.Threading.DispatcherOperation%601>, call the <xref:System.Windows.Threading.TaskExtensions.DispatcherOperationWait%2A> extension method. Calling <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> will result in a deadlock if the operation is queued on a calling thread. For more information about using a <xref:System.Threading.Tasks.Task> to perform asynchronous operations, see [Task Parallelism (Task Parallel Library)](../../../../docs/standard/parallel-programming/task-based-asynchronous-programming.md).  
  
<a name="events_markup_extenions"></a>   
## Markup Extensions for Events  
 WPF 4.5 supports markup extensions for events.  While WPF does not define a markup extension to be used for events, third parties are able to create a markup extension that can be used with events.  
  
## See Also  
 [What's New in the .NET Framework](../../../../docs/framework/whats-new/index.md)
