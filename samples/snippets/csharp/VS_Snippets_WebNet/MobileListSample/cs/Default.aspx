<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    // Persist across multiple postbacks.
    private static int doneCount, schedCount, pendCount;

    // <Snippet3>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set the DataMembers of the List
            List1.DataValueField = "Status";
            List1.DataTextField = "TaskName";

            // Create an ArrayList of task data
            ArrayList arr = new ArrayList();
            arr.Add(new Task("Define transactions", "scheduled"));
            arr.Add(new Task("Verify transactions", "scheduled"));
            arr.Add(new Task("Check balance sheet", "scheduled"));
            arr.Add(new Task("Compile balance sheet", "scheduled"));
            arr.Add(new Task("Prepare report", "scheduled"));
            arr.Add(new Task("Send report", "scheduled"));

            // Bind the array to the list
            List1.DataSource = arr;
            List1.DataBind();

            const string spec = "Start: {0} tasks are done, {1} " +
               "tasks are scheduled, and {2} tasks are pending.";
            Label2.Text = String.Format(spec, doneCount, +
                schedCount, pendCount);

            List1.Decoration = ListDecoration.Bulleted;
        }
    }
    // </Snippet3>

    // <Snippet2>
    private void Status_ItemCommand(object sender, 
        ListCommandEventArgs e)
    {
        const string spec = "You now have {0} " + 
            "tasks done, {1} tasks scheduled, and " +
            "{2} tasks pending.";

        // Move selection to next status toward 'done'
        switch (e.ListItem.Value)
        {
            case "scheduled":
                schedCount -= 1;
                pendCount += 1;
                e.ListItem.Value = "pending";
                break;
            case "pending":
                pendCount -= 1;
                doneCount += 1;
                e.ListItem.Value = "done";
                break;
        }

        // Show the status of the current task
        Label1.Text = e.ListItem.Text + " is " +
            e.ListItem.Value;

        // Show current selection counts
        Label2.Text = String.Format(spec, doneCount, 
            schedCount, pendCount);
    }
    // </Snippet2>

    // <Snippet4>
    private void Status_DataBinding(object sender, 
        ListDataBindEventArgs e)
    {
        // Increment initial counts
        switch (e.ListItem.Value)
        {
            case "done":
                doneCount += 1;
                break;
            case "scheduled":
                schedCount += 1;
                break;
            case "pending":
                pendCount += 1;
                break;
        }
    }
    // </Snippet4>
    
    // Custom class for the ArrayList items
    private class Task
    {
        private string _TaskName;
        private string _Status;

        public Task(string taskName, string status)
        {
            _TaskName = taskName;
            _Status = status;
        }
        
        public string TaskName
        {
            get { return _TaskName; }
        }
        
        public string Status
        {
            get { return _Status; }
        }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label ID="Label3" Runat="server">
            Click a task to change its status from 
            scheduled to pending or from pending to done:
        </mobile:Label>
        <mobile:List runat="server" id="List1" 
            OnItemCommand="Status_ItemCommand" 
            OnItemDataBind="Status_DataBinding" />
        <mobile:Label runat="server" id="Label1" 
            ForeColor="green" Font-Italic="true" />
        <mobile:Label id="Label2" runat="server" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
