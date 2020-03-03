<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender as Object, e As EventArgs)

         ' Retrieve the DropDownList control from the Controls 
         ' collection of the PlaceHolder control.
         Dim DropList As DropDownList = _
             CType(Place.FindControl("ColorList"), DropDownList) 

         ' Set the background color for days in the Calendar control 
         ' based on the value selected by the user from the
         ' DropDownList control.
         Calendar1.DayStyle.BackColor = _
             System.Drawing.Color.FromName(DropList.SelectedItem.Value)

      End Sub

      Sub Page_Load(sender as Object, e As EventArgs)

         ' Create a DropDownList control.
         Dim DropList As DropDownList = New DropDownList()

         ' Set the properties for the DropDownList control.
         DropList.ID = "ColorList"
         DropList.AutoPostBack = True

         ' Manually register the event-handling method for the 
         ' SelectedIndexChanged event.
         AddHandler DropList.SelectedIndexChanged, AddressOf Selection_Change

         ' Because the DropDownList control is created dynamically each 
         ' time the page is loaded, the data must be bound to the
         ' control each time the page is refreshed.

         ' Specify the data source and field names for the Text and
         ' Value properties of the items (ListItem objects) in the 
         ' DropDownList control.
         DropList.DataSource = CreateDataSource()
         DropList.DataTextField = "ColorTextField"
         DropList.DataValueField = "ColorValueField"

         ' Bind the data to the control.
         DropList.DataBind()

         ' Set the default selected item when the page is first loaded.
         If Not IsPostBack Then
        
            DropList.SelectedIndex = 0
         
         End If

         ' Add the DropDownList control to the Controls collection of 
         ' the PlaceHolder control.
         Place.Controls.Add(DropList)

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
    <title> DropDownList Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> DropDownList Constructor Example </h3>

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

               <asp:PlaceHolder id="Place"
                    runat="server"/>

            </td>

         </tr>
         
      </table>   
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
