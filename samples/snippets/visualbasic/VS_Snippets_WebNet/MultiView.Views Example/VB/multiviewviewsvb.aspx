
<!--<Snippet1>-->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ViewCollection Class Example</title>
<script runat="server">

        Sub Index_Changed(ByVal Sender As Object, ByVal e As EventArgs)
            ' A MultiView was added to the page declaratively.
            ' Now add the View control programmatically.            
            
            If SelectViewListBox.SelectedIndex >= 0 Then
                ' The user selected a view.
                ' Determine which view the user selected.
            
                Dim viewName As String = SelectViewListBox.SelectedItem.Text
                Dim myView as New View

                ' Use a helper function to create the view.
                myView = CreateView(viewName, "This is " + viewName)

                ' Add myView to the ViewCollection of the MultiView1 control.
                MultiView1.Views.Add(myView)

                ' Set myView as the active view.
                MultiView1.SetActiveView(myView)

                ' The Panel control was initially set to not visible.
                ' Set it to visible to add styles to the myView.
                Panel1.Visible=True
          
            Else
                Throw New Exception("You did not select a valid view.")

            End If

        End Sub
        
        ' A function to programmatically create a View control.
        Private Function CreateView(ByVal viewId As String, ByVal viewDescription As String) As View
            ' Create a View control
            Dim myView As New View
            myView.ID = viewId
            
            ' Create a Label control.
            Dim Label1 As New Label

            ' Set the text property for the label.
            Label1.Text = viewDescription
            
            ' Add the label to the controls collection of the view.
            myView.Controls.Add(Label1)
            
            Return myView
        End Function

</script>
 
</head>
<body>

    <form id="Form1" runat="server">

        <h3>ViewCollection Class Example</h3>

        <h4>Select a View to create and display in a MultiView control:</h4>
            
        <asp:ListBox ID="SelectViewListBox"
            AutoPostBack="True"
            Rows="1"
            SelectionMode="Single"
            OnSelectedIndexChanged="Index_Changed"
            runat="Server">
            <asp:ListItem Value="0">View1</asp:ListItem>
            <asp:ListItem Value="1">View2</asp:ListItem>
        </asp:ListBox><br /><br />
        
        <hr /><br /> 
        
        <asp:Panel ID="Panel1"
            Height="75px"
            Width="100px"
            Backcolor="Aqua"
            BorderStyle="Double" 
            Visible = "False"
            runat="Server"> 

            <asp:MultiView ID="MultiView1"
                runat="Server">
            </asp:MultiView>

        </asp:Panel>
    
    </form>
   
</body>
</html>
<!--</Snippet1>-->