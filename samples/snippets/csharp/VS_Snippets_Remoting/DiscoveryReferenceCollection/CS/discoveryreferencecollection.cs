// System.Web.Services.Discovery.DiscoveryReferenceCollection.DiscoveryReferenceCollection
// System.Web.Services.Discovery.DiscoveryReferenceCollection.Add(DiscoveryReference)
// System.Web.Services.Discovery.DiscoveryReferenceCollection.Contains(DiscoveryReference)
// System.Web.Services.Discovery.DiscoveryReferenceCollection.Item(int)
// System.Web.Services.Discovery.DiscoveryReferenceCollection.Remove(DiscoveryReference)
// System.Web.Services.Discovery.DiscoveryReferenceCollection

/* The following example demonstrates the usage of 'DiscoveryReferenceCollection' class, 'Add', 'Contains',
 * 'Item'and  'Remove' methods and its constructor. A variable of 'DiscoveryReferenceCollection'
 * class is taken. Two 'DiscoveryReference' type member is added to the collection. Using this
 * various methods of 'DiscoveryReferenceCollection' class are demonstrated.
*/

 // <Snippet1>
using System;
using System.IO;
using System.Web.Services.Discovery;

 // <Snippet2>
class MyDiscoveryDocumentClass
{
   static void Main()
   {
      DiscoveryDocumentReference myDiscoveryDocReference1 = 
         new DiscoveryDocumentReference();
      DiscoveryDocumentReference myDiscoveryDocReference2 = 
         new DiscoveryDocumentReference();
      DiscoveryReference myDiscoveryReference;

      Console.WriteLine("Demonstrating DiscoveryReferenceCollection class.");
     
      // Create new DiscoveryReferenceCollection.
      DiscoveryReferenceCollection myDiscoveryReferenceCollection = 
         new DiscoveryReferenceCollection();

      // Access the Count method.
      Console.WriteLine("The number of elements in the collection is: " 
         + myDiscoveryReferenceCollection.Count.ToString());

      // Add elements to the collection.
      myDiscoveryReferenceCollection.Add(myDiscoveryDocReference1);
      myDiscoveryReferenceCollection.Add(myDiscoveryDocReference2);

      Console.WriteLine("The number of elements in the collection "
         + "after adding two elements to the collection: " 
         + myDiscoveryReferenceCollection.Count.ToString());

      // Call the Contains method.
      if (myDiscoveryReferenceCollection.Contains(myDiscoveryDocReference1) 
         != true)
      {
         throw new Exception("Element not found in collection.");
      }

      // Access the indexed member.
      myDiscoveryReference = 
         (DiscoveryReference)myDiscoveryReferenceCollection[0];
      if (myDiscoveryReference == null)
      {
         throw new Exception("Element not found in collection.");
      }

      // Remove one element from collection.
      myDiscoveryReferenceCollection.Remove(myDiscoveryDocReference1);
      Console.WriteLine("The number of elements in the collection "
         + "after removing one element is: " 
         + myDiscoveryReferenceCollection.Count.ToString());
   }
// </Snippet2>
}
// </Snippet1>
