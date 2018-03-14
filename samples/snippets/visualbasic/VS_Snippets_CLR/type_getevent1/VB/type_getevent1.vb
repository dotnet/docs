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
            ' Creates a bitmask comprising  BindingFlags.
            Dim myBindingFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.Public _
                                                 Or BindingFlags.NonPublic
            Dim myTypeBindingFlags As Type = GetType(System.Windows.Forms.Button)
            Dim myEventBindingFlags As EventInfo = myTypeBindingFlags.GetEvent("Click", myBindingFlags)
            If myEventBindingFlags IsNot Nothing Then
                Console.WriteLine("Looking for the Click event in the Button class with the specified BindingFlags.")
                Console.WriteLine(myEventBindingFlags.ToString())
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