<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>SelectedDatesCollection SelectRange Example </title>
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
 
         // This method demonstrates how to select a range of dates 
         // in the calendar. 
  
         // Get the month and year of the date contained in the 
         // VisibleDate property.
         int CurrentMonth = Calendar1.VisibleDate.Month;
         int CurrentYear = Calendar1.VisibleDate.Year;

         // Set the start and end dates.
         DateTime BeginDate = new DateTime(CurrentYear, CurrentMonth, 1);
         DateTime EndDate = new DateTime(CurrentYear, CurrentMonth, 7);
 
         // Clear any selected dates.
         Calendar1.SelectedDates.Clear(); 
 
         // Select the specified range of dates.
         Calendar1.SelectedDates.SelectRange(BeginDate, EndDate);
 
      }
 
   </script>
 
</head>     
<body>
 
   <form id="form1" runat="server">

      <h3>SelectedDatesCollection SelectRange Example </h3>

      Click the button to select all dates between the 1st and the
      7th of the month.

      <br /><br />
 
      <asp:Calendar ID="Calendar1"  
           SelectionMode="DayWeekMonth"
           runat="server" />
 
      <hr />
 
      <asp:Button id="SubmitButton"
           Text="Select the 1st to the 7th of the Month" 
           OnClick="Button_Click"  
           runat="server"  /> 
       
      <br />
 
      <asp:Label id="Message" 
           runat="server" />
 
   </form>

</body>
</html>
 
<!--</Snippet1>-->
