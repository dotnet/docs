---
title: "Windows Forms and WPF Property Mapping"
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
  - "property mapping [WPF interoperability]"
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "WindowsFormsHost element property mapping [WPF]"
ms.assetid: 999d8298-9c04-467d-a453-86e41002057d
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms and WPF Property Mapping
The [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] technologies have two similar but different property models. *Property mapping* supports interoperation between the two architectures and provides the following capabilities:  
  
-   Makes it easy to map relevant property changes in the host environment to the hosted control or element.  
  
-   Provides default handling for mapping the most commonly used properties.  
  
-   Allows easy removal, overriding, or extending of default properties.  
  
-   Ensures that property value changes on the host are automatically detected and translated to the hosted control or element.  
  
> [!NOTE]
>  Property-change events are not propagated up the hosting control or element hierarchy. Property translation is not performed if the local value of a property does not change because of direct setting, styles, inheritance, data binding, or other mechanisms that change the value of the property.  
  
 Use the <xref:System.Windows.Forms.Integration.WindowsFormsHost.PropertyMap%2A> property on the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element and the <xref:System.Windows.Forms.Integration.ElementHost.PropertyMap%2A> property on <xref:System.Windows.Forms.Integration.ElementHost> control to access property mapping.  
  
## Property Mapping with the WindowsFormsHost Element  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element translates default [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] properties to their [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] equivalents using the following translation table.  
  
