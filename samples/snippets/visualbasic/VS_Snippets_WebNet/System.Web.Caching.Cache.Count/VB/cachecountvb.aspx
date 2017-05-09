<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >   
 <script runat="server">

  Public Sub Page_Load(sender As [Object], e As EventArgs)
    If Not IsPostBack Then
      Cache("Key1") = "Value1"
    End If

' <snippet1>
      ' Convert the Count property to a string
      ' and display its value in a Label server control.    
       Label1.Text = "The number of items in the cache:" + Cache.Count.ToString()
' </snippet1>
  End Sub 'Page_Load
 

  Public Sub cmdAdd_Click(objSender As [Object], objArgs As EventArgs)
   
   ' Add this item to the cache.
   Cache("Text") = txtValue.Text

  End Sub 'cmdAdd_Click 
 </script>

 <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
   <form id="form1" runat="server">
    <asp:TextBox id="txtValue" runat="server"/><br />
    <asp:Label id="Label1" runat="server"/><br />
    <asp:button id="cmdAdd" text="Add item to Cache" OnClick="cmdAdd_Click" runat="server" />
    
   </form>
 </body>
</html>
