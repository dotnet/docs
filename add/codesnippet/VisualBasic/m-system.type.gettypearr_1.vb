         Dim myObject(2) As Object
         myObject(0) = 66
         myObject(1) = "puri"
         myObject(2) = 33.33
         ' Get the array of 'Type' class objects.
         Dim myTypeArray As Type() = Type.GetTypeArray(myObject)
         Console.WriteLine("Full names of the 'Type' objects in the array are:")
         Dim h As Integer
         For h = 0 To myTypeArray.Length - 1
            Console.WriteLine(myTypeArray(h).FullName)
         Next h