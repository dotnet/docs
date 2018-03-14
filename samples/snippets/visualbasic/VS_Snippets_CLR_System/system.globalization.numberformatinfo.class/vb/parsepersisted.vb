' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example
   Public Sub Main()
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
      PersistData()
      
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
      RestoreData()
   End Sub
   
   Private Sub PersistData()
      ' Define an array of floating-point values.
      Dim values() As Double = { 160325.972, 8631.16, 1.304e5, 98017554.385, 
                                 8.5938287084321676e94 }
      Console.WriteLine("Original values: ")
      For Each value In values
         Console.WriteLine(value.ToString("R", CultureInfo.InvariantCulture))
      Next
         
      ' Serialize an array of doubles to a file 
      Dim sw As New StreamWriter(".\NumericData.bin")
      For ctr As Integer = 0 To values.Length - 1
         sw.Write(values(ctr).ToString("R"))
         If ctr < values.Length - 1 Then sw.Write("|")
      Next
      sw.Close()
      Console.WriteLine()
   End Sub
   
   Private Sub RestoreData()   
      ' Deserialize the data
      Dim sr AS New StreamReader(".\NumericData.bin")
      Dim data As String = sr.ReadToEnd()
      sr.Close()
      
      Dim stringValues() As String = data.Split("|"c)
      Dim newValueList As New List(Of Double)
      
      For Each stringValue In stringValues
         Try
            newValueList.Add(Double.Parse(stringValue))
         Catch e As FormatException
            newValueList.Add(Double.NaN)
         End Try   
      Next                                   

      Console.WriteLine("Restored values:")
      For Each newValue In newValueList
         Console.WriteLine(newValue.ToString("R", NumberFormatInfo.InvariantInfo))
      Next
   End Sub
End Module
' The example displays the following output:
'       Original values:
'       160325.972
'       8631.16
'       130400
'       98017554.385
'       8.5938287084321671E+94
'       
'       Restored values:
'       160325972
'       863116
'       130400
'       98017554385
'       8.5938287084321666E+110
' </Snippet6>