|Windows Presentation Foundation hosting|Windows Forms|Interoperation behavior|  
|---------------------------------------------|-------------------|-----------------------------|  
|<xref:System.Windows.Controls.Control.Background%2A><br /><br /> (<xref:System.Windows.Media.Brush?displayProperty=nameWithType>)|<xref:System.Windows.Forms.Control.BackColor%2A><br /><br /> (<xref:System.Drawing.Color?displayProperty=nameWithType>)|The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element sets the <xref:System.Windows.Forms.Control.BackColor%2A> property of the hosted control and the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property of the hosted control. Mapping is performed by using the following rules:<br /><br /> -   If <xref:System.Windows.Controls.Control.Background%2A> is a solid color, it is converted and used to set the <xref:System.Windows.Forms.Control.BackColor%2A> property of the hosted control. The <xref:System.Windows.Forms.Control.BackColor%2A> property is not set on the hosted control, because the hosted control can inherit the value of the <xref:System.Windows.Forms.Control.BackColor%2A> property. **Note:**  The hosted control does not support transparency. Any color assigned to <xref:System.Windows.Forms.Control.BackColor%2A> must be fully opaque, with an alpha value of 0xFF. <br /><br /> -   If <xref:System.Windows.Controls.Control.Background%2A> is not a solid color, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control creates a bitmap from the <xref:System.Windows.Controls.Control.Background%2A> property. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> control assigns this bitmap to the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property of the hosted control. This provides an effect which is similar to transparency. **Note:**  You can override this behavior or you can remove the <xref:System.Windows.Controls.Control.Background%2A> property mapping.|  
|<xref:System.Windows.FrameworkElement.Cursor%2A>|<xref:System.Windows.Forms.Control.Cursor%2A>|If the default mapping has not been reassigned, <xref:System.Windows.Forms.Integration.WindowsFormsHost> control traverses its ancestor hierarchy until it finds an ancestor with its <xref:System.Windows.FrameworkElement.Cursor%2A> property set. This value is translated to the closest corresponding [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] cursor.<br /><br /> If the default mapping for the <xref:System.Windows.FrameworkElement.ForceCursor%2A> property has not been reassigned, the traversal stops on the first ancestor with <xref:System.Windows.FrameworkElement.ForceCursor%2A> set to `true`.|  
|<xref:System.Windows.FrameworkElement.FlowDirection%2A><br /><br /> (<xref:System.Windows.FlowDirection?displayProperty=nameWithType>)|<xref:System.Windows.Forms.Control.RightToLeft%2A><br /><br /> (<xref:System.Windows.Forms.RightToLeft?displayProperty=nameWithType>)|<xref:System.Windows.FlowDirection.LeftToRight> maps to <xref:System.Windows.Forms.RightToLeft.No>.<br /><br /> <xref:System.Windows.FlowDirection.RightToLeft> maps to <xref:System.Windows.Forms.RightToLeft.Yes>.<br /><br /> <xref:System.Windows.Forms.RightToLeft.Inherit> is not mapped.<br /><br /> <xref:System.Windows.FlowDirection.RightToLeft?displayProperty=nameWithType> maps to <xref:System.Windows.Forms.RightToLeft.Yes?displayProperty=nameWithType>.|  
|<xref:System.Windows.Controls.Control.FontStyle%2A>|<xref:System.Drawing.Font.Style%2A> on the hosted control's <xref:System.Drawing.Font?displayProperty=nameWithType>|The set of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] properties is translated into a corresponding <xref:System.Drawing.Font>. When one of these properties changes, a new <xref:System.Drawing.Font> is created. For <xref:System.Windows.FontStyles.Normal%2A>: <xref:System.Drawing.FontStyle.Italic> is disabled. For <xref:System.Windows.FontStyles.Italic%2A> or <xref:System.Windows.FontStyles.Oblique%2A>: <xref:System.Drawing.FontStyle.Italic> is enabled.|  
|<xref:System.Windows.Controls.Control.FontWeight%2A>|<xref:System.Drawing.Font.Style%2A> on the hosted control's <xref:System.Drawing.Font?displayProperty=nameWithType>|The set of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] properties is translated into a corresponding <xref:System.Drawing.Font>. When one of these properties changes, a new <xref:System.Drawing.Font> is created. For <xref:System.Windows.FontWeights.Black%2A>, <xref:System.Windows.FontWeights.Bold%2A>, <xref:System.Windows.FontWeights.DemiBold%2A>, <xref:System.Windows.FontWeights.ExtraBold%2A>, <xref:System.Windows.FontWeights.Heavy%2A>, <xref:System.Windows.FontWeights.Medium%2A>, <xref:System.Windows.FontWeights.SemiBold%2A>, or <xref:System.Windows.FontWeights.UltraBold%2A>: <xref:System.Drawing.FontStyle.Bold> is enabled. For <xref:System.Windows.FontWeights.ExtraLight%2A>, <xref:System.Windows.FontWeights.Light%2A>, <xref:System.Windows.FontWeights.Normal%2A>, <xref:System.Windows.FontWeights.Regular%2A>, <xref:System.Windows.FontWeights.Thin%2A>, or <xref:System.Windows.FontWeights.UltraLight%2A>: <xref:System.Drawing.FontStyle.Bold> is disabled.|  
|<xref:System.Windows.Controls.Control.FontFamily%2A><br /><br /> <xref:System.Windows.Controls.Control.FontSize%2A><br /><br /> <xref:System.Windows.Controls.Control.FontStretch%2A><br /><br /> <xref:System.Windows.Controls.Control.FontStyle%2A><br /><br /> <xref:System.Windows.Controls.Control.FontWeight%2A>|<xref:System.Windows.Forms.Control.Font%2A><br /><br /> (<xref:System.Drawing.Font?displayProperty=nameWithType>)|The set of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] properties is translated into a corresponding <xref:System.Drawing.Font>. When one of these properties changes, a new <xref:System.Drawing.Font> is created. The hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control resizes based on the font size.<br /><br /> Font size in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is expressed as one ninety-sixth of an inch, and in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] as one seventy-second of an inch. The corresponding conversion is:<br /><br /> [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] font size = [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] font size * 72.0 / 96.0.|  
|<xref:System.Windows.Controls.Control.Foreground%2A><br /><br /> (<xref:System.Windows.Media.Brush?displayProperty=nameWithType>)|<xref:System.Windows.Forms.Control.ForeColor%2A><br /><br /> (<xref:System.Drawing.Color?displayProperty=nameWithType>)|The <xref:System.Windows.Controls.Control.Foreground%2A> property mapping is performed by using the following rules:<br /><br /> -   If <xref:System.Windows.Controls.Control.Foreground%2A> is a <xref:System.Windows.Media.SolidColorBrush>, use <xref:System.Windows.Media.SolidColorBrush.Color%2A> for <xref:System.Windows.Forms.Control.ForeColor%2A>.<br />-   If <xref:System.Windows.Controls.Control.Foreground%2A> is a <xref:System.Windows.Media.GradientBrush>, use the color of the <xref:System.Windows.Media.GradientStop> with the lowest offset value for <xref:System.Windows.Forms.Control.ForeColor%2A>.<br />-   For any other <xref:System.Windows.Media.Brush> type, leave <xref:System.Windows.Forms.Control.ForeColor%2A> unchanged. This means the default is used.|  
|<xref:System.Windows.UIElement.IsEnabled%2A>|<xref:System.Windows.Forms.Control.Enabled%2A>|When <xref:System.Windows.UIElement.IsEnabled%2A> is set, <xref:System.Windows.Forms.Integration.WindowsFormsHost> element sets the <xref:System.Windows.Forms.Control.Enabled%2A> property on the hosted control.|  
|<xref:System.Windows.Controls.Control.Padding%2A>|<xref:System.Windows.Forms.Control.Padding%2A>|All four values of the <xref:System.Windows.Forms.Control.Padding%2A> property on the hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control are set to the same <xref:System.Windows.Thickness> value.<br /><br /> -   Values greater than <xref:System.Int32.MaxValue> are set to <xref:System.Int32.MaxValue>.<br />-   Values less than <xref:System.Int32.MinValue> are set to <xref:System.Int32.MinValue>.|  
|<xref:System.Windows.UIElement.Visibility%2A>|<xref:System.Windows.Forms.Control.Visible%2A>|-   <xref:System.Windows.Visibility.Visible> maps to <xref:System.Windows.Forms.Control.Visible%2A> = `true`. The hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is visible. Explicitly setting the <xref:System.Windows.Forms.Control.Visible%2A> property on the hosted control to `false` is not recommended.<br />-   <xref:System.Windows.Visibility.Collapsed> maps to <xref:System.Windows.Forms.Control.Visible%2A> = `true` or `false`. The hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control is not drawn, and its area is collapsed.<br />-   <xref:System.Windows.Visibility.Hidden> : The hosted [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control occupies space in the layout, but is not visible. In this case, the <xref:System.Windows.Forms.Control.Visible%2A> property is set to `true`. Explicitly setting the <xref:System.Windows.Forms.Control.Visible%2A> property on the hosted control to `false` is not recommended.|  
  
 Attached properties on container elements are fully supported by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element.  
  
 For more information, see [Walkthrough: Mapping Properties Using the WindowsFormsHost Element](../../../../docs/framework/wpf/advanced/walkthrough-mapping-properties-using-the-windowsformshost-element.md).  
  
## Updates to Parent Properties  
 Changes to most parent properties cause notifications to the hosted child control. The following list describes properties which do not cause notifications when their values change.  
  
-   <xref:System.Windows.Controls.Control.Background%2A>  
  
-   <xref:System.Windows.FrameworkElement.Cursor%2A>  
  
-   <xref:System.Windows.FrameworkElement.ForceCursor%2A>  
  
-   <xref:System.Windows.UIElement.Visibility%2A>  
  
 For example, if you change the value of the <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, the <xref:System.Windows.Forms.Control.BackColor%2A> property of the hosted control does not change.  
  
## Property Mapping with the ElementHost Control  
 The following properties provide built-in change notification. Do not call the <xref:System.Windows.FrameworkElement.OnPropertyChanged%2A> method when you are mapping these properties:  
  
-   AutoSize  
  
-   BackColor  
  
-   BackgroundImage  
  
-   BackgroundImageLayout  
  
-   BindingContext  
  
-   CausesValidation  
  
-   ContextMenu  
  
-   ContextMenuStrip  
  
-   Cursor  
  
-   Dock  
  
-   Enabled  
  
-   Font  
  
-   ForeColor  
  
-   Location  
  
-   Margin  
  
-   Padding  
  
-   Parent  
  
-   Region  
  
-   RightToLeft  
  
-   Size  
  
-   TabIndex  
  
-   TabStop  
  
-   Text  
  
-   Visible  
  
 The <xref:System.Windows.Forms.Integration.ElementHost> control translates default [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] properties to their [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] equivalents by using the following translation table.  
  
 For more information, see [Walkthrough: Mapping Properties Using the ElementHost Control](../../../../docs/framework/wpf/advanced/walkthrough-mapping-properties-using-the-elementhost-control.md).  
  
|Windows Forms hosting|Windows Presentation Foundation|Interoperation behavior|  
|---------------------------|-------------------------------------|-----------------------------|  
|<xref:System.Windows.Forms.Control.BackColor%2A><br /><br /> (<xref:System.Drawing.Color?displayProperty=nameWithType>)|<xref:System.Windows.Controls.Control.Background%2A><br /><br /> (<xref:System.Windows.Media.Brush?displayProperty=nameWithType>) on the hosted element|Setting this property forces a repaint with an <xref:System.Windows.Media.ImageBrush>. If the <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> property is set to `false` (the default value), this <xref:System.Windows.Media.ImageBrush> is based on the appearance of the <xref:System.Windows.Forms.Integration.ElementHost> control, including its <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.BackgroundImage%2A>, <xref:System.Windows.Forms.Control.BackgroundImageLayout%2A> properties, and any attached paint handlers.<br /><br /> If the <xref:System.Windows.Forms.Integration.ElementHost.BackColorTransparent%2A> property is set to `true`, the <xref:System.Windows.Media.ImageBrush> is based on the appearance of the <xref:System.Windows.Forms.Integration.ElementHost> control's parent, including the parent's <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.BackgroundImage%2A>, <xref:System.Windows.Forms.Control.BackgroundImageLayout%2A> properties, and any attached paint handlers.|  
|<xref:System.Windows.Forms.Control.BackgroundImage%2A><br /><br /> (<xref:System.Drawing.Image?displayProperty=nameWithType>)|<xref:System.Windows.Controls.Control.Background%2A><br /><br /> (<xref:System.Windows.Media.Brush?displayProperty=nameWithType>) on the hosted element|Setting this property causes the same behavior described for the <xref:System.Windows.Forms.Control.BackColor%2A> mapping.|  
|<xref:System.Windows.Forms.Control.BackgroundImageLayout%2A>|<xref:System.Windows.Controls.Control.Background%2A><br /><br /> (<xref:System.Windows.Media.Brush?displayProperty=nameWithType>) on the hosted element|Setting this property causes the same behavior described for the <xref:System.Windows.Forms.Control.BackColor%2A> mapping.|  
|<xref:System.Windows.Forms.Control.Cursor%2A><br /><br /> (<xref:System.Windows.Forms.Cursor?displayProperty=nameWithType>)|<xref:System.Windows.FrameworkElement.Cursor%2A><br /><br /> (<xref:System.Windows.Input.Cursor?displayProperty=nameWithType>)|The [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] standard cursor is translated to the corresponding [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] standard cursor. If the [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] is not a standard cursor, the default is assigned.|  
|<xref:System.Windows.Forms.Control.Enabled%2A>|<xref:System.Windows.UIElement.IsEnabled%2A>|When <xref:System.Windows.Forms.Control.Enabled%2A> is set, the <xref:System.Windows.Forms.Integration.ElementHost> control sets the <xref:System.Windows.UIElement.IsEnabled%2A> property on the hosted element.|  
|<xref:System.Windows.Forms.Control.Font%2A><br /><br /> (<xref:System.Drawing.Font?displayProperty=nameWithType>)|<xref:System.Windows.Controls.Control.FontFamily%2A><br /><br /> <xref:System.Windows.Controls.Control.FontSize%2A><br /><br /> <xref:System.Windows.Controls.Control.FontStretch%2A><br /><br /> <xref:System.Windows.Controls.Control.FontStyle%2A><br /><br /> <xref:System.Windows.Controls.Control.FontWeight%2A>|The <xref:System.Windows.Forms.Control.Font%2A> value is translated into a corresponding set of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] font properties.|  
|<xref:System.Drawing.Font.Bold%2A>|<xref:System.Windows.Controls.Control.FontWeight%2A> on hosted element|If <xref:System.Drawing.Font.Bold%2A> is `true`, <xref:System.Windows.Controls.Control.FontWeight%2A> is set to <xref:System.Windows.FontWeights.Bold%2A>.<br /><br /> If <xref:System.Drawing.Font.Bold%2A> is `false`, <xref:System.Windows.Controls.Control.FontWeight%2A> is set to <xref:System.Windows.FontWeights.Normal%2A>.|  
|<xref:System.Drawing.Font.Italic%2A>|<xref:System.Windows.Controls.Control.FontStyle%2A> on hosted element|If <xref:System.Drawing.Font.Italic%2A> is `true`, <xref:System.Windows.Controls.Control.FontStyle%2A> is set to <xref:System.Windows.FontStyles.Italic%2A>.<br /><br /> If <xref:System.Drawing.Font.Italic%2A> is `false`, <xref:System.Windows.Controls.Control.FontStyle%2A> is set to <xref:System.Windows.FontStyles.Normal%2A>.|  
|<xref:System.Drawing.Font.Strikeout%2A>|<xref:System.Windows.TextDecorations> on hosted element|Applies only when hosting a <xref:System.Windows.Controls.TextBlock> control.|  
|<xref:System.Drawing.Font.Underline%2A>|<xref:System.Windows.TextDecorations> on hosted element|Applies only when hosting a <xref:System.Windows.Controls.TextBlock> control.|  
|<xref:System.Windows.Forms.Control.RightToLeft%2A><br /><br /> (<xref:System.Windows.Forms.RightToLeft?displayProperty=nameWithType>)|<xref:System.Windows.FrameworkElement.FlowDirection%2A><br /><br /> (<xref:System.Windows.FlowDirection>)|<xref:System.Windows.Forms.RightToLeft.No> maps to <xref:System.Windows.FlowDirection.LeftToRight>.<br /><br /> <xref:System.Windows.Forms.RightToLeft.Yes> maps to <xref:System.Windows.FlowDirection.RightToLeft>.|  
|<xref:System.Windows.Forms.Control.Visible%2A>|<xref:System.Windows.UIElement.Visibility%2A>|The <xref:System.Windows.Forms.Integration.ElementHost> control sets the <xref:System.Windows.UIElement.Visibility%2A> property on the hosted element by using the following rules:<br /><br /> -   <xref:System.Windows.Forms.Control.Visible%2A> = `true` maps to <xref:System.Windows.Visibility.Visible>.<br />-   <xref:System.Windows.Forms.Control.Visible%2A> = `false` maps to <xref:System.Windows.Visibility.Hidden>.|  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [WPF and Win32 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-win32-interoperation.md)  
 [WPF and Windows Forms Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-windows-forms-interoperation.md)  
 [Walkthrough: Mapping Properties Using the WindowsFormsHost Element](../../../../docs/framework/wpf/advanced/walkthrough-mapping-properties-using-the-windowsformshost-element.md)  
 [Walkthrough: Mapping Properties Using the ElementHost Control](../../../../docs/framework/wpf/advanced/walkthrough-mapping-properties-using-the-elementhost-control.md)
