'<snippet1>
' This example demonstrates the NativeDigits property.

Imports System
Imports System.Globalization
Imports System.Threading

Class Sample
    Public Shared Sub Main() 
        Dim currentCI As CultureInfo = Thread.CurrentThread.CurrentCulture
        Dim nfi As NumberFormatInfo = currentCI.NumberFormat
        Dim nativeDigitList As String() = nfi.NativeDigits
        
        Console.WriteLine("The native digits for the {0} culture are:", currentCI.Name)
        Dim s As String
        For Each s In  nativeDigitList
            Console.Write("""{0}"" ", s)
        Next s
        Console.WriteLine()
    
    End Sub 'Main
End Class 'Sample

'This code example produces the following results:
'
'The native digits for the en-US culture are:
'"0" "1" "2" "3" "4" "5" "6" "7" "8" "9"
'
'</snippet1>