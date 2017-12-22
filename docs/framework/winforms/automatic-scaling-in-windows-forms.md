---
title: "Automatic Scaling in Windows Forms"
ms.date: "06/15/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-winforms"
ms.topic: "article"
helpviewer_keywords: 
  - "scalability [Windows Forms], automatic in Windows Forms"
  - "Windows Forms, automatic scaling"
ms.assetid: 68fad25b-afbc-44bd-8e1b-966fc43507a4
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Automatic scaling in Windows Forms
Automatic scaling enables a form and its controls, designed on one machine with a certain display resolution or system font, to be displayed appropriately on another machine with a different display resolution or system font. It assures that the form and its controls will intelligently resize to be consistent with native windows and other applications on both the users' and other developers' machines. The support of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] for automatic scaling and visual styles enables [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications to maintain a consistent look and feel when compared to native Windows applications on each user's machine.
  
For the most part, automatic scaling works as expected in [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 2.0 and later. However, font scheme changes can be problematic. To see an example of how to resolve this, see [How to: Respond to Font Scheme Changes in a Windows Forms Application](how-to-respond-to-font-scheme-changes-in-a-windows-forms-application.md).
  
## Need for automatic scaling  
Without automatic scaling, an application designed for one display resolution or font will either appear too small or too large when that resolution or font is changed. For example, if the application is designed using Tahoma 9 point as a baseline, without adjustment it will appear too small if run on a machine where the system font is Tahoma 12 point. Text elements, such as titles, menus, text box contents, and so on will render smaller than other applications. Furthermore, the size of user interface (UI) elements that contain text, such as the title bar, menus, and many controls are dependent on the font used. In this example, these elements will also appear relatively smaller.

An analogous situation occurs when an application is designed for a certain display resolution. The most common display resolution is 96 dots per inch (DPI), which equals 100% display scaling, but higher resolution displays supporting 125%, 150%, 200% (which respectively equal 120, 144 and 192 DPI) and above are becoming more common. Without adjustment, an application, especially a graphics-based one, designed for one resolution will appear either too large or too small when run at another resolution.

Automatic scaling seeks to ameliorate these problems by automatically resizing the form and its child controls according to the relative font size or display resolution. The Windows operating system supports automatic scaling of dialog boxes using a relative unit of measurement called dialog units. A dialog unit is based on the system font and its relationship to pixels can be determined though the Win32 SDK function `GetDialogBaseUnits`. When a user changes the theme used by Windows, all dialog boxes are automatically adjusted accordingly. In addition, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] supports automatic scaling either according to the default system font or the display resolution. Optionally, automatic scaling can be disabled in an application.

## Original support for automatic scaling
Versions 1.0 and 1.1 of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] supported automatic scaling in a straightforward manner that was dependent on the Windows default font used for the UI, represented by the Win32 SDK value **DEFAULT_GUI_FONT**. This font is typically only changed when the display resolution changes. The following mechanism was used to implement automatic scaling:

1. At design time, the <xref:System.Windows.Forms.Form.AutoScaleBaseSize%2A> property (which is now deprecated) was set to the height and width of the default system font on the developer's machine.

2. At runtime, the default system font of the user's machine was used to initialize the <xref:System.Windows.Forms.Control.Font%2A> property of the <xref:System.Windows.Forms.Form> class.

3. Before displaying the form, the <xref:System.Windows.Forms.Form.ApplyAutoScaling%2A> method was called to scale the form. This method calculated the relative scale sizes from <xref:System.Windows.Forms.Form.AutoScaleBaseSize%2A> and <xref:System.Windows.Forms.Control.Font%2A> then called the <xref:System.Windows.Forms.Control.Scale%2A> method to actually scale the form and its children.

4. The value of <xref:System.Windows.Forms.Form.AutoScaleBaseSize%2A> was updated so that subsequent calls to <xref:System.Windows.Forms.Form.ApplyAutoScaling%2A> did not progressively resize the form.

While this mechanism was sufficient for most purposes, it suffered from the following limitations:

- Since the <xref:System.Windows.Forms.Form.AutoScaleBaseSize%2A> property represents the baseline font size as integer values, rounding errors occur that become evident when a form is cycled through multiple resolutions.

- Automatic scaling was implemented in only the <xref:System.Windows.Forms.Form> class, not in the <xref:System.Windows.Forms.ContainerControl> class. As a result, user controls would scale correctly only when the user control was designed at the same resolution as the form, and it was placed in the form at design time.

- Forms and their child controls could only be concurrently designed by multiple developers if their machine resolutions were the same. Likewise it also made inheritance of a form dependent on the resolution associated with the parent form.

