<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    // Called by the List whenever it needs new items
    private void LoadNow(object sender, LoadItemsEventArgs e)
    {
        int j = e.ItemIndex;
        int estItemSize = 110;

        // Get the optimum page weight for the device
        int wt = Form1.Adapter.Page.Adapter.OptimumPageWeight;
        // Get the number of items per page
        List1.ItemsPerPage = wt / estItemSize;
 
        // Clear the current items
        List1.Items.Clear();

        // Build a section of the array
        ArrayList arr= new ArrayList();
        for (int i = 1; i <= e.ItemCount; i++)
        {
            int v = i + j;
            arr.Add((v.ToString() + " List Item"));
        }

        // Assign the array to the list
        List1.DataSource = arr;
        List1.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" Paginate="true">
        <mobile:List id="List1" runat="server" 
            ItemCount="200" onLoadItems="LoadNow" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
