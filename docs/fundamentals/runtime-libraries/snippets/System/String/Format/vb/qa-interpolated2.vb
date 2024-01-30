
Module Example13
    Public Sub Main()
        Dim names = {"Balto", "Vanya", "Dakota", "Samuel", "Koani", "Yiska", "Yuma"}
        Dim output = $"{names(0)}, {names(1)}, {names(2)}, {names(3)}, {names(4)}, " +
                   $"{names(5)}, {names(6)}"

        Dim dat = DateTime.Now
        output += $"{vbCrLf}It is {dat:t} on {dat:d}. The day of the week is {dat.DayOfWeek}."
        Console.WriteLine(output)
    End Sub
End Module
' The example displays the following output:
'     Balto, Vanya, Dakota, Samuel, Koani, Yiska, Yuma
'     It is 10:29 AM on 1/8/2018. The day of the week is Monday.


