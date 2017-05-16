' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Security
Imports Microsoft.VisualBasic

' Compile this sample using the following command line:
' vbc type_getevent.vb /r:"System.Windows.Forms.dll" /r:"System.dll"

Class MyEventExample
    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType(System.Windows.Forms.Button)
            Dim myEvent As EventInfo = myType.GetEvent("Click")
            If Not (myEvent Is Nothing) Then
                Console.WriteLine(ControlChars.Cr + "Looking for the Click event in the Button class.")
                Console.WriteLine(ControlChars.Cr + myEvent.ToString())
            Else
                Console.WriteLine("The Click event is not available with the Button class.")
            End If
        Catch e As SecurityException
            Console.WriteLine("An exception occurred.")
            Console.WriteLine("Message :" + e.Message)
        Catch e As ArgumentNullException
            Console.WriteLine("An exception occurred.")
            Console.WriteLine("Message :" + e.Message)
        Catch e As Exception
            Console.WriteLine("The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'Main
End Class 'MyEventExample
' </Snippet1>
