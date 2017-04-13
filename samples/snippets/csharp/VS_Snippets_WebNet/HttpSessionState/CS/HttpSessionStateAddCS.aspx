<!-- <Snippet13> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        // If both name and value are specified
        // use the Add method to add the item to session-state.
        if (!String.IsNullOrEmpty(TextBox1.Text) &
            !String.IsNullOrEmpty(TextBox2.Text))
        {
            string itemName = Server.HtmlEncode(TextBox1.Text);
            string itemValue = Server.HtmlEncode(TextBox2.Text);
            Session.Add(itemName, itemValue);
            // Refresh the Repeater control.
            RefreshRepeater();
        }
    }

    protected void RefreshRepeater()
    {
        // Use the GetEnumerator method to 
        // iterate through the session-state.
        ArrayList values = new ArrayList();
        System.Collections.IEnumerator ie = Session.GetEnumerator();
        string currentSessionItemName;
        while (ie.MoveNext())
        {
            currentSessionItemName = (string)ie.Current;
            values.Add(new SessionDataDisplay(currentSessionItemName,
                Session[currentSessionItemName].ToString()));
            
        }
        // Bind values ArrayList to Repeater control.
        Repeater1.DataSource = values;
        Repeater1.DataBind();
    }
    
    public class SessionDataDisplay
    {
        private string _name;
        private string _value;

        public SessionDataDisplay(string name, string value)
        {
            this._name = name;
            this._value = value;
        }
        public string Name
        {
            get { return _name; }
        }
        public string Value
        {
            get { return _value; }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // Determine which item to remove and
        // use the Remove method to remove it.
        RepeaterItem itemToRemove = e.Item;
        string sessionItemToRemove = 
            ((Label)itemToRemove.FindControl("Label1")).Text;
        Session.Remove(sessionItemToRemove);
        // Refresh the Repeater control.
        RefreshRepeater();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpSessionState Example</title>
</head>
<body>
    <form id="form1" 
          runat="server" 
          defaultbutton="Button1" 
          defaultfocus="TextBox1">
    <div>
        Name
        <asp:TextBox ID="TextBox1"
                     runat="server"></asp:TextBox>
        <br />
        Value
        <asp:TextBox ID="TextBox2" 
                     runat="server"></asp:TextBox>
        <asp:Button ID="Button1" 
                    runat="server" 
                    OnClick="Button1_Click" 
                    Text="Add" />
        <br />
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <ItemTemplate>
             <br />
                SessionState Item Name:  
                <asp:Label ID="Label1" 
                           runat="server" 
                           Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'/>,
                SessionState Item Value: 
                <asp:Label ID="Label2" 
                           runat="server" 
                           Text='<%# DataBinder.Eval(Container.DataItem, "Value") %>'/>
                <asp:Button ID="RemoveItem" 
                            Text="Remove" 
                            runat="server" />
          </ItemTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet13> -->