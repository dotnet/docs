Option Strict On
Option Explicit On

Imports System

' <Snippet2>
<Serializable> _
Public Class PingPong
     Private greetings As String = "PING!"

     Public Shared Sub Main()
        Dim otherDomain As AppDomain = AppDomain.CreateDomain("otherDomain")

        Dim pp As New PingPong()
        pp.MyCallBack()
        pp.greetings = "PONG!"
        otherDomain.DoCallBack(AddressOf pp.MyCallBack)

        ' Output:
        '   PING! from defaultDomain
        '   PONG! from otherDomain
    End Sub 'Main

    Public Sub MyCallBack()
        Dim name As String = AppDomain.CurrentDomain.FriendlyName
        If name = AppDomain.CurrentDomain.SetupInformation.ApplicationName Then
            name = "defaultDomain"
        End If
        Console.WriteLine(greetings + " from " + name)
    End Sub 'MyCallBack

End Class 'PingPong
' </Snippet2>