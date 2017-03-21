            ' Create an array of doubles.
            Dim numbers() As Double = {49.6, 52.3, 51.0, 49.4, 50.2, 48.3}

            ' Get the last item whose value rounds to 50.0.
            Dim number50 As Double =
            numbers.LastOrDefault(Function(n) Math.Round(n) = 50.0)

            Dim output As New System.Text.StringBuilder
            output.AppendLine("The last number that rounds to 50 is " & number50)

            ' Get the last item whose value rounds to 40.0.
            Dim number40 As Double =
            numbers.LastOrDefault(Function(n) Math.Round(n) = 40.0)

            Dim text As String = IIf(number40 = 0.0,
                                 "[DOES NOT EXIST]",
                                 number40.ToString())
            output.AppendLine("The last number that rounds to 40 is " & text)

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' The last number that rounds to 50 is 50.2
            ' The last number that rounds to 40 is [DOES NOT EXIST]
