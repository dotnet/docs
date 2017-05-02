Module Module1
    Sub Main()
        ' <Snippet1>
        ' The number and field types of all these tuples are compatible. 
        ' The only difference Is the field names being used.
        Dim unnamed = (42, "The meaning of life")
        Dim anonymous = (16, "a perfect square")
        Dim named = (Answer:=42, Message:="The meaning of life")
        Dim differentNamed = (SecretConstant:=42, Label:="The meaning of life")
        ' </Snippet1>

        ' <Snippet2>
        ' Assign named to unnamed.
        named = unnamed

        ' Despite the assignment, named still has fields that can be referred to as 'answer' and 'message'.
        Console.WriteLine($"{named.Answer}, {named.Message}")
        ' Output:  42, The meaning of life

        ' Assign unnamed to anonymous.
        anonymous = unnamed
        ' Because of the assignment, the value of the elements of anonymous changed.
        Console.WriteLine($"{anonymous.Item1}, {anonymous.Item2}")
        ' Output:   42, The meaning of life

        ' Assign one named tuple to the other.
        named = differentNamed
        ' The field names are Not assigned. 'named' still has 'answer' and 'message' fields.
        Console.WriteLine($"{named.Answer}, {named.Message}")
        ' Output:   42, The meaning of life
        ' </Snippet2>

        ' <Snippet3>
        ' Assign an (Integer, String) tuple to a (Long, String) tuple (using implicit conversion).
        Dim conversion As (Long, String) = named
        Console.WriteLine($"{conversion.Item1} ({conversion.Item1.GetType().Name}), " +
                          $"{conversion.Item2} ({conversion.Item2.GetType().Name})")
        ' Output:      42 (Int64), The meaning of life (String)
        ' </Snippet3>
        Console.ReadLine()
    End Sub
End Module
