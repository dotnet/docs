using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected Label label1;
 protected ScrollBar vScrollBar1, hScrollBar1;
// <Snippet1>
private void AddMyScrollEventHandlers()
 {
    // Create and initialize a VScrollBar.
    VScrollBar vScrollBar1 = new VScrollBar();
 
    // Add event handlers for the OnScroll and OnValueChanged events.
    vScrollBar1.Scroll += new ScrollEventHandler(
       this.vScrollBar1_Scroll);
    vScrollBar1.ValueChanged += new EventHandler(
       this.vScrollBar1_ValueChanged); 
 }
 
 // Create the ValueChanged event handler.
 private void vScrollBar1_ValueChanged(Object sender, 
                                       EventArgs e)
 {
     // Display the new value in the label.
     label1.Text = "vScrollBar Value:(OnValueChanged Event) " + vScrollBar1.Value.ToString();
 }
 
 // Create the Scroll event handler.
 private void vScrollBar1_Scroll(Object sender, 
                                 ScrollEventArgs e)
 {
     // Display the new value in the label.
     label1.Text = "VScrollBar Value:(OnScroll Event) " + e.NewValue.ToString();
 }
 
 private void button1_Click(Object sender, 
                           EventArgs e)
 {
    // Add 40 to the Value property if it will not exceed the Maximum value.
    if (vScrollBar1.Value + 40 < vScrollBar1.Maximum)
    {
        vScrollBar1.Value = vScrollBar1.Value + 40;
    }
 }
 
// </Snippet1>
}
