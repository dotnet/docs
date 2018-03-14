' <Snippet4>
Module Example
    Public Sub Main() 
        Dim posValue As Double = 3.45
        Dim negValue As Double = -3.45
        
        ' Round a positive and a negative value using the default.  
        Dim result As Double = Math.Round(posValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, posValue)
        result = Math.Round(negValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, negValue)
        Console.WriteLine()
        
        ' Round a positive value using a MidpointRounding value. 
        result = Math.Round(posValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", 
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", 
                           result, posValue)
        Console.WriteLine()
        
        ' Round a positive value using a MidpointRounding value. 
        result = Math.Round(negValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", 
                            result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", 
                           result, negValue)
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'       3.4 = Math.Round( 3.45, 1)
'       -3.4 = Math.Round(-3.45, 1)
'       
'       3.4 = Math.Round( 3.45, 1, MidpointRounding.ToEven)
'       3.5 = Math.Round( 3.45, 1, MidpointRounding.AwayFromZero)
'       
'       -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
'       -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
' </Snippet4>
