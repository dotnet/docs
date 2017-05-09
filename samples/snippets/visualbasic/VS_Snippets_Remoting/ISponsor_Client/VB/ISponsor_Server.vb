Imports System
Imports System.Runtime.Remoting

Public Class Server
   
   Public Shared Sub Main()
      RemotingConfiguration.Configure("ISponsor_Server.config")
      
      Console.WriteLine("The server is listening. Press Enter to exit....")
      Console.ReadLine()
      
      Console.WriteLine("Garbage Collecting.")
      GC.Collect()
      GC.WaitForPendingFinalizers()
   End Sub 'Main
End Class 'Server