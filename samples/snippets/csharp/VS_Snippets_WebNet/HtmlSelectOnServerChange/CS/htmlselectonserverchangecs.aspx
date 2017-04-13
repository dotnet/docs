<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void Button_Click (Object sender, EventArgs e)
    {
        Label1.Text = "You selected:";

        for (int i=0; i<=Select1.Items.Count - 1; i++)
        {
           if (Select1.Items[i].Selected)
               Label1.Text += "<br /> &nbsp;&nbsp; -" + Select1.Items[i].Text;      
        }

    }

    void Server_Change (Object sender, EventArgs e)
    {
        int Count = 0;

        for (int i=0; i<=Select1.Items.Count - 1; i++)
        {
           if (Select1.Items[i].Selected)
               Count++;      
        }

        if ((Count > 1) && (Select1.Items[0].Selected))
            Label2.Text = "Hey! You can't select 'All' with another selection!!";
        else
            Label2.Text = "";
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> HtmlSelect Example </title>
</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlSelect Example </h3>

      Select items from the list: <br /><br />

      <select id="Select1" 
              multiple="true"
              onserverchange="Server_Change"
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
              onserverclick="Button_Click"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

      <br />

      <asp:Label id="Label2"
           runat="server"/>

   </form>

</body>

</html>
<!--</Snippet1>-->