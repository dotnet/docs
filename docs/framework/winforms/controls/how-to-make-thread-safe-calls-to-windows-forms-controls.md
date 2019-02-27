---
title: "How to: Make thread-safe calls to Windows Forms controls"
ms.date: "02/19/2019"
dev_langs:
  - "csharp"
  - "vb"
f1_keywords:
  - "EHInvalidOperation.WinForms.IllegalCrossThreadCall"
helpviewer_keywords:
  - "thread safety [Windows Forms], calling controls [Windows Forms]"
  - "calling controls [Windows Forms], thread safety [Windows Forms]"
  - "CheckForIllegalCrossThreadCalls property [Windows Forms]"
  - "Windows Forms controls [Windows Forms], multithreading"
  - "BackgroundWorker class [Windows Forms], examples"
  - "threading [Windows Forms], cross-thread calls"
  - "controls [Windows Forms], multithreading"
ms.assetid: 138f38b6-1099-4fd5-910c-390b41cbad35
---
# How to: Make thread-safe calls to Windows Forms controls

Multithreading can improve the performance of Windows Forms apps, but access to Windows Forms controls isn't inherently thread-safe. Multithreading can expose your code to very serious and complex bugs. Two or more threads manipulating a control can force the control into an inconsistent state and lead to race conditions, deadlocks, and freezes or hangs. If you implement multithreading in your app, be sure to call cross-thread controls in a thread-safe way. For more information, see [Managed threading best practices](../../../../docs/standard/threading/managed-threading-best-practices.md). 

There are two ways to safely call a Windows Forms control from a thread that didn't create that control. You can use the <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=fullName> method to call a delegate created in the main thread, which in turn calls the control. Or, you can implement a <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType>, which uses an event-driven model to separate work done in the background thread from reporting on the results. 

## Unsafe cross-thread calls

It's unsafe to call a control directly from a thread that didn't create it. The following code snippet illustrates an unsafe call to the <xref:System.Windows.Forms.TextBox?displayProperty=nameWithType> control. The `Button1_Click` event handler creates a new `UnsafeText` thread, which sets the main thread's <xref:System.Windows.Forms.TextBox> <xref:System.Windows.Forms.Control.Text%2A> property directly. 

```csharp
private void button1_Click(object sender, EventArgs e)
{
    thread2 = new Thread(new ThreadStart(UnsafeText));
    thread2.Start();
}
private void UnsafeText()
{
    textBox1.Text = "This text was set unsafely.";
}
```

```vb
Private Sub Button1_Click(ByVal sender As Object, e As EventArgs) Handles Button1.Click
    Thread2 = New Thread(New ThreadStart(AddressOf UnsafeText))
    Thread2.Start()
End Sub

Private Sub UnsafeText()
    TextBox1.Text = "This text was set unsafely."
End Sub
```

The Visual Studio debugger detects these unsafe thread calls by raising an <xref:System.InvalidOperationException> with the message, **Cross-thread operation not valid. Control "" accessed from a thread other than the thread it was created on.** The <xref:System.InvalidOperationException> exception always occurs during Visual Studio debugging, and may occur at app runtime. You should fix the issue, but you can disable the exception by setting the <xref:System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls%2A?displayProperty=nameWithType> property to `false`.

## Safe cross-thread calls 

The following code examples demonstrate two ways to safely call a Windows Forms control from a thread that didn't create it: 
1. The <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=fullName> method, which calls a delegate from the main thread to call the control. 
2. A <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType> component, which offers an event-driven model. 

In both examples, the background thread sleeps for one second to simulate work being done in that thread. 

You can build and run these examples as .NET Framework apps from the C# or Visual Basic command line. For more information, see [Command-line building with csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) or [Build from the command line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md). 

Starting with .NET Core 3.0, you can also build and run the examples as Windows .NET Core apps from a folder that has a .NET Core Windows Forms *\<folder name>.csproj* project file. 

## Example: Use the Invoke method with a delegate

The following example demonstrates a pattern for ensuring thread-safe calls to a Windows Forms control. It queries the <xref:System.Windows.Forms.Control.InvokeRequired%2A?displayProperty=fullName> property, which compares the control's creating thread ID to the calling thread ID. If the thread IDs are the same, it calls the control directly. If the thread IDs are different, it calls the <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=nameWithType> method with a delegate from the main thread, which makes the actual call to the control.

The `SafeCallDelegate` enables setting the <xref:System.Windows.Forms.TextBox> <xref:System.Windows.Forms.Control.Text%2A> property, and the `SafeText` method queries <xref:System.Windows.Forms.Control.InvokeRequired%2A>. If <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `true`, `SafeText` passes the `SafeCallDelegate` to the <xref:System.Windows.Forms.Control.Invoke%2A> method to make the actual call to the control. If <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `false`, `SafeText` sets the <xref:System.Windows.Forms.TextBox> <xref:System.Windows.Forms.Control.Text%2A> directly. The `Button1_Click` event handler creates the new thread and runs the `SafeText` method. 

