<!-- <Snippet13> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ' If both name and value are specified
        ' use the Add method to add the item to session-state.
        If (Not String.IsNullOrEmpty(TextBox1.Text) And _
            Not String.IsNullOrEmpty(TextBox2.Text)) Then
            
            Dim itemName As String = Server.HtmlEncode(TextBox1.Text)
            Dim itemValue As String = Server.HtmlEncode(TextBox2.Text)
            Session.Add(itemName, itemValue)
            ' Refresh the Repeater control.
            RefreshRepeater()
            
        End If        
    End Sub
    
    Protected Sub RefreshRepeater()
        
        ' Use the GetEnumerator method to 
        ' iterate through the session-state.
        Dim values As ArrayList = New ArrayList()
        Dim ie As System.Collections.IEnumerator = Session.GetEnumerator()
        Dim currentSessionItemName As String
        While (ie.MoveNext())
            
            currentSessionItemName = CType(ie.Current, String)
            values.Add(New SessionDataDisplay(currentSessionItemName, _
                Session(currentSessionItemName).ToString()))
        End While
        ' Bind values ArrayList to Repeater control.
        Repeater1.DataSource = values
        Repeater1.DataBind()
        
    End Sub
    
    Public Class SessionDataDisplay
        
        Private _name As String
        Private _value As String
        
        Public Sub New(ByVal name As String, ByVal value As String)
            
            Me._name = name
            Me._value = value
            
        End Sub
        Public ReadOnly Property Name() As String
            Get
                Return _name
            End Get
        End Property
        
        Public ReadOnly Property Value() As String
            Get
                Return _value
            End Get
        End Property
        
    End Class

    Protected Sub Repeater1_ItemCommand(ByVal source As Object, _
           ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs)

        ' Determine which item to remove and
        ' use the Remove method to remove it.
        Dim itemToRemove As RepeaterItem = e.Item
        Dim sessionItemToRemove As String = _
            CType(itemToRemove.FindControl("Label1"), Label).Text
        Session.Remove(sessionItemToRemove)
        ' Refresh the Repeater control.
        RefreshRepeater()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpSessionState Example</title>
</head>
<body>
    <form id="form1" 
          runat="server" 
          defaultbutton="Button1" 
          defaultfocus="TextBox1">
    <div>
        Name
        <asp:TextBox ID="TextBox1"
                     runat="server"></asp:TextBox>
        <br />
        Value
        <asp:TextBox ID="TextBox2" 
                     runat="server"></asp:TextBox>
        <asp:Button ID="Button1" 
                    runat="server" 
                    OnClick="Button1_Click" 
                    Text="Add" />
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <ItemTemplate>
             <br />
                SessionState Item Name:  
                <asp:Label ID="Label1" 
                           runat="server" 
                           Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'/>,
                SessionState Item Value: 
                <asp:Label ID="Label2" 
                           runat="server" 
                           Text='<%# DataBinder.Eval(Container.DataItem, "Value") %>'/>
                <asp:Button ID="RemoveItem" 
                            Text="Remove" 
                            runat="server" />
          </ItemTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet13> -->