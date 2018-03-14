<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlSelect Example </title>
<script runat="server">

      Sub Page_Load (sender As Object, e As EventArgs)

         ' Bind the HtmlSelect control to a data source when the page is initially loaded.
         If Not IsPostBack Then
 
            Dim i As Integer
      
            ' Create a data set to store the tables.
            Dim ds As DataSet = New DataSet("TitleDataSet")
            Dim dr As DataRow 

            ' Create the authors table with a single column.
            Dim authors As DataTable = New DataTable("Authors")            
            authors.Columns.Add(New DataColumn("LName", GetType(String)))                    
 
            ' Add the authors table to the data set.
            ds.Tables.Add(authors)

            ' Create sample data in the authors table.
            For i = 0 To 9 
           
               ' Create a new row for the authors table.
               dr = authors.NewRow()

               ' Add data to the LName column (column 0 in the row).
               dr(0) = "Author " & i.ToString()

               ' Insert the row into the authors table.   
               authors.Rows.Add(dr)

            Next i
  
            ' Create the titles table with a single column.
            Dim titles As DataTable = New DataTable("Titles")            
            titles.Columns.Add(New DataColumn("BookTitle", GetType(String)))                    
 
            ' Add the titles table to the data set.
            ds.Tables.Add(titles)

            ' Create sample data in the titles table.
            For i = 0 To 9
            
               ' Create a new row for the titles table.
               dr = titles.NewRow()

               ' Add data to the BookTitle column (column 0 in the row).
               dr(0) = "Title " & i.ToString()

               ' Insert the row into the titles table.   
               titles.Rows.Add(dr)

            Next i

            ' Bind the HtmlSelect control to the data source.
            Select1.DataSource = ds
            Select1.DataMember = "Titles"
            Select1.DataTextField = "BookTitle"
            Select1.DataBind()

         End If

      End Sub

      Sub Button_Click (sender As Object, e As EventArgs)

         Dim i As Integer
       
         ' Display the selected items. 
         Label1.Text = "You selected:"

         For i=0 To Select1.Items.Count - 1
      
            If Select1.Items(i).Selected Then
               Label1.Text = Label1.Text & "<br /> &nbsp;&nbsp; - " & Select1.Items(i).Text
            End If
         
         Next i

      End Sub

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