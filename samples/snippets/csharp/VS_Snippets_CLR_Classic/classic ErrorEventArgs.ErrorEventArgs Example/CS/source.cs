using System;
using System.IO;
using System.Windows.Forms;

public class Form1 : Form {

// <Snippet1>

 public static void Main(string[] args) {
    //Creates an exception with an error message.
    Exception myException= new Exception("This is an exception test");
 
    //Creates an ErrorEventArgs with the exception.
    ErrorEventArgs myErrorEventArgs = new ErrorEventArgs(myException);
 
    //Extracts the exception from the ErrorEventArgs and display it.
    Exception myReturnedException = myErrorEventArgs.GetException();
    MessageBox.Show("The returned exception is: " + myReturnedException.Message);
 }
// </Snippet1>

}
