using System;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

public class Form1: Form
{
// <Snippet1>
 // The specified IDesigner implements IUIService.
 Font GetFont(IDesigner designer)
 {      
       Font        hostfont;
 
       // Gets the dialog box font from the host environment. 
       hostfont = (Font)((IUIService)designer).Styles["DialogFont"];
       
       return hostfont;
 }
    
// </Snippet1>
}
