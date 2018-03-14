' <snippet1>
Imports System
Imports System.Threading
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to use non-greedy join blocks to distribute
' resources among a dataflow network.
Friend Class Program
   ' Represents a resource. A derived class might represent 
   ' a limited resource such as a memory, network, or I/O
   ' device.
   Private MustInherit Class Resource
   End Class

   ' Represents a memory resource. For brevity, the details of 
   ' this class are omitted.
   Private Class MemoryResource
       Inherits Resource
   End Class

   ' Represents a network resource. For brevity, the details of 
   ' this class are omitted.
   Private Class NetworkResource
       Inherits Resource
   End Class

   ' Represents a file resource. For brevity, the details of 
   ' this class are omitted.
   Private Class FileResource
       Inherits Resource
   End Class

   Shared Sub Main(ByVal args() As String)
      ' Create three BufferBlock<T> objects. Each object holds a different
      ' type of resource.
      Dim networkResources = New BufferBlock(Of NetworkResource)()
      Dim fileResources = New BufferBlock(Of FileResource)()
      Dim memoryResources = New BufferBlock(Of MemoryResource)()

      ' Create two non-greedy JoinBlock<T1, T2> objects. 
      ' The first join works with network and memory resources; 
      ' the second pool works with file and memory resources.

      Dim joinNetworkAndMemoryResources = New JoinBlock(Of NetworkResource, MemoryResource)(New GroupingDataflowBlockOptions With {.Greedy = False})

      Dim joinFileAndMemoryResources = New JoinBlock(Of FileResource, MemoryResource)(New GroupingDataflowBlockOptions With {.Greedy = False})

      ' Create two ActionBlock<T> objects. 
      ' The first block acts on a network resource and a memory resource.
      ' The second block acts on a file resource and a memory resource.

      Dim networkMemoryAction = New ActionBlock(Of Tuple(Of NetworkResource, MemoryResource))(Sub(data)
               ' Perform some action on the resources.
               ' Print a message.
               ' Simulate a lengthy operation that uses the resources.
               ' Print a message.
               ' Release the resources back to their respective pools.
          Console.WriteLine("Network worker: using resources...")
          Thread.Sleep(New Random().Next(500, 2000))
          Console.WriteLine("Network worker: finished using resources...")
          networkResources.Post(data.Item1)
          memoryResources.Post(data.Item2)
      End Sub)

      Dim fileMemoryAction = New ActionBlock(Of Tuple(Of FileResource, MemoryResource))(Sub(data)
               ' Perform some action on the resources.
               ' Print a message.
               ' Simulate a lengthy operation that uses the resources.
               ' Print a message.
               ' Release the resources back to their respective pools.
          Console.WriteLine("File worker: using resources...")
          Thread.Sleep(New Random().Next(500, 2000))
          Console.WriteLine("File worker: finished using resources...")
          fileResources.Post(data.Item1)
          memoryResources.Post(data.Item2)
      End Sub)

      ' Link the resource pools to the JoinBlock<T1, T2> objects.
      ' Because these join blocks operate in non-greedy mode, they do not
      ' take the resource from a pool until all resources are available from
      ' all pools.

      networkResources.LinkTo(joinNetworkAndMemoryResources.Target1)
      memoryResources.LinkTo(joinNetworkAndMemoryResources.Target2)

      fileResources.LinkTo(joinFileAndMemoryResources.Target1)
      memoryResources.LinkTo(joinFileAndMemoryResources.Target2)

      ' Link the JoinBlock<T1, T2> objects to the ActionBlock<T> objects.

      joinNetworkAndMemoryResources.LinkTo(networkMemoryAction)
      joinFileAndMemoryResources.LinkTo(fileMemoryAction)

      ' Populate the resource pools. In this example, network and 
      ' file resources are more abundant than memory resources.

      networkResources.Post(New NetworkResource())
      networkResources.Post(New NetworkResource())
      networkResources.Post(New NetworkResource())

      memoryResources.Post(New MemoryResource())

      fileResources.Post(New FileResource())
      fileResources.Post(New FileResource())
      fileResources.Post(New FileResource())

      ' Allow data to flow through the network for several seconds.
      Thread.Sleep(10000)

   End Sub

End Class

' Sample output:
'File worker: using resources...
'File worker: finished using resources...
'Network worker: using resources...
'Network worker: finished using resources...
'File worker: using resources...
'File worker: finished using resources...
'Network worker: using resources...
'Network worker: finished using resources...
'File worker: using resources...
'File worker: finished using resources...
'File worker: using resources...
'File worker: finished using resources...
'Network worker: using resources...
'Network worker: finished using resources...
'Network worker: using resources...
'Network worker: finished using resources...
'File worker: using resources...
'
' </snippet1>
