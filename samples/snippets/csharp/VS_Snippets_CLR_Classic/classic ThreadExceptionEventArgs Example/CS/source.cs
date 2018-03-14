// <Snippet1>
using System;
using System.Threading;
using System.Windows.Forms;

// Create a form with a button that, when clicked, throws an exception.
 public class ErrorForm : System.Windows.Forms.Form
 {
    internal Button button1;

    public ErrorForm() : base()
    {
       // Add the button to the form.
       this.button1 = new System.Windows.Forms.Button();
       this.SuspendLayout();
       this.button1.Location = new System.Drawing.Point(100, 43);
       this.button1.Size = new System.Drawing.Size(75, 23);
       this.button1.Text = "Click!";
       this.Controls.Add(this.button1);
       this.button1.Click += new EventHandler(this.button1_Click);

       this.Text = "ThreadException";
       this.ResumeLayout(false);
    }

    // Throw an exception when the button is clicked.
    private void button1_Click(object sender, System.EventArgs e)
    {
       throw new ArgumentException("The parameter was invalid");
    }
 
    public static void Main()
    {
       // Add the event handler.
       Application.ThreadException += new ThreadExceptionEventHandler(CustomExceptionHandler.OnThreadException);

       // Start the example.
       Application.Run(new ErrorForm());
    }
 }
 
 // Create a class to handle the exception event.
 internal class CustomExceptionHandler
 {
     // Handle the exception event
    public static void OnThreadException(object sender, ThreadExceptionEventArgs t)
    {
       DialogResult result = ShowThreadExceptionDialog(t.Exception);

       // Exit the program when the user clicks Abort.
       if (result == DialogResult.Abort) 
          Application.Exit();
    }
 
    // Create and display the error message.
    private static DialogResult ShowThreadExceptionDialog(Exception e)
    {
       string errorMsg = "An error occurred.  Please contact the adminstrator " +
            "with the following information:\n\n";
       errorMsg += String.Format("Exception Type: {0}\n\n", e.GetType().Name);
       errorMsg += "\n\nStack Trace:\n" + e.StackTrace;
       return MessageBox.Show(errorMsg, "Application Error", 
            MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
    }
 }
 
// </Snippet1>

