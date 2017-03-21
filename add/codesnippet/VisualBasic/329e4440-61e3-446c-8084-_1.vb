         ' Check element of type 'SoapAddressBinding' in collection.
         Dim myObj As Object = myCollection.Find(mySoapAddressBinding.GetType())
         If myObj Is Nothing Then
            Console.WriteLine("Element of type '{0}' not found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         Else
            Console.WriteLine("Element of type '{0}' found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         End If