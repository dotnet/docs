---
title: "How to: Open Files Using the OpenFileDialog Component"
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
  - "OpenFileDialog component [Windows Forms], opening files"
  - "OpenFile method [Windows Forms], OpenFileDialog component"
  - "files [Windows Forms], opening with OpenFileDialog component"
ms.assetid: 9d88367a-cc21-4ffd-be74-89fd63767d35
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Open Files Using the OpenFileDialog Component
The <xref:System.Windows.Forms.OpenFileDialog> component allows users to browse the folders of their computer or any computer on the network and select one or more files to open. The dialog box returns the path and name of the file the user selected in the dialog box.  
  
 Once the user has selected the file to be opened, there are two approaches to the mechanism of opening the file. If you prefer to work with file streams, you can create an instance of the <xref:System.IO.StreamReader> class. Alternately, you can use the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method to open the selected file.  
  
 The first example below involves a <xref:System.Security.Permissions.FileIOPermission> permission check (as described in the "Security Note" below), but gives you access to the filename. You can use this technique from the Local Machine, Intranet, and Internet zones. The second method also does a <xref:System.Security.Permissions.FileIOPermission> permission check, but is better suited for applications in the Intranet or Internet zones.  
  
### To open a file as a stream using the OpenFileDialog component  
  
1.  Display the **Open File** dialog box and call a method to open the file selected by the user.  
  
     One approach is to use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the Open File dialog box, and use an instance of the <xref:System.IO.StreamReader> class to open the file.  
  
     The example below uses the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open an instance of the <xref:System.Windows.Forms.OpenFileDialog> component. When a file is chosen and the user clicks **OK**, the file selected in the dialog box opens. In this case, the contents are displayed in a message box, just to show that the file stream has been read.  
  
    > [!IMPORTANT]
    >  To get or set the <xref:System.Windows.Forms.FileDialog.FileName%2A> property, your assembly requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. If you are running in a partial-trust context, the process might throw an exception due to insufficient privileges. For more information, see [Code Access Security Basics](../../../../docs/framework/misc/code-access-security-basics.md).  
  
     The example assumes your form has a <xref:System.Windows.Forms.Button> control and an <xref:System.Windows.Forms.OpenFileDialog> component.  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, _  
       ByVal e As System.EventArgs) Handles Button1.Click  
       If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then  
         Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)  
         MessageBox.Show(sr.ReadToEnd)  
         sr.Close()  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void button1_Click(object sender, System.EventArgs e)  
    {  
       if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)  
       {  
          System.IO.StreamReader sr = new   
             System.IO.StreamReader(openFileDialog1.FileName);  
          MessageBox.Show(sr.ReadToEnd());  
          sr.Close();  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void button1_Click(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          if(openFileDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK)  
          {  
             System::IO::StreamReader ^ sr = gcnew  
                System::IO::StreamReader(openFileDialog1->FileName);  
             MessageBox::Show(sr->ReadToEnd());  
             sr->Close();  
          }  
       }  
    ```  
  
     ([!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] and [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.button1.Click += new System.EventHandler(this.button1_Click);  
    ```  
  
    ```cpp  
    this->button1->Click += gcnew  
       System::EventHandler(this, &Form1::button1_Click);  
    ```  
  
    > [!NOTE]
    >  For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A> and <xref:System.IO.FileStream.Read%2A>.  
  
### To open a file as a file using the OpenFileDialog component  
  
1.  Use the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog box and the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method to open the file.  
  
     The <xref:System.Windows.Forms.OpenFileDialog> component's <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method returns the bytes that compose the file. These bytes give you a stream to read from. In the example below, an <xref:System.Windows.Forms.OpenFileDialog> component is instantiated with a "cursor" filter on it, allowing the user to choose only files with the file name extension`.cur`. If a`.cur` file is chosen, the form's cursor is set to the selected cursor.  
  
    > [!IMPORTANT]
    >  To call the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method, your assembly requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. If you are running in a partial-trust context, the process might throw an exception due to insufficient privileges. For more information, see [Code Access Security Basics](../../../../docs/framework/misc/code-access-security-basics.md).  
  
     The example assumes your form has a <xref:System.Windows.Forms.Button> control.  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, _  
       ByVal e As System.EventArgs) Handles Button1.Click  
       ' Displays an OpenFileDialog so the user can select a Cursor.  
       Dim openFileDialog1 As New OpenFileDialog()  
       openFileDialog1.Filter = "Cursor Files|*.cur"  
       openFileDialog1.Title = "Select a Cursor File"  
  
       ' Show the Dialog.  
       ' If the user clicked OK in the dialog and   
       ' a .CUR file was selected, open it.  
       If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then  
         ' Assign the cursor in the Stream to the Form's Cursor property.  
         Me.Cursor = New Cursor(openFileDialog1.OpenFile())  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void button1_Click(object sender, System.EventArgs e)  
    {  
       // Displays an OpenFileDialog so the user can select a Cursor.  
       OpenFileDialog openFileDialog1 = new OpenFileDialog();  
       openFileDialog1.Filter = "Cursor Files|*.cur";  
       openFileDialog1.Title = "Select a Cursor File";  
  
       // Show the Dialog.  
       // If the user clicked OK in the dialog and  
       // a .CUR file was selected, open it.  
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)  
       {  
          // Assign the cursor in the Stream to the Form's Cursor property.  
          this.Cursor = new Cursor(openFileDialog1.OpenFile());  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void button1_Click(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          // Displays an OpenFileDialog so the user can select a Cursor.  
          OpenFileDialog ^ openFileDialog1 = new OpenFileDialog();  
          openFileDialog1->Filter = "Cursor Files|*.cur";  
          openFileDialog1->Title = "Select a Cursor File";  
  
          // Show the Dialog.  
          // If the user clicked OK in the dialog and  
          // a .CUR file was selected, open it.  
          if (openFileDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK)  
          {  
             // Assign the cursor in the Stream to  
             // the Form's Cursor property.  
             this->Cursor = gcnew  
                System::Windows::Forms::Cursor(  
                openFileDialog1->OpenFile());  
          }  
       }  
    ```  
  
     ([!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] and [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.button1.Click += new System.EventHandler(this.button1_Click);  
    ```  
  
    ```cpp  
    this->button1->Click += gcnew  
       System::EventHandler(this, &Form1::button1_Click);  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.OpenFileDialog>  
 [OpenFileDialog Component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
