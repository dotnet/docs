        Try
            ' Attempts to pass an invalid enum value (MessageBoxButtons) to the Show method
            Dim myButton As MessageBoxButtons
            myButton = CType(123, MessageBoxButtons)
            MessageBox.Show("This is a message", "This is the Caption", myButton)
        Catch invE As System.ComponentModel.InvalidEnumArgumentException
            Console.WriteLine(invE.Message)
            Console.WriteLine(invE.ParamName)
            Console.WriteLine(invE.StackTrace)
            Console.WriteLine(invE.Source)
        End Try