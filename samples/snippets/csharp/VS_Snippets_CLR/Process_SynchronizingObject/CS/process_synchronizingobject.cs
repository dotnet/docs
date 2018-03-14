// System.Diagnostics.Process.SynchronizingObject
/*
The following example demonstrates the property 'SynchronizingObject'
of 'Process' class.

It starts a process 'mspaint.exe' on button click. 
It attaches 'MyProcessExited' method of 'MyButton' class as EventHandler to
'Exited' event of the process.
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace process_SynchronizingObject
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.ComponentModel.Container components = null;
      

      public Form1()
      {
         InitializeComponent();
      }
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      private void InitializeComponent()
      {
         this.button1 = new process_SynchronizingObject.MyButton();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(40, 80);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(168, 32);
         this.button1.TabIndex = 0;
         this.button1.Text = "Click Me";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
      #endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

// <Snippet1>
      private MyButton button1;
      private void button1_Click(object sender, System.EventArgs e)
      {
         Process myProcess = new Process();
         ProcessStartInfo myProcessStartInfo= new ProcessStartInfo("mspaint");
         myProcess.StartInfo = myProcessStartInfo;
         myProcess.Start();
         myProcess.Exited += new EventHandler(MyProcessExited);
         // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
         myProcess.EnableRaisingEvents = true;
         // Set method handling the exited event to be called  ;
         // on the same thread on which MyButton was created.
         myProcess.SynchronizingObject = button1;
         MessageBox.Show("Waiting for the process 'mspaint' to exit....");
         myProcess.WaitForExit();
         myProcess.Close();
      }
      private void MyProcessExited(Object source, EventArgs e)
      {
         MessageBox.Show("The process has exited.");
      }
   }

   public class MyButton:Button
   {

   }
// </Snippet1>
}