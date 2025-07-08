
Module Example12
    Public Sub Main()
        Dim names = {"Balto", "Vanya", "Dakota", "Samuel", "Koani", "Yiska", "Yuma"}
        Dim output = names(0) + ", " + names(1) + ", " + names(2) + ", " +
                   names(3) + ", " + names(4) + ", " + names(5) + ", " +
                   names(6)

        output += vbCrLf
        Dim dat = DateTime.Now
        output += String.Format("It is {0:t} on {0:d}. The day of the week is {1}.",
                              dat, dat.DayOfWeek)
        Console.WriteLine(output)
    End Sub
End Module
' The example displays the following output:
'     Balto, Vanya, Dakota, Samuel, Koani, Yiska, Yuma
'     It is 10:29 AM on 1/8/2018. The day of the week is Monday.


