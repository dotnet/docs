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

## Example: Read a file as a stream with StreamReader  
  
The following example uses a <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method. After the user chooses a file and selects **OK**, an instance of the <xref:System.IO.StreamReader> class reads the file and displays its contents in a message box. For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A> and <xref:System.IO.FileStream.Read%2A>.  
 
To build and run the example:
1. Start a new Windows Forms project named *OpenFileDialogStreamReader*. 
1. Paste the example code over the contents of the *Form1.cs* or *Form1.vb* code file. 
1. Add and configure the Form1 button, open file dialog, and button click event handler as follows: 
   - For .NET Framework:
     - Use **Designer** view to add a **Button** and an **OpenFileDialog** to *Form1* from the **Toolbox**. 
     - For C# only, in *Form1.Designer.cs* under `private void InitializeComponent()`, add the line:
       ```csharp
       this.button1.Click += new System.EventHandler(this.buttonSelect_Click);
       ```
       
   - For .NET Core 3.0, add or change the following lines in *Form1.Designer.cs*:
     - In `partial class Form1`, add the line:
       ```csharp
       private System.Windows.Forms.OpenFileDialog openFileDialog1;
       ```
     - In `private void InitializeComponent()`, add the line:
       ```csharp
       this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
       ```
     - In `private void InitializeComponent()`, repurpose the existing template button by changing the `this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);` to
       ```csharp
       this.buttonExit.Click += new System.EventHandler(this.SelectFileButton_Click);
       ```
       
       Also change the line `this.buttonExit.Text = "E&xit";` to `this.buttonExit.Text = "S&elect file";`.
       
1. Save all files, and build and run the project.

The complete *Form1.cs* or *Form1.vb* code file follows:

```csharp  
using System;
using System.IO;
using System.Windows.Forms;
using System.Security;

namespace OpenFileDialogStreamReader
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void InitializeOpenFileDialog()
        {
        }
        private void SelectFileButton_Click(object sender, EventArgs e)
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
}

```  

```vb  
Imports System.ComponentModel
Imports System.IO
Imports System.Security

Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(components As IContainer, button1 As Button, openFileDialog1 As OpenFileDialog)
        Me.components = components
        Me.Button1 = button1
        Me.OpenFileDialog1 = openFileDialog1
    End Sub

    Public Sub InitializeOpenFileDialog()
    End Sub

    Public Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        InitializeOpenFileDialog()
    End Sub

    Private Sub SelectFileButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim sr As New StreamReader(OpenFileDialog1.FileName)
                MessageBox.Show(sr.ReadToEnd(), "File contents:", MessageBoxButtons.OK)
            Catch SecEx As SecurityException
                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" &
                    "Error message: " & SecEx.Message & "\n\n" &
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            End Try
        End If
    End Sub
End Class
```  

## Example: Open a file from a filtered selection with OpenFile 

The following example uses a <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with a filter that shows only text files. After the user chooses a text file and selects **OK**, the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method is used to open the file in Notepad.

To build and run the example:
1. Start a new Windows Forms project named *OpenFileDialogOpenFile*. 
1. Paste the example code over the contents of the *Form1.cs* or *Form1.vb* code file. 
1. Add and configure the Form1 button, open file dialog, button click event handler, and background worker as follows: 
   - For .NET Framework:
     - Use **Designer** view to add a **Button**, **OpenFileDialog**, and **BackgroundWorker** to *Form1* from the **Toolbox**. 
     - For C# only, in *Form1.Designer.cs* under `private void InitializeComponent()`, add the line:
       ```csharp
       this.button1.Click += new System.EventHandler(this.buttonSelect_Click);
       ```
       
   - For .NET Core 3.0, add or change the following lines in *Form1.Designer.cs*:
     - In `partial class Form1`, add the lines:
       ```csharp
       private System.Windows.Forms.OpenFileDialog openFileDialog1;
       private System.ComponentModel.BackgroundWorker backgroundWorker1;
       ```
     - In `private void InitializeComponent()`, add the lines:
       ```csharp
       this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
       this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
       ```
     - In `private void InitializeComponent()`, repurpose the existing template button by changing the `this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);` to
       ```csharp
       this.buttonExit.Click += new System.EventHandler(this.SelectFileButton_Click);
       ```
       
       Also change the line `this.buttonExit.Text = "E&xit";` to `this.buttonExit.Text = "S&elect file";`.
       
1. Save all files, and build and run the project.

The complete *Form1.cs* or *Form1.vb* code file follows:

```csharp
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Security;

namespace OpenFileDialogOpenFile
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void InitializeOpenFileDialog()
        {
        }
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Select a text file";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Open text file";

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
                        "Details:\n\n" + ex.StackTrace
                    );
                }
            }
        }
    }
}
```

```vb
Imports System.ComponentModel
Imports System.IO
Imports System.Security

Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(components As IContainer, Button1 As Button, OpenFileDialog1 As OpenFileDialog, BackgroundWorker1 As BackgroundWorker)
        Me.components = components
        Me.Button1 = Button1
        Me.OpenFileDialog1 = OpenFileDialog1
        Me.BackgroundWorker1 = BackgroundWorker1
    End Sub

    Public Sub InitializeOpenFileDialog()
    End Sub

    Public Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.FileName = "Select a text file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        OpenFileDialog1.Title = "Open text file"
    End Sub

    Private Sub SelectFileButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim filePath = OpenFileDialog1.FileName
                Dim fs As FileStream = New FileStream(filePath, FileMode.Open)
                Process.Start("notepad.exe", filePath)
            Catch SecEx As SecurityException
                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" &
                    "Error message: " & SecEx.Message & "\n\n" &
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            End Try
        End If
    End Sub
End Class
```

## See also
- <xref:System.Windows.Forms.OpenFileDialog>
- [OpenFileDialog component](../../../../docs/framework/winforms/controls/openfiledialog-component-windows-forms.md)
