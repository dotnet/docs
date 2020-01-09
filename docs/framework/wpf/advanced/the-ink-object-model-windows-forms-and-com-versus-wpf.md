---
title: "The Ink Object Model: Windows Forms and COM versus WPF"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "enabling ink [WPF]"
  - "InkCanvas control [WPF]"
  - "ink object model [WPF]"
  - "tablet pen [WPF], events [WPF]"
  - "ink [WPF], enabling"
  - "events [WPF], tablet pen"
ms.assetid: 577835be-b145-4226-8570-1d309e9b3901
---
# The Ink Object Model: Windows Forms and COM versus WPF

There are essentially three platforms that support digital ink: the Tablet PC Windows Forms platform, the Tablet PC COM platform, and the Windows Presentation Foundation (WPF) platform.  The Windows Forms and COM platforms share a similar object model, but the object model for the WPF platform is substantially different.  This topic discusses the differences at a high-level so that developers that have worked with one object model can better understand the other.  
  
## Enabling Ink in an Application  
 All three platforms ship objects and controls that enable an application to receive input from a tablet pen.  The Windows Forms and COM platforms ship with [Microsoft.Ink.InkPicture](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583740(v=vs.90)), [Microsoft.Ink.InkEdit](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552265(v=vs.90)), [Microsoft.Ink.InkOverlay](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552322(v=vs.90)) and [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)) classes.  [Microsoft.Ink.InkPicture](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583740(v=vs.90)) and [Microsoft.Ink.InkEdit](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552265(v=vs.90)) are controls that you can add to an application to collect ink.  The [Microsoft.Ink.InkOverlay](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552322(v=vs.90)) and [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)) can be attached to an existing window to ink-enable windows and custom controls.  
  
 The WPF platform includes the <xref:System.Windows.Controls.InkCanvas> control.  You can add an <xref:System.Windows.Controls.InkCanvas> to your application and begin collecting ink immediately. With the <xref:System.Windows.Controls.InkCanvas>, the user can copy, select, and resize ink.  You can add other controls to the <xref:System.Windows.Controls.InkCanvas>, and the user can handwrite over those controls, too.  You can create an ink-enabled custom control by adding an <xref:System.Windows.Controls.InkPresenter> to it and collecting its stylus points.  
  
 The following table lists where to learn more about enabling ink in an application:  
  
|To do this…|On the WPF Platform…|On the Windows Forms/COM Platforms…|  
|-----------------|--------------------------|------------------------------------------|  
|Add an ink-enabled control to an application|See [Getting Started with Ink](getting-started-with-ink.md).|See [Auto Claims Form Sample](/windows/desktop/tablet/auto-claims-form-sample)|  
|Enable ink on a custom control|See [Creating an Ink Input Control](creating-an-ink-input-control.md).|See [Ink Clipboard Sample](/windows/desktop/tablet/ink-clipboard-sample).|  
  
