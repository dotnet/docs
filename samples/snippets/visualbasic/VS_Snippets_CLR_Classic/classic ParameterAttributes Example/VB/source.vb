' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class paramatt

    Public Shared Sub mymethod(ByVal str1 As String, ByRef str2 As String, _
    ByRef str3 As String)
        str2 = "string"
    End Sub

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf + "Reflection.ParameterAttributes")

        ' Get the Type and the method.
        Dim Mytype As Type = Type.GetType("paramatt")
        Dim Mymethodbase As MethodBase = Mytype.GetMethod("mymethod")

        ' Display the method.
        Console.WriteLine("Mymethodbase = " + Mymethodbase.ToString())

        ' Get the ParameterInfo array.
        Dim Myarray As ParameterInfo() = Mymethodbase.GetParameters()

        ' Get and display the attributes for the second parameter.
        Dim Myparamattributes As ParameterAttributes = Myarray(1).Attributes

        Console.WriteLine("For the second parameter:" + ControlChars.CrLf _
           + "Myparamattributes = " + CInt(Myparamattributes).ToString() _
           + ", which is a " + Myparamattributes.ToString())

        Return 0
    End Function
End Class
' </Snippet1>