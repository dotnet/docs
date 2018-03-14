'<snippet7>
#Const CONDITION1 = True
#Const CONDITION2 = True
Imports System
Imports System.Diagnostics

Class Test

    Shared Sub Main()
        Console.WriteLine("Calling Method1")
        Method1(3)
        Console.WriteLine("Calling Method2")
        Method2()
        
        Console.WriteLine("Using the Debug class")
        Debug.Listeners.Add(New ConsoleTraceListener())
        Debug.WriteLine("DEBUG is defined")
    End Sub
       
    '<snippet8>
    <ConditionalAttribute("CONDITION1")> _
    Shared Sub Method1(x As Integer)
        Console.WriteLine("CONDITION1 is defined")
    End Sub
    
    <ConditionalAttribute("CONDITION1"), ConditionalAttribute("CONDITION2")> _
    Shared Sub Method2()
        Console.WriteLine("CONDITION1 or CONDITIOIN2 is defined")
    End Sub
    '</snippet8>
    
End Class


' When compiled as shown, the application (named ConsoleApp) 
' produces the following output.

'Calling Method1
'CONDITION1 is defined
'Calling Method2
'CONDITION1 or CONDITION2 is defined
'Using the Debug class
'DEBUG is defined
'</snippet7>
