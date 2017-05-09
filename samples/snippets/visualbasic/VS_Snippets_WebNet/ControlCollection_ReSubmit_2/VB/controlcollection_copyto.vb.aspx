<%@ Page Language="VB" %>
<!--
      ' System.Web.UI.ControlCollection.CopyTo
      ' System.Web.UI.ControlCollection.Remove
      ' System.Web.UI.ControlCollection.Item
      ' System.Web.UI.ControlCollection.Clear
      The following example demonstrates methods and properties 
      of 'ControlCollection' class. A new Button is inserted on 
      the form. Two LiteralControls are added as child controls 
      to the Button.
      The ControlCollection of Button control is then copied to 
      an array of type object. The array is then enumerated through.
-->
<!-- <Snippet1> -->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)

        Response.Write("<h2>Sample for ControlCollection Class</h2>")
        Dim myLiteralControl As LiteralControl _
            = New LiteralControl("ChildControl1")

        myButton.Controls.Add(myLiteralControl)
        myButton.Controls.AddAt(1, New LiteralControl("ChildControl2"))

        Dim myControlCollectionArray As System.Array = _
            Array.CreateInstance(GetType(Object), _
                myButton.Controls.Count)
        myButton.Controls.CopyTo(myControlCollectionArray, 0)

        Dim myEnumerator1 As IEnumerator = _
            myControlCollectionArray.GetEnumerator()

        While myEnumerator1.MoveNext()
            Dim myObject As Object = myEnumerator1.Current

            If myObject.GetType().Equals(GetType(LiteralControl)) Then
                Dim childControl As LiteralControl _
                    = CType(myEnumerator1.Current, LiteralControl)
                Response.Write("<p style=""font-weight:bold"">")
                Response.Write("This is the  text of the child Control:" _
                    & Server.HtmlEncode(childControl.Text))
            End If
        End While

        myButton.Controls.Remove(myButton.Controls(0))
        Response.Write("</p><p style=""font-weight:bold"">ChildControl1 is removed")
        Response.Write("<br />The count of ControlCollection = " _
            & myButton.Controls.Count.ToString() & "</p>")
        myButton.Controls.Clear()

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sample for ControlCollection Class</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="myButton" Text="Sample ServerControl" 
            Runat="server"></asp:Button>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->