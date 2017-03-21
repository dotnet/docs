        ' Check to see whether the collection contains mySecondSoapHeader.
        If mySoapHeaderCollection.Contains(mySecondSoapHeader) Then
            ' Get the index of mySecondSoapHeader from the collection.
            Console.WriteLine("Index of mySecondSoapHeader: " & _
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader).ToString())

            ' Get the SoapHeader from the collection.
            Dim mySoapHeader1 As MySoapHeader = CType(mySoapHeaderCollection( _
                mySoapHeaderCollection.IndexOf(mySecondSoapHeader)), _
                MySoapHeader)
            Console.WriteLine("SoapHeader retrieved from the collection: " _
                & mySoapHeader1.ToString())

           ' Remove a SoapHeader from the collection.
           mySoapHeaderCollection.Remove(mySoapHeader1)
           Console.WriteLine("Number of items after removal: {0}", _
               & mySoapHeaderCollection.Count)
        Else
        Console.WriteLine( _
            "mySoapHeaderCollection does not contain mySecondSoapHeader.")
        End If