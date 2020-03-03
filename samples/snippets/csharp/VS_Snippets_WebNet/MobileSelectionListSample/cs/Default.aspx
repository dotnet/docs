<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Create data for the list
            ArrayList arr = new ArrayList();
            arr.Add (new 
                Task ("Verify transactions", "Done"));
            arr.Add (new 
                Task ("Check balance sheet", "Scheduled"));
            arr.Add (new 
                Task ("Call customer",       "Done"));
            arr.Add (new 
                Task ("Issue checks",          "Pending"));
            arr.Add (new 
                Task ("Send report",         "Pending"));
            arr.Add (new 
                Task ("Attend meeting",      "Scheduled"));
            
            // Set properties for the list
            SelList1.SelectType = 
                ListSelectType.ListBox;
            SelList1.Wrapping = Wrapping.NoWrap;
            SelList1.DataValueField = "Status";
            SelList1.DataTextField  = "TaskName";
            SelList1.Rows = 3;

            // Bind the list to the data
            SelList1.DataSource = arr;
            SelList1.DataBind ();

            Label1.Text = "Select an item and click the button.";
            Label2.Text = "Tasks are arranged by priority";
        }
    }
    
    void ShowStatus(Object sender, EventArgs e)
    {
        string statusSpec = "Status: {0} is {1}";
        string prioSpec = "Priority: {0}";
        
        // Expand the list to show all items
        SelList1.Rows = SelList1.Items.Count;

        // Display the status
        Label1.Text = String.Format(statusSpec, 
            SelList1.Selection.Text,
            SelList1.Selection.Value);
        // Display the priority
        Label2.Text = String.Format(prioSpec, 
            (SelList1.SelectedIndex + 1));
    }

    // Custom class for the task data
    class Task
    {
        private String _TaskName;
        private String _Status;

        public Task(String TaskName, String Status)
        {
            _TaskName = TaskName;
            _Status = Status;
        }
        public String TaskName { get { return _TaskName; } }
        public String Status { get { return _Status; } }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1">
        <mobile:Label runat="server" id="Label1" />
        <mobile:Label runat="server" id="Label2" />
        <mobile:SelectionList runat="server" id="SelList1" 
            OnSelectedIndexChanged="ShowStatus" />
        <mobile:Command ID="Command1" runat="server" 
            Text="Show Status" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
