// <Snippet1>
using System;
using System.Messaging;
 
 public class Server{
 
     public static void Main(){
 
         Console.WriteLine("Processing Orders");
 
         string queuePath = ".\\orders";
         EnsureQueueExists(queuePath);
         MessageQueue queue = new MessageQueue(queuePath);
         ((XmlMessageFormatter)queue.Formatter).TargetTypeNames = new string[]{"Order"};
 
         while(true){
             Order newOrder = (Order)queue.Receive().Body;
             newOrder.ShipItems();
         }
     }
 
     // Creates the queue if it does not already exist.
     public static void EnsureQueueExists(string path){
         if(!MessageQueue.Exists(path)){
             MessageQueue.Create(path);
         }
     }
 }
// </Snippet1>

public class Order
{
   public void ShipItems()
   {
   }
}
