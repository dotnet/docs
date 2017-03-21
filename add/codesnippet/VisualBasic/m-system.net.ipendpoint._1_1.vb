        ' Recreate the connection endpoint from the serialized information.
        Dim endpoint As New IPEndPoint(0, 0)
        Dim clonedIPEndPoint As IPEndPoint = CType(endpoint.Create(socketAddress), IPEndPoint)
        Console.WriteLine(("clonedIPEndPoint: " + clonedIPEndPoint.ToString()))