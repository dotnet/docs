<!-- AutoGenerateFields -->
<!-- <Snippet5> -->
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
            // Create and fill the array.
            ArrayList arr = new ArrayList();
            arr.Add(new Task("Tomorrow's work", "Yes"));
            arr.Add(new Task("Today's work", "Yes"));
            arr.Add(new Task("Next week's work", "No"));

            // Associate the array to List1.
            List1.DataSource = arr;

            // Turn off automatic field generation
            // because fields were built by hand
            List1.AutoGenerateFields = false;
            List1.DataBind();
        }
    }

    private class Task
    {
        private string _TaskName;
        private string _Editable;
        public Task(string TaskName, string Editable)
        {
            _TaskName = TaskName;
            _Editable = Editable;
        }
        public string TaskName
        { get { return _TaskName; } }
        public string Editable
        { get { return _Editable; } }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1">
        <mobile:ObjectList runat="server" id="List1" >
            <!-- Build the fields -->
            <Field Name="Task Name" DataField="TaskName" 
                Title="Name of Task" />
            <Field Name="Editable?" DataField="Editable" 
                Title="Is Editable?" />
        </mobile:ObjectList>
    </mobile:Form>
</body>
</html>
<!-- </Snippet5> -->
