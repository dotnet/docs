---
title: "Troubleshooting Hybrid Applications"
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
  - "overlapping controls [WPF]"
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "hybrid applications [WPF interoperability]"
  - "message loops [WPF]"
ms.assetid: f440c23f-fa5d-4d5a-852f-ba61150e6405
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Troubleshooting Hybrid Applications
<a name="introduction"></a> This topic lists some common problems that can occur when authoring hybrid applications, which use both [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] technologies.  
  

  
<a name="overlapping_controls"></a>   
## Overlapping Controls  
 Controls may not overlap as you would expect. [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] uses a separate HWND for each control. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses one HWND for all content on a page. This implementation difference causes unexpected overlapping behaviors.  
  
 A [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control hosted in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] always appears on top of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content hosted in an <xref:System.Windows.Forms.Integration.ElementHost> control appears at the z-order of the <xref:System.Windows.Forms.Integration.ElementHost> control. It is possible to overlap <xref:System.Windows.Forms.Integration.ElementHost> controls, but the hosted [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content does not combine or interact.  
  
<a name="child_property"></a>   
## Child Property  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost> classes can host only a single child control or element. To host more than one control or element, you must use a container as the child content. For example, you could add [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] button and check box controls to a <xref:System.Windows.Forms.Panel?displayProperty=nameWithType> control, and then assign the panel to a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control's <xref:System.Windows.Forms.Integration.WindowsFormsHost.Child%2A> property. However, you cannot add the button and check box controls separately to the same <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.  
  
<a name="scaling"></a>   
## Scaling  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] have different scaling models. Some [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] scaling transformations are meaningful to [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls, but others are not. For example, scaling a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control to 0 will work, but if you try to scale the same control back to a non-zero value, the control's size remains 0. For more information, see [Layout Considerations for the WindowsFormsHost Element](../../../../docs/framework/wpf/advanced/layout-considerations-for-the-windowsformshost-element.md).  
  
<a name="adapter"></a>   
## Adapter  
 There may be confusion when working the <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost> classes, because they include a hidden container. Both the <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost> classes have a hidden container, called an *adapter*, which they use to host content. For the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, the adapter derives from the <xref:System.Windows.Forms.ContainerControl?displayProperty=nameWithType> class. For the <xref:System.Windows.Forms.Integration.ElementHost> control, the adapter derives from the <xref:System.Windows.Controls.DockPanel> element. When you see references to the adapter in other interoperation topics, this container is what is being discussed.  
  
<a name="nesting"></a>   
## Nesting  
 Nesting a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element inside an <xref:System.Windows.Forms.Integration.ElementHost> control is not supported. Nesting an <xref:System.Windows.Forms.Integration.ElementHost> control inside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element is also not supported.  
  
<a name="focus"></a>   
## Focus  
 Focus works differently in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)], which means that focus issues may occur in a hybrid application. For example, if you have focus inside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, and you either minimize and restore the page or show a modal dialog box, focus inside the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element may be lost. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element still has focus, but the control inside it may not.  
  
 Data validation is also affected by focus. Validation works in a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, but it does not work as you tab out of the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, or between two different <xref:System.Windows.Forms.Integration.WindowsFormsHost> elements.  
  
<a name="property_mapping"></a>   
## Property Mapping  
 Some property mappings require extensive interpretation to bridge dissimilar implementations between the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] technologies. Property mappings enable your code to react to changes in fonts, colors, and other properties. In general, property mappings work by listening for either *Property*Changed events or On*Property*Changed calls, and setting appropriate properties on either the child control or its adapter. For more information, see [Windows Forms and WPF Property Mapping](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-property-mapping.md).  
  
