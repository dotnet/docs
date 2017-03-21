        ' Push ten items on to the stack and output the value of each.
        Dim number As Integer
        For number = 0 To 9
            Console.WriteLine(("Value pushed to stack: " + number.ToString()))
            stack.Push(number)
        Next number