## Ink Data  
 On the Windows Forms and COM platforms, [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)), [Microsoft.Ink.InkOverlay](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552322(v=vs.90)), [Microsoft.Ink.InkEdit](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552265(v=vs.90)), and [Microsoft.Ink.InkPicture](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583740(v=vs.90)) each expose a [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object. The [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object contains the data for one or more [Microsoft.Ink.Stroke](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552692(v=vs.90)) objects and exposes common methods and properties to manage and manipulate those strokes.  The [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object manages the lifetime of the strokes it contains; the [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object creates and deletes the strokes that it owns.  Each [Microsoft.Ink.Stroke](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552692(v=vs.90)) has an identifier that is unique within its parent [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object.  
  
 On the WPF platform, the <xref:System.Windows.Ink.Stroke?displayProperty=nameWithType> class owns and manages its own lifetime. A group of <xref:System.Windows.Ink.Stroke> objects can be collected together in a <xref:System.Windows.Ink.StrokeCollection>, which provides methods for common ink data management operations such as hit testing, erasing, transforming, and serializing the ink. A <xref:System.Windows.Ink.Stroke> can belong to zero, one, or more <xref:System.Windows.Ink.StrokeCollection> objects at any give time.  Instead of having a [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object, the <xref:System.Windows.Controls.InkCanvas> and <xref:System.Windows.Controls.InkPresenter> contain a <xref:System.Windows.Ink.StrokeCollection?displayProperty=nameWithType>.  
  
 The following pair of illustrations compares the ink data object models.  On the Windows Forms and COM platforms, the [Microsoft.Ink.Ink](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583670(v=vs.90)) object constrains the lifetime of the [Microsoft.Ink.Stroke](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552692(v=vs.90)) objects, and the stylus packets belong to the individual strokes.  Two or more strokes can reference the same [Microsoft.Ink.DrawingAttributes](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583636(v=vs.90)) object, as shown in the following illustration.  
  
 ![Diagram of the Ink Object Model for COM&#47;Winforms.](./media/ink-inkownsstrokes.png "Ink_InkOwnsStrokes")  
  
 On the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], each <xref:System.Windows.Ink.Stroke?displayProperty=nameWithType> is a common language runtime object that exists as long as something has a reference to it.  Each <xref:System.Windows.Ink.Stroke> references a <xref:System.Windows.Input.StylusPointCollection> and <xref:System.Windows.Ink.DrawingAttributes?displayProperty=nameWithType> object, which are also common language runtime objects.  
  
 ![Diagram of the Ink Object Model for WPF.](./media/ink-wpfinkobjectmodel.png "Ink_WPFInkObjectModel")  
  
 The following table compares how to accomplish some common tasks on the WPF platform and the Windows Forms and COM platforms.  
  
|Task|Windows Presentation Foundation|Windows Forms and COM|  
|----------|-------------------------------------|---------------------------|  
|Save Ink|<xref:System.Windows.Ink.StrokeCollection.Save%2A>|[Microsoft.Ink.Ink.Save](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms571335(v=vs.90))|  
|Load Ink|Create a <xref:System.Windows.Ink.StrokeCollection> with the <xref:System.Windows.Ink.StrokeCollection.%23ctor%2A> constructor.|[Microsoft.Ink.Ink.Load](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms569609(v=vs.90))|  
|Hit test|<xref:System.Windows.Ink.StrokeCollection.HitTest%2A>|[Microsoft.Ink.Ink.HitTest](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms571330(v=vs.90))|  
|Copy Ink|<xref:System.Windows.Controls.InkCanvas.CopySelection%2A>|[Microsoft.Ink.Ink.ClipboardCopy](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms571316(v=vs.90))|  
|Paste Ink|<xref:System.Windows.Controls.InkCanvas.Paste%2A>|[Microsoft.Ink.Ink.ClipboardPaste](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms571318(v=vs.90))|  
|Access custom properties on a collection of strokes|<xref:System.Windows.Ink.StrokeCollection.AddPropertyData%2A> (the properties are stored internally and accessed via <xref:System.Windows.Ink.StrokeCollection.AddPropertyData%2A>, <xref:System.Windows.Ink.StrokeCollection.RemovePropertyData%2A>, and <xref:System.Windows.Ink.StrokeCollection.ContainsPropertyData%2A>)|Use [Microsoft.Ink.Ink.ExtendedProperties](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms582214(v=vs.90))|  
  
### Sharing ink between platforms  
 Although the platforms have different object models for the ink data, sharing the data between the platforms is very easy. The following examples save ink from a Windows Forms application and load the ink into a Windows Presentation Foundation application.  
  
 [!code-csharp[WinFormWPFInk#UsingWinforms](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#usingwinforms)]
 [!code-vb[WinFormWPFInk#UsingWinforms](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#usingwinforms)]  
[!code-csharp[WinFormWPFInk#SaveWinforms](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#savewinforms)]
[!code-vb[WinFormWPFInk#SaveWinforms](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#savewinforms)]  
  
 [!code-csharp[WinFormWPFInk#UsingWPF](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#usingwpf)]
 [!code-vb[WinFormWPFInk#UsingWPF](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#usingwpf)]  
[!code-csharp[WinFormWPFInk#LoadWPF](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#loadwpf)]
[!code-vb[WinFormWPFInk#LoadWPF](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#loadwpf)]  
  
 The following examples save ink from a Windows Presentation Foundation application and load the ink into a Windows Forms application.  
  
 [!code-csharp[WinFormWPFInk#UsingWPF](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#usingwpf)]
 [!code-vb[WinFormWPFInk#UsingWPF](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#usingwpf)]  
[!code-csharp[WinFormWPFInk#SaveWPF](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#savewpf)]
[!code-vb[WinFormWPFInk#SaveWPF](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#savewpf)]  
  
 [!code-csharp[WinFormWPFInk#UsingWinforms](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#usingwinforms)]
 [!code-vb[WinFormWPFInk#UsingWinforms](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#usingwinforms)]  
[!code-csharp[WinFormWPFInk#LoadWinforms](~/samples/snippets/csharp/VS_Snippets_Wpf/WinformWPFInk/CSharp/Program.cs#loadwinforms)]
[!code-vb[WinFormWPFInk#LoadWinforms](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WinformWPFInk/VisualBasic/Module1.vb#loadwinforms)]
## Events from the Tablet Pen  

 The [Microsoft.Ink.InkOverlay](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552322(v=vs.90)), [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)), and [Microsoft.Ink.InkPicture](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583740(v=vs.90)) on the Windows Forms and COM platforms receive events when the user inputs pen data. The [Microsoft.Ink.InkOverlay](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms552322(v=vs.90)) or [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)) is attached to a window or a control, and can subscribe to the events raised by the tablet input data. The thread on which these events occurs depends on whether the events are raised with a pen, a mouse, or programmatically. For more information about threading in relation to these events, see [General Threading Considerations](/windows/desktop/tablet/general-threading-considerations) and [Threads on Which an Event Can Fire](/windows/desktop/tablet/threads-on-which-an-event-can-fire).  
  
 On the Windows Presentation Foundation platform, the <xref:System.Windows.UIElement> class has events for pen input. This means that every control exposes the full set of stylus events.  The stylus events have tunneling/bubbling event pairs and always occur on the application thread.  For more information, see [Routed Events Overview](routed-events-overview.md).  
  
 The following diagram shows compares the object models for the classes that raise stylus events. The Windows Presentation Foundation object model shows only the bubbling events, not the tunneling event counterparts.  
  
 ![Diagram of the Stylus events in WPF vs Winforms.](./media/ink-stylusevents.png "Ink_StylusEvents")  
  
## Pen Data  
 All three platforms provide you with ways to intercept and manipulate the data that comes in from a tablet pen.  On the Windows Forms and COM Platforms, this is achieved by creating a [Microsoft.StylusInput.RealTimeStylus](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms585724(v=vs.90)), attaching a window or control to it, and creating a class that implements the [Microsoft.StylusInput.IStylusSyncPlugin](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms575201(v=vs.90)) or [Microsoft.StylusInput.IStylusAsyncPlugin](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms575194(v=vs.90)) interface. The custom plug-in is then added to the plug-in collection of the [Microsoft.StylusInput.RealTimeStylus](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms585724(v=vs.90)). For more information about this object model, see [Architecture of the StylusInput APIs](/windows/desktop/tablet/architecture-of-the-stylusinput-apis).  
  
 On the WPF platform, the <xref:System.Windows.UIElement> class exposes a collection of plug-ins, similar in design to the [Microsoft.StylusInput.RealTimeStylus](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms585724(v=vs.90)).  To intercept pen data, create a class that inherits from <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> and add the object to the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection of the <xref:System.Windows.UIElement>. For more information about this interaction, see [Intercepting Input from the Stylus](intercepting-input-from-the-stylus.md).  
  
 On all platforms, a thread pool receives the ink data via stylus events and sends it to the application thread.  For more information about threading on the COM and Windows Platforms, see [Threading Considerations for the StylusInput APIs](/windows/desktop/tablet/threading-considerations-for-the-stylusinput-apis).  For more information about threading on the Windows Presentation Software, see [The Ink Threading Model](the-ink-threading-model.md).  
  
 The following illustration compares the object models for the classes that receive pen data on the pen thread pool.  
  
 ![Diagram of the StylusPlugin model WPF vs Winforms.](./media/ink-stylusplugins.png "Ink_StylusPlugins")
