// <Snippet2>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[PartialCaching(100)]
public class LogOnControl:UserControl
{
    public TextBox user;
    public TextBox password;
}
// </Snippet2>