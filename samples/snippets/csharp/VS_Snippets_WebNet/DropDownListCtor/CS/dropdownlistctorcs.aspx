<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Selection_Change(Object sender, EventArgs e)
      {

         // Retrieve the DropDownList control from the Controls  
         // collection of the PlaceHolder control.
         DropDownList DropList = 
             (DropDownList)Place.FindControl("ColorList"); 

         // Set the background color for days in the Calendar control
         // based on the value selected by the user from the 
         // DropDownList control.
         Calendar1.DayStyle.BackColor = 
             System.Drawing.Color.FromName(DropList.SelectedItem.Value);

      }

      void Page_Load(Object sender, EventArgs e)
      {

         // Create a DropDownList control.
         DropDownList DropList = new DropDownList();

         // Set the properties for the DropDownList control.
         DropList.ID = "ColorList";
         DropList.AutoPostBack = true;

         // Manually register the event-handling method for the 
         // SelectedIndexChanged event.
         DropList.SelectedIndexChanged += 
             new EventHandler(this.Selection_Change);

         // Because the DropDownList control is created dynamically each
         // time the page is loaded, the data must be bound to the
         // control each time the page is refreshed.

         // Specify the data source and field names for the Text and 
         // Value properties of the items (ListItem objects) in the
         // DropDownList control.
         DropList.DataSource = CreateDataSource();
         DropList.DataTextField = "ColorTextField";
         DropList.DataValueField = "ColorValueField";

         // Bind the data to the control.
         DropList.DataBind();

         // Set the default selected item when the page is first loaded.
         if(!IsPostBack)
         {  
            DropList.SelectedIndex = 0;
         }

         // Add the DropDownList control to the Controls collection of 
         // the PlaceHolder control.
         Place.Controls.Add(DropList);

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
