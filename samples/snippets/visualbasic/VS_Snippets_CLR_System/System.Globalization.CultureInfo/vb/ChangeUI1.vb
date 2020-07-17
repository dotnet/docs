' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim current As CultureInfo = CultureInfo.CurrentUICulture
        Console.WriteLine("The current UI culture is {0}", current.Name)
        Dim newUICulture As CultureInfo
        If current.Name.Equals("sl-SI") Then
            newUICulture = New CultureInfo("hr-HR")
        Else
            newUICulture = new CultureInfo("sl-SI")
        End If

        CultureInfo.CurrentUICulture = newUICulture
        Console.WriteLine("The current UI culture is now {0}",
                          CultureInfo.CurrentUICulture.Name)
    End Sub
End Module
' The example displays output like the following:
'     The current UI culture is en-US
'     The current UI culture is now sl-SI
' </Snippet4>

