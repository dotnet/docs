' The following code example shows that CultureInfo.ReadOnly also protects the DateTimeFormatInfo and NumberFormatInfo instances associated with the CultureInfo.

' <snippet1>
Imports System
Imports System.Globalization


Public Class SamplesCultureInfo

   Public Shared Sub Main()
      
      ' Creates a CultureInfo.
      Dim myCI As New CultureInfo("en-US")
      
      ' Creates a read-only CultureInfo based on myCI.
      Dim myReadOnlyCI As CultureInfo = CultureInfo.ReadOnly(myCI)
      
      ' Display the read-only status of each CultureInfo and their DateTimeFormat and NumberFormat properties.
      If myCI.IsReadOnly Then 
         Console.WriteLine("myCI is read only.")
      Else
         Console.WriteLine("myCI is writable.")
      End If

      If myCI.DateTimeFormat.IsReadOnly Then 
         Console.WriteLine("myCI.DateTimeFormat is read only.")
      Else
         Console.WriteLine("myCI.DateTimeFormat is writable.")
      End If

      If myCI.NumberFormat.IsReadOnly Then 
         Console.WriteLine("myCI.NumberFormat is read only.")
      Else
         Console.WriteLine("myCI.NumberFormat is writable.")
      End If

      If myReadOnlyCI.IsReadOnly Then 
         Console.WriteLine("myReadOnlyCI is read only.")
      Else
         Console.WriteLine("myReadOnlyCI is writable.")
      End If

      If myReadOnlyCI.DateTimeFormat.IsReadOnly Then 
         Console.WriteLine("myReadOnlyCI.DateTimeFormat is read only.")
      Else
         Console.WriteLine("myReadOnlyCI.DateTimeFormat is writable.")
      End If

      If myReadOnlyCI.NumberFormat.IsReadOnly Then 
         Console.WriteLine("myReadOnlyCI.NumberFormat is read only.")
      Else
         Console.WriteLine("myReadOnlyCI.NumberFormat is writable.")
      End If

   End Sub 'Main 

End Class 'SamplesCultureInfo


' This code produces the following output.
'
' myCI is writable.
' myCI.DateTimeFormat is writable.
' myCI.NumberFormat is writable.
' myReadOnlyCI is read only.
' myReadOnlyCI.DateTimeFormat is read only.
' myReadOnlyCI.NumberFormat is read only.
' </snippet1>