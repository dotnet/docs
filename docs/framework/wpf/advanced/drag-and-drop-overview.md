---
title: "Drag and Drop Overview"
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
  - "drag-and-drop [WPF], implementing"
  - "drag sources [WPF], drag-and-drop"
  - "data transfer [WPF], drag-and-drop"
  - "drag-and-drop [WPF], about"
  - "drag-and-drop [WPF], events"
  - "drop targets [WPF], drag-and-drop"
ms.assetid: 1a5b27b0-0ac5-4cdf-86c0-86ac0271fa64
caps.latest.revision: 31
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Drag and Drop Overview
This topic provides an overview of drag-and-drop support in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] applications. Drag-and-drop commonly refers to a method of data transfer that involves using a mouse (or some other pointing device) to select one or more objects, dragging these objects over some desired drop target in the [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)], and dropping them.  
  
  
<a name="Drag_and_Drop_Support"></a>   
## Drag-and-Drop Support in WPF  
 Drag-and-drop operations typically involve two parties: a drag source from which the dragged object originates and a drop target which receives the dropped object.  The drag source and drop target may be UI elements in the same application or a different application.  
  
 The type and number of objects that can be manipulated with drag-and-drop is completely arbitrary. For example, files, folders, and selections of content are some of the more common objects manipulated through drag-and-drop operations.  
  
 The particular actions performed during a drag-and-drop operation are application specific, and often determined by context.  For example, dragging a selection of files from one folder to another on the same storage device moves the files by default, whereas dragging files from a [!INCLUDE[TLA#tla_unc](../../../../includes/tlasharptla-unc-md.md)] share to a local folder copies the files by default.  
  
 The drag-and-drop facilities provided by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are designed to be highly flexible and customizable to support a wide variety of drag-and-drop scenarios.  Drag-and-drop supports manipulating objects within a single application, or between different applications. Dragging-and-dropping between [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications and other [!INCLUDE[TLA2#tla_win](../../../../includes/tla2sharptla-win-md.md)] applications is also fully supported.  
  
 In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], any <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> can participate in drag-and-drop. The events and methods required for drag-and-drop operations are defined in the <xref:System.Windows.DragDrop> class. The <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement> classes contain aliases for the <xref:System.Windows.DragDrop> attached events so that the events appear in the class members list when a <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> is inherited as a base element. Event handlers that are attached to these events are attached to the underlying <xref:System.Windows.DragDrop> attached event and receive the same event data instance. For more information, see the <xref:System.Windows.UIElement.Drop?displayProperty=nameWithType> event.  
  
> [!IMPORTANT]
>  OLE drag-and-drop does not work while in the Internet zone.  
  
<a name="Data_Transfer"></a>   
## Data Transfer  
 Drag-and-drop is part of the more general area of data transfer. Data transfer includes drag-and-drop and copy-and-paste operations. A drag-and-drop operation is analogous to a copy-and-paste or cut-and-paste operation that is used to transfer data from one object or application to another by using the system clipboard. Both types of operations require:  
  
-   A source object that provides the data.  
  
-   A way to temporarily store the transferred data.  
  
-   A target object that receives the data.  
  
 In a copy-and-paste operation, the system clipboard is used to temporarily store the transferred data; in a drag-and-drop operation, a <xref:System.Windows.DataObject> is used to store the data. Conceptually, a data object consists of one or more pairs of an <xref:System.Object> that contains the actual data, and a corresponding data format identifier.  
  
 The drag source initiates a drag-and-drop operation by calling the static <xref:System.Windows.DragDrop.DoDragDrop%2A?displayProperty=nameWithType> method and passing the transferred data to it. The <xref:System.Windows.DragDrop.DoDragDrop%2A> method will automatically wrap the data in a <xref:System.Windows.DataObject> if necessary. For greater control over the data format, you can wrap the data in a <xref:System.Windows.DataObject> before passing it to the <xref:System.Windows.DragDrop.DoDragDrop%2A> method. The drop target is responsible for extracting the data from the <xref:System.Windows.DataObject>. For more information about working with data objects, see [Data and Data Objects](../../../../docs/framework/wpf/advanced/data-and-data-objects.md).  
  
 The source and target of a drag-and-drop operation are UI elements; however, the data that is actually being transferred typically does not have a visual representation. You can write code to provide a visual representation of the data that is dragged, such as occurs when dragging files in Windows Explorer. By default, feedback is provided to the user by changing the cursor to represent the effect that the drag-and-drop operation will have on the data, such as whether the data will be moved or copied.  
  
### Drag-and-Drop Effects  
 Drag-and-drop operations can have different effects on the transferred data. For example, you can copy the data or you can move the data. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] defines a <xref:System.Windows.DragDropEffects> enumeration that you can use to specify the effect of a drag-and-drop operation. In the drag source, you can specify the effects that the source will allow in the <xref:System.Windows.DragDrop.DoDragDrop%2A> method. In the drop target, you can specify the effect that the target intends in the <xref:System.Windows.DragEventArgs.Effects%2A> property of the <xref:System.Windows.DragEventArgs> class. When the drop target specifies its intended effect in the <xref:System.Windows.DragDrop.DragOver> event, that information is passed back to the drag source in the <xref:System.Windows.DragDrop.GiveFeedback> event. The drag source uses this information to inform the user what effect the drop target intends to have on the data. When the data is dropped, the drop target specifies its actual effect in the <xref:System.Windows.DragDrop.Drop> event. That information is passed back to the drag source as the return value of the <xref:System.Windows.DragDrop.DoDragDrop%2A> method. If the drop target returns an effect that is not in the drag sources list of `allowedEffects`, the drag-and-drop operation is cancelled without any data transfer occurring.  
  
 It is important to remember that in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], the <xref:System.Windows.DragDropEffects> values are only used to provide communication between the drag source and the drop target regarding the effects of the drag-and-drop operation. The actual effect of the drag-and-drop operation depends on you to write the appropriate code in your application.  
  
 For example, the drop target might specify that the effect of dropping data on it is to move the data. However, to move the data, it must be both added to the target element and removed from the source element. The source element might indicate that it allows moving the data, but if you do not provide the code to remove the data from the source element, the end result will be that the data is copied, and not moved.  
  
<a name="Drag_and_Drop_Events"></a>   
## Drag-and-Drop Events  
 Drag-and-drop operations support an event driven model.  Both the drag source and the drop target use a standard set of events to handle drag-and-drop operations.  The following tables summarize the standard drag-and-drop events. These are attached events on the <xref:System.Windows.DragDrop> class. For more information about attached events, see [Attached Events Overview](../../../../docs/framework/wpf/advanced/attached-events-overview.md).  
  
### Drag Source Events  
  
|Event|Summary|  
|-----------|-------------|  
|<xref:System.Windows.DragDrop.GiveFeedback>|This event occurs continuously during a drag-and-drop operation, and enables the drop source to give feedback information to the user. This feedback is commonly given by changing the appearance of the mouse pointer to indicate the effects allowed by the drop target.  This is a bubbling event.|  
|<xref:System.Windows.DragDrop.QueryContinueDrag>|This event occurs when there is a change in the keyboard or mouse button states during a drag-and-drop operation, and enables the drop source to cancel the drag-and-drop operation depending on the key/button states. This is a bubbling event.|  
|<xref:System.Windows.DragDrop.PreviewGiveFeedback>|Tunneling version of <xref:System.Windows.DragDrop.GiveFeedback>.|  
|<xref:System.Windows.DragDrop.PreviewQueryContinueDrag>|Tunneling version of <xref:System.Windows.DragDrop.QueryContinueDrag>.|  
  
### Drop Target Events  
  
|Event|Summary|  
|-----------|-------------|  
|<xref:System.Windows.DragDrop.DragEnter>|This event occurs when an object is dragged into the drop target's boundary. This is a bubbling event.|  
|<xref:System.Windows.DragDrop.DragLeave>|This event occurs when an object is dragged out of the drop target's boundary.  This is a bubbling event.|  
|<xref:System.Windows.DragDrop.DragOver>|This event occurs continuously while an object is dragged (moved) within the drop target's boundary. This is a bubbling event.|  
|<xref:System.Windows.DragDrop.Drop>|This event occurs when an object is dropped on the drop target.  This is a bubbling event.|  
|<xref:System.Windows.DragDrop.PreviewDragEnter>|Tunneling version of <xref:System.Windows.DragDrop.DragEnter>.|  
|<xref:System.Windows.DragDrop.PreviewDragLeave>|Tunneling version of <xref:System.Windows.DragDrop.DragLeave>.|  
|<xref:System.Windows.DragDrop.PreviewDragOver>|Tunneling version of <xref:System.Windows.DragDrop.DragOver>.|  
|<xref:System.Windows.DragDrop.PreviewDrop>|Tunneling version of <xref:System.Windows.DragDrop.Drop>.|  
  
 To handle drag-and-drop events for instances of an object, add handlers for the events listed in the preceding tables. To handle drag-and-drop events at the class level, override the corresponding virtual On*Event and On\*PreviewEvent methods. For more information, see [Class Handling of Routed Events by Control Base Classes](../../../../docs/framework/wpf/advanced/marking-routed-events-as-handled-and-class-handling.md#Class_Handling_of_Routed_Events).  
  
<a name="Implementing_Drag_And_Drop"></a>   
## Implementing Drag-and-Drop  
 A UI element can be a drag source, a drop target, or both. To implement basic drag-and-drop, you write code to initiate the drag-and-drop operation and to process the dropped data. You can enhance the drag-and-drop experience by handling optional drag-and-drop events.  
  
 To implement basic drag-and-drop, you will complete the following tasks:  
  
-   Identify the element that will be a drag source. A drag source can be a <xref:System.Windows.UIElement> or a <xref:System.Windows.ContentElement>.  
  
-   Create an event handler on the drag source that will initiate the drag-and-drop operation. The event is typically the <xref:System.Windows.UIElement.MouseMove> event.  
  
-   In the drag source event handler, call the <xref:System.Windows.DragDrop.DoDragDrop%2A> method to initiate the drag-and-drop operation. In the <xref:System.Windows.DragDrop.DoDragDrop%2A> call, specify the drag source, the data to be transferred, and the allowed effects.  
  
-   Identify the element that will be a drop target. A drop target can be <xref:System.Windows.UIElement> or a <xref:System.Windows.ContentElement>.  
  
-   On the drop target, set the <xref:System.Windows.UIElement.AllowDrop%2A> property to `true`.  
  
-   In the drop target, create a <xref:System.Windows.DragDrop.Drop> event handler to process the dropped data.  
  
-   In the <xref:System.Windows.DragDrop.Drop> event handler, extract the data from the <xref:System.Windows.DragEventArgs> by using the <xref:System.Windows.DataObject.GetDataPresent%2A> and <xref:System.Windows.DataObject.GetData%2A> methods.  
  
-   In the <xref:System.Windows.DragDrop.Drop> event handler, use the data to perform the desired drag-and-drop operation.  
  
 You can enhance your drag-and-drop implementation by creating a custom <xref:System.Windows.DataObject> and by handling optional drag source and drop target events, as shown in the following tasks:  
  
-   To transfer custom data or multiple data items, create a <xref:System.Windows.DataObject> to pass to the <xref:System.Windows.DragDrop.DoDragDrop%2A> method.  
  
-   To perform additional actions during a drag, handle the <xref:System.Windows.DragDrop.DragEnter>, <xref:System.Windows.DragDrop.DragOver>, and <xref:System.Windows.DragDrop.DragLeave> events on the drop target.  
  
-   To change the appearance of the mouse pointer, handle the <xref:System.Windows.DragDrop.GiveFeedback> event on the drag source.  
  
-   To change how the drag-and-drop operation is canceled, handle the <xref:System.Windows.DragDrop.QueryContinueDrag> event on the drag source.  
  
<a name="Drag_And_Drop_Example"></a>   
## Drag-and-Drop Example  
 This section describes how to implement drag-and-drop for an <xref:System.Windows.Shapes.Ellipse> element. The <xref:System.Windows.Shapes.Ellipse> is both a drag source and a drop target. The transferred data is the string representation of the ellipse’s <xref:System.Windows.Shapes.Shape.Fill%2A> property. The following XAML shows the <xref:System.Windows.Shapes.Ellipse> element and the drag-and-drop related events that it handles. For complete steps on how to implement drag-and-drop, see [Walkthrough: Enabling Drag and Drop on a User Control](../../../../docs/framework/wpf/advanced/walkthrough-enabling-drag-and-drop-on-a-user-control.md).  
  
 [!code-xaml[DragDropSnippets#EllipseXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml#ellipsexaml)]  
  
### Enabling an Element to be a Drag Source  
 An object that is a drag source is responsible for:  
  
-   Identifying when a drag occurs.  
  
-   Initiating the drag-and-drop operation.  
  
-   Identifying the data to be transferred.  
  
-   Specifying the effects that the drag-and-drop operation is allowed to have on the transferred data.  
  
 The drag source may also give feedback to the user regarding the allowed actions (move, copy, none), and can cancel the drag-and-drop operation based on additional user input, such as pressing the ESC key during the drag.  
  
 It is the responsibility of your application to determine when a drag occurs, and then initiate the drag-and-drop operation by calling the <xref:System.Windows.DragDrop.DoDragDrop%2A> method. Typically, this is when a <xref:System.Windows.UIElement.MouseMove> event occurs over the element to be dragged while a mouse button is pressed. The following example shows how to initiate a drag-and-drop operation from the <xref:System.Windows.UIElement.MouseMove> event handler of an <xref:System.Windows.Shapes.Ellipse> element to make it a drag source. The transferred data is the string representation of the ellipse’s <xref:System.Windows.Shapes.Shape.Fill%2A> property.  
  
 [!code-csharp[DragDropSnippets#DoDragDrop](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml.cs#dodragdrop)]
 [!code-vb[DragDropSnippets#DoDragDrop](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/dragdropsnippets/vb/mainwindow.xaml.vb#dodragdrop)]  
  
 Inside of the <xref:System.Windows.UIElement.MouseMove> event handler, call the <xref:System.Windows.DragDrop.DoDragDrop%2A> method to initiate the drag-and-drop operation. The <xref:System.Windows.DragDrop.DoDragDrop%2A> method takes three parameters:  
  
-   `dragSource` – A reference to the dependency object that is the source of the transferred data; this is typically the source of the <xref:System.Windows.UIElement.MouseMove> event.  
  
-   `data` - An object that contains the transferred data, wrapped in a <xref:System.Windows.DataObject>.  
  
-   `allowedEffects` - One of the <xref:System.Windows.DragDropEffects> enumeration values that specifies the permitted effects of the drag-and-drop operation.  
  
 Any serializable object can be passed in the `data` parameter. If the data is not already wrapped in a <xref:System.Windows.DataObject>, it will automatically be wrapped in a new <xref:System.Windows.DataObject>. To pass multiple data items, you must create the <xref:System.Windows.DataObject> yourself, and pass it to the <xref:System.Windows.DragDrop.DoDragDrop%2A> method. For more information, see [Data and Data Objects](../../../../docs/framework/wpf/advanced/data-and-data-objects.md).  
  
 The `allowedEffects` parameter is used to specify what the drag source will allow the drop target to do with the transferred data. The common values for a drag source are <xref:System.Windows.DragDropEffects.Copy>, <xref:System.Windows.DragDropEffects.Move>, and <xref:System.Windows.DragDropEffects.All>.  
  
> [!NOTE]
>  The drop target is also able to specify what effects it intends in response to the dropped data. For example, if the drop target does not recognize the data type to be dropped, it can refuse the data by setting its allowed effects to <xref:System.Windows.DragDropEffects.None>. It typically does this in its <xref:System.Windows.DragDrop.DragOver> event handler.  
  
 A drag source can optionally handle the <xref:System.Windows.DragDrop.GiveFeedback> and <xref:System.Windows.DragDrop.QueryContinueDrag> events. These events have default handlers that are used unless you mark the events as handled. You will typically ignore these events unless you have a specific need to change their default behavior.  
  
 The <xref:System.Windows.DragDrop.GiveFeedback> event is raised continuously while the drag source is being dragged. The default handler for this event checks whether the drag source is over a valid drop target. If it is, it checks the allowed effects of the drop target. It then gives feedback to the end user regarding the allowed drop effects. This is typically done by changing the mouse cursor to a no-drop, copy, or move cursor. You should only handle this event if you need to use custom cursors to provide feedback to the user. If you handle this event, be sure to mark it as handled so that the default handler does not override your handler.  
  
 The <xref:System.Windows.DragDrop.QueryContinueDrag> event is raised continuously while the drag source is being dragged. You can handle this event to determine what action ends the drag-and-drop operation based on the state of the ESC, SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons. The default handler for this event cancels the drag-and-drop operation if the ESC key is pressed, and drops the data if the mouse button is released.  
  
> [!CAUTION]
>  These events are raised continuously during the drag-and-drop operation. Therefore, you should avoid resource-intensive tasks in the event handlers.  For example, use a cached cursor instead of creating a new cursor each time the <xref:System.Windows.DragDrop.GiveFeedback> event is raised.  
  
### Enabling an Element to be a Drop Target  
 An object that is a drop target is responsible for:  
  
-   Specifying that it is a valid drop target.  
  
-   Responding to the drag source when it drags over the target.  
  
-   Checking that the transferred data is in a format that it can receive.  
  
-   Processing the dropped data.  
  
 To specify that an element is a drop target, you set its <xref:System.Windows.UIElement.AllowDrop%2A> property to `true`. The drop target events will then be raised on the element so that you can handle them. During a drag-and-drop operation, the following sequence of events occurs on the drop target:  
  
1.  <xref:System.Windows.DragDrop.DragEnter>  
  
2.  <xref:System.Windows.DragDrop.DragOver>  
  
3.  <xref:System.Windows.DragDrop.DragLeave> or <xref:System.Windows.DragDrop.Drop>  
  
 The <xref:System.Windows.DragDrop.DragEnter> event occurs when the data is dragged into the drop target's boundary. You typically handle this event to provide a preview of the effects of the drag-and-drop operation, if appropriate for your application. Do not set the <xref:System.Windows.DragEventArgs.Effects%2A?displayProperty=nameWithType> property in the <xref:System.Windows.DragDrop.DragEnter> event, as it will be overwritten in the <xref:System.Windows.DragDrop.DragOver> event.  
  
 The following example shows the <xref:System.Windows.DragDrop.DragEnter> event handler for an <xref:System.Windows.Shapes.Ellipse> element. This code previews the effects of the drag-and-drop operation by saving the current <xref:System.Windows.Shapes.Shape.Fill%2A> brush. It then uses the <xref:System.Windows.DataObject.GetDataPresent%2A> method to check whether the <xref:System.Windows.DataObject> being dragged over the ellipse contains string data that can be converted to a <xref:System.Windows.Media.Brush>. If so, the data is extracted using the <xref:System.Windows.DataObject.GetData%2A> method. It is then converted to a <xref:System.Windows.Media.Brush> and applied to the ellipse. The change is reverted in the <xref:System.Windows.DragDrop.DragLeave> event handler. If the data cannot be converted to a <xref:System.Windows.Media.Brush>, no action is performed.  
  
 [!code-csharp[DragDropSnippets#DragEnter](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml.cs#dragenter)]
 [!code-vb[DragDropSnippets#DragEnter](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/dragdropsnippets/vb/mainwindow.xaml.vb#dragenter)]  
  
 The <xref:System.Windows.DragDrop.DragOver> event occurs continuously while the data is dragged over the drop target. This event is paired with the <xref:System.Windows.DragDrop.GiveFeedback> event on the drag source. In the <xref:System.Windows.DragDrop.DragOver> event handler, you typically use the <xref:System.Windows.DataObject.GetDataPresent%2A> and <xref:System.Windows.DataObject.GetData%2A> methods to check whether the transferred data is in a format that the drop target can process. You can also check whether any modifier keys are pressed, which will typically indicate whether the user intends a move or copy action. After these checks are performed, you set the <xref:System.Windows.DragEventArgs.Effects%2A?displayProperty=nameWithType> property to notify the drag source what effect dropping the data will have. The drag source receives this information in the <xref:System.Windows.DragDrop.GiveFeedback> event args, and can set an appropriate cursor to give feedback to the user.  
  
 The following example shows the <xref:System.Windows.DragDrop.DragOver> event handler for an <xref:System.Windows.Shapes.Ellipse> element. This code checks to see if the <xref:System.Windows.DataObject> being dragged over the ellipse contains string data that can be converted to a <xref:System.Windows.Media.Brush>. If so, it sets the <xref:System.Windows.DragEventArgs.Effects%2A?displayProperty=nameWithType> property to <xref:System.Windows.DragDropEffects.Copy>. This indicates to the drag source that the data can be copied to the ellipse. If the data cannot be converted to a <xref:System.Windows.Media.Brush>, the <xref:System.Windows.DragEventArgs.Effects%2A?displayProperty=nameWithType> property is set to <xref:System.Windows.DragDropEffects.None>. This indicates to the drag source that the ellipse is not a valid drop target for the data.  
  
 [!code-csharp[DragDropSnippets#DragOver](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml.cs#dragover)]
 [!code-vb[DragDropSnippets#DragOver](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/dragdropsnippets/vb/mainwindow.xaml.vb#dragover)]  
  
 The <xref:System.Windows.DragDrop.DragLeave> event occurs when the data is dragged out of the target's boundary without being dropped. You handle this event to undo anything that you did in the <xref:System.Windows.DragDrop.DragEnter> event handler.  
  
 The following example shows the <xref:System.Windows.DragDrop.DragLeave> event handler for an <xref:System.Windows.Shapes.Ellipse> element. This code undoes the preview performed in the <xref:System.Windows.DragDrop.DragEnter> event handler by applying the saved <xref:System.Windows.Media.Brush> to the ellipse.  
  
 [!code-csharp[DragDropSnippets#DragLeave](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml.cs#dragleave)]
 [!code-vb[DragDropSnippets#DragLeave](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/dragdropsnippets/vb/mainwindow.xaml.vb#dragleave)]  
  
 The <xref:System.Windows.DragDrop.Drop> event occurs when the data is dropped over the drop target; by default, this happens when the mouse button is released. In the <xref:System.Windows.DragDrop.Drop> event handler, you use the <xref:System.Windows.DataObject.GetData%2A> method to extract the transferred data from the <xref:System.Windows.DataObject> and perform any data processing that your application requires. The <xref:System.Windows.DragDrop.Drop> event ends the drag-and-drop operation.  
  
 The following example shows the <xref:System.Windows.DragDrop.Drop> event handler for an <xref:System.Windows.Shapes.Ellipse> element. This code applies the effects of the drag-and-drop operation, and is similar to the code in the <xref:System.Windows.DragDrop.DragEnter> event handler. It checks to see if the <xref:System.Windows.DataObject> being dragged over the ellipse contains string data that can be converted to a <xref:System.Windows.Media.Brush>. If so, the <xref:System.Windows.Media.Brush> is applied to the ellipse. If the data cannot be converted to a <xref:System.Windows.Media.Brush>, no action is performed.  
  
 [!code-csharp[DragDropSnippets#Drop](../../../../samples/snippets/csharp/VS_Snippets_Wpf/dragdropsnippets/cs/mainwindow.xaml.cs#drop)]
 [!code-vb[DragDropSnippets#Drop](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/dragdropsnippets/vb/mainwindow.xaml.vb#drop)]  
  
## See Also  
 <xref:System.Windows.Clipboard>  
 [Walkthrough: Enabling Drag and Drop on a User Control](../../../../docs/framework/wpf/advanced/walkthrough-enabling-drag-and-drop-on-a-user-control.md)  
 [How-to Topics](../../../../docs/framework/wpf/advanced/drag-and-drop-how-to-topics.md)  
 [Drag and Drop](../../../../docs/framework/wpf/advanced/drag-and-drop.md)