```csharp
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class InvokeThreadSafeForm : Form
{
    private delegate void SafeCallDelegate(string text);
    private Button button1;
    private TextBox textBox1;
    private Thread thread2 = null;

    [STAThread]
    static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new InvokeThreadSafeForm());
    }
    public InvokeThreadSafeForm()
    {
        button1 = new Button
        {
            Location = new Point(15, 55),
            Size = new Size(240, 20),
            Text = "Set text safely"
        };
        button1.Click += new EventHandler(Button1_Click);
        textBox1 = new TextBox
        {
            Location = new Point(15, 15),
            Size = new Size(240, 20)
        };
        Controls.Add(button1);
        Controls.Add(textBox1);
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        thread2 = new Thread(new ThreadStart(SetText));
        thread2.Start();
        Thread.Sleep(1000);
    }

    private void SafeText(string text)
    {
        if (textBox1.InvokeRequired)
        {
            var d = new SafeCallDelegate(SafeText);
            Invoke(d, new object[] { text });
        }
        else
        {
            textBox1.Text = text;
        }
    }
    private void SetText()
    {
        SafeText("This text was set safely.");
    }
}
```

```vb
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Public Class InvokeThreadSafeForm : Inherits Form

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New InvokeThreadSafeForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents Button1 As Button
    Dim TextBox1 As TextBox
    Dim Thread2 as Thread = Nothing

    Delegate Sub SafeCallDelegate([text] As String)

    Private Sub New()
        Button1 = New Button()
        With Button1
            .Text = "Set text safely"
            .Location = New Point(15, 55)
        End With
        TextBox1 = New TextBox()
        With TextBox1
            .Location = New Point(15, 15)
            .Size = New Size(240, 20)
        End With
        Controls.Add(Button1)
        Controls.Add(TextBox1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        thread2 = New Thread(New ThreadStart(AddressOf SetText))
        thread2.Start()
        Thread.Sleep(1000)
    End Sub

    Private Sub SafeText([text] As String)
        If TextBox1.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf SetText)
            Invoke(d, New Object() {[text]})
        Else
            TextBox1.Text = [text]
        End If
    End Sub

    Private Sub SetText()
        SafeText("This text was set safely.")
    End Sub
End Class
```

## Example: Use a BackgroundWorker event handler

An easy way to implement multithreading is with the <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType> component, which uses an event-driven model. The background thread runs the <xref:System.ComponentModel.BackgroundWorker.DoWork?displayProperty=nameWithType> event handler, which doesn't interact with the main thread. The main thread runs the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged?displayProperty=nameWithType> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted?displayProperty=nameWithType> event handlers, which can call the main thread's controls.

To make a thread-safe call by using <xref:System.ComponentModel.BackgroundWorker>, create a method in the background thread to do the work, and bind it to the <xref:System.ComponentModel.BackgroundWorker.DoWork> event. Create another method in the main thread to report the results of the background work, and bind it to the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> or <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> events. To start the background thread, call <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A?displayProperty=nameWithType>. 

The example uses the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler to set the <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.Control.Text%2A> property. For an example using the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event, see <xref:System.ComponentModel.BackgroundWorker>. 

```csharp
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class BackgroundWorkerForm : Form
{
    private BackgroundWorker backgroundWorker1;
    private Button button1;
    private TextBox textBox1;
    private Thread thread2 = null;

    [STAThread]
    static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new BackgroundWorkerForm());
    }
    public BackgroundWorkerForm()
    {
        backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        button1 = new Button
        {
            Location = new Point(15, 55),
            Size = new Size(240, 20),
            Text = "Set text safely with BackgroundWorker"
        };
        button1.Click += new EventHandler(Button1_Click);
        textBox1 = new TextBox
        {
            Location = new Point(15, 15),
            Size = new Size(240, 20)
        };
        Controls.Add(button1);
        Controls.Add(textBox1);
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }

    private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        thread2 = new Thread(new ThreadStart(backgroundWorker1.RunWorkerAsync));
        Thread.Sleep(1000);
    }

    private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        textBox1.Text = "This text was set safely by BackgroundWorker.";
    }
}
```

```vb
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Public Class BackgroundWorkerForm : Inherits Form

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New BackgroundWorkerForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents BackgroundWorker1 As BackgroundWorker
    Dim WithEvents Button1 As Button
    Dim TextBox1 As TextBox
    Dim Thread2 as Thread = Nothing

    Private Sub New()
        BackgroundWorker1 = New BackgroundWorker()
        Button1 = New Button()
        With Button1
            .Text = "Set text safely with BackgroundWorker"
            .Location = New Point(15, 55)
            .Size = New Size(240, 20)
        End With
        TextBox1 = New TextBox()
        With TextBox1
            .Location = New Point(15, 15)
            .Size = New Size(240, 20)
        End With
        Controls.Add(Button1)
        Controls.Add(TextBox1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) _
     Handles BackgroundWorker1.DoWork
        thread2 = new Thread(new ThreadStart(AddressOf backgroundWorker1.RunWorkerAsync))
        Thread.Sleep(1000)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) _
     Handles BackgroundWorker1.RunWorkerCompleted
        textBox1.Text = "This text was set safely by BackgroundWorker."
    End Sub
End Class
```

## See also

- <xref:System.ComponentModel.BackgroundWorker>
- [How to: Run an operation in the background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)
- [How to: Implement a form that uses a background operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)
- [Develop custom Windows Forms controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)
