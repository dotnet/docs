' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization

Module Example
   Private Const filename As String = ".\LeapYears.xml"
   
   Public Sub Main()
      ' Serialize the data.
      Dim leapYears As New List(Of DateTime)()
      For year As Integer = 2000 To 2100 Step 4
         If Date.IsLeapYear(year) Then 
            leapYears.Add(New Date(year, 2, 29))
         End If
      Next
      Dim dateArray() As DateTime = leapYears.ToArray()
      
      Dim serializer As New XMLSerializer(dateArray.GetType())
      Dim sw As TextWriter = New StreamWriter(fileName)
      
      Try
         serializer.Serialize(sw, dateArray)
      Catch e As InvalidOperationException
         Console.WriteLine(e.InnerException.Message)         
      Finally
         If sw IsNot Nothing Then sw.Close()
      End Try   

      ' Deserialize the data.
      Dim deserializedDates() As Date
      Using fs As New FileStream(filename, FileMode.Open)
         deserializedDates = CType(serializer.Deserialize(fs), Date())
      End Using 
      
      ' Display the dates.
      Console.WriteLine("Leap year days from 2000-2100 on an {0} system:",
                        Thread.CurrentThread.CurrentCulture.Name)
      Dim nItems As Integer
      For Each dat In deserializedDates
         Console.Write("   {0:d}     ", dat)
         nItems += 1
         If nItems Mod 5 = 0 Then Console.WriteLine() 
      Next
   End Sub
End Module
' The example displays the following output:
'    Leap year days from 2000-2100 on an en-GB system:
'       29/02/2000       29/02/2004       29/02/2008       29/02/2012       29/02/2016
'       29/02/2020       29/02/2024       29/02/2028       29/02/2032       29/02/2036
'       29/02/2040       29/02/2044       29/02/2048       29/02/2052       29/02/2056
'       29/02/2060       29/02/2064       29/02/2068       29/02/2072       29/02/2076
'       29/02/2080       29/02/2084       29/02/2088       29/02/2092       29/02/2096
' </Snippet5>
