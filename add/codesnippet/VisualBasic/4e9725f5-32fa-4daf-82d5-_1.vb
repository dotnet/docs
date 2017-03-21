         ' Check for 'myFormatExtension' object in collection.
         If myCollection.Contains(myFormatExtensionObject) Then
            ' Get index of a 'myFormatExtension' object in collection.
            Console.WriteLine("Index of 'myFormatExtensionObject' is " + _
                 "{0} in collection.", myCollection.IndexOf(myFormatExtensionObject).ToString())
            ' Remove 'myFormatExtensionObject' element from collection.
            myCollection.Remove(myFormatExtensionObject)
            Console.WriteLine("'myFormatExtensionObject' is removed" + _
                 " from collection.")
         End If