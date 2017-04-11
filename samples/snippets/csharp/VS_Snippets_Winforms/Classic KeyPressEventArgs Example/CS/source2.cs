using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
public class Form1:Form
{
    public TextBox textBox1;
    // <Snippet2>
    myKeyPressClass myKeyPressHandler = new myKeyPressClass();
    public Form1()
    {
         InitializeComponent();
     
         textBox1.KeyPress += new KeyPressEventHandler(myKeyPressHandler.myKeyCounter);
    }
    // </Snippet2>
    private void InitializeComponent() {
    }
    public class myKeyPressClass 
    {
        internal void myKeyCounter(object sender, KeyPressEventArgs ex){
        }
    }

}

