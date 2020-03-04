<!-- ShowItemCommands -->
<!-- <Snippet10> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    //System.Web.UI.MobileControls.ObjectListItem item;
    //System.Web.UI.MobileControls.ObjectListItemCollection itemColl;
    // Get the persisted array through postbacks.
    ArrayList arr = new ArrayList();
    public void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Create and fill the array
            arr.Add(new Task("Tomorrow's work", "Yes", 1));
            arr.Add(new Task("Today's work", "Yes", 1));
            arr.Add(new Task("Yesterday's work", "No", 1));
            
            // Persist the array in the Session object
            Session["MyArrayList"] = arr;

            // Associate and bind array to the 
            // ObjectList for each postback.
            ObjectList1.DataSource = arr;
            ObjectList1.LabelField = "TaskName";
            ObjectList1.DataBind();
        }
    }

    private void ItemCommand_Click(Object sender, 
        ObjectListCommandEventArgs e)
    {
        // Get the array from the Session object
        arr = (ArrayList)Session["MyArrayList"];

        // Remove selected item from the ObjectLis
        int i = ObjectList1.SelectedIndex;
        arr.RemoveAt(i);
        Session["MyArrayList"] = arr;

        // Re-Bind ObjectList to altered ArrayList.
        ObjectList1.DataSource = arr;
        ObjectList1.LabelField = "TaskName";
        ObjectList1.DataBind();
        ObjectList1.ViewMode = ObjectListViewMode.List;
    }

    void ItemCommands_Show(Object sender, 
        ObjectListShowCommandsEventArgs e) 
    {
        // Check conditions, and add or remove 
        // commands in the detail view.
        if (e.ListItem["Editable"].Equals("No"))
            ObjectList1.Commands.RemoveAt(0);
        else if (ObjectList1.Commands.Count < 1)
            ObjectList1.Commands.Add(new 
                ObjectListCommand("Delete", "Delete"));
    }

    private class Task
    {
        private string _TaskName;
        private string _Editable;
        private int _Days;
        public Task(string TaskName, string Editable, int Days)
        {
            _TaskName = TaskName;
            _Editable = Editable;
            _Days = Days;
        }
        public string TaskName
        { get { return _TaskName; } }
        public string Editable
        { get { return _Editable; } }
        public int Days
        { get { return _Days; } }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1" >
        <mobile:ObjectList runat="server" id="ObjectList1" 
            OnItemCommand="ItemCommand_Click" 
            OnShowItemCommands="ItemCommands_Show" >
            <Command Name="Delete" Text="Delete" />
        </mobile:ObjectList>
        <mobile:Label runat="server" id="Label1" />
        <mobile:Label runat="server" id="Label2" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet10> -->
