Option Strict on
Option Explicit On

' <Snippet1>
Public Module PingPong

    Private greetings As String = "PONG!"

    Sub Main()
        Dim otherDomain As AppDomain = AppDomain.CreateDomain("otherDomain")

        greetings = "PING!"
        MyCallBack()
        otherDomain.DoCallBack(AddressOf MyCallBack)

        ' Output:
        '   PING! from defaultDomain
        '   PONG! from otherDomain
     End Sub

     Sub MyCallBack()
        Dim name As String = AppDomain.CurrentDomain.FriendlyName
        If name = AppDomain.CurrentDomain.SetupInformation.ApplicationName Then
            name = "defaultDomain"
        End If
        Console.WriteLine(greetings + " from " + name)
     End Sub

End Module 'PingPong
' </Snippet1>