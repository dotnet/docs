// <snippet1>
// <snippet2>
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
// </snippet2>

namespace CrossThreadDemo
{
	public class Form1 : Form
	{
		// <snippet3>
		// This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void SetTextCallback(string text);
		// </snippet3>

		// <snippet4>
		// This thread is used to demonstrate both thread-safe and
		// unsafe ways to call a Windows Forms control.
		private Thread demoThread = null;
		// </snippet4>

		// <snippet5>
		// This BackgroundWorker is used to demonstrate the 
		// preferred way of performing asynchronous operations.
		private BackgroundWorker backgroundWorker1;
		// </snippet5>

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

		// <snippet6>
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
		// </snippet6>

		// <snippet7>
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
		// </snippet7>

		// <snippet8>
		// This method demonstrates a pattern for making thread-safe
		// calls on a Windows Forms control. 
		//
		// If the calling thread is different from the thread that
		// created the TextBox control, this method creates a
		// SetTextCallback and calls itself asynchronously using the
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
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.textBox1.Text = text;
			}
		}
		// </snippet8>

		// <snippet9>
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
		// </snippet9>

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
// </snippet1>