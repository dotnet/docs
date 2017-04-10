'<snippet1>
' This example demonstrates the Math.Round() method in conjunction 
' with the MidpointRounding enumeration.
Imports System

Class Sample
    Public Shared Sub Main() 
        Dim result As Decimal = 0D
        Dim posValue As Decimal = 3.45D
        Dim negValue As Decimal = -3.45D
        
        ' By default, round a positive and a negative value to the nearest even number. 
        ' The precision of the result is 1 decimal place.
        result = Math.Round(posValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, posValue)
        result = Math.Round(negValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, negValue)
        Console.WriteLine()
        
        ' Round a positive value to the nearest even number, then to the nearest number 
        ' away from zero. The precision of the result is 1 decimal place.
        result = Math.Round(posValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", _
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", _
                           result, posValue)
        Console.WriteLine()
        
        ' Round a negative value to the nearest even number, then to the nearest number 
        ' away from zero. The precision of the result is 1 decimal place.
        result = Math.Round(negValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", _
                            result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", _
                           result, negValue)
        Console.WriteLine()
    
    End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
' 3.4 = Math.Round( 3.45, 1)
'-3.4 = Math.Round(-3.45, 1)
'
' 3.4 = Math.Round( 3.45, 1, MidpointRounding.ToEven)
' 3.5 = Math.Round( 3.45, 1, MidpointRounding.AwayFromZero)
'
'-3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
'-3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
'
'</snippet1>