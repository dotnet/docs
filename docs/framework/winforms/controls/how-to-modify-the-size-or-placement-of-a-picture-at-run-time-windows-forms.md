---
title: "How to: Modify the Size or Placement of a Picture at Run Time (Windows Forms)"
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
  - "cpp"
helpviewer_keywords: 
  - "images [Windows Forms], controlling placement in PictureBox control [Windows Forms]"
  - "examples [Windows Forms], PictureBox control"
  - "PictureBox control [Windows Forms], picture size and alignment"
  - "pictures [Windows Forms], controlling placement in PictureBox control [Windows Forms]"
ms.assetid: d0b332a3-fae2-4891-957c-dc3e17743326
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Modify the Size or Placement of a Picture at Run Time (Windows Forms)
If you use the Windows Forms <xref:System.Windows.Forms.PictureBox> control on a form, you can set the <xref:System.Windows.Forms.PictureBox.SizeMode%2A> property on it to:  
  
-   Align the picture's upper left corner with the control's upper left corner  
  
-   Center the picture within the control  
  
-   Adjust the size of the control to fit the picture it displays  
  
-   Stretch any picture it displays to fit the control  
  
 Stretching a picture (especially one in bitmap format) can produce a loss in image quality. Metafiles, which are lists of graphics instructions for drawing images at run time, are better suited for stretching than bitmaps are.  
  
### To set the SizeMode property at run time  
  
1.  Set <xref:System.Windows.Forms.PictureBox.SizeMode%2A> to <xref:System.Windows.Forms.PictureBoxSizeMode.Normal> (the default), <xref:System.Windows.Forms.PictureBoxSizeMode.AutoSize>, <xref:System.Windows.Forms.PictureBoxSizeMode.CenterImage>, or <xref:System.Windows.Forms.PictureBoxSizeMode.StretchImage>. <xref:System.Windows.Forms.PictureBoxSizeMode.Normal> means that the image is placed in the control's upper-left corner; if the image is larger than the control, its lower and right edges are clipped. <xref:System.Windows.Forms.PictureBoxSizeMode.CenterImage> means that the image is centered within the control; if the image is larger than the control, the picture's outside edges are clipped. <xref:System.Windows.Forms.PictureBoxSizeMode.AutoSize> means that the size of the control is adjusted to the size of the image. <xref:System.Windows.Forms.PictureBoxSizeMode.StretchImage> is the reverse, and means that the size of the image is adjusted to the size of the control.  
  
     In the example below, the path set for the location of the image is the My Documents folder. This is done, because you can assume that most computers running the Windows operating system will include this directory. This also allows users with minimal system access levels to safely run the application. The example below assumes a form with a <xref:System.Windows.Forms.PictureBox> control already added.  
  
    ```vb  
    Private Sub StretchPic()  
       ' Stretch the picture to fit the control.  
       PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage  
       ' Load the picture into the control.  
       ' You should replace the bold image   
       ' in the sample below with an icon of your own choosing.  
       PictureBox1.Image = Image.FromFile _  
       (System.Environment.GetFolderPath _  
       (System.Environment.SpecialFolder.Personal) _  
       & "\Image.gif")  
    End Sub  
    ```  
  
    ```csharp  
    private void StretchPic(){  
       // Stretch the picture to fit the control.  
       PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;  
       // Load the picture into the control.  
       // You should replace the bold image   
       // in the sample below with an icon of your own choosing.  
       // Note the escape character used (@) when specifying the path.  
       PictureBox1.Image = Image.FromFile _  
       (System.Environment.GetFolderPath _  
       (System.Environment.SpecialFolder.Personal) _  
       + @"\Image.gif")  
    }  
    ```  
  
    ```cpp  
    private:  
       void StretchPic()  
       {  
          // Stretch the picture to fit the control.  
          pictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;  
          // Load the picture into the control.  
          // You should replace the bold image   
          // in the sample below with an icon of your own choosing.  
          pictureBox1->Image = Image::FromFile(String::Concat(  
             System::Environment::GetFolderPath(  
             System::Environment::SpecialFolder::Personal),  
             "\\Image.gif"));  
       }  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.PictureBox>  
 [How to: Load a Picture Using the Designer](../../../../docs/framework/winforms/controls/how-to-load-a-picture-using-the-designer-windows-forms.md)  
 [PictureBox Control Overview](../../../../docs/framework/winforms/controls/picturebox-control-overview-windows-forms.md)  
 [How to: Set Pictures at Run Time](../../../../docs/framework/winforms/controls/how-to-set-pictures-at-run-time-windows-forms.md)  
 [PictureBox Control](../../../../docs/framework/winforms/controls/picturebox-control-windows-forms.md)
