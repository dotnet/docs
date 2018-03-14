' <Snippet1>
Imports System.Reflection

' Create a class with three properties.
Public Class MyTypeClass
    Public Class Myclass1
    End Class 

    Public Class Myclass2
    End Class 

    Protected Class MyClass3
    End Class 

    Protected Class MyClass4
    End Class 
End Class 

Public Class TypeMain
    Public Shared Sub Main()
        Dim myType As Type = GetType(MyTypeClass)

        ' Get the public nested classes.
        Dim myTypeArray As Type() = myType.GetNestedTypes((BindingFlags.Public))
        Console.WriteLine("The number of public nested classes is {0}.", myTypeArray.Length.ToString())
        ' Display all the public nested classes.
        DisplayTypeInfo(myTypeArray)
        Console.WriteLine()
        
        ' Get the nonpublic nested classes.
        Dim myTypeArray1 As Type() = myType.GetNestedTypes((BindingFlags.NonPublic))
        Console.WriteLine("The number of protected nested classes is {0}.", myTypeArray1.Length.ToString())
        ' Display  the information for all nested classes.
        DisplayTypeInfo(myTypeArray1)
    End Sub 

    Public Shared Sub DisplayTypeInfo(ByVal myArrayType() As Type)
        ' Display the information for all nested classes.
        For Each t In myArrayType
            Console.WriteLine("The name of the nested class is {0}.", t.FullName)
        Next 
    End Sub 
End Class  
' The example displays the following output:
'       The number of public nested classes is 2.
'       The name of the nested class is MyTypeClass+Myclass1.
'       The name of the nested class is MyTypeClass+Myclass2.
'       
'       The number of protected nested classes is 2.
'       The name of the nested class is MyTypeClass+MyClass3.
'       The name of the nested class is MyTypeClass+MyClass4.
' </Snippet1>