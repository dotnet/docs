        Dim value As Integer = 321
        Dim strValue As String = converter.ConvertValueToString(value, GetType(Int32))
        Console.WriteLine("the value = {0}, the string representation of the value = {1}", value, strValue)