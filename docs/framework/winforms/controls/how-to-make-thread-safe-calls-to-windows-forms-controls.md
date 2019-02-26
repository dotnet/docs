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

Multithreading can improve the performance of your Windows Forms apps, but access to Windows Forms controls is not inherently thread safe. If two or more threads are manipulating a control, it is possible to force the control into an inconsistent state, or cause race conditions and deadlocks. If you use multithreading, be sure to call your controls in a thread-safe way. 

> [!CAUTION]
> When you use multithreading, your code can be exposed to very serious and complex bugs. For more information, see [Managed threading best practices](../../../../docs/standard/threading/managed-threading-best-practices.md).

There are two ways to safely call a Windows Forms control from a thread that did not create it. You can use the <xref:System.Windows.Forms.Control.Invoke%2A> method to call a delegate created in the main thread, which calls the control. Or, you can use a <xref:System.ComponentModel.BackgroundWorker> component, which uses an event-driven model. The following article and code examples describe both approaches. 

## Unsafe cross-thread calls

It is unsafe to call a control directly from a thread that did not create it. The following code shows an unsafe call to the <xref:System.Windows.Forms.TextBox> control. The button click event handler creates a new `Unsafe` thread, which sets the main thread's <xref:System.Windows.Forms.TextBox> <xref:System.Windows.Forms.Control.Text%2A> property directly. 

```csharp
    public Form1()
    {
        textBox1 = new TextBox;
        button1 = new Button;
        button1.Click += new EventHandler(Button1_Click);

    private void Button1_Click(object sender, EventArgs e)
    {
        thread1 = new Thread(new ThreadStart(Unsafe));
        thread1.Start();
    }
    private void Unsafe()
    {
        textBox1.Text = "This text was set unsafely.";
    }
```

The Visual Studio debugger detects unsafe thread calls by raising an <xref:System.InvalidOperationException> with the message, **Cross-thread operation not valid. Control "" accessed from a thread other than the thread it was created on.** This exception occurs reliably during Visual Studio debugging, and can occur at runtime. Although you should fix this problem, you can disable the exception by setting the <xref:System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls%2A> property to `false`.

## Make thread-safe calls by using the Invoke method

The following code demonstrates a pattern for ensuring thread-safe calls to a Windows Forms control. First, query the <xref:System.Windows.Forms.Control.InvokeRequired%2A> property, which compares the control's creating thread ID to the calling thread ID. If the thread IDs are the same, you can call the control directly. If the thread IDs are different, call the <xref:System.Windows.Forms.Control.Invoke%2A> method with a delegate from the main thread that makes the actual call to the control.

In the following code, the `SetSafe` method queries <xref:System.Windows.Forms.Control.InvokeRequired%2A>, and if <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `true`, passes the delegate to the form's <xref:System.Windows.Forms.Control.Invoke%2A> method The `StringArgReturningVoidDelegate` enables setting the <xref:System.Windows.Forms.TextBox> <xref:System.Windows.Forms.Control.Text%2A> property. to make the actual call to the control. If <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `false`, it sets the text box text directly. The event handler creates a new `Safe` worker thread that runs the `SetSafe` method. 

```csharp
    public Form1()
    {
        delegate void StringArgReturningVoidDelegate(string text);
        textBox1 = new TextBox;
        button1 = new Button;
        button1.Click += new EventHandler(Button1_Click);

    private void SetSafe(string text)
    {
        if (textBox1.InvokeRequired)
        {
            var d = new StringArgReturningVoidDelegate(SetSafe);
            Invoke(d, new object[] { text });
        }
        else
        {
            textBox1.Text = text;
        }
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        Thread1 = new Thread(new ThreadStart(Safe));
        Thread1.Start();
    }
    private void Safe()
    {
        SetSafe = "This text was set safely.";
    }
```

## Make thread-safe calls by using BackgroundWorker

The easiest and most direct way to implement multithreading is with the <xref:System.ComponentModel.BackgroundWorker> component, which uses an event-driven model. The background thread runs the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler, which does not call controls created by the main thread. The thread that created the controls runs the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handlers, which call the controls.

To make a thread-safe call by using <xref:System.ComponentModel.BackgroundWorker>, create a method in the background thread to do the work, and bind it to the <xref:System.ComponentModel.BackgroundWorker.DoWork> event. Create another method in the main thread to report the results of the background work, and bind it to the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> or <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event. To start the background thread, call the <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A> method.

