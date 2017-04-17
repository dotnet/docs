Imports System
Imports System.Diagnostics

Public Class SomeClass
'/ <Snippet4>
    Private Shared boolSwitch As new BooleanSwitch("mySwitch", _
        "Switch in config file")

    Public Shared Sub Main( )
        '...
        Console.WriteLine("Boolean switch {0} configured as {1}",
            boolSwitch.DisplayName, boolSwitch.Enabled.ToString())
        If boolSwitch.Enabled = True Then
            '...
        End If
    End Sub
'/ </Snippet4>
End Class

