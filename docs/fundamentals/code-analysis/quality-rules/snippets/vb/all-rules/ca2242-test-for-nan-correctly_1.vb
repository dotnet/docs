Imports System

Namespace ca2242

    Class NaNTests

        Shared zero As Double

        Shared Sub Main2242()
            Console.WriteLine(0 / zero = Double.NaN)
            Console.WriteLine(0 / zero <> Double.NaN)
            Console.WriteLine(Double.IsNaN(0 / zero))
        End Sub

    End Class

End Namespace
