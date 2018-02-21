---
title: "UI Automation and Screen Scaling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "scaling, screens"
  - "screens, scaling"
  - "UI (user interface), automation"
  - "UI Automation"
ms.assetid: 4380cad7-e509-448f-b9a5-6de042605fd4
caps.latest.revision: 16
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation and Screen Scaling
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] enables users to change the [!INCLUDE[TLA#tla_dpi](../../../includes/tlasharptla-dpi-md.md)] setting so that most [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] elements on the screen appear larger. Although this feature has long been available in [!INCLUDE[TLA#tla_win](../../../includes/tlasharptla-win-md.md)], in previous versions the scaling had to be implemented by applications. In [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)], the Desktop Window Manager performs default scaling for all applications that do not handle their own scaling. UI Automation client applications must take this feature into account.  
  
<a name="Scaling_in_Windows_Vista"></a>   
## Scaling in Windows Vista  
 The default [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting is 96, which means that 96 pixels occupy a width or height of one notional inch. The exact measure of an "inch" depends on the size and physical resolution of the monitor. For example, on a monitor 12 inches wide, at a horizontal resolution of 1280 pixels, a horizontal line of 96 pixels extends about 9/10 of an inch.  
  
 Changing the [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting is not the same as changing the screen resolution. With [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] scaling, the number of physical pixels on the screen remains the same. However, scaling is applied to the size and location of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements. This scaling can be performed automatically by the Desktop Window Manager (DWM) for the desktop and for applications that do not explicitly ask not to be scaled.  
  
 In effect, when the user sets the scale factor to 120 [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)], a vertical or horizontal inch on the screen becomes bigger by 25 percent. All dimensions are scaled accordingly. The offset of an application window from the top and left edges of the screen increases by 25 percent. If application scaling is enabled and the application is not [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware, the size of the window increases in the same proportion, along with the offsets and sizes of all [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements it contains.  
  
> [!NOTE]
>  By default, the DWM does not perform scaling for non-[!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware applications when the user sets the [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] to 120, but does perform it when the [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] is set to a custom value of 144 or higher. However, the user can override the default behavior.  
  
 Screen scaling creates new challenges for applications that are concerned in any way with screen coordinates. The screen now contains two coordinate systems: physical and logical. The physical coordinates of a point are the actual offset in pixels from the top left of the origin. The logical coordinates are the offsets as they would be if the pixels themselves were scaled.  
  
 Suppose you design a dialog box with a button at coordinates (100, 48). When this dialog box is displayed at the default 96 [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)], the button is located at physical coordinates of (100, 48). At 120 [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)], it is located at physical coordinates of (125, 60). But the logical coordinates are the same at any [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting: (100, 48).  
  
 Logical coordinates are important, because they make the behavior of the operating system and applications consistent regardless of the [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting. For example, <xref:System.Windows.Forms.Cursor.Position%2A?displayProperty=nameWithType> normally returns the logical coordinates. If you move the cursor over an element in a dialog box, the same coordinates are returned regardless of the [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting. If you draw a control at (100, 100), it is drawn to those logical coordinates, and will occupy the same relative position at any [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] setting.  
  
<a name="Scaling_in_UI_Automation_Clients"></a>   
## Scaling in UI Automation Clients  
 The [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] [!INCLUDE[TLA#tla_api](../../../includes/tlasharptla-api-md.md)] does not use logical coordinates. The following methods and properties either return physical coordinates or take them as parameters.  
  
-   <xref:System.Windows.Automation.AutomationElement.GetClickablePoint%2A>  
  
-   <xref:System.Windows.Automation.AutomationElement.TryGetClickablePoint%2A>  
  
-   <xref:System.Windows.Automation.AutomationElement.ClickablePointProperty>  
  
-   <xref:System.Windows.Automation.AutomationElement.FromPoint%2A>  
  
-   <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.BoundingRectangle%2A>  
  
 By default, a UI Automation client application running in a non-96- [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] environment will not be able to obtain correct results from these methods and properties. For example, because the cursor position is in logical coordinates, the client cannot simply pass these coordinates to <xref:System.Windows.Automation.AutomationElement.FromPoint%2A> to obtain the element that is under the cursor. In addition, the application will not be able to correctly place windows outside its client area.  
  
 The solution is in two parts.  
  
1.  First, make the client application [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware. To do this, call the [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] function `SetProcessDPIAware` at startup. In managed code, the following declaration makes this function available.  
  
     [!code-csharp[Highlighter#101](../../../samples/snippets/csharp/VS_Snippets_Wpf/Highlighter/CSharp/NativeMethods.cs#101)]
     [!code-vb[Highlighter#101](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Highlighter/VisualBasic/NativeMethods.vb#101)]  
  
     This function makes the entire process [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware, meaning that all windows that belong to the process are unscaled. In the [Highlighter Sample](http://msdn.microsoft.com/library/19ba4577-753e-4efd-92cc-c02ee67c1b69), for instance, the four windows that make up the highlight rectangle are located at the physical coordinates obtained from [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], not the logical coordinates. If the sample were not [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware, the highlight would be drawn at the logical coordinates on the desktop, which would result in incorrect placement in a non-96- [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)] environment.  
  
2.  To get cursor coordinates, call the [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] function `GetPhysicalCursorPos`. The following example shows how to declare and use this function.  
  
     [!code-csharp[UIAClient_snip#185](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#185)]
     [!code-vb[UIAClient_snip#185](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#185)]  
  
> [!CAUTION]
>  Do not use <xref:System.Windows.Forms.Cursor.Position%2A?displayProperty=nameWithType>. The behavior of this property outside client windows in a scaled environment is undefined.  
  
 If your application performs direct cross-process communication with non- [!INCLUDE[TLA2#tla_dpi](../../../includes/tla2sharptla-dpi-md.md)]-aware applications, you may have convert between logical and physical coordinates by using the [!INCLUDE[TLA#tla_win32](../../../includes/tlasharptla-win32-md.md)] functions `PhysicalToLogicalPoint` and `LogicalToPhysicalPoint`.  
  
## See Also  
 [Highlighter Sample](http://msdn.microsoft.com/library/19ba4577-753e-4efd-92cc-c02ee67c1b69)
