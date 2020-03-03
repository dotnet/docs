<!-- Overview -->
<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    int bakeryCount = 0, dairyCount = 0, produceCount = 0;

    public void Page_Load(Object o, EventArgs e)
    {
        if (!IsPostBack)
        {   // Create an array and bind it to the list
            ArrayList arr = new ArrayList();
            arr.Add (new GroceryItem 
                ("Bakery", "Rolls", "On Sale"));
            arr.Add (new GroceryItem 
                ("Dairy", "Eggnog", "Half price"));
            arr.Add (new GroceryItem 
                ("Produce", "Apples", 
                "A dollar a bushel"));
            arr.Add (new GroceryItem 
                ("Bakery", "Bread", "On Sale"));

            List1.DataSource = arr;
            List1.DataBind ();

            // To show only one field on opening page,
            // comment the next line
            List1.TableFields = "Item;Department";
            List1.LabelField = "Department";

            // Display a report after items are databound
            string txt = "Number of items by Department<br>Produce: {0}<br />" +
                "Dairy: {1}<br />Bakery: {2}";
            TextView2.Text = String.Format(txt, produceCount, dairyCount, bakeryCount);
        }
    }

    // Command event for buttons
    public void List1_Click(Object sender, 
        ObjectListCommandEventArgs e)
    {
        if (e.CommandName == "Reserve")
           ActiveForm = Form2;
        else if (e.CommandName == "Buy")
           ActiveForm = Form3;
        else
           ActiveForm = Form4;
    }

    //<Snippet4>
    // Count items in each department
    private void List1_ItemDataBind(object sender, ObjectListDataBindEventArgs e)
    {
        switch (((GroceryItem)e.DataItem).Department)
        {
            case "Bakery":
                bakeryCount++;
                break;
            case "Dairy":
                dairyCount++;
                break;
            case "Produce":
                produceCount++;
                break;
        }
    }
    //</Snippet4>

    //<Snippet2>
    private void AllFields_Click(object sender, EventArgs e)
    {
        ActiveForm = Form5;
        string spec = "{0}: {1}<br/>";
        IObjectListFieldCollection flds = List1.AllFields;
        for (int i = 0; i < flds.Count; i++)
            TextView1.Text += 
                String.Format(spec, (i + 1), flds[i].Title);
    }
    //</Snippet2>

    // Structure for ArrayList records
    private class GroceryItem
    {   // A private class for the Grocery List
        private String _department, _item, _status;
        public GroceryItem(string department,
            string item, string status)
        {
            _department = department;
            _item = item;
            _status = status;
        }
        public String Department
        { get { return _department; } }
        public String Item
        { get { return _item; } }
        public String Status
        { get { return _status; } }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" BackColor="LightBlue">
        <mobile:ObjectList id="List1" runat="server" 
            OnItemCommand="List1_Click" OnItemDataBind="List1_ItemDataBind">
            <DeviceSpecific ID="DeviceSpecific1" Runat="server">
                <!-- See Web.config for filters -->
                <Choice Filter="isWML11" CommandStyle-Font-Bold="NotSet" />
                <Choice CommandStyle-Font-Bold="true" 
                    CommandStyle-Font-Name="Arial" />
            </DeviceSpecific>
            <Command Name="Reserve" Text="Reserve" />
            <Command Name="Buy" Text="Buy" />
        </mobile:ObjectList>
        <mobile:Command ID="AllFieldsCmd" Runat="server" 
            OnClick="AllFields_Click">
            List All Fields</mobile:Command>
        <mobile:TextView ID="TextView2" Runat="server" />
    </mobile:Form>
    <mobile:Form id="Form2" runat="server" BackColor="LightBlue">
        <mobile:Label id="ResLabel" runat="server"
            text="Sale item reservation system coming soon!" />
        <mobile:Link id="ResLink" NavigateURL="#Form1" 
            runat="server" text="Return" />
    </mobile:Form>
    <mobile:Form id="Form3" runat="server" BackColor="LightBlue">
        <mobile:Label id="BuyLabel" runat="server"
            Text="Online purchasing system coming soon!" />
        <mobile:Link ID="BuyLink" NavigateURL="#Form1" 
            Runat="server" text="Return" />
    </mobile:Form>
    <mobile:Form id="Form4" Runat="server" BackColor="LightBlue">
        <mobile:Label ID="DefLabel" Runat="server" 
             Text="Detailed item descriptions will be here soon!"/>
        <mobile:Link ID="DefLink" NavigateURL="#Form1" 
            Runat="server" Text="Return" />
    </mobile:Form>
    <mobile:Form ID="Form5" Runat="server">
        <mobile:Label Runat="server">
            List of AllFields:</mobile:Label>
        <mobile:TextView ID="TextView1" Runat="server" />
        <mobile:Link Runat="server" NavigateUrl="#Form1" 
            Text="Return"></mobile:Link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
