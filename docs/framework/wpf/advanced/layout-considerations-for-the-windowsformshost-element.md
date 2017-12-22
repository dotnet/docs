---
title: "Layout Considerations for the WindowsFormsHost Element"
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
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "WindowsFormsHost element layout considerations [WPF]"
  - "dynamic layout [WPF interoperability]"
  - "device-independent pixels"
ms.assetid: 3c574597-bbde-440f-95cc-01371f1a5d9d
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Layout Considerations for the WindowsFormsHost Element
This topic describes how the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element interacts with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout system.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] support different, but similar, logic for sizing and positioning elements on a form or page. When you create a hybrid user interface (UI) that hosts [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element integrates the two layout schemes.  
  
## Differences in Layout Between WPF and Windows Forms  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses resolution-independent layout. All [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout dimensions are specified using *device-independent pixels*. A device-independent pixel is one ninety-sixth of an inch in size and resolution-independent, so you get similar results regardless of whether you are rendering to a 72-dpi monitor or a 19,200-dpi printer.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is also based on *dynamic layout*. This means that a UI element arranges itself on a form or page according to its content, its parent layout container, and the available screen size. Dynamic layout facilitates localization by automatically adjusting the size and position of UI elements when the strings they contain change length.  
  
 Layout in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] is device-dependent and more likely to be static. Typically, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls are positioned absolutely on a form using dimensions specified in hardware pixels. However, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] does support some dynamic layout features, as summarized in the following table.  
  
