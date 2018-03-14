' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading

Module Example
   Private filename As String = ".\dates.dat"
   
   Public Sub Main()
      Dim dates() As Date = { #5/6/1758 9:26PM#, #5/5/1818 7:19AM#, _ 
                              #4/22/1870 11:54PM#, #9/8/1890 6:47AM#, _ 
                              #2/18/1905 3:12PM# }
      ' Write the data to a file using the current culture.
      WriteData(dates)
      ' Change the current culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-CH")
      ' Read the data using the current culture.
      Dim newDates() As Date = ReadData()
      For Each newDate In newDates
         Console.WriteLine(newDate.ToString("g"))
      Next
   End Sub
   
   Private Sub WriteData(dates() As Date)
      Dim sw As New StreamWriter(filename, False, Encoding.Utf8)    
      For ctr As Integer = 0 To dates.Length - 1
         sw.Write("{0}", dates(ctr).ToString("g", CultureInfo.CurrentCulture))
         If ctr < dates.Length - 1 Then sw.Write("|")   
      Next      
      sw.Close()
   End Sub
   
   Private Function ReadData() As Date()
      Dim exceptionOccurred As Boolean = False
           
      ' Read file contents as a single string, then split it.
      Dim sr As New StreamReader(filename, Encoding.Utf8)
      Dim output As String = sr.ReadToEnd()
      sr.Close()   

      Dim values() As String = output.Split( {"|"c } )
      Dim newDates(values.Length - 1) As Date 
      For ctr As Integer = 0 To values.Length - 1
         Try
            newDates(ctr) = DateTime.Parse(values(ctr), CultureInfo.CurrentCulture)
         Catch e As FormatException
            Console.WriteLine("Failed to parse {0}", values(ctr))
            exceptionOccurred = True
         End Try
      Next      
      If exceptionOccurred Then Console.WriteLine()
      Return newDates
   End Function
End Module
' The example displays the following output:
'       Failed to parse 4/22/1870 11:54 PM
'       Failed to parse 2/18/1905 3:12 PM
'       
'       05.06.1758 21:26
'       05.05.1818 07:19
'       01.01.0001 00:00
'       09.08.1890 06:47
'       01.01.0001 00:00
'       01.01.0001 00:00
'
' </Snippet21>