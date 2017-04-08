Option Strict On
Option Explicit On

Imports System

' <Snippet3>
Public Class PingPong
    Inherits MarshalByRefObject

    Private greetings As String = "PING!"
   
    Public Shared Sub Main()
        Dim otherDomain As AppDomain = AppDomain.CreateDomain("otherDomain")

        Dim pp As New PingPong()
        pp.MyCallBack()
        pp.greetings = "PONG!"
        otherDomain.DoCallBack(AddressOf pp.MyCallBack)

        ' Output:
        '   PING! from default domain
        '   PONG! from default domain
     End Sub 'Main

    ' Callback will always execute within defaultDomain due to inheritance from
    ' MarshalByRefObject
    Public Sub MyCallBack()
        Dim name As String = AppDomain.CurrentDomain.FriendlyName
        If name = AppDomain.CurrentDomain.SetupInformation.ApplicationName Then
            name = "defaultDomain"
        End If
        Console.WriteLine((greetings + " from " + name))
    End Sub 'MyCallBack

End Class 'PingPong
' </Snippet3>