Option Strict On
Option Infer On

Module Tuples
    Sub Main()
        UseUnNamedTuple()
        Console.WriteLine()
        UseNamedTuple()
        Console.WriteLine()
        NamedTupleDeclaration()
        Console.WriteLine()
        AssignmentsConversions()
        Console.WriteLine()

        TupleReturns.Run()
        Console.WriteLine()

        Console.Write("Press <Enter> to exit... ")
        Console.ReadLine()
    End Sub

    Private Sub UseUnNamedTuple()
        ' <Instantiate>
        Dim holiday = (#07/04/2017#, "Independence Day", True)
        ' </Instantiate>
        ' <DefaultNames>
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        ' </DefaultNames>
        ' <Mutable>
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' Output: 1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Mutable> 
    End Sub

    Private Sub UseNamedTuple()
        ' <Named>
        Dim holiday = (EventDate:=#07/04/2017#, Name:="Independence Day", IsHoliday:=True)
        Console.WriteLine($"{holiday.EventDate} Is {holiday.Name}" +
                          $"{If(holiday.IsHoliday, ", a national holiday", String.Empty)}")
        holiday.Item1 = #01/01/2018#
        holiday.Item2 = "New Year's Day"
        Console.WriteLine($"{holiday.Item1} is {holiday.Item2}" +
                          $"{If(holiday.Item3, ", a national holiday", String.Empty)}")
        ' The example displays the following output:
        '   7/4/2017 12:00:00 AM Is Independence Day, a national holiday
        '   1/1/2018 12:00:00 AM Is New Year's Day, a national holiday
        ' </Named>
    End Sub

    Private Sub NamedTupleDeclaration()
        '<NamedDeclaration>
        Dim holiday As (EventDate As Date, Name As String, IsHoliday As Boolean) =
            (#07/04/2017#, "Independence Day", True)
        Console.WriteLine(holiday.Name)
        ' Output: Independence Day
        '</NamedDeclaration>

        '<NamedCollectionInitializer>
        Dim events As New List(Of (EventDate As Date, Name As String, IsHoliday As Boolean)) From {
            (#07/04/2017#, "Independence Day", True),
            (#04/22/2017#, "Earth Day", False)
        }
        Console.WriteLine(events(1).IsHoliday)
        ' Output: False
        '</NamedCollectionInitializer>
    End Sub

    Private Sub AssignmentsConversions()
        ' <AssignmentsIDeclarations>
        ' The number and field types of all these tuples are compatible. 
        ' The only difference Is the field names being used.
        Dim unnamed = (42, "The meaning of life")
        Dim anonymous = (16, "a perfect square")
        Dim named = (Answer:=42, Message:="The meaning of life")
        Dim differentNamed = (SecretConstant:=42, Label:="The meaning of life")
        ' </AssignmentsIDeclarations>

        ' <Assignments>
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
        ' </Assignments>

        ' <AssignmentImplicitConversion>
        ' Assign an (Integer, String) tuple to a (Long, String) tuple (using implicit conversion).
        Dim conversion As (Long, String) = named
        Console.WriteLine($"{conversion.Item1} ({conversion.Item1.GetType().Name}), " +
                          $"{conversion.Item2} ({conversion.Item2.GetType().Name})")
        ' Output:      42 (Int64), The meaning of life (String)
        ' </AssignmentImplicitConversion>
    End Sub

    Sub TupleValueTupleConversions()
        '<TupleValueTupleConversions>
        Dim cityInfo = (name:="New York", area:=468.5, population:=8_550_405)
        Console.WriteLine($"{cityInfo}, type {cityInfo.GetType().Name}")

        ' Convert the Visual Basic tuple to a .NET tuple.
        Dim cityInfoT = TupleExtensions.ToTuple(cityInfo)
        Console.WriteLine($"{cityInfoT}, type {cityInfoT.GetType().Name}")

        ' Convert the .NET tuple back to a Visual Basic tuple and ensure they are the same.
        Dim cityInfo2 = TupleExtensions.ToValueTuple(cityInfoT)
        Console.WriteLine($"{cityInfo2}, type {cityInfo2.GetType().Name}")
        Console.WriteLine($"{NameOf(cityInfo)} = {NameOf(cityInfo2)}: {cityInfo.Equals(cityInfo2)}")

        ' The example displays the following output:
        '       (New York, 468.5, 8550405), type ValueTuple`3
        '       (New York, 468.5, 8550405), type Tuple`3
        '       (New York, 468.5, 8550405), type ValueTuple`3
        '       cityInfo = cityInfo2 :  True
        '</TupleValueTupleConversions>
    End Sub
End Module