<a name="layoutrelated_properties_on_hosted_content"></a>   
## Layout-related Properties on Hosted Content  
 When the <xref:System.Windows.Forms.Integration.WindowsFormsHost.Child%2A?displayProperty=nameWithType> or <xref:System.Windows.Forms.Integration.ElementHost.Child%2A?displayProperty=nameWithType> property is assigned, several layout-related properties on the hosted content are set automatically. Changing these content properties can cause unexpected layout behaviors.  
  
 Your hosted content is docked to fill the <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost> parent. To enable this fill behavior, several properties are set when you set the child property. The following table lists which content properties are set by the <xref:System.Windows.Forms.Integration.ElementHost> and <xref:System.Windows.Forms.Integration.WindowsFormsHost> classes.  
  
|Host Class|Content Properties|  
|----------------|------------------------|  
|<xref:System.Windows.Forms.Integration.ElementHost>|<xref:System.Windows.FrameworkElement.Height%2A><br /><br /> <xref:System.Windows.FrameworkElement.Width%2A><br /><br /> <xref:System.Windows.FrameworkElement.Margin%2A><br /><br /> <xref:System.Windows.FrameworkElement.VerticalAlignment%2A><br /><br /> <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A>|  
|<xref:System.Windows.Forms.Integration.WindowsFormsHost>|<xref:System.Windows.Forms.Control.Margin%2A><br /><br /> <xref:System.Windows.Forms.Control.Dock%2A><br /><br /> <xref:System.Windows.Forms.Control.AutoSize%2A><br /><br /> <xref:System.Windows.Forms.Control.Location%2A><br /><br /> <xref:System.Windows.Forms.Control.MaximumSize%2A>|  
  
 Do not set these properties directly on the hosted content. For more information, see [Layout Considerations for the WindowsFormsHost Element](../../../../docs/framework/wpf/advanced/layout-considerations-for-the-windowsformshost-element.md).  
  
<a name="navigation_applications"></a>   
## Navigation Applications  
 Navigation applications may not maintain user state. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element recreates its controls when it is used in a navigation application. Recreating child controls occurs when the user navigates away from the page hosting the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element and then returns to it. Any content that has been typed in by the user will be lost.  
  
<a name="message_loop_interoperation"></a>   
## Message Loop Interoperation  
 When working with [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] message loops, messages may not be processed as expected. The <xref:System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop%2A> method is called by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> constructor. This method adds a message filter to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] message loop. This filter calls the <xref:System.Windows.Forms.Control.PreProcessMessage%2A?displayProperty=nameWithType> method if a <xref:System.Windows.Forms.Control?displayProperty=nameWithType> was the target of the message and translates/dispatches the message.  
  
 If you show a <xref:System.Windows.Window> in a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] message loop with <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType>, you cannot type anything unless you call the <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A> method. The <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A> method takes a <xref:System.Windows.Window> and adds a <xref:System.Windows.Forms.IMessageFilter?displayProperty=nameWithType>, which reroutes key-related messages to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] message loop. For more information, see [Windows Forms and WPF Interoperability Input Architecture](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-interoperability-input-architecture.md).  
  
<a name="opacity_and_layering"></a>   
## Opacity and Layering  
 The <xref:System.Windows.Interop.HwndHost> class does not support layering. This means that setting the <xref:System.Windows.UIElement.Opacity%2A> property on the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element has no effect, and no blending will occur with other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] windows which have <xref:System.Windows.Window.AllowsTransparency%2A> set to `true`.  
  
<a name="dispose"></a>   
## Dispose  
 Not disposing classes properly can leak resources. In your hybrid applications, make sure that the <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost> classes are disposed, or you could leak resources. [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] disposes <xref:System.Windows.Forms.Integration.ElementHost> controls when its non-modal <xref:System.Windows.Forms.Form> parent closes. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] disposes <xref:System.Windows.Forms.Integration.WindowsFormsHost> elements when your application shuts down. It is possible to show a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element in a <xref:System.Windows.Window> in a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] message loop. In this case, your code may not receive notification that your application is shutting down.  
  
