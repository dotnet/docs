---
title: "How to: Load a Picture Using the Designer (Windows Forms)"
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
  - "picture formats"
  - "images [Windows Forms], displaying on Windows Forms"
  - "pictures [Windows Forms], displaying"
  - "forms [Windows Forms], displaying images"
  - "PictureBox control [Windows Forms], adding pictures"
ms.assetid: 4dc7b973-afb1-4276-8322-20825af96655
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Load a Picture Using the Designer (Windows Forms)
With the Windows Forms <xref:System.Windows.Forms.PictureBox> control, you can load and display a picture on a form at design time by setting the <xref:System.Windows.Forms.PictureBox.Image%2A> property to a valid picture. The following table shows the acceptable file types.  
  
|Type|File name extension|  
|----------|-------------------------|  
|Bitmap|.bmp|  
|Icon|.ico|  
|GIF|.gif|  
|Metafile|.wmf|  
|JPEG|.jpg|  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To display a picture at design time  
  
1.  Draw a <xref:System.Windows.Forms.PictureBox> control on a form.  
  
2.  On the Properties window, select the <xref:System.Windows.Forms.PictureBox.Image%2A> property, then click the ellipsis button to display the **Open** dialog box.  
  
3.  If you are looking for a specific file type (for example, .gif files), select it in the **Files of type** box.  
  
4.  Select the file you want to display.  
  
### To clear the picture at design time  
  
1.  On the **Properties** window, select the <xref:System.Windows.Forms.PictureBox.Image%2A> property and right-click the small thumbnail image that appears to the left of the name of the image object. Choose **Reset**.  
  
## See Also  
 <xref:System.Windows.Forms.PictureBox>  
 [PictureBox Control Overview](../../../../docs/framework/winforms/controls/picturebox-control-overview-windows-forms.md)  
 [How to: Modify the Size or Placement of a Picture at Run Time](../../../../docs/framework/winforms/controls/how-to-modify-the-size-or-placement-of-a-picture-at-run-time-windows-forms.md)  
 [How to: Set Pictures at Run Time](../../../../docs/framework/winforms/controls/how-to-set-pictures-at-run-time-windows-forms.md)  
 [PictureBox Control](../../../../docs/framework/winforms/controls/picturebox-control-windows-forms.md)
