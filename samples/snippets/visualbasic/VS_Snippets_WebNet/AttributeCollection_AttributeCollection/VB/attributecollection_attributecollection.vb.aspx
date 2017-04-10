<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="vb" runat="server">

' System.Web.UI.AttributeCollection.AttributeCollection(StateBag)

' The following example demonstrates the Constructor 'AttributeCollection(StateBag)' of the 
' 'Web.UI.AttributeCollection' class. On Page Load an instance of AttributeCollection is created
' by passing ViewState as statebag. The statebag internally maintains state of all custom attributes 
' added after postback. 

' <Snippet1>
  Dim myAttributeCollection As AttributeCollection = Nothing 

  Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet2>
      myAttributeCollection = New AttributeCollection(ViewState)
' </Snippet2>
      Response.Write("<h3> AttributeCollection.AttributeCollection Sample </h3>")
      If Not IsPostBack Then
' <Snippet3>
         myAttributeCollection.Add("Color", "Color.Red")
         myAttributeCollection.Add("BackColor", "Color.blue")
' </Snippet3>
' <Snippet4>
         Response.Write("Attribute Collection count before PostBack = " & _
myAttributeCollection.Count.ToString())
' </Snippet4>
         Response.Write("<br /><u><h4>Enumerating Attributes for " & _
                                 "CustomControl before PostBack</h4></u>")
         Dim keys As IEnumerator = myAttributeCollection.Keys.GetEnumerator()
         Dim i As Integer = 1
         Dim key As String
         While keys.MoveNext()
            key = CType(keys.Current, String)
            Response.Write(i.ToString() + ". " + key + "=" + myAttributeCollection(key) + "<br />")
            i += 1
         End While
      Else
         Response.Write("Attribute Collection  count after PostBack = " + _
                                    myAttributeCollection.Count.ToString())
         Response.Write("<br /><u><h4>Enumerating Attributes for " + _
                                 "CustomControl after PostBack</h4></u>")
         Dim keys As IEnumerator = myAttributeCollection.Keys.GetEnumerator()
         Dim i As Integer = 1
         Dim key As String
         While keys.MoveNext()
            key = CType(keys.Current, String)
            Response.Write(i.ToString() + ". " + key + "=" + myAttributeCollection(key) + "<br />")
            i += 1
         End While
      End If
   End Sub
' </Snippet1>
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title> AttributeCollection.AttributeCollection Sample </title>
</head>
   <body>
      <form id="form1" method="post" runat="server">
         <asp:Button Text="Submit" Runat="server"></asp:Button>
         <h5>
            Click Submit Button to force PostBack
         </h5>
      </form>
   </body>
</html>
