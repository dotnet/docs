         ' Get an IDictionary of properties for a given proxy.
         Dim myDictionary As IDictionary = ChannelServices.GetChannelSinkProperties(myProxy)
         Dim myKeysCollection As ICollection = myDictionary.Keys
         Dim myKeysArray(myKeysCollection.Count-1) As Object
         Dim myValuesCollection As ICollection = myDictionary.Values
         Dim myValuesArray(myValuesCollection.Count-1) As Object
         myKeysCollection.CopyTo(myKeysArray, 0)
         myValuesCollection.CopyTo(myValuesArray, 0)
         Dim iIndex As Integer
         For iIndex = 0 To myKeysArray.Length - 1
            Console.Write("Property Name : " & myKeysArray(iIndex) & " value : ")
            Console.WriteLine(myValuesArray(iIndex))
         Next iIndex