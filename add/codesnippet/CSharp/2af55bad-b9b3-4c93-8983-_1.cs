         // Get an IDictionary of properties for a given proxy.
         IDictionary myDictionary = ChannelServices.
                  GetChannelSinkProperties(myProxy);
         ICollection myKeysCollection = myDictionary.Keys;
         object[] myKeysArray = new object[myKeysCollection.Count];
         ICollection myValuesCollection = myDictionary.Values;
         object[] myValuesArray = new object[myValuesCollection.Count];
         myKeysCollection.CopyTo(myKeysArray,0);
         myValuesCollection.CopyTo(myValuesArray,0);
         for(int iIndex=0;iIndex<myKeysArray.Length;iIndex++)
         {
            Console.WriteLine("Property Name : "+myKeysArray[iIndex]+ 
               " value : "+myValuesArray[iIndex]);
         }