using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form {
    
    protected Label label1;
    
// <Snippet1>
 public Form1()
 {
    InitializeComponent();
 
    this.label1.Text = this.Handle.ToString();
 }
 
// </Snippet1>

    protected void InitializeComponent() {

    }

}
