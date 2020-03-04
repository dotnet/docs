<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Add Controls to a Web Forms Page Programmatically</title>
</head>

<script runat="server">
    
    Private Sub Page_Load()
        
        '<Snippet2>
        Dim myLabel As New Label()
        myLabel.Text = "Sample Label"
        '</Snippet2>
    
        '<Snippet3>
        Dim Panel1 As New Panel()
        Panel1.Controls.Add(myLabel)
        '</Snippet3>
        
    End Sub
        
    '<Snippet4>
    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim DropDownList1 As New DropDownList()
        Dim PlaceHolder1 As New PlaceHolder()
        Dim i As Integer
        Dim numlabels As Integer
        
        ' Get the number of labels to create.
        numlabels = CInt(DropDownList1.SelectedItem.Text)
        For i = 1 To numlabels
            Dim myLabel As Label = New Label()
            ' Set the label's Text and ID properties.
            myLabel.Text = "Label " & i
            myLabel.ID = "Label" & i
            PlaceHolder1.Controls.Add(myLabel)
            ' Add a spacer in the form of an HTML <br /> element
            Dim spacer As LiteralControl = New LiteralControl("<br />")
            PlaceHolder1.Controls.Add(spacer)
        Next
    End Sub
    '</Snippet4>
    
</script>

<body>
    <form id="form1" runat="server">
    <div>
      <asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
