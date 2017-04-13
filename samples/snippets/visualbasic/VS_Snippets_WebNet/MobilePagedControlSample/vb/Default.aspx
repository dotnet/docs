<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Security.Permissions" %>

<script runat="server">
    ' A custom list control for illustration
    < _
    AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class ListControl
        Inherits List

        Public Sub New()
            MyBase.New()
        End Sub

        ' Set a weight for the items
        Protected Overrides ReadOnly _
            Property ItemWeight() As Integer
            Get
                Return 150
            End Get
        End Property
    End Class

    Dim WithEvents List1 As ListControl
    
    Private Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        ' Instantiate the custom control
        List1 = New ListControl()
        List1.ItemCount = 20
        List1.ID = "List1"
        Form1.Controls.Add(List1)

        Form1.ControlToPaginate = List1
    End Sub

    ' Called by the List whenever it needs new items
    Private Sub LoadNow(ByVal sender As Object, _
        ByVal e As LoadItemsEventArgs) _
        Handles List1.LoadItems

        Dim j As Integer = e.ItemIndex
        
        ' You have to estimate the item size
        Dim estItemSize As Integer = 110

        ' Get the optimum page weight for the device
        Dim wt As Integer = _
            Form1.Adapter.Page.Adapter.OptimumPageWeight
        ' Get the number of items per page
        List1.ItemsPerPage = wt / estItemSize
 
        ' Build a section of the array
        Dim arr As New ArrayList()
        For i As Integer = 1 To e.ItemCount
            Dim v As Integer = i + j
            arr.Add((v.ToString() + " List Item"))
        Next

        ' Bind the array to the list
        List1.DataSource = arr
        List1.DataBind()
    End Sub
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" 
        Paginate="true">
        <mobile:TextView ID="TextView1" 
            Runat="server" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->