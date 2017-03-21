            Dim myGuid As New Guid("B80D56EC-5899-459d-83B4-1AE0BB8418E4")
            Dim myGuidString As String = "1AA7F83F-C7F5-11D0-A376-00C04FC9DA04"
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertTo(myGuid, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertFrom(myGuidString))