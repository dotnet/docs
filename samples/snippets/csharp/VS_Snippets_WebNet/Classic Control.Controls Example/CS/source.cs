using System;
using System.Data;
using System.Web.UI;

public class Form1: Control
{
 
 public void Method()
 {
// <Snippet1>
Controls.Add(new LiteralControl("<h3>Value: "));
// </Snippet1>
 }
}
