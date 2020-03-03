<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender as Object, e As EventArgs)

         ' Set the background color for days in the Calendar control 
         ' based on the value selected by the user from the
         ' DropDownList control.
         Calendar1.DayStyle.BackColor = _
             System.Drawing.Color.FromName(ColorList.SelectedItem.Value)

      End Sub

      Sub Page_Load(sender as Object, e As EventArgs)
  
         ' Load data for the DropDownList control only once, when the 
         ' page is first loaded.
         If Not IsPostBack Then

            ' Specify the data source and field names for the Text 
            ' and Value properties of the items (ListItem objects)
            ' in the DropDownList control.
            ColorList.DataSource = CreateDataSource()
            ColorList.DataTextField = "ColorTextField"
            ColorList.DataValueField = "ColorValueField"

            ' Bind the data to the control.
            ColorList.DataBind()

            ' Set the default selected item, if desired.
            ColorList.SelectedIndex = 0

         End If

      End Sub

      Function CreateDataSource() As ICollection 
      
         ' Create a table to store data for the DropDownList control.
         Dim dt As DataTable = New DataTable()
         
         ' Define the columns of the table.
         dt.Columns.Add(new DataColumn("ColorTextField", GetType(String)))
         dt.Columns.Add(new DataColumn("ColorValueField", GetType(String)))
 
         ' Populate the table with sample values.
         dt.Rows.Add(CreateRow("White", "White", dt))
         dt.Rows.Add(CreateRow("Silver", "Silver", dt))
         dt.Rows.Add(CreateRow("Dark Gray", "DarkGray", dt))
         dt.Rows.Add(CreateRow("Khaki", "Khaki", dt))
         dt.Rows.Add(CreateRow("Dark Khaki", "DarkKhaki", dt))
 
         ' Create a DataView from the DataTable to act as the data source
         ' for the DropDownList control.
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function

      Function CreateRow(Text As String, Value As String, dt As DataTable) As DataRow 

         ' Create a DataRow using the DataTable defined in the 
         ' CreateDataSource method.
         Dim dr As DataRow = dt.NewRow()
 
         ' This DataRow contains the ColorTextField and ColorValueField 
         ' fields, as defined in the CreateDataSource method. Set the 
         ' fields with the appropriate value. Remember that column 0 
         ' is defined as ColorTextField, and column 1 is defined as 
         ' ColorValueField.
         dr(0) = Text
         dr(1) = Value
 
         Return dr

      End Function
  
   </script>
  
<head runat="server">
    <title> DropDownList Data Binding Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> DropDownList Data Binding Example </h3>

      Select a background color for days in the calendar.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               Background color:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="ColorList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server"/>

            </td>

         </tr>
         
      </table>   
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
