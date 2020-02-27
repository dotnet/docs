<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>SelectedDatesCollection Add Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Initialize the VisibleDate property with today's date when
         ' the page is first loaded.
         If Not IsPostBack Then

            Calendar1.VisibleDate = Calendar1.TodaysDate

         End If

      End Sub
     
      Sub Button_Click(sender As Object, e As EventArgs) 

         ' This method demonstrates how to select noncontiguous dates 
         ' in the calendar. 
  
         ' Get the month, day, and year of the date contained in the 
         ' VisibleDate property.
         Dim CurrentMonth As Integer = Calendar1.VisibleDate.Month
         Dim CurrentYear As Integer = Calendar1.VisibleDate.Year
   
         ' Clear all selected dates.
         Calendar1.SelectedDates.Clear()
   
         ' Iterate through the current month and add all Wednesdays 
         ' to the collection.
         Dim i As Integer

         For i = 1 To System.DateTime.DaysInMonth(CurrentYear, CurrentMonth)

            Dim CurrentDate As DateTime = _
                New DateTime(CurrentYear, CurrentMonth, i)

            If CurrentDate.DayOfWeek = DayOfWeek.Wednesday Then
            
                Calendar1.SelectedDates.Add(CurrentDate)
            
            End If

         Next i
 
         ' Display the number of items selected.
         Message.Text = "Selection Count = " & _
             Calendar1.SelectedDates.Count.ToString()
 
      End Sub
 
      Sub Selection_Change(sender As Object, e As EventArgs) 

         ' Display the number of items selected.
         Message.Text = "Selection Count = " & _
             Calendar1.SelectedDates.Count.ToString()

      End Sub
 
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
