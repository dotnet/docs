   public class MyControl1 : Control, IPostBackEventHandler
   {
      // Create an integer property that is displayed when
      // the page that contains this control is requested
      // and save it to the control's ViewState property.
      public int Number
      {
        get
        {
          if ( ViewState["Number"] !=null )
          return (int) ViewState["Number"];
          return 50;
        }

        set
        {
          ViewState["Number"] = value;
        }        
      }

      // Implement the RaisePostBackEvent method from the
      // IPostBackEventHandler interface. If 'inc' is passed
      // to this method, it increases the Number property by one.
      public void RaisePostBackEvent(string eventArgument)
      {
        Number = Number + 1;
      }

      
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
      protected override void Render(HtmlTextWriter writer)
      {
        // Converts the Number property to a string and
	// writes it to the containing page.
        writer.Write("The Number is " + Number.ToString() + " (" );

	// Uses the GetPostBackEventReference method to pass
	// 'inc' to the RaisePostBackEvent method when the link
	// this code creates is clicked.
        writer.Write("<a href=\"javascript:" + Page.GetPostBackEventReference(this) + "\">Increase Number</a>");
      }
   }