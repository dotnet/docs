' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim years() As Integer = { 2012, 2014 }
      Dim dtfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
      Console.WriteLine("Days in the Month for the {0} culture " +
                        "using the {1} calendar", 
                        CultureInfo.CurrentCulture.Name, 
                        dtfi.Calendar.GetType.Name.Replace("Calendar", ""))
      Console.WriteLine()
      Console.WriteLine("{0,-10}{1,-15}{2,4}", "Year", "Month", "Days")
      Console.WriteLine()
      
      For Each [year] As Integer In years
         For ctr As Integer = 0 To dtfi.MonthNames.Length - 1
            If String.IsNullOrEmpty(dtfi.MonthNames(ctr)) Then 
               Continue For
            End If    
            
            Console.WriteLine("{0,-10}{1,-15}{2,4}", [year], 
                              dtfi.MonthNames(ctr), 
                              DateTime.DaysInMonth([year], ctr + 1))
         Next
         Console.WriteLine() 
      Next
   End Sub
End Module
' The example displays the following output:
'    Days in the Month for the en-US culture using the Gregorian calendar
'    
'    Year      Month          Days
'    
'    2012      January          31
'    2012      February         29
'    2012      March            31
'    2012      April            30
'    2012      May              31
'    2012      June             30
'    2012      July             31
'    2012      August           31
'    2012      September        30
'    2012      October          31
'    2012      November         30
'    2012      December         31
'    
'    2014      January          31
'    2014      February         28
'    2014      March            31
'    2014      April            30
'    2014      May              31
'    2014      June             30
'    2014      July             31
'    2014      August           31
'    2014      September        30
'    2014      October          31
'    2014      November         30
'    2014      December         31
' </Snippet1>
