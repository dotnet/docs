using System;
using System.Drawing;
using System.Windows.Forms;

public class Sample {

    protected RadioButton radioButton1;

//<Snippet1>
 private void radioButton1_CheckedChanged(Object sender, 
                                          EventArgs e)
 {
    // Change the check box position to be opposite its current position.
    if (radioButton1.CheckAlign == ContentAlignment.MiddleLeft)
    {
       radioButton1.CheckAlign = ContentAlignment.MiddleRight;
    }
    else
    {
       radioButton1.CheckAlign = ContentAlignment.MiddleLeft;
    }
 }
 
//</Snippet1>

}
