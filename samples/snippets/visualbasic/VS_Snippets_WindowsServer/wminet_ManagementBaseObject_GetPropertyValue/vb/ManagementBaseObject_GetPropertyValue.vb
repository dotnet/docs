'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim processClass As New ManagementClass( _
            "Win32_Process")

        Dim classObjects As ManagementObjectCollection
        classObjects = processClass.GetInstances()

        For Each classObject As ManagementObject _
            In classObjects

            Console.WriteLine( _
                classObject.GetPropertyValue( _
                    "Name"))

        Next

    End Function
End Class
'</Snippet1>