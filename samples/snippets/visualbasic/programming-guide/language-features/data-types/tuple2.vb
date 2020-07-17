Option Strict On
Option Infer On

' <Snippet1>
Module Example
    Sub Main()
        Dim cityInfo = (name:="New York", area:=468.5, population:=8_550_405)
        Console.WriteLine($"{cityInfo}, type {cityInfo.GetType().Name}")

        ' Convert the Visual Basic tuple to a .NET tuple.
        Dim cityInfoT = TupleExtensions.ToTuple(cityInfo)
        Console.WriteLine($"{cityInfoT}, type {cityInfoT.GetType().Name}")

        ' Convert the .NET tuple back to a Visual Basic tuple and ensure they are the same.
        Dim cityInfo2 = TupleExtensions.ToValueTuple(cityInfoT)
        Console.WriteLine($"{cityInfo2}, type {cityInfo2.GetType().Name}")
        Console.WriteLine($"{NameOf(cityInfo)} = {NameOf(cityInfo2)}: {cityInfo.Equals(cityInfo2)}")
        Console.ReadLine()
    End Sub
End Module
' The example displays the following output:
'       (New York, 468.5, 8550405), type ValueTuple`3
'       (New York, 468.5, 8550405), type Tuple`3
'       (New York, 468.5, 8550405), type ValueTuple`3
'       cityInfo = cityInfo2 :  True
' </Snippet1>
