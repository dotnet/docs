---
title: "Using WPF Controls"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Forms Designer [Windows Forms], interoperability with WPF"
  - "interoperability [WPF]"
ms.assetid: 03c85dce-26ad-44cd-bc1d-8e0cb56de096
---
# Using WPF Controls
You can use Windows Presentation Foundation (WPF) controls in your Windows Forms-based applications. Although these are two different view technologies, they interoperate smoothly.  
  
 The Windows Forms Designer provides a visual design environment for hosting Windows Presentation Foundation controls. A WPF control is hosted by a special Windows Forms control that is named <xref:System.Windows.Forms.Integration.ElementHost>. This control enables the WPF control to participate in the form's layout and to receive keyboard and mouse messages. At design time, you can arrange the <xref:System.Windows.Forms.Integration.ElementHost> control just as you would any Windows Forms control.  
  
 You can also use Windows Forms controls in your WPF-based applications. For more information, see [Design XAML in Visual Studio](/visualstudio/designers/designing-xaml-in-visual-studio).  
  
## In This Section  
 [How to: Copy and Paste an ElementHost Control at Design Time](how-to-copy-and-paste-an-elementhost-control-at-design-time.md)  
 Shows how to copy a Windows Presentation Foundation control on a Windows Form.  
  
 [Walkthrough: Arranging WPF Content on Windows Forms at Design Time](walkthrough-arranging-wpf-content-on-windows-forms-at-design-time.md)  
 Shows how to use the Windows Forms layout features, such as anchoring and snaplines, to arrange Windows Presentation Foundation controls.
  
 [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md)  
 Shows how to create a Windows Presentation Foundation control for use in your Windows Forms-based applications.
  
 [Walkthrough: Assigning WPF Content on Windows Forms at Design Time](walkthrough-assigning-wpf-content-on-windows-forms-at-design-time.md)  
 Shows how to select the Windows Presentation Foundation control types you want to display on your form.  
  
 [Walkthrough: Styling WPF Content](walkthrough-styling-wpf-content.md)  
 Shows the workflow between the Windows Forms Designer and the [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)] for applying styles to Windows Presentation Foundation controls.  
  
## Reference  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 Describes a class which you can use to host Windows Presentation Foundation controls in your Windows Forms-based applications.  
  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 Describes a class which you can use to host Windows Forms controls in your Windows Presentation Foundation-based application.  
  
## Related Sections  
 [Migration and Interoperability](../../wpf/advanced/migration-and-interoperability.md)  
 Describes interoperation between the Windows Presentation Foundation and Windows Forms technologies.  
  
 [Design XAML in Visual Studio](/visualstudio/designers/designing-xaml-in-visual-studio)  
 Describes how to design Windows Presentation Foundation controls in Visual Studio.
