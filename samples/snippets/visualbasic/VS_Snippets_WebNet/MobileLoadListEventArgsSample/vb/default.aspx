<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    ' Called by the List whenever it needs new items
    Private Sub LoadNow(ByVal sender As Object, _
        ByVal e As LoadItemsEventArgs)
        
        Dim i, j As Integer
        i = 0
        j = e.ItemIndex
        Dim estItemSize As Integer = 110

        ' Get the optimum page weight for the device
        Dim wt As Integer = _
            form1.Adapter.Page.Adapter.OptimumPageWeight
        ' Get the number of items per page
        List1.ItemsPerPage = wt / estItemSize

        ' Clear the current items
        List1.Items.Clear()
        
        ' Build a section of the array
        Dim arr As New ArrayList()
        For i = 1 To e.ItemCount
            arr.Add(j + i)
        Next
        
        ' Assign the array to the list
        List1.DataSource = arr
        List1.DataBind()
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server" Paginate="true">
        <mobile:List id="List1" runat="server" 
            ItemCount="200" onLoadItems="LoadNow" 
            ItemsPerPage="8" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
