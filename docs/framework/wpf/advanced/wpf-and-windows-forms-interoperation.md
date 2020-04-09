---
title: WPF and Windows Forms interop
titleSuffix: ""
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Forms [WPF], interoperability with"
  - "nester interoperation [WPF]"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "hybrid control [WPF interoperability]"
ms.assetid: 9e8aa6b6-112c-4579-98d1-c974917df499
---
# WPF and Windows Forms Interoperation
[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and Windows Forms present two different architectures for creating application interfaces. The <xref:System.Windows.Forms.Integration?displayProperty=nameWithType> namespace provides classes that enable common interoperation scenarios. The two key classes that implement interoperation capabilities are <xref:System.Windows.Forms.Integration.WindowsFormsHost> and <xref:System.Windows.Forms.Integration.ElementHost>. This topic describes which interoperation scenarios are supported and which scenarios are not supported.  
  
> [!NOTE]
> Special consideration is given to the *hybrid control* scenario. A hybrid control has a control from one technology nested in a control from the other technology. This is also called a *nested interoperation*. A *multilevel hybrid control* has more than one level of hybrid control nesting. An example of a multilevel nested interoperation is a Windows Forms control that contains a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, which contains another Windows Forms control. Multilevel hybrid controls are not supported.  

<a name="Windows_Presentation_Foundation_Application_Hosting"></a>
## Hosting Windows Forms Controls in WPF  
 The following interoperation scenarios are supported when a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control hosts a Windows Forms control:  
  
- The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control may host one or more Windows Forms controls using XAML.  
  
- It may host one or more Windows Forms controls using code.  
  
- It may host Windows Forms container controls that contain other Windows Forms controls.  
  
- It may host a master/detail form with a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] master and Windows Forms details.  
  
- It may host a master/detail form with a Windows Forms master and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] details.  
  
- It may host one or more ActiveX controls.  
  
- It may host one or more composite controls.  
  
- It may host hybrid controls using [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)].  
  
- It may host hybrid controls using code.  
  
### Layout Support  
 The following list describes the known limitations when the  <xref:System.Windows.Forms.Integration.WindowsFormsHost> element attempts to integrate its hosted Windows Forms control into the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] layout system.  
  
- In some cases, Windows Forms controls cannot be resized, or can be sized only to specific dimensions. For example, a Windows Forms <xref:System.Windows.Forms.ComboBox> control supports only a single height, which is defined by the control's font size. In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] dynamic layout, which assumes that elements can stretch vertically, a hosted <xref:System.Windows.Forms.ComboBox> control will not stretch as expected.  
  
- Windows Forms controls cannot be rotated or skewed. For example, when you rotate your user interface by 90 degrees, hosted Windows Forms controls will maintain their upright position.  
  
- In most cases, Windows Forms controls do not support proportional scaling. Although the overall dimensions of the control will scale, child controls and component elements of the control may not resize as expected. This limitation depends on how well each Windows Forms control supports scaling.  
  
- In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] user interface, you can change the z-order of elements to control overlapping behavior. A hosted Windows Forms control is drawn in a separate HWND, so it is always drawn on top of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements.  
  
- Windows Forms controls support autoscaling based on the font size. In a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] user interface, changing the font size does not resize the entire layout, although individual elements may dynamically resize.  
  
### Ambient Properties  
 Some of the ambient properties of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls have Windows Forms equivalents. These ambient properties are propagated to the hosted Windows Forms controls and exposed as public properties on the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> control translates each [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] ambient property into its Windows Forms equivalent.  
  
 For more information, see [Windows Forms and WPF Property Mapping](windows-forms-and-wpf-property-mapping.md).  
  
### Behavior  
 The following table describes interoperation behavior.  
  
