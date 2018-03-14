<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Protected Sub Page_Load(ByVal byvalsender As Object, _
        ByVal e As EventArgs)

        If Not IsPostBack Then
            ' Add items to the list
            SelectionList1.Items.Add(New _
                MobileListItem("Verify transactions", "Done"))
            SelectionList1.Items.Add(New _
                MobileListItem("Check balance sheet", "Scheduled"))
            SelectionList1.Items.Add(New _
                MobileListItem("Call customer", "Done"))
            SelectionList1.Items.Add(New _
                MobileListItem("Send checks", "Pending"))
            SelectionList1.Items.Add(New _
                MobileListItem("Send report", "Pending"))
            SelectionList1.Items.Add(New _
                MobileListItem("Attend meeting", "Scheduled"))

            ' Show all items in list
            SelectionList1.Rows = SelectionList1.Items.Count
        End If
    End Sub
    
    Private Sub TextChanged(ByVal sender As Object, _
        ByVal e As EventArgs)

        ' Called during PostBack, if changed
        Dim task As String = TextBox1.Text
        Dim status As String = TextBox2.Text
        
        If (task.Length > 0 AndAlso status.Length > 0) Then
            Dim li As New MobileListItem(task, status)

            ' Remove the item if it exists
            If (SelectionList1.Items.Contains(li)) Then
                SelectionList1.Items.Remove(li)
            Else
                ' Add the item if it does not exist
                SelectionList1.Items.Add(li)
            End If

            ' Clear the text boxes
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If

        ' Display all items.
        SelectionList1.Rows = SelectionList1.Items.Count
    End Sub
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server">
        <mobile:Label Id="Label1" runat="server">
            Create a new Task with Status</mobile:Label>   
        <mobile:SelectionList runat="server" 
            SelectType="ListBox"
            id="SelectionList1" />
        <mobile:Label Id="Label2" runat="server" 
            Text="Enter the Task name" />
        <mobile:TextBox runat="server" id="TextBox1" 
            OnTextChanged="TextChanged" />
        <mobile:Label Id="Label3" runat="server" 
            Text="Enter the Task status" />
        <mobile:TextBox runat="server" id="TextBox2" />
        <mobile:Command ID="Command1" runat="server" 
            Text="Submit" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
