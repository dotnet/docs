<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlSelect Example </title>
<script runat="server">

      Sub Page_Load (sender As Object, e As EventArgs)
  
        ' Bind the HtmlSelect control to a data source when the page is initially loaded.
        If Not IsPostBack Then
        
           ' Open a connection to the database and run the query.
           ' Note that the connection string may vary depending on your
           ' database server settings.
           Dim ConnectString As String = "server=localhost;database=pubs;integrated security=SSPI"
           Dim QueryString As String = "select * from authors"

           Dim myConnection As SqlConnection = New SqlConnection(ConnectString)
           Dim myCommand As SqlDataAdapter = New SqlDataAdapter(QueryString, myConnection)

           ' Create a dataset to store the query results.
           Dim ds As DataSet = New DataSet()
           myCommand.Fill(ds, "Authors")

           ' Bind the HtmlSelect control to the data source.
           Select1.DataSource = ds
           Select1.DataTextField = "au_fname"
           Select1.DataValueField = "au_fname"
           Select1.DataBind()
        
        End If

      End Sub

      Sub Button_Click (sender As Object, e As EventArgs)
        
         Dim i As Integer

         Label1.Text = "You selected:"

         For i = 0 To Select1.Items.Count - 1
         
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