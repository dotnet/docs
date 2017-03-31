Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class ClientClass
   
   Shared Sub Main()
      Try
         ChannelServices.RegisterChannel(New TcpChannel())
         RemotingConfiguration.RegisterActivatedClientType(GetType(MyServerImpl), _ 
                                                      "tcp://localhost:8085")
         Dim myObject As New MyServerImpl()
         Dim i As Integer
         For i = 0 To 4
            Console.WriteLine _ 
               (myObject.MyMethod("invoke the server method " +(i + 1).ToString() + " time"))
         Next i
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'ClientClass