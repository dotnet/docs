// <snippet1>
using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

// Demonstrates how to use non-greedy join blocks to distribute
// resources among a dataflow network.
class Program
{
   // Represents a resource. A derived class might represent
   // a limited resource such as a memory, network, or I/O
   // device.
   abstract class Resource
   {
   }

   // Represents a memory resource. For brevity, the details of
   // this class are omitted.
   class MemoryResource : Resource
   {
   }

   // Represents a network resource. For brevity, the details of
   // this class are omitted.
   class NetworkResource : Resource
   {
   }

   // Represents a file resource. For brevity, the details of
   // this class are omitted.
   class FileResource : Resource
   {
   }

   static void Main(string[] args)
   {
      // Create three BufferBlock<T> objects. Each object holds a different
      // type of resource.
      var networkResources = new BufferBlock<NetworkResource>();
      var fileResources = new BufferBlock<FileResource>();
      var memoryResources = new BufferBlock<MemoryResource>();

      // Create two non-greedy JoinBlock<T1, T2> objects.
      // The first join works with network and memory resources;
      // the second pool works with file and memory resources.

      var joinNetworkAndMemoryResources =
         new JoinBlock<NetworkResource, MemoryResource>(
            new GroupingDataflowBlockOptions
            {
               Greedy = false
            });

      var joinFileAndMemoryResources =
         new JoinBlock<FileResource, MemoryResource>(
            new GroupingDataflowBlockOptions
            {
               Greedy = false
            });

      // Create two ActionBlock<T> objects.
      // The first block acts on a network resource and a memory resource.
      // The second block acts on a file resource and a memory resource.

      var networkMemoryAction =
         new ActionBlock<Tuple<NetworkResource, MemoryResource>>(
            data =>
            {
               // Perform some action on the resources.

               // Print a message.
               Console.WriteLine("Network worker: using resources...");

               // Simulate a lengthy operation that uses the resources.
               Thread.Sleep(new Random().Next(500, 2000));

               // Print a message.
               Console.WriteLine("Network worker: finished using resources...");

               // Release the resources back to their respective pools.
               networkResources.Post(data.Item1);
               memoryResources.Post(data.Item2);
            });

      var fileMemoryAction =
         new ActionBlock<Tuple<FileResource, MemoryResource>>(
            data =>
            {
               // Perform some action on the resources.

               // Print a message.
               Console.WriteLine("File worker: using resources...");

               // Simulate a lengthy operation that uses the resources.
               Thread.Sleep(new Random().Next(500, 2000));

               // Print a message.
               Console.WriteLine("File worker: finished using resources...");

               // Release the resources back to their respective pools.
               fileResources.Post(data.Item1);
               memoryResources.Post(data.Item2);
            });

      // Link the resource pools to the JoinBlock<T1, T2> objects.
      // Because these join blocks operate in non-greedy mode, they do not
      // take the resource from a pool until all resources are available from
      // all pools.

      networkResources.LinkTo(joinNetworkAndMemoryResources.Target1);
      memoryResources.LinkTo(joinNetworkAndMemoryResources.Target2);

      fileResources.LinkTo(joinFileAndMemoryResources.Target1);
      memoryResources.LinkTo(joinFileAndMemoryResources.Target2);

      // Link the JoinBlock<T1, T2> objects to the ActionBlock<T> objects.

      joinNetworkAndMemoryResources.LinkTo(networkMemoryAction);
      joinFileAndMemoryResources.LinkTo(fileMemoryAction);

      // Populate the resource pools. In this example, network and
      // file resources are more abundant than memory resources.

      networkResources.Post(new NetworkResource());
      networkResources.Post(new NetworkResource());
      networkResources.Post(new NetworkResource());

      memoryResources.Post(new MemoryResource());

      fileResources.Post(new FileResource());
      fileResources.Post(new FileResource());
      fileResources.Post(new FileResource());

      // Allow data to flow through the network for several seconds.
      Thread.Sleep(10000);
   }
}

/* Sample output:
File worker: using resources...
File worker: finished using resources...
Network worker: using resources...
Network worker: finished using resources...
File worker: using resources...
File worker: finished using resources...
Network worker: using resources...
Network worker: finished using resources...
File worker: using resources...
File worker: finished using resources...
File worker: using resources...
File worker: finished using resources...
Network worker: using resources...
Network worker: finished using resources...
Network worker: using resources...
Network worker: finished using resources...
File worker: using resources...
*/
// </snippet1>