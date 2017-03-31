using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

    // <Snippet1>
    public class myKeyPressClass 
     {
         static long keyPressCount = 0 ;
         static long backspacePressed =  0;
         static long returnPressed = 0 ;
         static long escPressed = 0 ;
         private TextBox textBox1 = new TextBox();
         private void myKeyCounter(object sender, KeyPressEventArgs ex)
         {
         switch(ex.KeyChar)
         {
                 // Counts the backspaces.
             case '\b':
             backspacePressed = backspacePressed + 1;
             break ;
                 // Counts the ENTER keys.
             case '\r':
             returnPressed = returnPressed + 1 ;
             break ;
                 // Counts the ESC keys.  
             case (char)27:
             escPressed = escPressed + 1 ;
             break ;
                 // Counts all other keys.
             default:
             keyPressCount = keyPressCount + 1 ;
             break;
         }
         
         textBox1.Text = 
             backspacePressed + " backspaces pressed\r\n" + 
             escPressed + " escapes pressed\r\n" +
             returnPressed + " returns pressed\r\n" +
             keyPressCount + " other keys pressed\r\n" ;
         ex.Handled = true ;
         }
     }
     // </Snippet1>
