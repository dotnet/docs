<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Drawing" %>

<script runat="server">
    // When Form1 is activated
    private void Form1_Activate(object sender, EventArgs e)
    {
        string viewText = "You have viewed this Form {0} times.";
        
        if (count == 0) // First viewing
            message2.Text = "Welcome to the Form Sample";
        else // subsequent viewings
            message2.Text = String.Format(viewText,
              (count + 1).ToString());
        
        // Format the form
        Form1.Alignment = Alignment.Center;
        Form1.Wrapping = Wrapping.NoWrap;
        Form1.BackColor = Color.LightBlue;
        Form1.ForeColor = Color.Blue;
        Form1.Paginate = true;

        // Create an array and add the tasks to it.
        ArrayList arr = new ArrayList();
        arr.Add(new Task("Verify transactions", "Done"));
        arr.Add(new Task("Check balance sheet", "Scheduled"));
        arr.Add(new Task("Send report", "Pending"));

        // Bind the SelectionList to the array.
        SelectionList1.DataValueField = "Status";
        SelectionList1.DataTextField = "TaskName";
        SelectionList1.DataSource = arr;
        SelectionList1.DataBind();
    }

    // <Snippet2>
    // When Form1 is deactivated
    private void Form1_Deactivate(object sender, EventArgs e)
    {
        count++;
    }
    // </Snippet2>

    // <Snippet3>
    // When Form2 is activated
    private void Form2_Activate(object sender, EventArgs e)
    {
        Form2.BackColor = Color.DarkGray;
        Form2.ForeColor = Color.White;
        Form2.Font.Bold = BooleanOption.True;
    }
    // </Snippet3>

    // The the Submit button is clicked
    protected void Command1_OnSubmit(object sender, EventArgs e)
    {
        message2.Text = "FORM RESULTS:";
        message2.Font.Bold = BooleanOption.True;

        // Display a list of selected items with values
        for (int i = 0; i < SelectionList1.Items.Count; i++)
        {
            // Create a string and a TextView control
            TextView txtView = new TextView();
            string txt = "";
            string spec = "{0} is {1}<br />";

            // Display a list of selected items with values
            // Get the list item
            MobileListItem itm = SelectionList1.Items[i];

            // List the selected items and values
            if (itm.Selected)
            {
                txt += String.Format(spec, itm.Text, itm.Value);
            }
            
            // Put the text into the TextView
            txtView.Text = txt;
            // Add txtView to the form
            Form1.Controls.Add(txtView);
        }
        
        // Hide unnecessary controls
        SelectionList1.Visible = false;
        link1.Visible = false;
        Command1.Visible = false;
    }

    // Property to persist the count between postbacks
    private int count
    {
        get
        {
            object o = ViewState["FormCount"];
            return o == null ? 0 : (int)o;
        }
        set { ViewState["FormCount"] = value; }
    }


    // A custom class for the task array
    private class Task
    {
        private String _TaskName;
        private String _Status;

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
    <!-- The first form: Form1 -->
    <mobile:Form ID="Form1" Runat="server"
        OnDeactivate="Form1_Deactivate" 
        OnActivate="Form1_Activate">
        <mobile:Label ID="message1" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        
        <mobile:Label ID="message2" Runat="server" />
        <mobile:SelectionList Runat="server" 
            ID="SelectionList1" 
            ForeColor="red" SelectType="CheckBox" />
        <mobile:Link ID="link1" Runat="server" 
            NavigateUrl="#Form2" 
            Text="Next Form" /><br />
        <mobile:Command ID="Command1" Runat="server" 
            Text="Submit" OnClick="Command1_OnSubmit" />
    </mobile:Form>

    <!-- The second form: Form2 -->
    <mobile:Form ID="Form2" Runat="server" 
        OnActivate="Form2_Activate">
        <mobile:Label ID="message4" Runat="server">
           Welcome to ASP.NET
        </mobile:Label> 
        <mobile:Link ID="Link2" Runat="server" 
            NavigateUrl="#Form1" Text="Back" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
