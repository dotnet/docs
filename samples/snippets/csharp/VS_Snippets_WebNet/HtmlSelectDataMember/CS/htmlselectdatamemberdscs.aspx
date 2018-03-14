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
      
            // Create a data set to store the tables.
            DataSet ds = new DataSet("TitleDataSet");
            DataRow dr; 

            // Create the authors table with a single column.
            DataTable authors = new DataTable("Authors");            
            authors.Columns.Add(new DataColumn("LName", typeof(string)));                    
 
            // Add the authors table to the data set.
            ds.Tables.Add(authors);

            // Create sample data in the authors table.
            for (int i = 0; i < 9; i++) 
            {
               // Create a new row for the authors table.
               dr = authors.NewRow();

               // Add data to the LName column (column 0 in the row).
               dr[0] = "Author " + i.ToString();

               // Insert the row into the authors table.   
               authors.Rows.Add(dr);
            }
  
            // Create the titles table with a single column.
            DataTable titles = new DataTable("Titles");            
            titles.Columns.Add(new DataColumn("BookTitle", typeof(string)));                    
 
            // Add the titles table to the data set.
            ds.Tables.Add(titles);

            // Create sample data in the titles table.
            for (int i = 0; i < 9; i++) 
            {
               // Create a new row for the titles table.
               dr = titles.NewRow();

               // Add data to the BookTitle column (column 0 in the row).
               dr[0] = "Title " + i.ToString();

              // Insert the row into the titles table.   
              titles.Rows.Add(dr);
            }

            // Bind the HtmlSelect control to the data source.
            Select1.DataSource = ds;
            Select1.DataMember = "Titles";
            Select1.DataTextField = "BookTitle";
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