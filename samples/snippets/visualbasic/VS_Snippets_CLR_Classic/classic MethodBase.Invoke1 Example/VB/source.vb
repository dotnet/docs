' <Snippet1>
Imports System
Imports System.Reflection

Public Class MagicClass
    Private magicBaseValue As Integer

    Public Sub New()
        magicBaseValue = 9
    End Sub

    Public Function ItsMagic(preMagic As Integer) As Integer
        Return preMagic * magicBaseValue
    End Function
End Class

Public Class TestMethodInfo
    Public Shared Sub Main()
        ' Get the constructor and create an instance of MagicClass

        Dim magicType As Type = Type.GetType("MagicClass")
        Dim magicConstructor As ConstructorInfo = magicType.GetConstructor(Type.EmptyTypes)
        Dim magicClassObject As Object = magicConstructor.Invoke(New Object(){})

        ' Get the ItsMagic method and invoke with a parameter value of 100

        Dim magicMethod As MethodInfo = magicType.GetMethod("ItsMagic")
        Dim magicValue As Object = magicMethod.Invoke(magicClassObject, New Object(){100})

        Console.WriteLine("MethodInfo.Invoke() Example" + vbNewLine)
        Console.WriteLine("MagicClass.ItsMagic() returned: {0}", magicValue)
    End Sub
End Class

' The example program gives the following output:
'
' MethodInfo.Invoke() Example
'
' MagicClass.ItsMagic() returned: 900
' </Snippet1>

