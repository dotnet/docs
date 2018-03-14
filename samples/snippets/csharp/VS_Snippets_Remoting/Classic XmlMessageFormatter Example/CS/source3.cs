// <Snippet3>
using System;
using System.Messaging;
 
 class Client{
 
     public static void Main(){
 
         string queuePath = ".\\orders";
         EnsureQueueExists(queuePath);
         MessageQueue queue = new MessageQueue(queuePath);
 
         Order orderRequest = new Order();
         orderRequest.itemId = 1025;
         orderRequest.quantity = 5;
         orderRequest.address = "One Microsoft Way";
 
         queue.Send(orderRequest);
         // This line uses a new method you define on the Order class:
         // orderRequest.PrintReceipt();
     }
 
     // Creates the queue if it does not already exist.
     public static void EnsureQueueExists(string path){
         if(!MessageQueue.Exists(path)){
             MessageQueue.Create(path);
         }
     }
 
 }
 // </Snippet3>

public class Order
{
   public int itemId;
   public int quantity;
   public string address;

   public void ShipItems()
   {
   }
}
