<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    private void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Create array and add the tasks to it.
            ArrayList arr = new ArrayList();
            arr.Add(new Task("Verify transactions", "Done"));
            arr.Add(new Task("Check balance sheet", "Scheduled"));
            arr.Add(new Task("Send report", "Pending"));

            // Bind the List to the ArrayList
            ObjectList1.DataSource = arr;
            ObjectList1.DataBind();
        }
        ObjectList1.DefaultCommand = "Check";
    }

    // Event handler for all ObjectList1 commands
    private void SelectCommand(Object sender, 
        ObjectListCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Check")
            ActiveForm = Form2;
        else if (e.CommandName.ToString() == "Browse")
            ActiveForm = Form3;
    }

    // Custom class for the ArrayList items
    private class Task
    {
        private String _TaskName, _Status;

        public Task(String TaskName, String Status)
        {
            _TaskName = TaskName;
            _Status = Status;
        }
        public String TaskName
        {
            get { return _TaskName; }
        }
        public String Status
        {
            get { return _Status; }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server">
        <mobile:ObjectList runat="server" id="ObjectList1" 
            OnItemCommand="SelectCommand">
            <Command Name="Check" Text="Check Appointments" />
            <Command Name="Browse" Text="Browse Tasks" />
        </mobile:ObjectList>
    </mobile:form>
    <mobile:Form ID="Form2" Runat="server">
        <mobile:Label ID="Label1" Runat="server">
            Check Appointments</mobile:Label>
        <mobile:Link ID="Link1" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:Link>
    </mobile:Form>
    <mobile:Form ID="Form3" Runat="server">
        <mobile:Label ID="Label2" Runat="server">
            Browse Tasks</mobile:Label>
        <mobile:Link ID="Link2" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:Link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->