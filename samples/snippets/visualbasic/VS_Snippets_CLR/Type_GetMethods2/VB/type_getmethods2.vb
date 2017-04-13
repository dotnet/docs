' <Snippet1>

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports Microsoft.VisualBasic

' Create a class having two public methods and one protected method.
Public Class MyTypeClass
    Public Sub MyMethods()
    End Sub 'MyMethods
    Public Function MyMethods1() As Integer
        Return 3
    End Function 'MyMethods1
    Protected Function MyMethods2() As [String]
        Return "hello"
    End Function 'MyMethods2
End Class 'MyTypeClass
Public Class TypeMain
    Public Shared Sub Main()

        Dim myType As Type = GetType(MyTypeClass)
        ' Get the public methods.
        Dim myArrayMethodInfo As MethodInfo() = myType.GetMethods((BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly))
        Console.WriteLine((ControlChars.Cr + "The number of public methods is " & myArrayMethodInfo.Length.ToString() & "."))
        ' Display all the public methods.
        DisplayMethodInfo(myArrayMethodInfo)
        ' Get the nonpublic methods.
        Dim myArrayMethodInfo1 As MethodInfo() = myType.GetMethods((BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly))
        Console.WriteLine((ControlChars.Cr + "The number of protected methods is " & myArrayMethodInfo1.Length.ToString() & "."))
        ' Display all the nonpublic methods.
        DisplayMethodInfo(myArrayMethodInfo1)
    End Sub 'Main

    Public Shared Sub DisplayMethodInfo(ByVal myArrayMethodInfo() As MethodInfo)
        ' Display information for all methods.
        Dim i As Integer
        For i = 0 To myArrayMethodInfo.Length - 1
            Dim myMethodInfo As MethodInfo = CType(myArrayMethodInfo(i), MethodInfo)
            Console.WriteLine((ControlChars.Cr + "The name of the method is " & myMethodInfo.Name & "."))
        Next i
    End Sub 'DisplayMethodInfo
End Class 'TypeMain	
' </Snippet1>