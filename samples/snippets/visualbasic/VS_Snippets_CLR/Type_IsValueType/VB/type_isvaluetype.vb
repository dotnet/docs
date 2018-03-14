' <Snippet1>   
' Declare an enum type.
Enum NumEnum
    One
    Two
End Enum
    
Public Class Example

    Public Shared Sub Main()
        Dim flag As Boolean = False
        Dim testEnum As NumEnum = NumEnum.One
        ' Get the type of myTestEnum.
        Dim t As Type = testEnum.GetType()
        ' Get the IsValueType property of the myTestEnum variable.
         flag = t.IsValueType()
         Console.WriteLine("{0} is a value type: {1}", t.FullName, flag)
     End Sub 
 End Class  
' The example displays the following output:
'       NumEnum is a value type: True
' </Snippet1>
