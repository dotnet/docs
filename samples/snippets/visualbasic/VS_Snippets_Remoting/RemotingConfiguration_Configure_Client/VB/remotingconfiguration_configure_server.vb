' System.Runtime.Remoting.RemotingConfiguration.Configure
' System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownServiceTypes
'
' The following example demonstrates the 'Configure' and 
' 'GetRegisteredWellKnownServiceTypes' methods of 'RemotingConfiguration' class.
' It configures the remoting infrastructure using the 'Configure' method.Then gets
' the registered well-known objects at the service end and displays it's properties 
' on the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http

Public Class Sample
   
   Public Shared Sub Main()
' <Snippet1>
      ' Configure the remoting structure.
      RemotingConfiguration.Configure("server.config")
      
' </Snippet1>
' <Snippet2>

      ' Retrive the array of objects registered as well known types at
      ' the service end.
      Dim myEntries As WellKnownServiceTypeEntry() = _ 
                       RemotingConfiguration.GetRegisteredWellKnownServiceTypes()
      Console.WriteLine("The number of WellKnownServiceTypeEntries are:" + myEntries.Length.ToString())
      Console.WriteLine("The Object Type is:" + myEntries(0).ObjectType.ToString())
      Console.WriteLine("The Object Uri is:" + myEntries(0).ObjectUri)
      Console.WriteLine("The Mode is:" + myEntries(0).Mode.ToString())
      
' </Snippet2>
      Console.WriteLine("Press <enter> to exit...")
      Console.ReadLine()
   End Sub 'Main
End Class 'Sample