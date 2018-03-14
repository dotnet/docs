'<snippet1>
Imports System

Public Class GetNameTest
    
    Enum Colors
        Red
        Green
        Blue
        Yellow
    End Enum 'Colors
    
    Enum Styles
        Plaid
        Striped
        Tartan
        Corduroy
    End Enum 'Styles
    
    Public Shared Sub Main() 
        Console.WriteLine("The 4th value of the Colors Enum is {0}", [Enum].GetName(GetType(Colors), 3))
        Console.WriteLine("The 4th value of the Styles Enum is {0}", [Enum].GetName(GetType(Styles), 3))
    End Sub 'Main
End Class 'GetNameTest
' The example displays the following output:
'       The 4th value of the Colors Enum is Yellow
'       The 4th value of the Styles Enum is Corduroy
' </snippet1>
