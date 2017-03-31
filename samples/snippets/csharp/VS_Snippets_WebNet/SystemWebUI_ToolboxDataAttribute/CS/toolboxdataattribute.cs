/*
 *File Name: toolBoxDataAttribute
 *
 */



//<snippet1>

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CustomControls
{

  [ ToolboxData("<{0}:MyLabel Text='MyLabel' BorderColor='Yellow' BackColor='Magenta' BorderWidth = '10'  runat='server'></{0}:MyLabel>") ]	
  public class MyLabel : Label 
  {
    public  MyLabel()
    { 
      // Your code goes here.
    } 
  }

}

//</snippet1>


