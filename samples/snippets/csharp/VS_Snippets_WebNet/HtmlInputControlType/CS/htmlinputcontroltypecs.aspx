<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlInputControl Type Example </title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {

         // Create the data source.
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("Value", typeof(string)));
   
         for (int i = 0; i < 3; i++) 
         {
            dr = dt.NewRow();
  
            dr[0] = "Item " + i.ToString();
 
            dt.Rows.Add(dr);
         }
 
         // Bind the data source to the Repeater control.
         Repeater1.DataSource = new DataView(dt);
         Repeater1.DataBind();

      }

      void AddButton_Click(Object sender, EventArgs e)
      {
      
         Message.Text = "The type of the HtmlInputControl clicked is " + 
                        ((HtmlInputControl)sender).Type;

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlInputControl Type Example </h3>

      <asp:Repeater id="Repeater1"
           runat="server">

         <ItemTemplate>
            
            <input type="submit"
                   name="AddButton"
                   value='<%# DataBinder.Eval(Container.DataItem, "Value") %>'
                   onserverclick="AddButton_Click"
                   runat="server"/>

         </ItemTemplate>


      </asp:Repeater>

      <br /><br />

      <asp:Label id="Message" runat="server"/>

   </form>

</body>

</html>

<!-- </Snippet1> -->