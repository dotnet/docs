// System.Web.UI.Control.Page;
/*
  The following example demonstrates the 'Page' property
  of 'Control' Class. 
*/

using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSample 
{
   public class Simple : Control 
	{
// <Snippet1>
      protected override void Render(HtmlTextWriter output) 
	   {
         output.Write("Welcome to Control Development!<br>");

			// Test if the page is loaded for the first time
			if (!Page.IsPostBack)
				output.Write("Page has just been loaded");
		   else
				output.Write("Postback has occured");
       }
  // </Snippet1>
    }    
}