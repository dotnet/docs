' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cal As New UmAlQuraCalendar()
      Dim currentYear As Integer = cal.GetYear(Date.Now)
      
      Console.WriteLine("Era     Year     Days")
      Console.WriteLine()
      For Each era As Integer In cal.Eras
         For year As Integer = currentYear To currentYear + 9
            Console.WriteLine("{0}{1}      {2}      {3}", 
                              ShowCurrentEra(cal, era), era, year, 
                              cal.GetDaysInYear(year, era))   
         Next     
      Next   
      Console.WriteLine()
      Console.WriteLine("   * Indicates the current era.")
   End Sub
   
   Private Function ShowCurrentEra(cal As Calendar, era As Integer) As String
      If era = cal.Eras(Calendar.CurrentEra) Then
         Return "*"
      Else
         Return " "
      End If   
   End Function
End Module
' The example displays the following output:
'       Era     Year     Days
'       
'       *1      1431      354
'       *1      1432      354
'       *1      1433      355
'       *1      1434      354
'       *1      1435      355
'       *1      1436      354
'       *1      1437      354
'       *1      1438      354
'       *1      1439      355
'       *1      1440      354
'       
'          * Indicates the current era.
' </Snippet1>