|Layout feature|Description|  
|--------------------|-----------------|  
|Autosizing|Some [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls resize themselves to display their contents properly. For more information, see [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md).|  
|Anchoring and docking|[!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls support positioning and sizing based on the parent container. For more information, see <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=nameWithType>.|  
|Autoscaling|Container controls resize themselves and their children based on the resolution of the output device or the size, in pixels, of the default container font. For more information, see [Automatic Scaling in Windows Forms](../../../../docs/framework/winforms/automatic-scaling-in-windows-forms.md).|  
|Layout containers|The <xref:System.Windows.Forms.FlowLayoutPanel> and <xref:System.Windows.Forms.TableLayoutPanel> controls arrange their child controls and size themselves according to their contents.|  
  
## Layout Limitations  
 In general, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls cannot be scaled and transformed to the extent possible in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. The following list describes the known limitations when the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element attempts to integrate its hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control into the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout system.  
  
-   In some cases, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls cannot be resized, or can be sized only to specific dimensions. For example, a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] <xref:System.Windows.Forms.ComboBox> control supports only a single height, which is defined by the control's font size. In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] dynamic layout where elements can stretch vertically, a hosted <xref:System.Windows.Forms.ComboBox> control will not stretch as expected.  
  
-   [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls cannot be rotated or skewed. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element raises the <xref:System.Windows.Forms.Integration.WindowsFormsHost.LayoutError> event if you apply a skew or rotation transformation. If you do not handle the <xref:System.Windows.Forms.Integration.WindowsFormsHost.LayoutError> event, an <xref:System.InvalidOperationException> is raised.  
  
-   In most cases, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls do not support proportional scaling. Although the overall dimensions of the control will scale, child controls and component elements of the control may not resize as expected. This limitation depends on how well each [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control supports scaling. In addition, you cannot scale [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls down to a size of 0 pixels.  
  
-   [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls support autoscaling, in which the form will automatically resize itself and its controls based on the font size. In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] user interface, changing the font size does not resize the entire layout, although individual elements may dynamically resize.  
  
### Z-order  
 In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] user interface, you can change the z-order of elements to control overlapping behavior. A hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is drawn in a separate HWND, so it is always drawn on top of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements.  
  
 A hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is also drawn on top of any <xref:System.Windows.Documents.Adorner> elements.  
  
## Layout Behavior  
 The following sections describe specific aspects of layout behavior when hosting [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
### Scaling, Unit Conversion, and Device Independence  
 Whenever the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element performs operations involving [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] dimensions, two coordinate systems are involved: device-independent pixels for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and hardware pixels for [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)]. Therefore, you must apply proper unit and scaling conversions to achieve a consistent layout.  
  
 Conversion between the coordinate systems depends on the current device resolution and any layout or rendering transforms applied to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element or to its ancestors.  
  
 If the output device is 96 dpi and no scaling has been applied to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, one device-independent pixel is equal to one hardware pixel.  
  
 All other cases require coordinate system scaling. The hosted control is not resized. Instead, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element attempts to scale the hosted control and all of its child controls. Because [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] does not fully support scaling, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element scales to the degree supported by particular controls.  
  
 Override the <xref:System.Windows.Forms.Integration.WindowsFormsHost.ScaleChild%2A> method to provide custom scaling behavior for the hosted [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] control.  
  
 In addition to scaling, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element handles rounding and overflow cases as described in the following table.  
  
|Conversion issue|Description|  
|----------------------|-----------------|  
|Rounding|[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] device-independent pixel dimensions are specified as `double`, and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] hardware pixel dimensions are specified as `int`. In cases where `double`-based dimensions are converted to `int`-based dimensions, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses standard rounding, so that fractional values less than 0.5 are rounded down to 0.|  
|Overflow|When the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element converts from `double` values to `int` values, overflow is possible. Values that are larger than <xref:System.Int32.MaxValue> are set to <xref:System.Int32.MaxValue>.|  
  
### Layout-related Properties  
 Properties that control layout behavior in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements are mapped appropriately by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element. For more information, see [Windows Forms and WPF Property Mapping](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-property-mapping.md).  
  
### Layout Changes in the Hosted Control  
 Layout changes in the hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control are propagated to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to trigger layout updates. The <xref:System.Windows.UIElement.InvalidateMeasure%2A> method on <xref:System.Windows.Forms.Integration.WindowsFormsHost> ensures that layout changes in the hosted control cause the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout engine to run.  
  
### Continuously Sized Windows Forms Controls  
 [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls that support continuous scaling fully interact with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout system. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> and <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> methods as usual to size and arrange the hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control.  
  
### Sizing Algorithm  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses the following procedure to size the hosted control:  
  
1.  The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element overrides the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> and <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> methods.  
  
2.  To determine the size of the hosted control, the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> method calls the hosted control's <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method with a constraint translated from the constraint passed to the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> method.  
  
3.  The <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> method attempts to set the hosted control to the given size constraint.  
  
4.  If the hosted control's <xref:System.Windows.Forms.Control.Size%2A> property matches the specified constraint, the hosted control is sized to the constraint.  
  
 If the <xref:System.Windows.Forms.Control.Size%2A> property does not match the specified constraint, the hosted control does not support continuous sizing. For example, the <xref:System.Windows.Forms.MonthCalendar> control allows only discrete sizes. The permitted sizes for this control consist of integers (representing the number of months) for both height and width. In cases such as this, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element behaves as follows:  
  
-   If the <xref:System.Windows.Forms.Control.Size%2A> property returns a larger size than the specified constraint, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element clips the hosted control. Height and width are handled separately, so the hosted control may be clipped in either direction.  
  
-   If the <xref:System.Windows.Forms.Control.Size%2A> property returns a smaller size than the specified constraint, <xref:System.Windows.Forms.Integration.WindowsFormsHost> accepts this size value and returns the value to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout system.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Walkthrough: Arranging Windows Forms Controls in WPF](../../../../docs/framework/wpf/advanced/walkthrough-arranging-windows-forms-controls-in-wpf.md)  
 [Arranging Windows Forms Controls in WPF Sample](http://go.microsoft.com/fwlink/?LinkID=159971)  
 [Windows Forms and WPF Property Mapping](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-property-mapping.md)  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)
