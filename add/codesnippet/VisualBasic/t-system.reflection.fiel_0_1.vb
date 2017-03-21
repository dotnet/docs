        Dim fi As FieldInfo = obj.GetType().GetField("field1")

        If (fi.Attributes And FieldAttributes.FieldAccessMask) = _
            FieldAttributes.Public Then
            Console.WriteLine("{0:s} is public. Value: {1:d}", fi.Name, fi.GetValue(obj))
        End If