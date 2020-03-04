<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Security.Permissions" %>

<script runat="server">
    // A custom list control for illustration
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal), 
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public class ListControl : List
    {
        public ListControl()
            : base()
        {}

        // Set a weight for the items
        protected override int ItemWeight
        {
            get { return 150; }
        }
    }

    ListControl List1;
    
    private void Page_Load(object sender, 
        System.EventArgs e)
    {
        // Instantiate the custom control
        List1 = new ListControl();
        List1.ItemCount = 20;
        List1.ID = "List1";
        List1.LoadItems += this.LoadNow;
        Form1.Controls.Add(List1);

        Form1.ControlToPaginate = List1;
    }

    // Called by the List whenever it needs new items
    private void LoadNow(object sender, 
        LoadItemsEventArgs e)
    {
        int j = e.ItemIndex;
        // You have to estimate the item size
        int estItemSize = 110;

        // Get the optimum page weight for the device
        int wt = 
            Form1.Adapter.Page.Adapter.OptimumPageWeight;
        // Get the number of items per page
        List1.ItemsPerPage = wt / estItemSize;
 
        // Build a section of the array
        ArrayList arr= new ArrayList();
        for (int i = 1; i <= e.ItemCount; i++)
        {
            int v = i + j;
            arr.Add((v.ToString() + " List Item"));
        }

        // Bind the array to the list
        List1.DataSource = arr;
        List1.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" 
        Paginate="true">
        <mobile:TextView ID="TextView1" 
            Runat="server" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
