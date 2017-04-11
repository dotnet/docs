' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class methodbase1

    Public Shared Function Main() As Integer
        Console.WriteLine("Reflection.MethodBase")
        Console.WriteLine()
        ' Get the types.
        Dim MyType1 As Type = _
           Type.GetType("System.Runtime.Serialization.Formatter")
        Dim MyType2 As Type = _
           Type.GetType("System.Reflection.MethodBase")

        ' Get and display the methods
        Dim Mymethodbase1 As MethodBase = _
           MyType1.GetMethod("WriteInt32", BindingFlags.NonPublic Or BindingFlags.Instance)
        Dim Mymethodbase2 As MethodBase = _
           MyType2.GetMethod("GetCurrentMethod", BindingFlags.Public Or BindingFlags.Static)

        Console.WriteLine("Mymethodbase = {0}", Mymethodbase1.ToString())
        If Mymethodbase1.IsAbstract Then
            Console.WriteLine(ControlChars.CrLf & "Mymethodbase is an abstract method.")
        Else
            Console.WriteLine(ControlChars.CrLf & "Mymethodbase is not an abstract method.")
        End If
        Console.Write("Mymethodbase = {0}", Mymethodbase2.ToString())
        If Mymethodbase2.IsAbstract Then
            Console.WriteLine(ControlChars.CrLf & "Mymethodbase is an abstract method.")
        Else
            Console.WriteLine(ControlChars.CrLf & "Mymethodbase is not an abstract method.")
        End If
        Return 0
    End Function

End Class
' </Snippet1>
