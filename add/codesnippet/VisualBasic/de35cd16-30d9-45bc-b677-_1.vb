         ' Check all elements of type 'SoapBinding' in collection.
         Dim myObjectArray1(myCollection.Count -1 ) As Object
         myObjectArray1 = myCollection.FindAll(mySoapBinding1.GetType())
         Dim myNumberOfElements As Integer = 0
         Dim myIEnumerator As IEnumerator = myObjectArray1.GetEnumerator()
         
         ' Calculate number of elements of type 'SoapBinding'.
         While myIEnumerator.MoveNext()
            If mySoapBinding1.GetType() Is  myIEnumerator.Current.GetType() Then
               myNumberOfElements += 1
            End If
         End While
         Console.WriteLine("Collection contains {0} objects of type '{1}'.", _
                 myNumberOfElements.ToString(), mySoapBinding1.GetType().ToString())