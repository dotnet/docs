---
title: "Optimizing Performance: Object Behavior"
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
  - "user interface virtualization [WPF]"
  - "dependency properties [WPF], performance"
  - "event handlers [WPF]"
  - "object performance considerations [WPF]"
  - "Freezable objects [WPF], performance"
ms.assetid: 73aa2f47-1d73-439a-be1f-78dc4ba2b5bd
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Object Behavior
Understanding the intrinsic behavior of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] objects will help you make the right tradeoffs between functionality and performance.  
  

  
<a name="Not_Removing_Event_Handlers"></a>   
## Not Removing Event Handlers on Objects may Keep Objects Alive  
 The delegate that an object passes to its event is effectively a reference to that object. Therefore, event handlers can keep objects alive longer than expected. When performing clean up of an object that has registered to listen to an object's event, it is essential to remove that delegate before releasing the object. Keeping unneeded objects alive increases the application's memory usage. This is especially true when the object is the root of a logical tree or a visual tree.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] introduces a weak event listener pattern for events that can be useful in situations where the object lifetime relationships between source and listener are difficult to keep track of. Some existing [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] events use this pattern. If you are implementing objects with custom events, this pattern may be of use to you. For details, see [Weak Event Patterns](../../../../docs/framework/wpf/advanced/weak-event-patterns.md).  
  
 There are several tools, such as the CLR Profiler and the Working Set Viewer, that can provides information on the memory usage of a specified process. The CLR Profiler includes a number of very useful views of the allocation profile, including a histogram of allocated types, allocation and call graphs, a time line showing garbage collections of various generations and the resulting state of the managed heap after those collections, and a call tree showing per-method allocations and assembly loads. For more information, see [.NET Framework Developer Center](http://go.microsoft.com/fwlink/?LinkId=117435).  
  
<a name="DPs_and_Objects"></a>   
## Dependency Properties and Objects  
 In general, accessing a dependency property of a <xref:System.Windows.DependencyObject> is not slower than accessing a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] property. While there is a small performance overhead for setting a property value, getting a value is as fast as getting the value from a [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] property. Offsetting the small performance overhead is the fact that dependency properties support robust features, such as data binding, animation, inheritance, and styling. For more information, see [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md).  
  
### DependencyProperty Optimizations  
 You should define dependency properties in your application very carefully. If your <xref:System.Windows.DependencyProperty> affects only render type metadata options, rather than other metadata options such as <xref:System.Windows.FrameworkPropertyMetadata.AffectsMeasure%2A>, you should mark it as such by overriding its metadata. For more information about overriding or obtaining property metadata, see [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md).  
  
 It may be more efficient to have a property change handler invalidate the measure, arrange, and render passes manually if not all property changes actually affect measure, arrange, and render. For instance, you might decide to re-render a background only when a value is greater than a set limit. In this case, your property change handler would only invalidate render when the value exceeds the set limit.  
  
### Making a DependencyProperty Inheritable is Not Free  
 By default, registered dependency properties are non-inheritable. However, you can explicitly make any property inheritable. While this is a useful feature, converting a property to be inheritable impacts performance by increasing the length of time for property invalidation.  
  
### Use RegisterClassHandler Carefully  
 While calling <xref:System.Windows.EventManager.RegisterClassHandler%2A> allows you to save your instance state, it is important to be aware that the handler is called on every instance, which can cause performance problems. Only use <xref:System.Windows.EventManager.RegisterClassHandler%2A> when your application requires that you save your instance state.  
  
### Set the Default Value for a DependencyProperty during Registration  
 When creating a <xref:System.Windows.DependencyProperty> that requires a default value, set the value using the default metadata passed as a parameter to the <xref:System.Windows.DependencyProperty.Register%2A> method of the <xref:System.Windows.DependencyProperty>. Use this technique rather than setting the property value in a constructor or on each instance of an element.  
  
### Set the PropertyMetadata Value using Register  
 When creating a <xref:System.Windows.DependencyProperty>, you have the option of setting the <xref:System.Windows.PropertyMetadata> using either the <xref:System.Windows.DependencyProperty.Register%2A> or <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> methods. Although your object could have a static constructor to call <xref:System.Windows.DependencyProperty.OverrideMetadata%2A>, this is not the optimal solution and will impact performance. For best performance, set the <xref:System.Windows.PropertyMetadata> during the call to <xref:System.Windows.DependencyProperty.Register%2A>.  
  
