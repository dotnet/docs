' Visual Basic .NET Document
Option Strict On
' <Snippet12>
Imports System.Collections.Concurrent
Imports System.Threading

Public Class Continent
   Public Property Name As String
   Public Property Population As Integer
   Public Property Area As Decimal  
End Class

Module Example
   Dim continents As New ConcurrentBag(Of Continent)
   Dim gate As CountdownEvent
   Dim msg As String = String.Empty
      
   Public Sub Main()
      Dim names() As String = { "Africa", "Antarctica", "Asia", 
                                "Australia", "Europe", "North America",
                                "South America" }
      gate = new CountdownEvent(names.Length)
      
      ' Populate the list.
      For Each name In names
         Dim th As New Thread(AddressOf PopulateContinents)
         th.Start(name)
      Next              

      ' Display the list.
      gate.Wait()
      Console.WriteLine(msg)
      Console.WriteLine()

      For ctr As Integer = 0 To names.Length - 1
         Dim continent = continents(ctr)
         Console.WriteLine("{0}: Area: {1}, Population {2}", 
                           continent.Name, continent.Population,
                           continent.Area)
      Next
   End Sub
   
   Private Sub PopulateContinents(obj As Object)
      Dim name As String = obj.ToString()
      SyncLock msg 
         msg += String.Format("Adding '{0}' to the list.{1}", name, vbCrLf)
      End SyncLock
      Dim continent As New Continent()
      continent.Name = name
      ' Sleep to simulate retrieving remaining data.
      Thread.Sleep(25)
      continents.Add(continent)
      gate.Signal()
   End Sub
End Module
' The example displays output like the following:
'    Adding 'Africa' to the list.
'    Adding 'Antarctica' to the list.
'    Adding 'Asia' to the list.
'    Adding 'Australia' to the list.
'    Adding 'Europe' to the list.
'    Adding 'North America' to the list.
'    Adding 'South America' to the list.
'    
'    
'    Africa: Area: 0, Population 0
'    Antarctica: Area: 0, Population 0
'    Asia: Area: 0, Population 0
'    Australia: Area: 0, Population 0
'    Europe: Area: 0, Population 0
'    North America: Area: 0, Population 0
'    South America: Area: 0, Population 0
' </Snippet12>
