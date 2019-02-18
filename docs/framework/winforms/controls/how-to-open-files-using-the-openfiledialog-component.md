---
title: "How to: Open files with the OpenFileDialog component"
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
# How to: Open files with the OpenFileDialog 

The <xref:System.Windows.Forms.OpenFileDialog?displayProperty=nameWithType> component opens the Windows dialog box for browsing and selecting files. To open and read the selected files, you can use the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method, or create an instance of the <xref:System.IO.StreamReader?displayProperty=nameWithType> class. The following examples show both approaches. 

To get or set the <xref:System.Windows.Forms.FileDialog.FileName%2A> property requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. The examples run a <xref:System.Security.Permissions.FileIOPermission> permission check, and can throw an exception due to insufficient privileges if run in a partial-trust context. For more information, see [Code access security basics](../../../../docs/framework/misc/code-access-security-basics.md).

You can build and run these examples from the C# or Visual Basic command line. For more information, see [Command-line building with csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) or [Build from the command line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md). 

## Example: Read a file as a stream with StreamReader  
  
The following example uses a <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method. After the user chooses a file and selects **OK**, an instance of the <xref:System.IO.StreamReader> class reads the file and displays its contents in a message box. For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> and <xref:System.IO.FileStream.Read%2A?displayProperty=nameWithType>.  
 

```csharp  
using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

public class OpenFileDialogForm : Form
{
    public Button selectButton;
    public OpenFileDialog openFileDialog1;

    public OpenFileDialogForm()
    {
        selectButton = new Button();
        openFileDialog1 = new OpenFileDialog();

        selectButton.Text = "Select file";
        Controls.Add(selectButton);
        selectButton.Click += new EventHandler(selectButton_Click);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new OpenFileDialogForm());
    }

    private void selectButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd(), "File contents:", MessageBoxButtons.OK);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("Security error.\n\n" +
                    "Error message: " + ex.Message + "\n\n" +
                    "Details:\n\n" + ex.StackTrace);
            }
        }
    }
}
```

```vb  
Imports System.ComponentModel
Imports System.IO
Imports System.Security
Imports System.Windows.Forms

Public Class OpenFileDialogForm : Inherits Form 
   Dim WithEvents selectButton As Button
   Dim openFileDialog1 As OpenFileDialog
   
   Public Sub New()
      openFileDialog1 = New OpenFileDialog()
      selectButton = New Button()
      With selectButton
         .Text = "Select file"
      End With
      Controls.Add(selectButton)
   End Sub
   
   Public Sub selectButton_Click(sender As Object, e As EventArgs) _ 
              Handles selectButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim sr As New StreamReader(OpenFileDialog1.FileName)
                MessageBox.Show(sr.ReadToEnd(), "File contents:", MessageBoxButtons.OK)
            Catch SecEx As SecurityException
                MessageBox.Show("Security error.\n\n" &
                    "Error message: " & SecEx.Message & "\n\n" &
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            End Try
        End If
    End Sub

   Public Shared Sub Main()
      Application.Run(New OpenFileDialogForm())
   End Sub
End Class
```  

## Example: Open a file from a filtered selection with OpenFile 

The following example uses a <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with a filter that shows only text files. After the user chooses a text file and selects **OK**, the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method is used to open the file in Notepad.

```csharp
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Windows.Forms;

public class OpenFileDialogForm : Form
{
    public Button selectButton;
    public OpenFileDialog openFileDialog1;
    public BackgroundWorker backgroundWorker1;

    public OpenFileDialogForm()
    {
        selectButton = new Button();
        openFileDialog1 = new OpenFileDialog();
        backgroundWorker1 = new BackgroundWorker();

        selectButton.Text = "Select file";
        openFileDialog1.FileName = "Select a text file";
        openFileDialog1.Filter = "Text files (*.txt)|*.txt";
        openFileDialog1.Title = "Open text file";

        Controls.Add(selectButton);
        selectButton.Click += new EventHandler(selectButton_Click);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new OpenFileDialogForm());
    }

    private void selectButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var filePath = openFileDialog1.FileName;
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    Process.Start("notepad.exe", filePath);
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("Security error.\n\n" +
                    "Error message: " + ex.Message + "\n\n" +
                    "Details:\n\n" + ex.StackTrace);
            }
        }
    }
}
```

```vb
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports System.Windows.Forms

Public Class OpenFileDialogForm : Inherits Form 
   Dim WithEvents selectButton As Button
   Dim openFileDialog1 As OpenFileDialog
   Dim backgroundWorker1 As BackgroundWorker

   Public Sub New()
      backgroundWorker1 = New BackgroundWorker()
      openFileDialog1 = New OpenFileDialog()
      With openFileDialog1
         .FileName = "Select a text file"
         .Filter = "Text files (*.txt)|*.txt"
         .Title = "Open text file"
      End With
      selectButton = New Button()
      With selectButton
         .Text = "Select file"
      End With
      Controls.Add(selectButton)
   End Sub
   
   Public Sub selectButton_Click(sender As Object, e As EventArgs) _ 
              Handles selectButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim filePath = OpenFileDialog1.FileName
                Dim fs As FileStream = New FileStream(filePath, FileMode.Open)
                Process.Start("notepad.exe", filePath)
            Catch SecEx As SecurityException
                MessageBox.Show("Security error. Please contact your administrator.\n\n" &
                    "Error message: " & SecEx.Message & "\n\n" &
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            End Try
        End If
    End Sub

Public Shared Sub Main()
      Dim frm As New OpenFileDialogForm()
      Application.Run(frm)
   End Sub
End Class
```

## See also
- <xref:System.Windows.Forms.OpenFileDialog>
- [OpenFileDialog component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
