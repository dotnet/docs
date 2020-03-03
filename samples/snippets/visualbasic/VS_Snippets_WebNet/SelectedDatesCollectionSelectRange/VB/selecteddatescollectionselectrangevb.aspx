<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>SelectedDatesCollection SelectRange Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Initialize the VisibleDate property with today's date when
         ' the page is first loaded.
         If Not IsPostBack Then

            Calendar1.VisibleDate = Calendar1.TodaysDate

         End If

      End Sub
 
      Sub Button_Click(sender As Object, e As EventArgs) 
 
         ' This method demonstrates how to select a range of dates
         ' in the calendar. 
  
         ' Get the month and year of the date contained in the 
         ' VisibleDate property.
         Dim CurrentMonth As Integer = Calendar1.VisibleDate.Month
         Dim CurrentYear As Integer = Calendar1.VisibleDate.Year

         ' Set the start and end dates.
         Dim BeginDate As DateTime = New DateTime(CurrentYear, CurrentMonth, 1)
         Dim EndDate As DateTime = New DateTime(CurrentYear, CurrentMonth, 7)
 
         ' Clear any selected dates.
         Calendar1.SelectedDates.Clear() 
 
         ' Select the specified range of dates.
         Calendar1.SelectedDates.SelectRange(BeginDate, EndDate)
 
      End Sub
 
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
