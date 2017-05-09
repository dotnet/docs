<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Button_Click (Object sender, EventArgs e)
    {
        // Display the selected items.
        Label1.Text = "You selected:";

        for (int i=0; i<=Select1.Items.Count - 1; i++)
        {
            if (Select1.Items[i].Selected)
                Label1.Text += "<br /> &nbsp;&nbsp; -" + Select1.Items[i].Text;      
        }
    }

    void Server_Change(Object sender, EventArgs e)
    {
        // The ServerChange event is commonly used for data validation.
        // This method will display a warning if the "All" option is  
        // selected in combination with another item in the list.
        int Count = 0;

        // Determine the number of selected items in the list.
        for (int i=0; i<=Select1.Items.Count - 1; i++)
        {
            if (Select1.Items[i].Selected)
                Count++;      
        }

        // Display an error message if more than one item is selected with
        // the "All" item selected.
        if ((Count > 1) && (Select1.Items[0].Selected))
            Label2.Text = "Hey! You can't select 'All' with another selection!!";
        else
            Label2.Text = "";
    }

    void Page_Load(Object sender, EventArgs e)
    {
        // Create an EventHandler delegate for the method you want to
        // handle the event, and then add it to the list of methods
        // called when the event is raised.
        Select1.ServerChange += new System.EventHandler(this.Server_Change);
        Button1.ServerClick += new System.EventHandler(this.Button_Click);
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> HtmlSelect Server Change Example </title>
</head>
<body>
<form id="form1" runat="server">
   <div>

      <h3> HtmlSelect Server Change Example </h3>

      Select items from the list: <br /><br />

      <select id="Select1" 
              multiple="true"
              runat="server">

         <option value="All"> All </option>
         <option value="1" selected="selected"> Item 1 </option>
         <option value="2"> Item 2 </option>
         <option value="3"> Item 3 </option>
         <option value="4"> Item 4 </option>
         <option value="5"> Item 5 </option>
         <option value="6"> Item 6 </option>

      </select>

      <br /><br />

      <button id="Button1"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

      <br />

      <asp:Label id="Label2"
           runat="server"/>

   </div>
</form>
</body>
</html>

<!-- </Snippet1> -->   