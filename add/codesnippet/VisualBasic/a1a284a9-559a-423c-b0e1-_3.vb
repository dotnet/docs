
      If service Is Nothing Then
         Console.WriteLine("Could not locate server.")
         Return
      End If
            
      ' Calls the remote method.
      Console.WriteLine()
      Console.WriteLine("Calling remote object")
      Console.WriteLine(service.HelloMethod("Caveman"))
      Console.WriteLine(service.HelloMethod("Spaceman"))
      Console.WriteLine(service.HelloMethod("Client Man"))
      Console.WriteLine("Finished remote object call")
      Console.WriteLine()

   End Sub 'Main

End Class 'ClientClass