<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Label1.Text = "Select an item"

            ' Create and fill an array list.
            Dim listValues As New ArrayList()
            listValues.Add("One")
            listValues.Add("Two")
            listValues.Add("Three")

            ' Bind the array to the list.
            SelList1.DataSource = listValues
            SelList1.DataBind()

            ' Set the SelectType.
            SelList1.SelectType = ListSelectType.Radio
        Else
            If (SelList1.SelectedIndex > -1) Then
                ' To show the selection, use the Selection property.
                Label1.Text = "Your selection is " & _
                    SelList1.Selection.Text

                ' Or, show the selection by using 
                ' the MobileListItemCollection class.
                ' Get the index of the selected item
                Dim idx As Integer = SelList1.SelectedIndex
                Label2.Text = "You have selected " & _
                    SelList1.Items(idx).Text

                ' Insert a copy of the selected item
                Dim mi As MobileListItem = SelList1.Selection
                Label3.Text = "The index of your selection is " & _
                    mi.Index.ToString()
                SelList1.Items.Insert(idx, _
                    New MobileListItem(mi.Text + " Copy"))
            Else
                Label1.Text = "No items selected"
            End If
        End If
    End Sub
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label id="Label1" runat="server" 
            Text="Show a list" />
        <mobile:Label id="Label2" runat="server" />
        <mobile:Label id="Label3" runat="server" />
        <mobile:SelectionList runat="server" 
            id="SelList1" />
        <mobile:Command id="Command1" runat="server" 
            Text=" OK " />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
