'<Snippet1>
Public Interface IExample
End Interface

Public Class BaseClass : Implements IExample
End Class

Public Class DerivedClass : Inherits BaseClass
End Class

Public Module Example
    Public Sub Main()
        Dim interfaceType As Type = GetType(IExample)
        Dim base1 As New BaseClass()
        Dim base1Type As Type = base1.GetType()
        Dim derived1 = New DerivedClass()
        Dim derived1Type As Type = derived1.GetType()
        Dim arr(10) As Integer

        Console.WriteLine("Is int[] an instance of the Array class? {0}.",
                           GetType(Array).IsInstanceOfType(arr))
        Console.WriteLine("Is base1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(base1))
        Console.WriteLine("Is derived1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(derived1))
        Console.WriteLine("Is base1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(base1))
        Console.WriteLine("Is derived1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(derived1))
    End Sub
End Module
' The example displays the following output:
'    Is int[] an instance of the Array class? True.
'    Is base1 an instance of BaseClass? True.
'    Is derived1 an instance of BaseClass? True.
'    Is base1 an instance of IExample? True.
'    Is derived1 an instance of IExample? True.
'</Snippet1>