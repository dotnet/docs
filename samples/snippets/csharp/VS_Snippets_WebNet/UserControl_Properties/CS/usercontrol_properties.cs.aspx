<%@ Page Language="C#" Debug = "true"%>
<%@ Import NameSpace = "System.Collections"%>
<%@ Register TagPrefix="MyUserControl" TagName="simplemessage" Src="UserControl_Properties.cs.ascx" %>
<%@ Reference Control="UserControl_Properties.cs.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
                  Application Variables:
                </title>
</head>
<body>
     <script language="C#" runat="server">
// System.Web.UI.UserControl.Attributes;System.Web.UI.UserControl.Application;
// System.Web.UI.UserControl.Cache

/* The following example demonstrates the properties 'Application', 'Cache' and 'Attributes' of 'UserControl'
   class. 
   It displays the value of 'Message' property for 'MyUserControl:simplemessage' initialized in the asp tags.
   Stores some information in the 'HttpApplicationState' of UserControl. It also stores some value in the 
   Cache with absolute expiration set to 0.1 minute. Clicking on 'Force PostBack' button displays the values. 
  
   Note : Click 'Force PostBack' button once and wait for some time before clicking it again.
          If cache expires in that time an appropriate message will be displayed.
*/

void Page_Load(object sender, System.EventArgs e)
{
  Response.Write("<h2><b> User Control Properties Example</b></h2><br />");
// <Snippet1>
  // Retrieve and display the 'Message' attribute tag 
  // initialized in the .aspx code.
  Response.Write("<b>Message tag value declared in the aspx file is : </b>" + myControl.Attributes["Message"]);
// </Snippet1>
// <Snippet2>        
  if (!myControl.IsPostBack)
  {
    // Add new objects to the HttpApplicationState.
    // These will be maintained as long as the application is active.
    myControl.Application.Add("Author","Shafeeque");
    myControl.Application.Add("Date",new DateTime(2001,6,21));
    // Add an object to the cache with expirations 
    // set to 0.1 minute.
    myControl.Cache.Insert("MyData1", "somevalue", null, DateTime.Now.AddMinutes(0.1), Cache.NoSlidingExpiration);
  }
// </Snippet2>
  // PostBack occurs when 'Force PostBack' button is clicked and the following code executes.
  else
// <Snippet3>
  {
    // If the Cache items have not expired, display the contents.
    if (myControl.Cache["MyData1"] != null)
      lblCache.Text = "<b>Cache Contents: </b>" + myControl.Cache["MyData1"];
    else
    {
      lblCache.Text = "<b>Cache Contents Expired: </b>";
      lblCache.ForeColor = System.Drawing.Color.Red;
    }
              
    // Display the stored application variables.
    lblAuthor.Text =  "Author : " + myControl.Application["Author"];
    lblDate.Text = "Date  : " + ((DateTime)myControl.Application["Date"]);              
  }
// </Snippet3>
}


    </script>
     <form id="form1" runat="server">
        <table>
          <tr>
             <MyUserControl:simplemessage id="myControl" Message="Hello World" runat="server" />
          </tr>
          <tr>
             <asp:Button ID="display" Text="Force PostBack" Runat="server" />
          </tr>
          <tr>
             <td>
                <h4>
                  Application Variables:
                </h4>
             </td>
             <td>
                <asp:Label ID="lblAuthor" Runat="server" />
                <br />
                <asp:Label ID="lblDate" Runat="server" />
             </td>
             <td>
                <asp:Label ID="lblCache" Runat="server" />
             </td>
          </tr>
        </table>
     </form>
  </body>
</html>
