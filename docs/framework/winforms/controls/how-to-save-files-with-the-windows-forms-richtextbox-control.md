---
title: "How to: Save Files with the Windows Forms RichTextBox Control"
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
  - "saving files"
  - "RTF files [Windows Forms], saving in RichTextBox control"
  - "examples [Windows Forms], text boxes"
  - "saving files [Windows Forms], RichTextBox control"
  - "files [Windows Forms], saving with RichTextBox control"
  - "RichTextBox control [Windows Forms], saving files"
  - ".rtf files [Windows Forms], saving in RichTextBox control"
  - "text files [Windows Forms], saving from RichTextBox control"
ms.assetid: 4a58ec19-84d1-4383-9110-298c06adcfca
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Save Files with the Windows Forms RichTextBox Control
The Windows Forms <xref:System.Windows.Forms.RichTextBox> control can write the information it displays in one of several formats:  
  
-   Plain text  
  
-   Unicode plain text  
  
-   Rich-Text Format (RTF)  
  
-   RTF with spaces in place of OLE objects  
  
-   Plain text with a textual representation of OLE objects  
  
 To save a file, call the <xref:System.Windows.Forms.RichTextBox.SaveFile%2A> method. You can also use the **SaveFile** method to save data to a stream. For more information, see <xref:System.Windows.Forms.RichTextBox.SaveFile%28System.IO.Stream%2CSystem.Windows.Forms.RichTextBoxStreamType%29>.  
  
### To save the contents of the control to a file  
  
1.  Determine the path of the file to be saved.  
  
     To do this in a real-world application, you would typically use the <xref:System.Windows.Forms.SaveFileDialog> component. For an overview, see [SaveFileDialog Component Overview](../../../../docs/framework/winforms/controls/savefiledialog-component-overview-windows-forms.md).  
  
2.  Call the <xref:System.Windows.Forms.RichTextBox.SaveFile%2A> method of the <xref:System.Windows.Forms.RichTextBox> control, specifying the file to save and optionally a file type. If you call the method with a file name as its only argument, the file will be saved as RTF. To specify another file type, call the method with a value of the <xref:System.Windows.Forms.RichTextBoxStreamType> enumeration as its second argument.  
  
     In the example below, the path set for the location of the rich-text file is the **My Documents** folder. This location is used because you can assume that most computers running the Windows operating system will include this folder. Choosing this location also allows users with minimal system access levels to safely run the application. The example below assumes a form with a <xref:System.Windows.Forms.RichTextBox> control already added.  
  
    ```vb  
    Public Sub SaveFile()  
       ' You should replace the bold file name in the   
       ' sample below with a file name of your own choosing.  
       RichTextBox1.SaveFile(System.Environment.GetFolderPath _  
       (System.Environment.SpecialFolder.Personal) _  
       & "\Testdoc.rtf", _  
          RichTextBoxStreamType.RichNoOleObjs)  
    End Sub  
    ```  
  
    ```csharp  
    public void SaveFile()  
    {  
       // You should replace the bold file name in the   
       // sample below with a file name of your own choosing.  
       // Note the escape character used (@) when specifying the path.  
       richTextBox1.SaveFile(System.Environment.GetFolderPath  
       (System.Environment.SpecialFolder.Personal)  
       + @"\Testdoc.rtf",  
          RichTextBoxStreamType.RichNoOleObjs);  
    }  
    ```  
  
    ```cpp  
    public:  
       void SaveFile()  
       {  
          // You should replace the bold file name in the   
          // sample below with a file name of your own choosing.  
          richTextBox1->SaveFile(String::Concat  
             (System::Environment::GetFolderPath  
             (System::Environment::SpecialFolder::Personal),  
             "\\Testdoc.rtf"), RichTextBoxStreamType::RichNoOleObjs);  
       }  
    ```  
  
    > [!IMPORTANT]
    >  This example creates a new file, if the file does not already exist. If an application needs to create a file, that application needs Create access for the folder. Permissions are set using access control lists. If the file already exists, the application needs only Write access, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant Read access to a single file, rather than Create access for a folder. Also, it is more secure to write data to user folders than to the root folder or the Program Files folder.  
  
## See Also  
 <xref:System.Windows.Forms.RichTextBox.SaveFile%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.RichTextBox>  
 [RichTextBox Control](../../../../docs/framework/winforms/controls/richtextbox-control-windows-forms.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
