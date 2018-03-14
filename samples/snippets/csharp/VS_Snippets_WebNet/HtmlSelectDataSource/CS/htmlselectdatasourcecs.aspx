<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlSelect Example </title>
<script runat="server">

      void Page_Load (Object sender, EventArgs e)
      {

        // Bind the HtmlSelect control to a data source when the page is initially loaded.
        if (!IsPostBack)
        {
      
           // Open a connection to the database and run the query.
           // Note that the connection string may vary depending on your
           // database server settings. 
           string ConnectString = "server=localhost;database=pubs;integrated security=SSPI";
           string QueryString = "select * from authors";

           SqlConnection myConnection = new SqlConnection(ConnectString);
           SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);

           // Create a dataset to store the query results.
           DataSet ds = new DataSet();
           myCommand.Fill(ds, "Authors");

           // Bind the HtmlSelect control to the data source.
           Select1.DataSource = ds;
           Select1.DataTextField = "au_fname";
           Select1.DataValueField = "au_fname";
           Select1.DataBind();
        }

      }

      void Button_Click (Object sender, EventArgs e)
      {
       
         // Display the selected items. 
         Label1.Text = "You selected:";

         for (int i=0; i<=Select1.Items.Count - 1; i++)
         {
            if (Select1.Items[i].Selected)
               Label1.Text += "<br /> &nbsp;&nbsp; - " + Select1.Items[i].Text;
         }

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlSelect Example </h3>

      Select items from the list. <br />
      Use the Control or Shift key to select multiple items. <br /><br />

      <select id="Select1"
              multiple="true" 
              runat="server"/>

      <br /><br />

      <button id="Button1"
              onserverclick="Button_Click"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

   </form>

</body>

</html>
<!--</Snippet1>-->