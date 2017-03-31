<%--<Snippet1>--%>
' Create a page that accesses the view state of an ASP.NET custom 
' server control.
<%@ Register TagPrefix="Custom" Namespace="ViewStateSamples1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="vb" runat="server">

' Declare a StateItem object so that the StateItem class 
' can be accessed by the page.
Public myStateItem As StateItem


Public Sub Page_Load(sender As [Object], e As EventArgs)
' <snippet3>
   ' Create a StateBag object to contain the view state 
   ' associated with the custom control named myControl. Use the
   ' StateBag.GetEnumerator method to create an
   ' IDictionaryEnumerator named myDictionaryEnumerator.
   Dim ctlOne As New ctlViewState1()
   Dim myStateBag As New StateBag()
   myStateBag = ctlOne.GetState()
   Dim myDictionaryEnumerator As IDictionaryEnumerator = myStateBag.GetEnumerator()
   
' </snippet3>
   ' Get each StateItem stored in the Control's view state. 
   While(myDictionaryEnumerator.MoveNext())
' <snippet4>
      ' Set the myStateItem object to the values encountered
      ' by the enumerator. 
      myStateItem = CType(myDictionaryEnumerator.Value, StateItem)
      
      ' Check whether the StateItem is modified and then write
      ' its value and a string stating whether it is modified.
      If myStateItem.IsDirty Then       
             Response.Write("<br />"+ myStateItem.Value + " is modified" )
      Else
             Response.Write("<br />"+ myStateItem.Value + " is not modified" )
 
      End If 
' </snippet4>
   End While
End Sub 'Page_Load


Public Sub Button_Click(sender As [Object], e As EventArgs)
   myControl.Text = myTextBox.Text
   myControl.FontSize = 14
End Sub 'Button_Click

  </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>StateItem Example</title>
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