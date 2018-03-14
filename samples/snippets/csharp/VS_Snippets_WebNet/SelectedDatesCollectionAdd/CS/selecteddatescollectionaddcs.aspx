<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>SelectedDatesCollection Add Example </title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {

         // Initialize the VisibleDate property with today's date when
         // the page is first loaded.
         if(!IsPostBack)
         {

            Calendar1.VisibleDate = Calendar1.TodaysDate;

         }

      }
     
      void Button_Click(Object sender, EventArgs e) 
      {

         // This method demonstrates how to select noncontiguous dates 
         // in the calendar. 
  
         // Get the month and year of the date contained in the 
         // VisibleDate property.
         int CurrentMonth = Calendar1.VisibleDate.Month;
         int CurrentYear = Calendar1.VisibleDate.Year;
   
         // Clear all selected dates.
         Calendar1.SelectedDates.Clear();
   
         // Iterate through the current month and add all Wednesdays 
         // to the collection.
         for (int i = 1; 
             i <= System.DateTime.DaysInMonth(CurrentYear, CurrentMonth);
              i++)
         {

            DateTime CurrentDate = new DateTime(CurrentYear, CurrentMonth, i);

            if (CurrentDate.DayOfWeek == DayOfWeek.Wednesday)
            {
               Calendar1.SelectedDates.Add(CurrentDate);
            }

         }
 
         // Display the number of items selected.
         Message.Text = "Selection Count = " + 
             Calendar1.SelectedDates.Count.ToString();
 
      }
 
      void Selection_Change(Object sender, EventArgs e) 
      {

         // Display the number of items selected.
         Message.Text = "Selection Count = " + 
             Calendar1.SelectedDates.Count.ToString();

      }
 
   </script>
 
</head>     
<body>
 
   <form id="form1" runat="server">

      <h3>SelectedDatesCollection Add Example </h3>

      Click the button to select all Wednesdays in the month.

      <br /><br />
 
      <asp:Calendar ID="Calendar1" runat="server"  
           SelectionMode="DayWeekMonth" 
           OnSelectionChanged="Selection_Change" />
 
      <hr />
 
      <asp:Button id="SubmitButton"
           Text="Select All Weds in Month" 
           OnClick="Button_Click"  
           runat="server"  /> 

      <br />
 
      <asp:Label id="Message" 
           runat="server" />

   </form>

</body>
</html>
 
<!--</Snippet1>-->
