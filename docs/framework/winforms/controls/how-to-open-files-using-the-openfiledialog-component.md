---
title: "How to: Open files by using the OpenFileDialog component"
ms.date: "02/11/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "OpenFileDialog component [Windows Forms], opening files"
  - "OpenFile method [Windows Forms], OpenFileDialog component"
  - "files [Windows Forms], opening with OpenFileDialog component"
ms.assetid: 9d88367a-cc21-4ffd-be74-89fd63767d35
---
# How to: Open files by using OpenFileDialog 

The <xref:System.Windows.Forms.OpenFileDialog> component displays a dialog box for browsing and selecting files to open. You can use the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method to open the selected file, or create an instance of the <xref:System.IO.StreamReader> class to read it.  

To get or set the <xref:System.Windows.Forms.FileDialog.FileName%2A> property, your assembly requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. The following examples run a <xref:System.Security.Permissions.FileIOPermission> permission check. If you run them in a partial-trust context, they might throw an exception due to insufficient privileges. For more information, see [Code access security basics](../../../../docs/framework/misc/code-access-security-basics.md).

The first example gives you access to the filename. You can use this technique from the local, intranet, and internet zones. The second example is better for apps in the intranet or internet zones.  
  
## Show file contents as a stream with OpenFileDialog and StreamReader  
  
The following example uses the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the **Open File** dialog box, and an instance of the <xref:System.IO.StreamReader> class to open the file and display the contents as a stream. 

The <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler opens the <xref:System.Windows.Forms.OpenFileDialog>. When the user chooses a file and selects **OK**, <xref:System.IO.StreamReader> opens the file and displays its contents in a message box.  

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

     (Visual C# and [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.button1.Click += new System.EventHandler(this.button1_Click);  
    ```  
For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A> and <xref:System.IO.FileStream.Read%2A>.  
  
## Open a file from a filtered list with OpenFileDialog  

The following example uses the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method to display the dialog box and the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method to open the file. The <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method returns the bytes that compose the file and give you a stream to read from. In the example, the <xref:System.Windows.Forms.OpenFileDialog> component is instantiated with a "cursor" filter on it, showing only files with the file name extension *.cur*. If a`.cur` file is chosen, the form's cursor is set to the selected cursor.  

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
  
     (Visual C# and [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.button1.Click += new System.EventHandler(this.button1_Click);  
    ```  
  
## See also
- <xref:System.Windows.Forms.OpenFileDialog>
- [OpenFileDialog component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
