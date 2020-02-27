<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Add items to the list
            SelectionList1.Items.Add(new 
                MobileListItem("Verify transactions","Done"));
            SelectionList1.Items.Add(new 
                MobileListItem("Check balance sheet","Scheduled"));
            SelectionList1.Items.Add(new
                MobileListItem("Call customer", "Done"));
            SelectionList1.Items.Add(new
                MobileListItem("Send checks", "Pending"));
            SelectionList1.Items.Add(new
                MobileListItem("Send report", "Pending"));
            SelectionList1.Items.Add(new
                MobileListItem("Attend meeting", "Scheduled"));

            // Show all items in list
            SelectionList1.Rows = SelectionList1.Items.Count;
        }
    }
    void TextChanged(object sender, EventArgs e)
    {
        // Called during PostBack, if changed
        string task = TextBox1.Text;
        string status = TextBox2.Text;
        
        if (task.Length > 0 && status.Length > 0)
        {

            MobileListItem li = new MobileListItem(task, status);
            
            // Remove the item if it exists
            if (SelectionList1.Items.Contains(li))
                SelectionList1.Items.Remove(li);
            else
                // Add the item if it does not exist
                SelectionList1.Items.Add(li);

            // Clear the text boxes
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
        }

        // Display all items.
        SelectionList1.Rows = SelectionList1.Items.Count;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server">
        <mobile:Label Id="Label1" runat="server">
            Create a new Task with Status</mobile:Label>   
        <mobile:SelectionList runat="server" BreakAfter="true" 
            SelectType="ListBox"
            id="SelectionList1" />
        <mobile:Label Id="Label2" runat="server" 
            Text="Enter the Task name" />
        <mobile:TextBox runat="server" id="TextBox1" 
            OnTextChanged="TextChanged" />
        <mobile:Label Id="Label3" runat="server" 
            Text="Enter the Task status" />
        <mobile:TextBox runat="server" id="TextBox2" />
        <mobile:Command ID="Command1" runat="server" 
            Text="Submit" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
