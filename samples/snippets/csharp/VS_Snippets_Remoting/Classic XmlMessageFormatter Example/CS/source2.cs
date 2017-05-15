// <Snippet2>
using System;
 
 public class Order{
 
     public int itemId;
     public int quantity;
     public string address;
 
     public void ShipItems(){
 
         Console.WriteLine("Order Placed:");
         Console.WriteLine("\tItem ID  : {0}",itemId);
         Console.WriteLine("\tQuantity : {0}",quantity);
         Console.WriteLine("\tShip To  : {0}",address);
 
         // Add order to the database.
         /* Insert code here. */
 
     }
 }
 // </Snippet2>

