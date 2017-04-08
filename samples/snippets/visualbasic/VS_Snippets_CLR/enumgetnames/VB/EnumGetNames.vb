' <Snippet1>
Public Class GetNamesTest
    Enum Colors
        Red
        Green
        Blue
        Yellow
    End Enum 
    
    Enum Styles
        Plaid
        Striped
        Tartan
        Corduroy
    End Enum
    
    Public Shared Sub Main()
        
        Console.WriteLine("The members of the Colors enum are:")
        For Each s In [Enum].GetNames(GetType(Colors))
            Console.WriteLine(s)
        Next

        Console.WriteLine()
        
        Console.WriteLine("The members of the Styles enum are:")
        For Each s In [Enum].GetNames(GetType(Styles))
            Console.WriteLine(s)
        Next
    End Sub
End Class
' The example displays the following output:
'       The members of the Colors enum are:
'       Red
'       Green
'       Blue
'       Yellow
'       
'       The members of the Styles enum are:
'       Plaid
'       Striped
'       Tartan
'       Corduroy
' </Snippet1>