The following example uses the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event. For an example using the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event, see <xref:System.ComponentModel.BackgroundWorker>.

In the following code example, the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler uses <xref:System.Threading.Thread.Sleep%2A> to simulate work that takes some time. It does not call the form’s <xref:System.Windows.Forms.TextBox> control. The <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.Control.Text%2A> property is set in the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler.

// This event handler starts the form's
// BackgroundWorker by calling RunWorkerAsync.
//
// The Text property of the TextBox control is set
// when the BackgroundWorker raises the RunWorkerCompleted
// event.

// This event handler sets the Text property of the TextBox
// control. It is called on the thread that created the
// TextBox control, so the call is thread-safe.
//
// BackgroundWorker is the preferred way to perform asynchronous
// operations.


```csharp
private BackgroundWorker backgroundWorker1;
private Button button1;
private TextBox textBox1;

private void button1_Click(object sender, EventArgs e)
{
	backgroundWorker1.RunWorkerAsync();
}
private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
	textBox1.Text = "This text was set safely by BackgroundWorker.";
}

```

```vb
Private WithEvents backgroundWorker1 As BackgroundWorker

 Private Sub button1_Click( ByVal sender As Object, e As EventArgs) 
   Handles button1.Click
     backgroundWorker1.RunWorkerAsync()
 End Sub

 Private Sub backgroundWorker1_RunWorkerCompleted( ByVal sender As Object, e As RunWorkerCompletedEventArgs) 
   Handles backgroundWorker1.RunWorkerCompleted
     textBox1.Text = "This text was set safely by BackgroundWorker."
 End Sub
```

## Example
The following code example is a complete Windows Forms app that demonstrates unsafe cross-thread access and safe cross-thread access by using <xref:System.Windows.Forms.Control.Invoke%2A> and by using <xref:System.ComponentModel.BackgroundWorker>. 

When you debug the app in Visual Studio and select the **Unsafe call** button, the Visual Studio debugger indicates that an exception occurred, and stops at the line in the background thread that attempted to write directly to the text box. You will have to restart the app to test the other two buttons. 

When you select the **Safe call** button, **This text was set safely** appears in the text box, which indicates that the <xref:System.Windows.Forms.Control.Invoke%2A> method was called. When you select the **Safe BW call** button, **This text was set safely by BackgroundWorker** appears in the text box, indicating that the handler for the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event of <xref:System.ComponentModel.BackgroundWorker> was called.