|Behavior|Supported|Not supported|  
|--------------|---------------|-------------------|  
|Transparency|Windows Forms control rendering supports transparency. The background of the parent [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control can become the background of hosted Windows Forms controls.|Some Windows Forms controls do not support transparency. For example, the <xref:System.Windows.Forms.TextBox> and <xref:System.Windows.Forms.ComboBox> controls will not be transparent when hosted by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].|  
|Tabbing|Tab order for hosted Windows Forms controls is the same as when those controls are hosted in a Windows Forms-based application.<br /><br /> Tabbing from a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control to a Windows Forms control with the TAB key and SHIFT+TAB keys works as usual.<br /><br /> Windows Forms controls that have a <xref:System.Windows.Forms.Control.TabStop%2A> property value of `false` do not receive focus when the user tabs through controls.<br /><br /> -   Each <xref:System.Windows.Forms.Integration.WindowsFormsHost> control has a <xref:System.Windows.Forms.Integration.WindowsFormsHost.TabIndex%2A> value, which determines when that <xref:System.Windows.Forms.Integration.WindowsFormsHost> control will receive focus.<br />-   Windows Forms controls that are contained inside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> container follow the order specified by the <xref:System.Windows.Forms.Control.TabIndex%2A> property. Tabbing from the last tab index puts focus on the next [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, if one exists. If no other focusable [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control exists, tabbing returns to the first Windows Forms control in the tab order.<br />-   <xref:System.Windows.Forms.Integration.WindowsFormsHost.TabIndex%2A> values for controls inside the <xref:System.Windows.Forms.Integration.WindowsFormsHost> are relative to sibling Windows Forms controls that are contained in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.<br />-   Tabbing honors control-specific behavior. For example, pressing the TAB key in a <xref:System.Windows.Forms.TextBox> control that has a <xref:System.Windows.Forms.TextBoxBase.AcceptsTab%2A> property value of `true` enters a tab in the text box instead of moving the focus.|Not applicable.|  
|Navigation with arrow keys|-   Navigation with arrow keys in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control is the same as in an ordinary Windows Forms container control: The UP ARROW and LEFT ARROW keys select the previous control, and the DOWN ARROW and RIGHT ARROW keys select the next control.<br />-   The UP ARROW and LEFT ARROW keys from the first control that is contained in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control perform the same action as the SHIFT+TAB keyboard shortcut. If there is a focusable [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, focus moves outside the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control. This behavior differs from the standard <xref:System.Windows.Forms.ContainerControl> behavior in that no wrapping to the last control occurs. If no other focusable [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control exists, focus returns to the last Windows Forms control in the tab order.<br />-   The DOWN ARROW and RIGHT ARROW keys from the last control that is contained in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control perform the same action as the TAB key. If there is a focusable [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, focus moves outside the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control. This behavior differs from the standard <xref:System.Windows.Forms.ContainerControl> behavior in that no wrapping to the first control occurs. If no other focusable [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control exists, focus returns to the first Windows Forms control in the tab order.|Not applicable.|  
|Accelerators|Accelerators work as usual, except where noted in the "Not supported" column.|Duplicate accelerators across technologies do not work like ordinary duplicate accelerators. When an accelerator is duplicated across technologies, with at least one on a Windows Forms control and the other on a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control, the Windows Forms control always receives the accelerator. Focus does not toggle between the controls when the duplicate accelerator is pressed.|  
|Shortcut keys|Shortcut keys work as usual, except where noted in the "Not supported" column.|-   Windows Forms shortcut keys that are handled at the preprocessing stage always take precedence over [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] shortcut keys. For example, if you have a <xref:System.Windows.Forms.ToolStrip> control with CTRL+S shortcut keys defined, and there is a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] command bound to CTRL+S, the <xref:System.Windows.Forms.ToolStrip> control handler is always invoked first, regardless of focus.<br />-   Windows Forms shortcut keys that are handled by the <xref:System.Windows.Forms.Control.KeyDown> event are processed last in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. You can prevent this behavior by overriding the Windows Forms control's <xref:System.Windows.Forms.Control.IsInputKey%2A> method or handling the <xref:System.Windows.Forms.Control.PreviewKeyDown> event. Return `true` from the <xref:System.Windows.Forms.Control.IsInputKey%2A> method, or set the value of the <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey%2A?displayProperty=nameWithType> property to `true` in your <xref:System.Windows.Forms.Control.PreviewKeyDown> event handler.|  
|AcceptsReturn, AcceptsTab, and other control-specific behavior|Properties that change the default keyboard behavior work as usual, assuming that the Windows Forms control overrides the <xref:System.Windows.Forms.Control.IsInputKey%2A> method to return `true`.|Windows Forms controls that change default keyboard behavior by handling the <xref:System.Windows.Forms.Control.KeyDown> event are processed last in the host [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control. Because these controls are processed last, they can produce unexpected behavior.|  
|Enter and Leave Events|When focus is not going to the containing <xref:System.Windows.Forms.Integration.ElementHost> control, the Enter and Leave events are raised as usual when focus changes in a single <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.|Enter and Leave events are not raised when the following focus changes occur:<br /><br /> -   From inside to outside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.<br />-   From outside to inside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.<br />-   Outside a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.<br />-   From a Windows Forms control hosted in a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control to an <xref:System.Windows.Forms.Integration.ElementHost> control hosted inside the same <xref:System.Windows.Forms.Integration.WindowsFormsHost>.|  
|Multithreading|All varieties of multithreading are supported.|Both the Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] technologies assume a single-threaded concurrency model. During debugging, calls to framework objects from other threads will raise an exception to enforce this requirement.|  
|Security|All interoperation scenarios require full trust.|No interoperation scenarios are allowed in partial trust.|  
|Accessibility|All accessibility scenarios are supported. Assistive technology products function correctly when they are used for hybrid applications that contain both Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
|Clipboard|All Clipboard operations work as usual. This includes cutting and pasting between Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
|Drag-and-drop feature|All drag-and-drop operations work as usual. This includes operations between Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
  
<a name="Windows_Forms_Application_Hosting_Windows"></a>
## Hosting WPF Controls in Windows Forms  
 The following interoperation scenarios are supported when a Windows Forms control hosts a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control:  
  
- Hosting one or more [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls using code.  
  
- Associating a property sheet with one or more hosted [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.  
  
- Hosting one or more [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] pages in a form.  
  
- Starting a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] window.  
  
- Hosting a master/detail form with a Windows Forms master and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] details.  
  
- Hosting a master/detail form with a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] master and Windows Forms details.  
  
- Hosting custom [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.  
  
- Hosting hybrid controls.  
  
### Ambient Properties  
 Some of the ambient properties of Windows Forms controls have [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] equivalents. These ambient properties are propagated to the hosted [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls and exposed as public properties on the <xref:System.Windows.Forms.Integration.ElementHost> control. The <xref:System.Windows.Forms.Integration.ElementHost> control translates each Windows Forms ambient property to its [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] equivalent.  
  
 For more information, see [Windows Forms and WPF Property Mapping](windows-forms-and-wpf-property-mapping.md).  
  
### Behavior  
 The following table describes interoperation behavior.  
  
|Behavior|Supported|Not supported|  
|--------------|---------------|-------------------|  
|Transparency|[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control rendering supports transparency. The background of the parent Windows Forms control can become the background of hosted [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
|Multithreading|All varieties of multithreading are supported.|Both the Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] technologies assume a single-threaded concurrency model. During debugging, calls to framework objects from other threads will raise an exception to enforce this requirement.|  
|Security|All interoperation scenarios require full trust.|No interoperation scenarios are allowed in partial trust.|  
|Accessibility|All accessibility scenarios are supported. Assistive technology products function correctly when they are used for hybrid applications that contain both Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
|Clipboard|All Clipboard operations work as usual. This includes cutting and pasting between Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
|Drag-and-drop feature|All drag-and-drop operations work as usual. This includes operations between Windows Forms and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.|Not applicable.|  
  
## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Walkthrough: Hosting a Windows Forms Control in WPF](walkthrough-hosting-a-windows-forms-control-in-wpf.md)
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
- [Windows Forms and WPF Property Mapping](windows-forms-and-wpf-property-mapping.md)
