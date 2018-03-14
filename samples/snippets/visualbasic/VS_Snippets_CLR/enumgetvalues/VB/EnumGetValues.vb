'<snippet1>
Public Class GetValuesTest
   
    Enum Colors
        Red
        Green
        Blue
        Yellow
    End Enum 'Colors
    
    Enum Styles
        Plaid = 0
        Striped = 23
        Tartan = 65
        Corduroy = 78
    End Enum 'Styles
    
    Public Shared Sub Main()
        
        Console.WriteLine("The values of the Colors Enum are:")
        Dim i As Integer
        For Each i In  [Enum].GetValues(GetType(Colors))
            Console.WriteLine(i)
        Next

        Console.WriteLine()
        
        Console.WriteLine("The values of the Styles Enum are:")
        For Each i In  [Enum].GetValues(GetType(Styles))
            Console.WriteLine(i)
        Next
    End Sub 
End Class 
' The example produces the following output:
'       The values of the Colors Enum are:
'       0
'       1
'       2
'       3
'       
'       The values of the Styles Enum are:
'       0
'       23
'       65
'       78
'</snippet1>