```csharp
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace CrossThreadDemo
{
	public class Form1 : Form
	{
		// This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void StringArgReturningVoidDelegate(string text);

		// This thread is used to demonstrate both thread-safe and
		// unsafe ways to call a Windows Forms control.
		private Thread demoThread = null;

		// This BackgroundWorker is used to demonstrate the
		// preferred way of performing asynchronous operations.
		private BackgroundWorker backgroundWorker1;

		private TextBox textBox1;
		private Button setTextUnsafeBtn;
		private Button setTextSafeBtn;
		private Button setTextBackgroundWorkerBtn;

		private System.ComponentModel.IContainer components = null;

		public Form1()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		// This event handler creates a thread that calls a
		// Windows Forms control in an unsafe way.
		private void setTextUnsafeBtn_Click(
			object sender,
			EventArgs e)
		{
			this.demoThread =
				new Thread(new ThreadStart(this.ThreadProcUnsafe));

			this.demoThread.Start();
		}

		// This method is executed on the worker thread and makes
		// an unsafe call on the TextBox control.
		private void ThreadProcUnsafe()
		{
			this.textBox1.Text = "This text was set unsafely.";
		}

		// This event handler creates a thread that calls a
		// Windows Forms control in a thread-safe way.
		private void setTextSafeBtn_Click(
			object sender,
			EventArgs e)
		{
			this.demoThread =
				new Thread(new ThreadStart(this.ThreadProcSafe));

			this.demoThread.Start();
		}

		// This method is executed on the worker thread and makes
		// a thread-safe call on the TextBox control.
		private void ThreadProcSafe()
		{
			this.SetText("This text was set safely.");
		}

		// This method demonstrates a pattern for making thread-safe
		// calls on a Windows Forms control.
		//
		// If the calling thread is different from the thread that
		// created the TextBox control, this method creates a
		// StringArgReturningVoidDelegate and calls itself asynchronously using the
		// Invoke method.
		//
		// If the calling thread is the same as the thread that created
		// the TextBox control, the Text property is set directly.

		private void SetText(string text)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.textBox1.InvokeRequired)
			{
				StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.textBox1.Text = text;
			}
		}

		// This event handler starts the form's
		// BackgroundWorker by calling RunWorkerAsync.
		//
		// The Text property of the TextBox control is set
		// when the BackgroundWorker raises the RunWorkerCompleted
		// event.
		private void setTextBackgroundWorkerBtn_Click(
			object sender,
			EventArgs e)
		{
			this.backgroundWorker1.RunWorkerAsync();
		}

		// This event handler sets the Text property of the TextBox
		// control. It is called on the thread that created the
		// TextBox control, so the call is thread-safe.
		//
		// BackgroundWorker is the preferred way to perform asynchronous
		// operations.

		private void backgroundWorker1_RunWorkerCompleted(
			object sender,
			RunWorkerCompletedEventArgs e)
		{
			this.textBox1.Text =
				"This text was set safely by BackgroundWorker.";
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.setTextUnsafeBtn = new System.Windows.Forms.Button();
			this.setTextSafeBtn = new System.Windows.Forms.Button();
			this.setTextBackgroundWorkerBtn = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			//
			// textBox1
			//
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 20);
			this.textBox1.TabIndex = 0;
			//
			// setTextUnsafeBtn
			//
			this.setTextUnsafeBtn.Location = new System.Drawing.Point(15, 55);
			this.setTextUnsafeBtn.Name = "setTextUnsafeBtn";
			this.setTextUnsafeBtn.TabIndex = 1;
			this.setTextUnsafeBtn.Text = "Unsafe Call";
			this.setTextUnsafeBtn.Click += new System.EventHandler(this.setTextUnsafeBtn_Click);
			//
			// setTextSafeBtn
			//
			this.setTextSafeBtn.Location = new System.Drawing.Point(96, 55);
			this.setTextSafeBtn.Name = "setTextSafeBtn";
			this.setTextSafeBtn.TabIndex = 2;
			this.setTextSafeBtn.Text = "Safe Call";
			this.setTextSafeBtn.Click += new System.EventHandler(this.setTextSafeBtn_Click);
			//
			// setTextBackgroundWorkerBtn
			//
			this.setTextBackgroundWorkerBtn.Location = new System.Drawing.Point(177, 55);
			this.setTextBackgroundWorkerBtn.Name = "setTextBackgroundWorkerBtn";
			this.setTextBackgroundWorkerBtn.TabIndex = 3;
			this.setTextBackgroundWorkerBtn.Text = "Safe BW Call";
			this.setTextBackgroundWorkerBtn.Click += new System.EventHandler(this.setTextBackgroundWorkerBtn_Click);
			//
			// backgroundWorker1
			//
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			//
			// Form1
			//
			this.ClientSize = new System.Drawing.Size(268, 96);
			this.Controls.Add(this.setTextBackgroundWorkerBtn);
			this.Controls.Add(this.setTextSafeBtn);
			this.Controls.Add(this.setTextUnsafeBtn);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

	}
}
```

