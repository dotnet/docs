        Dim Result1 As Short
        Dim Result2 As Integer
        Dim Result3 As Integer
        Dim MathObject As New MathClass
        Result1 = MathObject.AddNumbers(4S, 2S) ' Add two Shorts.
        Result2 = MathObject.AddNumbers(4, 2) 'Add two Integers.
        Result3 = MathObject.SubtractNumbers(2, 4) ' Subtract 2 from 4.
        MathObject.Prop1 = 6 ' Set an inherited property.

        MsgBox("Calling the AddNumbers method in the base class " &
               "using Short type numbers 4 and 2 = " & Result1)
        MsgBox("Calling the overloaded AddNumbers method using " &
               "Integer type numbers 4 and 2 = " & Result2)
        MsgBox("Calling the SubtractNumbers method " &
               "subtracting 2 from 4 = " & Result3)
        MsgBox("The value of the inherited property is " &
                MathObject.Prop1)