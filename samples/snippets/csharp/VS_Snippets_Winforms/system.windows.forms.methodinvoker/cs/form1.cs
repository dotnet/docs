using System;
using System.Windows.Forms;

namespace _454942_CS_MethodInvoker
{
    //<Snippet1>
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Create a timer that will call the ShowTime method every second.
            var timer = new System.Threading.Timer(ShowTime, null, 0, 1000);           
        }

        private void ShowTime(object x)
        {
            // Don't do anything if the form's handle hasn't been created 
            // or the form has been disposed.
            if (!this.IsHandleCreated && !this.IsDisposed) return;
            
            // Invoke an anonymous method on the thread of the form.
            this.Invoke((MethodInvoker) delegate
            {
                // Show the current time in the form's title bar.
                this.Text = DateTime.Now.ToLongTimeString();
            });
        }
    }
    //</Snippet1>
}