```vb
Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms

Public Class Form1
   Inherits Form

   ' This delegate enables asynchronous calls for setting
   ' the text property on a TextBox control.
   Delegate Sub StringArgReturningVoidDelegate([text] As String)

   ' This thread is used to demonstrate both thread-safe and
   ' unsafe ways to call a Windows Forms control.
   Private demoThread As Thread = Nothing

   ' This BackgroundWorker is used to demonstrate the
   ' preferred way of performing asynchronous operations.
   Private WithEvents backgroundWorker1 As BackgroundWorker

   Private textBox1 As TextBox
   Private WithEvents setTextUnsafeBtn As Button
   Private WithEvents setTextSafeBtn As Button
   Private WithEvents setTextBackgroundWorkerBtn As Button

   Private components As System.ComponentModel.IContainer = Nothing

   Public Sub New()
      InitializeComponent()
    End Sub

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub

   ' This event handler creates a thread that calls a
   ' Windows Forms control in an unsafe way.
    Private Sub setTextUnsafeBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextUnsafeBtn.Click

        Me.demoThread = New Thread( _
        New ThreadStart(AddressOf Me.ThreadProcUnsafe))

        Me.demoThread.Start()
    End Sub

   ' This method is executed on the worker thread and makes
   ' an unsafe call on the TextBox control.
   Private Sub ThreadProcUnsafe()
      Me.textBox1.Text = "This text was set unsafely."
   End Sub

   ' This event handler creates a thread that calls a
   ' Windows Forms control in a thread-safe way.
    Private Sub setTextSafeBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextSafeBtn.Click

        Me.demoThread = New Thread( _
        New ThreadStart(AddressOf Me.ThreadProcSafe))

        Me.demoThread.Start()
    End Sub

   ' This method is executed on the worker thread and makes
   ' a thread-safe call on the TextBox control.
   Private Sub ThreadProcSafe()
      Me.SetText("This text was set safely.")
    End Sub

   ' This method demonstrates a pattern for making thread-safe
   ' calls on a Windows Forms control.
   '
   ' If the calling thread is different from the thread that
   ' created the TextBox control, this method creates a
   ' StringArgReturningVoidDelegate and calls itself asynchronously using the
   ' Invoke method.
   '
   ' If the calling thread is the same as the thread that created
    ' the TextBox control, the Text property is set directly.

    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.textBox1.InvokeRequired Then
            Dim d As New StringArgReturningVoidDelegate(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.textBox1.Text = [text]
        End If
    End Sub

   ' This event handler starts the form's
   ' BackgroundWorker by calling RunWorkerAsync.
   '
   ' The Text property of the TextBox control is set
   ' when the BackgroundWorker raises the RunWorkerCompleted
   ' event.
    Private Sub setTextBackgroundWorkerBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextBackgroundWorkerBtn.Click
        Me.backgroundWorker1.RunWorkerAsync()
    End Sub

   ' This event handler sets the Text property of the TextBox
   ' control. It is called on the thread that created the
   ' TextBox control, so the call is thread-safe.
   '
   ' BackgroundWorker is the preferred way to perform asynchronous
   ' operations.
    Private Sub backgroundWorker1_RunWorkerCompleted( _
    ByVal sender As Object, _
    ByVal e As RunWorkerCompletedEventArgs) _
    Handles backgroundWorker1.RunWorkerCompleted
        Me.textBox1.Text = _
        "This text was set safely by BackgroundWorker."
    End Sub

   #Region "Windows Form Designer generated code"

   Private Sub InitializeComponent()
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.setTextUnsafeBtn = New System.Windows.Forms.Button()
      Me.setTextSafeBtn = New System.Windows.Forms.Button()
      Me.setTextBackgroundWorkerBtn = New System.Windows.Forms.Button()
      Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
      Me.SuspendLayout()
      '
      ' textBox1
      '
      Me.textBox1.Location = New System.Drawing.Point(12, 12)
      Me.textBox1.Name = "textBox1"
      Me.textBox1.Size = New System.Drawing.Size(240, 20)
      Me.textBox1.TabIndex = 0
      '
      ' setTextUnsafeBtn
      '
      Me.setTextUnsafeBtn.Location = New System.Drawing.Point(15, 55)
      Me.setTextUnsafeBtn.Name = "setTextUnsafeBtn"
      Me.setTextUnsafeBtn.TabIndex = 1
      Me.setTextUnsafeBtn.Text = "Unsafe Call"
      '
      ' setTextSafeBtn
      '
      Me.setTextSafeBtn.Location = New System.Drawing.Point(96, 55)
      Me.setTextSafeBtn.Name = "setTextSafeBtn"
      Me.setTextSafeBtn.TabIndex = 2
      Me.setTextSafeBtn.Text = "Safe Call"
      '
      ' setTextBackgroundWorkerBtn
      '
      Me.setTextBackgroundWorkerBtn.Location = New System.Drawing.Point(177, 55)
      Me.setTextBackgroundWorkerBtn.Name = "setTextBackgroundWorkerBtn"
      Me.setTextBackgroundWorkerBtn.TabIndex = 3
      Me.setTextBackgroundWorkerBtn.Text = "Safe BW Call"
      '
      ' backgroundWorker1
      '
      '
      ' Form1
      '
      Me.ClientSize = New System.Drawing.Size(268, 96)
      Me.Controls.Add(setTextBackgroundWorkerBtn)
      Me.Controls.Add(setTextSafeBtn)
      Me.Controls.Add(setTextUnsafeBtn)
      Me.Controls.Add(textBox1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub 'InitializeComponent

   #End Region

   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
    End Sub
End Class
```

## See also

- <xref:System.ComponentModel.BackgroundWorker>
- [How to: Run an operation in the background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)
- [How to: Implement a form that uses a background operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)
- [Develop custom Windows Forms controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)
- [Windows Forms and unmanaged apps](../../../../docs/framework/winforms/advanced/windows-forms-and-unmanaged-applications.md)