<a name="Freezable_Objects"></a>   
## Freezable Objects  
 A <xref:System.Windows.Freezable> is a special type of object that has two states: unfrozen and frozen. Freezing objects whenever possible improves the performance of your application and reduces its working set. For more information, see [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
 Each <xref:System.Windows.Freezable> has a <xref:System.Windows.Freezable.Changed> event that is raised whenever it changes. However, change notifications are costly in terms of application performance.  
  
 Consider the following example in which each <xref:System.Windows.Shapes.Rectangle> uses the same <xref:System.Windows.Media.Brush> object:  
  
 [!code-csharp[Performance#PerformanceSnippet2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet2)]
 [!code-vb[Performance#PerformanceSnippet2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet2)]  
  
 By default, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides an event handler for the <xref:System.Windows.Media.SolidColorBrush> object's <xref:System.Windows.Freezable.Changed> event in order to invalidate the <xref:System.Windows.Shapes.Rectangle> object's <xref:System.Windows.Shapes.Shape.Fill%2A> property. In this case, each time the <xref:System.Windows.Media.SolidColorBrush> has to fire its <xref:System.Windows.Freezable.Changed> event it is required to invoke the callback function for each <xref:System.Windows.Shapes.Rectangle>—the accumulation of these callback function invocations impose a significant performance penalty. In addition, it is very performance intensive to add and remove handlers at this point since the application would have to traverse the entire list to do so. If your application scenario never changes the <xref:System.Windows.Media.SolidColorBrush>, you will be paying the cost of maintaining <xref:System.Windows.Freezable.Changed> event handlers unnecessarily.  
  
 Freezing a <xref:System.Windows.Freezable> can improve its performance, because it no longer needs to expend resources on maintaining change notifications. The table below shows the size of a simple <xref:System.Windows.Media.SolidColorBrush> when its <xref:System.Windows.Freezable.IsFrozen%2A> property is set to `true`, compared to when it is not. This assumes applying one brush to the <xref:System.Windows.Shapes.Shape.Fill%2A> property of ten <xref:System.Windows.Shapes.Rectangle> objects.  
  
|**State**|**Size**|  
|---------------|--------------|  
|Frozen <xref:System.Windows.Media.SolidColorBrush>|212 Bytes|  
|Non-frozen <xref:System.Windows.Media.SolidColorBrush>|972 Bytes|  
  
 The following code sample demonstrates this concept:  
  
 [!code-csharp[Performance#PerformanceSnippet3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet3)]
 [!code-vb[Performance#PerformanceSnippet3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet3)]  
  
### Changed Handlers on Unfrozen Freezables may Keep Objects Alive  
 The delegate that an object passes to a <xref:System.Windows.Freezable> object's <xref:System.Windows.Freezable.Changed> event is effectively a reference to that object. Therefore, <xref:System.Windows.Freezable.Changed> event handlers can keep objects alive longer than expected. When performing clean up of an object that has registered to listen to a <xref:System.Windows.Freezable> object's <xref:System.Windows.Freezable.Changed> event, it is essential to remove that delegate before releasing the object.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also hooks up <xref:System.Windows.Freezable.Changed> events internally. For example, all dependency properties which take <xref:System.Windows.Freezable> as a value will listen to <xref:System.Windows.Freezable.Changed> events automatically. The <xref:System.Windows.Shapes.Shape.Fill%2A> property, which takes a <xref:System.Windows.Media.Brush>, illustrates this concept.  
  
 [!code-csharp[Performance#PerformanceSnippet4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet4)]
 [!code-vb[Performance#PerformanceSnippet4](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet4)]  
  
 On the assignment of `myBrush` to `myRectangle.Fill`, a delegate pointing back to the <xref:System.Windows.Shapes.Rectangle> object will be added to the <xref:System.Windows.Media.SolidColorBrush> object's <xref:System.Windows.Freezable.Changed> event. This means the following code does not actually make `myRect` eligible for garbage collection:  
  
 [!code-csharp[Performance#PerformanceSnippet5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet5)]
 [!code-vb[Performance#PerformanceSnippet5](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet5)]  
  
 In this case `myBrush` is still keeping `myRectangle` alive and will call back to it when it fires its <xref:System.Windows.Freezable.Changed> event. Note that assigning `myBrush` to the <xref:System.Windows.Shapes.Shape.Fill%2A> property of a new <xref:System.Windows.Shapes.Rectangle> will simply add another event handler to `myBrush`.  
  
 The recommended way to clean up these types of objects is to remove the <xref:System.Windows.Media.Brush> from the <xref:System.Windows.Shapes.Shape.Fill%2A> property, which will in turn remove the <xref:System.Windows.Freezable.Changed> event handler.  
  
 [!code-csharp[Performance#PerformanceSnippet6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet6)]
 [!code-vb[Performance#PerformanceSnippet6](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet6)]  
  
<a name="User_Interface_Virtualization"></a>   
## User Interface Virtualization  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also provides a variation of the <xref:System.Windows.Controls.StackPanel> element that automatically "virtualizes" data-bound child content. In this context, the word virtualize refers to a technique by which a subset of objects are generated from a larger number of data items based upon which items are visible on-screen. It is intensive, both in terms of memory and processor, to generate a large number of UI elements when only a few may be on the screen at a given time. <xref:System.Windows.Controls.VirtualizingStackPanel> (through functionality provided by <xref:System.Windows.Controls.VirtualizingPanel>) calculates visible items and works with the <xref:System.Windows.Controls.ItemContainerGenerator> from an <xref:System.Windows.Controls.ItemsControl> (such as <xref:System.Windows.Controls.ListBox> or <xref:System.Windows.Controls.ListView>) to only create elements for visible items.  
  
 As a performance optimization, visual objects for these items are only generated or kept alive if they are visible on the screen. When they are no longer in the viewable area of the control, the visual objects may be removed. This is not to be confused with data virtualization, where data objects are not all present in the local collection- rather streamed in as needed.  
  
 The table below shows the elapsed time adding and rendering 5000 <xref:System.Windows.Controls.TextBlock> elements to a <xref:System.Windows.Controls.StackPanel> and a <xref:System.Windows.Controls.VirtualizingStackPanel>. In this scenario, the measurements represent the time between attaching a text string to the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property of an <xref:System.Windows.Controls.ItemsControl> object to the time when the panel elements display the text string.  
  
|**Host panel**|**Render time (ms)**|  
|--------------------|----------------------------|  
|<xref:System.Windows.Controls.StackPanel>|3210|  
|<xref:System.Windows.Controls.VirtualizingStackPanel>|46|  
  
## See Also  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Taking Advantage of Hardware](../../../../docs/framework/wpf/advanced/optimizing-performance-taking-advantage-of-hardware.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Other Performance Recommendations](../../../../docs/framework/wpf/advanced/optimizing-performance-other-recommendations.md)
