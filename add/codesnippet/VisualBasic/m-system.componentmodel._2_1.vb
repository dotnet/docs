        ' Pop each item off the stack.        
        Dim item As Object = stack.Pop()
        While item IsNot Nothing
            Console.WriteLine(("Value popped from stack: " + item.ToString()))
            item = stack.Pop()
        End While