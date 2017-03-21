         // Check all elements of type 'SoapBinding' in collection.
         Object[] myObjectArray1 = new Object[myCollection.Count];
         myObjectArray1 = myCollection.FindAll(mySoapBinding1.GetType());
         int myNumberOfElements = 0;
         IEnumerator myIEnumerator  = myObjectArray1.GetEnumerator();
         
         // Calculate number of elements of type 'SoapBinding'.
         while(myIEnumerator.MoveNext())
         {
            if(mySoapBinding1.GetType() == myIEnumerator.Current.GetType())
               myNumberOfElements++;
         }
         Console.WriteLine("Collection contains {0} objects of type '{1}'.", 
                           myNumberOfElements.ToString(),
                           mySoapBinding1.GetType().ToString());