> [!NOTE]
> With the extreme differences in display DPIs, especially in modern 2-in-1 devices, this can still happen with the most current versions of the .NET Framework and Visual Studio. To address this in a team using different DPI displays, make sure Visual Studio always starts in a non-DPI-aware mode, so the Windows Forms designer always bases the layout calculation on 96 DPI. To this end, simply set the following registry key to disable Visual Studio's HighDPI awareness:
>
> ```
> [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\devenv.exe]
> "dpiAwareness"=dword:00000000
> ```

- It is not compatible with the newer layout managers introduced with the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 2.0, such as <xref:System.Windows.Forms.FlowLayoutPanel> and <xref:System.Windows.Forms.TableLayoutPanel>.

- It did not support scaling based directly on the display resolution that is required for compatibility to the [!INCLUDE[compact](../../../includes/compact-md.md)].

Although this mechanism is preserved in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 2.0 to maintain backward compatibility, it has been superseded by the more robust scaling mechanism described next. As a consequence, the <xref:System.Windows.Forms.Form.AutoScale%2A>, <xref:System.Windows.Forms.Form.ApplyAutoScaling%2A>, <xref:System.Windows.Forms.Form.AutoScaleBaseSize%2A>, and certain <xref:System.Windows.Forms.Control.Scale%2A> overloads are marked as obsolete.

> [!NOTE]
> You can safely delete references to these members when you upgrade your legacy code to the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 2.0.

## Current support for automatic scaling
The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] version 2.0 surmounts previous limitations by introducing the following changes to the automatic scaling of Windows Forms:

- Base support for scaling has been moved to the <xref:System.Windows.Forms.ContainerControl> class so that forms, native composite controls and user controls all receive uniform scaling support. The new members <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A>, <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>, <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> have been added.

- The <xref:System.Windows.Forms.Control> class also has several new members that allow it to participate in scaling and to support mixed scaling on the same form. Specifically the <xref:System.Windows.Forms.Control.Scale%2A>, <xref:System.Windows.Forms.Control.ScaleChildren%2A>, and <xref:System.Windows.Forms.Control.GetScaledBounds%2A> members support scaling.

- Support for scaling based upon the screen resolution has been added to complement system font support, as defined by the <xref:System.Windows.Forms.AutoScaleMode> enumeration. This mode is compatible with automatic scaling supported by the [!INCLUDE[compact](../../../includes/compact-md.md)] enabling easier application migration.

- Compatibility with layout managers such as <xref:System.Windows.Forms.FlowLayoutPanel> and <xref:System.Windows.Forms.TableLayoutPanel> has been added to the implementation of automatic scaling.

- Scaling factors are now represented as floating point values, typically using the <xref:System.Drawing.SizeF> structure, so that rounding errors have been practically eliminated.

> [!CAUTION]
> Arbitrary mixtures of DPI and font scaling modes are not supported. Although you may scale a user control using one mode (for example, DPI) and place it on a form using another mode (Font) with no issues, but mixing a base form in one mode and a derived form in another can lead to unexpected results.

### Automatic scaling in action
Windows Forms now uses the following logic to automatically scale forms and their contents:

1. At design time, each <xref:System.Windows.Forms.ContainerControl> records the scaling mode and it current resolution in the <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>, respectively.

2. At run time, the actual resolution is stored in the <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> property. The <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A> property dynamically calculates the ratio between the run-time and design-time scaling resolution.

3. When the form loads, if the values of <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> are different, then the <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> method is called to scale the control and its children. This method suspends layout and calls the <xref:System.Windows.Forms.Control.Scale%2A> method to perform the actual scaling. Afterwards, the value of <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> is updated to avoid progressive scaling.

4. <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> is also automatically invoked in the following situations:

    - In response to the <xref:System.Windows.Forms.Control.OnFontChanged%2A> event if the scaling mode is <xref:System.Windows.Forms.AutoScaleMode.Font>.
  
    - When the layout of the container control resumes and a change is detected in the <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> or <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> properties.
  
    - As implied above, when a parent <xref:System.Windows.Forms.ContainerControl> is being scaled. Each container control is responsible for scaling its children using its own scaling factors and not the one from its parent container.

5. Child controls can modify their scaling behavior through several means:

    - The <xref:System.Windows.Forms.Control.ScaleChildren%2A> property can be overridden to determine if their child controls should be scaled or not.

    - The <xref:System.Windows.Forms.Control.GetScaledBounds%2A> method can be overridden to adjust the bounds that the control is scaled to, but not the scaling logic.

    - The <xref:System.Windows.Forms.Control.ScaleControl%2A> method can be overridden to change the scaling logic for the current control.

## See also
 <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A>  
 <xref:System.Windows.Forms.Control.Scale%2A>  
 <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A>  
 <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>  
 [Rendering Controls with Visual Styles](./controls/rendering-controls-with-visual-styles.md)  
 [How to: Improve Performance by Avoiding Automatic Scaling](./advanced/how-to-improve-performance-by-avoiding-automatic-scaling.md)
