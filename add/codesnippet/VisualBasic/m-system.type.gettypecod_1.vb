    Sub WriteObjectInfo(ByVal testObject As Object)
        Dim typeCode As TypeCode = Type.GetTypeCode(testObject.GetType())

        Select Case typeCode
            Case typeCode.Boolean
                Console.WriteLine("Boolean: {0}", testObject)

            Case typeCode.Double
                Console.WriteLine("Double: {0}", testObject)

            Case Else
                Console.WriteLine("{0}: {1}", typeCode.ToString(), testObject)
        End Select
    End Sub