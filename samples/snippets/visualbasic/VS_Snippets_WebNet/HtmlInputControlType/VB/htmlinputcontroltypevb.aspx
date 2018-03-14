<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title> HtmlInputControl Type Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create the data source.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         dt.Columns.Add(new DataColumn("Value", GetType(String)))

         Dim i As Integer   

         For i = 0 to 2

            dr = dt.NewRow()
  
            dr(0) = "Item " + i.ToString()
 
            dt.Rows.Add(dr)
         
         Next i
 
         ' Bind the data source to the Repeater control.
         Repeater1.DataSource = New DataView(dt)
         Repeater1.DataBind()

      End Sub

      Sub AddButton_Click(sender As Object, e As EventArgs)
      
         Message.Text = "The type of the HtmlInputControl clicked is " & _ 
                        CType(sender, HtmlInputControl).Type

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlInputControl Type Example </h3>

      <asp:Repeater id="Repeater1"
           runat="server">

         <ItemTemplate>
            
            <input id="Submit1" type="submit"
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