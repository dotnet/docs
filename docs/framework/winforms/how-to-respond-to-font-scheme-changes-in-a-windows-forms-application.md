---
title: "How to: Respond to Font Scheme Changes in a Windows Forms Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Windows Forms, font scheme changes"
ms.assetid: 4db27702-22e7-43bf-a07d-9a004549853c
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Respond to Font Scheme Changes in a Windows Forms Application
In the Windows operating systems, a user can change the system-wide font settings to make the default font appear larger or smaller. Changing these font settings is critical for users who are visually impaired and require larger type to read the text on their screens. You can adjust your Windows Forms application to react to these changes by increasing or decreasing the size of the form and all contained text whenever the font scheme changes. If you want your form to accommodate changes in font sizes dynamically, you can add code to your form.  
  
 Typically, the default font used by Windows Forms is the font returned by the <xref:Microsoft.Win32> namespace call to `GetStockObject(DEFAULT_GUI_FONT)`. The font returned by this call only changes when the screen resolution changes. As shown in the following procedure, your code must change the default font to <xref:System.Drawing.SystemFonts.IconTitleFont%2A> to respond to changes in font size.  
  
### To use the desktop font and respond to font scheme changes  
  
1.  Create your form, and add the controls you want to it. For more information, see [How to: Create a Windows Forms Application from the Command Line](../../../docs/framework/winforms/how-to-create-a-windows-forms-application-from-the-command-line.md) and [Controls to Use on Windows Forms](../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md).  
  
2.  Add a reference to the <xref:Microsoft.Win32> namespace to your code.  
  
     [!code-csharp[WinFormsAutoScaling#2](../../../samples/snippets/csharp/VS_Snippets_Winforms/WinFormsAutoScaling/CS/Form1.cs#2)]
     [!code-vb[WinFormsAutoScaling#2](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/WinFormsAutoScaling/VB/Form1.vb#2)]  
  
3.  Add the following code to the constructor of your form to hook up required event handlers, and to change the default font in use for the form.  
  
     [!code-csharp[WinFormsAutoScaling#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/WinFormsAutoScaling/CS/Form1.cs#3)]
     [!code-vb[WinFormsAutoScaling#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/WinFormsAutoScaling/VB/Form1.vb#3)]  
  
4.  Implement a handler for the <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanged> event that causes the form to scale automatically when the <xref:Microsoft.Win32.UserPreferenceCategory.Window> category changes.  
  
     [!code-csharp[WinFormsAutoScaling#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/WinFormsAutoScaling/CS/Form1.cs#4)]
     [!code-vb[WinFormsAutoScaling#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/WinFormsAutoScaling/VB/Form1.vb#4)]  
  
5.  Finally, implement a handler for the <xref:System.Windows.Forms.Form.FormClosing> event that detaches the <xref:Microsoft.Win32.SystemEvents.UserPreferenceChanged> event handler.  
  
> [!IMPORTANT]
>  Failure to include this code will cause your application to leak memory.  
  
 [!code-csharp[WinFormsAutoScaling#5](../../../samples/snippets/csharp/VS_Snippets_Winforms/WinFormsAutoScaling/CS/Form1.cs#5)]
 [!code-vb[WinFormsAutoScaling#5](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/WinFormsAutoScaling/VB/Form1.vb#5)]  
  
1.  Compile and run the code.  
  
### To manually change the font scheme in Windows XP  
  
1.  While your Windows Forms application is running, right-click the Windows desktop and choose **Properties** from the shortcut menu.  
  
2.  In the **Display Properties** dialog box, click the **Appearance** tab.  
  
3.  From the **Font Size** drop-down list box, select a new font size.  
  
     You will notice that the form now reacts to run time changes in the desktop font scheme. When the user changes between **Normal**, **Large Fonts**, and **Extra Large Fonts**, the form changes font and scales correctly.  
  
## Example  
 [!code-csharp[WinFormsAutoScaling#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/WinFormsAutoScaling/CS/Form1.cs#1)]
 [!code-vb[WinFormsAutoScaling#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/WinFormsAutoScaling/VB/Form1.vb#1)]  
  
 The constructer in this code example contains a call to `InitializeComponent`, which is defined when you create a new Windows Forms project in Visual Studio. Remove this line of code if you are building your application on the command line.  
  
## See Also  
 <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A>  
 [Automatic Scaling in Windows Forms](../../../docs/framework/winforms/automatic-scaling-in-windows-forms.md)
