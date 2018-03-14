using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
public void MoveMyForm()
 {
    // Create a Point object that will be used as the location of the form.
    Point tempPoint = new Point(100,100);
    // Set the location of the form using the Point object.
    this.DesktopLocation = tempPoint;
 }
   
// </Snippet1>
}
