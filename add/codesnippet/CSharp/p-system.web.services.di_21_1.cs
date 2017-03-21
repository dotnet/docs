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