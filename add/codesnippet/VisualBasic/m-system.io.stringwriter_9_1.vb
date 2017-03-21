Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.IO

Public Class StrWriter

    Shared Sub Main()
        Dim strWriter As New StringWriter(New CultureInfo("ar-DZ"))

        strWriter.Write(DateTime.Now)

        Console.WriteLine( _
            "Current date and time using the invariant culture: {0}" _
            & vbCrLf & _
            "Current date and time using the Algerian culture: {1}", _
            DateTime.Now.ToString(), strWriter.ToString())
    End Sub

End Class