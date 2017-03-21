        // Check to see whether the collection contains mySecondSoapHeader.
        if(mySoapHeaderCollection.Contains(mySecondSoapHeader))
        {
            // Get the index of mySecondSoapHeader from the collection.
            Console.WriteLine("Index of mySecondSoapHeader: " + 
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader));

            // Get the SoapHeader from the collection.
            MySoapHeader mySoapHeader1 = (MySoapHeader)mySoapHeaderCollection
                [mySoapHeaderCollection.IndexOf(mySecondSoapHeader)];
            Console.WriteLine("SoapHeader retrieved from the collection: " 
                + mySoapHeader1);

            // Remove a SoapHeader from the collection.
            mySoapHeaderCollection.Remove(mySoapHeader1);
            Console.WriteLine("Number of items after removal: {0}", 
                mySoapHeaderCollection.Count);
        }
        else
            Console.WriteLine(
                "mySoapHeaderCollection does not contain mySecondSoapHeader.");