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

The <xref:System.Windows.Forms.OpenFileDialog?displayProperty=nameWithType> component opens the Windows dialog box for browsing and selecting files. To open and read the selected files, you can use the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A?displayProperty=nameWithType> method, or create an instance of the <xref:System.IO.StreamReader?displayProperty=nameWithType> class. The following examples show both approaches. 

In .NET Framework, to get or set the <xref:System.Windows.Forms.FileDialog.FileName%2A> property requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. The examples run a <xref:System.Security.Permissions.FileIOPermission> permission check, and can throw an exception due to insufficient privileges if run in a partial-trust context. For more information, see [Code access security basics](../../../../docs/framework/misc/code-access-security-basics.md).

You can build and run these examples as .NET Framework apps from the C# or Visual Basic command line. For more information, see [Command-line building with csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) or [Build from the command line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md). 

Starting with .NET Core 3.0, you can also build and run the examples from a folder that has a .NET Core Windows Forms *\<folder name>.csproj* project file. 

## Example: Read a file as a stream with StreamReader  
  
The following example uses the Windows Forms <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method. After the user chooses a file and selects **OK**, an instance of the <xref:System.IO.StreamReader> class reads the file and displays its contents in the form's text box. For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> and <xref:System.IO.FileStream.Read%2A?displayProperty=nameWithType>.  
 

```csharp  
using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

public class OpenFileDialogForm : Form
{
    [STAThread]
    public static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new OpenFileDialogForm());
    }

    private Button selectButton;
    private OpenFileDialog openFileDialog1;
    private TextBox textBox1;

    public OpenFileDialogForm()
    {
        openFileDialog1 = new OpenFileDialog();
        selectButton = new Button
        {
            Size = new Size(100, 20),
            Location = new Point(15, 15),
            Text = "Select file"
        };
        selectButton.Click += new EventHandler(SelectButton_Click);
        textBox1 = new TextBox
        {
            Size = new Size(300, 300),
            Location = new Point(15, 40),
            Multiline = true,
            ScrollBars = ScrollBars.Vertical
        };
        ClientSize = new Size(330, 360);
        Controls.Add(selectButton);
        Controls.Add(textBox1);
    }
    private void SetText(string text)
    {
        textBox1.Text = text;
    }
    private void SelectButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                SetText(sr.ReadToEnd());
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
    }
}
```

```vb  
Imports System.Drawing
Imports System.IO
Imports System.Security
Imports System.Windows.Forms

Public Class OpenFileDialogForm : Inherits Form

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New OpenFileDialogForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents SelectButton As Button
    Dim openFileDialog1 As OpenFileDialog
    Dim TextBox1 As TextBox

    Private Sub New()
        ClientSize = New Size(400, 400)
        openFileDialog1 = New OpenFileDialog()
        SelectButton = New Button()
        With SelectButton
            .Text = "Select file"
            .Location = New Point(15, 15)
            .Size = New Size(100, 25)
        End With
        TextBox1 = New TextBox()
        With TextBox1
            .Size = New Size(300, 300)
            .Location = New Point(15, 50)
            .Multiline = True
            .ScrollBars = ScrollBars.Vertical
        End With
        Controls.Add(SelectButton)
        Controls.Add(TextBox1)
    End Sub

    Private Sub SetText(text)
        TextBox1.Text = text
    End Sub

    Public Sub SelectButton_Click(sender As Object, e As EventArgs) _
              Handles SelectButton.Click
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim sr As New StreamReader(openFileDialog1.FileName)
                SetText(sr.ReadToEnd())
            Catch SecEx As SecurityException
                MessageBox.Show($"Security error:{vbCrLf}{vbCrLf}{SecEx.Message}{vbCrLf}{vbCrLf}" &
                $"Details:{vbCrLf}{vbCrLf}{SecEx.StackTrace}")
            End Try
        End If
    End Sub
End Class
```  

## Example: Open a file from a filtered selection with OpenFile 

The following example uses the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with a filter that shows only text files. After the user chooses a text file and selects **OK**, the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method is used to open the file in Notepad.

```csharp
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Windows.Forms;

public class OpenFileDialogForm : Form
{
    [STAThread]
    public static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new OpenFileDialogForm());
    }

    private Button selectButton;
    private OpenFileDialog openFileDialog1;
    private BackgroundWorker backgroundWorker1;

    public OpenFileDialogForm()
    {
        openFileDialog1 = new OpenFileDialog();
        {
            Filename = "Select a text file",
            Filter = "Text files (*.txt)|*.txt",
            Title = "Open text file"
        };

        selectButton = new Button
        {
            Size = new Size(100, 20),
            Location = new Point(15, 15),
            Text = "Select file"
        };
        selectButton.Click += new EventHandler(selectButton_Click);
        Controls.Add(selectButton);
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
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
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

    Public Shared Sub Main()
      Application.SetCompatibleTextRenderingDefault(false)
      Application.EnableVisualStyles()
      Dim frm As New OpenFileDialogForm()
      Application.Run(frm)
    End Sub

    Private Sub New()
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
                MessageBox.Show($"Security error:{vbCrLf}{vbCrLf}{SecEx.Message}{vbCrLf}{vbCrLf}" &
                $"Details:{vbCrLf}{vbCrLf}{SecEx.StackTrace}")
            End Try
        End If
    End Sub
End Class
```

## See also
- <xref:System.Windows.Forms.OpenFileDialog>
- [OpenFileDialog component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
