using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected Panel panel1;
// <Snippet1>
private void SetAutoScrollMargins()
 {
    /* If the text box is outside the panel's bounds, 
       turn on auto-scrolling and set the margin. */  
    if (text1.Location.X > panel1.Location.X || 
       text1.Location.Y > panel1.Location.Y)
    {
       panel1.AutoScroll = true;
       /* If the AutoScrollMargin is set to less 
          than (5,5), set it to 5,5. */
       if( panel1.AutoScrollMargin.Width < 5 || 
          panel1.AutoScrollMargin.Height < 5)
       {
          panel1.SetAutoScrollMargin(5, 5);
       }
    }
 }
 
// </Snippet1>
}
