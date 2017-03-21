        Dim doubles() As Double = {1.5E+104, 9.0E+103, -2.0E+103}

        Dim min As Double = doubles.AsQueryable().Min()

        MsgBox(String.Format("The smallest number is {0}.", min))

        'This code produces the following output:

        'The smallest number is -2E+103.
