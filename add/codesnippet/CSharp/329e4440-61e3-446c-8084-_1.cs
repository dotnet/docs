         // Check element of type 'SoapAddressBinding' in collection.
         Object   myObj = myCollection.Find(mySoapAddressBinding.GetType());
         if(myObj == null)
         {
            Console.WriteLine("Element of type '{0}' not found in collection.",
               mySoapAddressBinding.GetType().ToString());
         }
         else
         {
            Console.WriteLine("Element of type '{0}' found in collection.",
               mySoapAddressBinding.GetType().ToString());
         }