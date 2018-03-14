---
title: "Rendering Controls with Visual Styles"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "professional appearance [Windows Forms], rendering Windows Forms controls"
  - "themes [Windows Forms], XP visual styles in Window Forms"
  - "custom controls [Windows Forms], rendering"
  - "custom controls [Windows Forms], painting"
  - "visual themes [Windows Forms], rendering Windows Forms controls"
  - "user controls [Windows Forms], painting"
  - "visual styles [Windows Forms], rendering Windows Forms controls"
ms.assetid: a5b178ba-610e-46c4-a6c0-509c0886a744
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Rendering Controls with Visual Styles
The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] provides support for rendering controls and other Windows user interface (UI) elements using visual styles in operating systems that support them. This topic discusses the several levels of support in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] for rendering controls and other UI elements with the current visual style of the operating system.  
  
## Rendering Classes for Common Controls  
 Rendering a control refers to drawing the user interface of a control. The <xref:System.Windows.Forms?displayProperty=nameWithType> namespace provides the <xref:System.Windows.Forms.ControlPaint> class for rendering some common Windows Forms controls. However, this class draws controls in the classic Windows style, which can make it difficult to maintain a consistent UI experience when drawing custom controls in applications with visual styles enabled.  
  
 The [!INCLUDE[dnprdnlong](../../../../includes/dnprdnlong-md.md)] includes classes in the <xref:System.Windows.Forms?displayProperty=nameWithType> namespace that render the parts and states of common controls with visual styles. Each of these classes includes `static` methods for drawing the control or parts of the control in a particular state with the current visual style of the operating system.  
  
 Some of these classes are designed to draw the related control regardless of whether visual styles are available. If visual styles are enabled, then the class members will draw the related control with visual styles; if visual styles are disabled, then the class members will draw the control in the classic Windows style. These classes include:  
  
-   <xref:System.Windows.Forms.ButtonRenderer>  
  
-   <xref:System.Windows.Forms.CheckBoxRenderer>  
  
-   <xref:System.Windows.Forms.GroupBoxRenderer>  
  
-   <xref:System.Windows.Forms.RadioButtonRenderer>  
  
 Other classes can only draw the related control when visual styles are available, and their members will throw an exception if visual styles are disabled. These classes include:  
  
-   <xref:System.Windows.Forms.ComboBoxRenderer>  
  
-   <xref:System.Windows.Forms.ProgressBarRenderer>  
  
-   <xref:System.Windows.Forms.ScrollBarRenderer>  
  
-   <xref:System.Windows.Forms.TabRenderer>  
  
-   <xref:System.Windows.Forms.TextBoxRenderer>  
  
-   <xref:System.Windows.Forms.TrackBarRenderer>  
  
 For more information on using these classes to draw a control, see [How to: Use a Control Rendering Class](../../../../docs/framework/winforms/controls/how-to-use-a-control-rendering-class.md).  
  
## Visual Style Element and Rendering Classes  
 The <xref:System.Windows.Forms.VisualStyles?displayProperty=nameWithType> namespace includes classes that can be used to draw and get information about any control or UI element that is supported by visual styles. Supported controls include common controls that have a rendering class in the <xref:System.Windows.Forms?displayProperty=nameWithType> namespace (see the previous section), as well as other controls, such as tab controls and rebar controls. Other supported UI elements include the parts of the **Start** menu, the taskbar, and the nonclient area of windows.  
  
 The main classes of the <xref:System.Windows.Forms.VisualStyles?displayProperty=nameWithType> namespace are <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> and <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer>. <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> is a foundation class for identifying any control or user interface element supported by visual styles. In addition to <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> itself, the <xref:System.Windows.Forms.VisualStyles?displayProperty=nameWithType> namespace includes many nested classes of <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> with `static` properties that return a <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> for every state of a control, control part, or other UI element supported by visual styles.  
  
 <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> provides the methods that draw and get information about each <xref:System.Windows.Forms.VisualStyles.VisualStyleElement> defined by the current visual style of the operating system. Information that can be retrieved about an element includes its default size, background type, and color definitions. <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> wraps the functionality of the visual styles (UxTheme) API from the Windows Shell portion of the Windows Platform SDK. For more information, see [Using Windows XP Visual Styles](https://msdn.microsoft.com/library/ms997649.aspx).  
  
 For more information about using <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> and <xref:System.Windows.Forms.VisualStyles.VisualStyleElement>, see [How to: Render a Visual Style Element](../../../../docs/framework/winforms/controls/how-to-render-a-visual-style-element.md).  
  
## Enabling Visual Styles  
 To enable visual styles for an application written for the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.0, programmers must include an application manifest that specifies that ComCtl32.dll version 6 or later will be used to draw controls. Applications built with the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.1 or later can use the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method of the <xref:System.Windows.Forms.Application> class.  
  
## Checking for Visual Styles Support  
 The <xref:System.Windows.Forms.Application.RenderWithVisualStyles%2A> property of the <xref:System.Windows.Forms.Application> class indicates whether the current application is drawing controls with visual styles. When painting a custom control, you can check the value of <xref:System.Windows.Forms.Application.RenderWithVisualStyles%2A> to determine whether you should render your control with or without visual styles. The following table lists the four conditions that must exist for <xref:System.Windows.Forms.Application.RenderWithVisualStyles%2A> to return `true`.  
  
|Condition|Notes|  
|---------------|-----------|  
|The operating system supports visual styles.|To verify this condition separately, use the <xref:System.Windows.Forms.VisualStyles.VisualStyleInformation.IsSupportedByOS%2A> property of the <xref:System.Windows.Forms.VisualStyles.VisualStyleInformation> class.|  
|The user has enabled visual styles in the operating system.|To verify this condition separately, use the <xref:System.Windows.Forms.VisualStyles.VisualStyleInformation.IsEnabledByUser%2A> property of the <xref:System.Windows.Forms.VisualStyles.VisualStyleInformation> class.|  
|Visual styles are enabled in the application.|Visual styles can be enabled in an application by calling the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method or by using an application manifest that specifies that ComCtl32.dll version 6 or later will be used to draw controls.|  
|Visual styles are being used to draw the client area of application windows.|To verify this condition separately, use the <xref:System.Windows.Forms.Application.VisualStyleState%2A> property of the <xref:System.Windows.Forms.Application> class and verify that it has the value <xref:System.Windows.Forms.VisualStyles.VisualStyleState.ClientAreaEnabled?displayProperty=nameWithType> or <xref:System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled?displayProperty=nameWithType>.|  
  
 To determine when a user enables or disables visual styles, or switches from one visual style to another, check for the <xref:Microsoft.Win32.UserPreferenceCategory.VisualStyle?displayProperty=nameWithType> value in the handlers for the <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanging?displayProperty=nameWithType> or <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanged?displayProperty=nameWithType> events.  
  
> [!IMPORTANT]
>  If you want to use <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> to render a control or UI element when the user enables or switches visual styles, make sure that you do this when handling the <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanged> event instead of the <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanging> event. An exception will be thrown if you use the <xref:System.Windows.Forms.VisualStyles.VisualStyleRenderer> class when handling <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanging>.  
  
## See Also  
 [Custom Control Painting and Rendering](../../../../docs/framework/winforms/controls/custom-control-painting-and-rendering.md)
