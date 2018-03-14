' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Security
Imports Microsoft.VisualBasic

' Compile this sample using the following command line:
' vbc type_getevents.vb /r:"System.Windows.Forms.dll" /r:"System.dll"

Class EventsSample

    Public Shared Sub Main()
        Try
            ' Creates a bitmask based on BindingFlags.
            Dim myBindingFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.Public
            Dim myTypeEvent As Type = GetType(System.Windows.Forms.Button)
            Dim myEventsBindingFlags As EventInfo() = myTypeEvent.GetEvents(myBindingFlags)
            Console.WriteLine(ControlChars.Cr + "The events on the Button class with the specified BindingFlags are : ")
            Dim index As Integer
            For index = 0 To myEventsBindingFlags.Length - 1
                Console.WriteLine(myEventsBindingFlags(index).ToString())
            Next index
        Catch e As SecurityException
            Console.WriteLine(("SecurityException :" + e.Message))
        Catch e As ArgumentNullException
            Console.WriteLine(("ArgumentNullException : " + e.Message))
        Catch e As Exception
            Console.WriteLine(("Exception : " + e.Message))
        End Try
    End Sub 'Main
End Class 'EventsSample
' </Snippet1>
