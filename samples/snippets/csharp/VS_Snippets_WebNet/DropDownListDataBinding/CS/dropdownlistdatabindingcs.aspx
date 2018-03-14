<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the background color for days in the Calendar control
         // based on the value selected by the user from the 
         // DropDownList control.
         Calendar1.DayStyle.BackColor = 
             System.Drawing.Color.FromName(ColorList.SelectedItem.Value);

      }

      void Page_Load(Object sender, EventArgs e)
      {
  
         // Load data for the DropDownList control only once, when the 
         // page is first loaded.
         if(!IsPostBack)
         {

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.
            ColorList.DataSource = CreateDataSource();
            ColorList.DataTextField = "ColorTextField";
            ColorList.DataValueField = "ColorValueField";

            // Bind the data to the control.
            ColorList.DataBind();

            // Set the default selected item, if desired.
            ColorList.SelectedIndex = 0;

         }

      }

      ICollection CreateDataSource() 
      {
      
         // Create a table to store data for the DropDownList control.
         DataTable dt = new DataTable();
         
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("ColorTextField", typeof(String)));
         dt.Columns.Add(new DataColumn("ColorValueField", typeof(String)));
 
         // Populate the table with sample values.
         dt.Rows.Add(CreateRow("White", "White", dt));
         dt.Rows.Add(CreateRow("Silver", "Silver", dt));
         dt.Rows.Add(CreateRow("Dark Gray", "DarkGray", dt));
         dt.Rows.Add(CreateRow("Khaki", "Khaki", dt));
         dt.Rows.Add(CreateRow("Dark Khaki", "DarkKhaki", dt));
 
         // Create a DataView from the DataTable to act as the data source
         // for the DropDownList control.
         DataView dv = new DataView(dt);
         return dv;

      }

      DataRow CreateRow(String Text, String Value, DataTable dt)
      {

         // Create a DataRow using the DataTable defined in the 
         // CreateDataSource method.
         DataRow dr = dt.NewRow();
 
         // This DataRow contains the ColorTextField and ColorValueField 
         // fields, as defined in the CreateDataSource method. Set the 
         // fields with the appropriate value. Remember that column 0 
         // is defined as ColorTextField, and column 1 is defined as 
         // ColorValueField.
         dr[0] = Text;
         dr[1] = Value;
 
         return dr;

      }
  
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
