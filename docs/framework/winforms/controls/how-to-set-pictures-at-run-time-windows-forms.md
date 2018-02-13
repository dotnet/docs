---
title: "How to: Set Pictures at Run Time (Windows Forms)"
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
  - "pictures [Windows Forms], setting display"
  - "examples [Windows Forms], PictureBox control"
  - "bitmaps [Windows Forms], displaying in PictureBox control [Windows Forms]"
  - "PictureBox control [Windows Forms], adding images"
  - "images [Windows Forms], adding with PictureBox control [Windows Forms]"
  - "PictureBox control [Windows Forms], adding pictures"
ms.assetid: 18ca41d0-68a5-4660-985e-a6c1fbc01d76
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set Pictures at Run Time (Windows Forms)
You can programmatically set the image displayed by a Windows Forms <xref:System.Windows.Forms.PictureBox> control.  
  
### To set a picture programmatically  
  
-   Set the <xref:System.Windows.Forms.PictureBox.Image%2A> property using the <xref:System.Drawing.Image.FromFile%2A> method of the <xref:System.Drawing.Image> class.  
  
     In the example below, the path set for the location of the image is the My Documents folder. This is done, because you can assume that most computers running the Windows operating system will include this directory. This also allows users with minimal system access levels to safely run the application. The example below assumes a form with a <xref:System.Windows.Forms.PictureBox> control already added.  
  
    ```vb  
    Private Sub LoadNewPict()  
       ' You should replace the bold image   
       ' in the sample below with an icon of your own choosing.  
       PictureBox1.Image = Image.FromFile _  
       (System.Environment.GetFolderPath _  
       (System.Environment.SpecialFolder.Personal) _  
       & "\Image.gif")  
    End Sub  
    ```  
  
    ```csharp  
    private void LoadNewPict(){  
       // You should replace the bold image   
       // in the sample below with an icon of your own choosing.  
       // Note the escape character used (@) when specifying the path.  
       pictureBox1.Image = Image.FromFile  
       (System.Environment.GetFolderPath  
       (System.Environment.SpecialFolder.Personal)  
       + @"\Image.gif");  
    }  
    ```  
  
    ```cpp  
    private:  
       void LoadNewPict()  
       {  
          // You should replace the bold image   
          // in the sample below with an icon of your own choosing.  
          pictureBox1->Image = Image::FromFile(String::Concat(  
             System::Environment::GetFolderPath(  
             System::Environment::SpecialFolder::Personal),  
             "\\Image.gif"));  
       }  
    ```  
  
### To clear a graphic  
  
-   First, release the memory being used by the image, and then clear the graphic. Garbage collection will free up the memory later if memory management becomes a problem.  
  
    ```vb  
    If Not (PictureBox1.Image Is Nothing) Then  
       PictureBox1.Image.Dispose()  
       PictureBox1.Image = Nothing  
    End If  
    ```  
  
    ```csharp  
    if (pictureBox1.Image != null)   
    {  
       pictureBox1.Image.Dispose();  
       pictureBox1.Image = null;  
    }  
    ```  
  
    ```cpp  
    if (pictureBox1->Image != nullptr)  
    {  
       pictureBox1->Image->Dispose();  
       pictureBox1->Image = nullptr;  
    }  
    ```  
  
    > [!NOTE]
    >  For more information on why you should use the <xref:System.Drawing.Image.Dispose%2A> method in this way, see [Cleaning Up Unmanaged Resources](../../../../docs/standard/garbage-collection/unmanaged.md).  
  
     This code will clear the image even if a graphic was loaded into the control at design time.  
  
## See Also  
 <xref:System.Windows.Forms.PictureBox>  
 <xref:System.Drawing.Image.FromFile%2A?displayProperty=nameWithType>  
 [PictureBox Control Overview](../../../../docs/framework/winforms/controls/picturebox-control-overview-windows-forms.md)  
 [How to: Load a Picture Using the Designer](../../../../docs/framework/winforms/controls/how-to-load-a-picture-using-the-designer-windows-forms.md)  
 [How to: Modify the Size or Placement of a Picture at Run Time](../../../../docs/framework/winforms/controls/how-to-modify-the-size-or-placement-of-a-picture-at-run-time-windows-forms.md)  
 [PictureBox Control](../../../../docs/framework/winforms/controls/picturebox-control-windows-forms.md)
