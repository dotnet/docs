---
title: "UI Automation and Screen Scaling"
description: Read how Windows and UI Automation handle screen scaling. DWM does default scaling for all applications, which UI Automation client apps must take into account.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "scaling, screens"
  - "screens, scaling"
  - "UI (user interface), automation"
  - "UI Automation"
---
# UI Automation and Screen Scaling

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

Starting with Windows Vista, Windows enables users to change the dots per inch (dpi) setting so that most user interface (UI) elements on the screen appear larger. Although this feature has long been available in Windows, in previous versions the scaling had to be implemented by applications. Starting with Windows Vista, the Desktop Window Manager performs default scaling for all applications that do not handle their own scaling. UI Automation client applications must take this feature into account.

<a name="Scaling_in_Windows_Vista"></a>

## Scaling in Windows Vista

 The default dpi setting is 96, which means that 96 pixels occupy a width or height of one notional inch. The exact measure of an "inch" depends on the size and physical resolution of the monitor. For example, on a monitor 12 inches wide, at a horizontal resolution of 1280 pixels, a horizontal line of 96 pixels extends about 9/10 of an inch.

 Changing the dpi setting is not the same as changing the screen resolution. With dpi scaling, the number of physical pixels on the screen remains the same. However, scaling is applied to the size and location of UI elements. This scaling can be performed automatically by the Desktop Window Manager (DWM) for the desktop and for applications that do not explicitly ask not to be scaled.

 In effect, when the user sets the scale factor to 120 dpi, a vertical or horizontal inch on the screen becomes bigger by 25 percent. All dimensions are scaled accordingly. The offset of an application window from the top and left edges of the screen increases by 25 percent. If application scaling is enabled and the application is not dpi-aware, the size of the window increases in the same proportion, along with the offsets and sizes of all UI elements it contains.

> [!NOTE]
> By default, the DWM does not perform scaling for non-dpi-aware applications when the user sets the dpi to 120, but does perform it when the dpi is set to a custom value of 144 or higher. However, the user can override the default behavior.

 Screen scaling creates new challenges for applications that are concerned in any way with screen coordinates. The screen now contains two coordinate systems: physical and logical. The physical coordinates of a point are the actual offset in pixels from the top left of the origin. The logical coordinates are the offsets as they would be if the pixels themselves were scaled.

 Suppose you design a dialog box with a button at coordinates (100, 48). When this dialog box is displayed at the default 96 dpi, the button is located at physical coordinates of (100, 48). At 120 dpi, it is located at physical coordinates of (125, 60). But the logical coordinates are the same at any dpi setting: (100, 48).

 Logical coordinates are important, because they make the behavior of the operating system and applications consistent regardless of the dpi setting. For example, <xref:System.Windows.Forms.Cursor.Position%2A?displayProperty=nameWithType> normally returns the logical coordinates. If you move the cursor over an element in a dialog box, the same coordinates are returned regardless of the dpi setting. If you draw a control at (100, 100), it is drawn to those logical coordinates, and will occupy the same relative position at any dpi setting.

<a name="Scaling_in_UI_Automation_Clients"></a>

## Scaling in UI Automation Clients

 The UI Automation API does not use logical coordinates. The following methods and properties either return physical coordinates or take them as parameters.

- <xref:System.Windows.Automation.AutomationElement.GetClickablePoint%2A>

- <xref:System.Windows.Automation.AutomationElement.TryGetClickablePoint%2A>

- <xref:System.Windows.Automation.AutomationElement.ClickablePointProperty>

- <xref:System.Windows.Automation.AutomationElement.FromPoint%2A>

- <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.BoundingRectangle%2A>

 By default, a UI Automation client application running in a non-96- dpi environment will not be able to obtain correct results from these methods and properties. For example, because the cursor position is in logical coordinates, the client cannot simply pass these coordinates to <xref:System.Windows.Automation.AutomationElement.FromPoint%2A> to obtain the element that is under the cursor. In addition, the application will not be able to correctly place windows outside its client area.

 The solution is in two parts.

1. First, make the client application dpi-aware. To do this, call the Win32 function `SetProcessDPIAware` at startup. In managed code, the following declaration makes this function available.

     [!code-csharp[Highlighter#101](../../../samples/snippets/csharp/VS_Snippets_Wpf/Highlighter/CSharp/NativeMethods.cs#101)]
     [!code-vb[Highlighter#101](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Highlighter/VisualBasic/NativeMethods.vb#101)]

     This function makes the entire process dpi-aware, meaning that all windows that belong to the process are unscaled. In the [Highlighter Sample](https://github.com/Microsoft/WPF-Samples/tree/main/Accessibility/Highlighter), for instance, the four windows that make up the highlight rectangle are located at the physical coordinates obtained from UI Automation, not the logical coordinates. If the sample were not dpi-aware, the highlight would be drawn at the logical coordinates on the desktop, which would result in incorrect placement in a non-96- dpi environment.

2. To get cursor coordinates, call the Win32 function `GetPhysicalCursorPos`. The following example shows how to declare and use this function.

     [!code-csharp[UIAClient_snip#185](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#185)]
     [!code-vb[UIAClient_snip#185](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#185)]

> [!CAUTION]
> Do not use <xref:System.Windows.Forms.Cursor.Position%2A?displayProperty=nameWithType>. The behavior of this property outside client windows in a scaled environment is undefined.

 If your application performs direct cross-process communication with non- dpi-aware applications, you may have convert between logical and physical coordinates by using the Win32 functions `PhysicalToLogicalPoint` and `LogicalToPhysicalPoint`.

## See also

- [Highlighter Sample](https://github.com/Microsoft/WPF-Samples/tree/main/Accessibility/Highlighter)
