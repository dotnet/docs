<%--<Snippet1>--%>
// Create a page that accesses the view state of an ASP.NET custom 
// server control.
<%@ Register TagPrefix="Custom" Namespace="ViewStateSamples1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <script language="c#" runat="server">
   // Declare a StateItem object so that the StateItem class 
   // can be accessed by the page.
   public StateItem myStateItem;

   public void Page_Load(Object sender, EventArgs e)
   {
// <snippet3>
      // Create a StateBag object to contain the view state 
      // associated with the custom control named myControl. Use the
      // StateBag.GetEnumerator method to create an
      // IDictionaryEnumerator named myDictionaryEnumerator.
      ctlViewState1 ctlOne = new ctlViewState1();
      StateBag myStateBag = new StateBag(); 
      myStateBag = ctlOne.GetState();
      IDictionaryEnumerator myDictionaryEnumerator = myStateBag.GetEnumerator();
// </snippet3>

      // Get each StateItem stored in the Control's view state. 
      while(myDictionaryEnumerator.MoveNext())
      {
         // <snippet4>
         // Set the myStateItem object to the values encountered
         // by the enumerator. 
         myStateItem = (StateItem)myDictionaryEnumerator.Value;

         // Check whether the StateItem is modified and then write
         // its value and a string stating whether it is modified.
         if(myStateItem.IsDirty)
         {
           Response.Write("<br />"+ myStateItem.Value + " is modified" );
         }
         else
            Response.Write("<br />"+ myStateItem.Value + " is not modified" );
         // </snippet4>

      } 
   }

   public void Button_Click(Object sender, EventArgs e)
   {
      myControl.Text = myTextBox.Text;
      myControl.FontSize = 14;
   }
  </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
            StateItem Example
         </title>
</head>
<body>
      <form method="post" action="FirstControl.aspx" runat="server" id="Form1">
         <h3>
            StateItem Example
         </h3>
         <Custom:ctlViewState1 id="myControl" Text="Message" FontSize="12" runat="server" />
         <br />
         <asp:TextBox ID="myTextBox" Text="Enter value to view state" runat="server" />
         <br /><br />
         <asp:Button ID="myButton" Text="Submit" OnClick="Button_Click" Runat="server"></asp:Button>
      </form>
  </body>
</html>
<%--</Snippet1>--%>