<a name="enabling_visual_styles"></a>   
## Enabling Visual Styles  
 [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)] visual styles on a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control may not be enabled. The <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method is called in the template for a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] application. Although this method is not called by default, if you use [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)] to create a project, you will get [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)] visual styles for controls, if version 6.0 of Comctl32.dll is available. You must call the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method before handles are created on the thread. For more information, see [How to: Enable Visual Styles in a Hybrid Application](../../../../docs/framework/wpf/advanced/how-to-enable-visual-styles-in-a-hybrid-application.md).  
  
<a name="licensed_controls"></a>   
## Licensed Controls  
 Licensed [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls that display licensing information in a message box to the user might cause unexpected behavior for a hybrid application. Some licensed controls show a dialog box in response to handle creation. For example, a licensed control might inform the user that a license is required, or that the user has three remaining trial uses of the control.  
  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element derives from the <xref:System.Windows.Interop.HwndHost> class, and the child control’s handle is created inside the <xref:System.Windows.Forms.Integration.WindowsFormsHost.BuildWindowCore%2A> method. The <xref:System.Windows.Interop.HwndHost> class does not allow messages to be processed in the <xref:System.Windows.Forms.Integration.WindowsFormsHost.BuildWindowCore%2A> method, but displaying a dialog box causes messages to be sent. To enable this licensing scenario, call the <xref:System.Windows.Forms.Control.CreateControl%2A?displayProperty=nameWithType> method on the control before assigning it as the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element's child.  
  
<a name="wpf_designer"></a>   
## WPF Designer  
 You can design your WPF content by using the [!INCLUDE[wpfdesigner_current_long](../../../../includes/wpfdesigner-current-long-md.md)]. The following sections list some common problems that can occur when authoring hybrid applications with the [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)].  
  
### BackColorTransparent is ignored at design time  
 The <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> property might not work as expected at design time.  
  
 If a WPF control is not on a visible parent, the WPF runtime ignores the <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> value. The reason that <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> might be ignored is because <xref:System.Windows.Forms.Integration.ElementHost> object is created in a separate <xref:System.AppDomain>. However, when you run the application, <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> does work as expected.  
  
### Design-time Error List appears when the obj folder is deleted  
 If the obj folder is deleted, the Design-time Error List appears.  
  
 When you design using <xref:System.Windows.Forms.Integration.ElementHost>, the Windows Forms Designer uses generated files in the Debug or Release folder within your project's obj folder. If you delete these files, the Design-time Error List appears. To fix this problem, rebuild your project. For more information, see [Design-Time Errors in the Windows Forms Designer](../../../../docs/framework/winforms/controls/design-time-errors-in-the-windows-forms-designer.md).  
  
<a name="elementhost_and_ime"></a>   
## ElementHost and IME  
 WPF controls hosted in an <xref:System.Windows.Forms.Integration.ElementHost> currently do not support the <xref:System.Windows.Forms.Control.ImeMode%2A> property. Changes to <xref:System.Windows.Forms.Control.ImeMode%2A> will be ignored by the hosted controls.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Interoperability in the WPF Designer](http://msdn.microsoft.com/library/2cb7c1ca-2a75-463b-8801-fba81e2b7042)  
 [Windows Forms and WPF Interoperability Input Architecture](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-interoperability-input-architecture.md)  
 [How to: Enable Visual Styles in a Hybrid Application](../../../../docs/framework/wpf/advanced/how-to-enable-visual-styles-in-a-hybrid-application.md)  
 [Layout Considerations for the WindowsFormsHost Element](../../../../docs/framework/wpf/advanced/layout-considerations-for-the-windowsformshost-element.md)  
 [Windows Forms and WPF Property Mapping](../../../../docs/framework/wpf/advanced/windows-forms-and-wpf-property-mapping.md)  
 [Design-Time Errors in the Windows Forms Designer](../../../../docs/framework/winforms/controls/design-time-errors-in-the-windows-forms-designer.md)  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)
