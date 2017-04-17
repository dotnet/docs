' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define a custom attribute with one named parameter.
<AttributeUsage(AttributeTargets.Parameter)> _
Public Class MyAttribute
    Inherits Attribute
    Private myName As String

    Public Sub New(ByVal name As String)
        myName = name
    End Sub 

    Public ReadOnly Property Name() As String
        Get
            Return myName
        End Get
    End Property
End Class 

' Derive another custom attribute from MyAttribute
<AttributeUsage(AttributeTargets.Parameter)> _
Public Class MyDerivedAttribute
    Inherits MyAttribute

    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub 
End Class

' Define a class with a method that has three parameters. Apply
' MyAttribute to one parameter, MyDerivedAttribute to another, and
' no attributes to the third. 
Public Class MyClass1

    Public Sub MyMethod(<MyAttribute("This is an example parameter attribute")> _
                        ByVal i As Integer, _
                        <MyDerivedAttribute("This is another parameter attribute")> _
                        ByVal j As Integer, _
                        ByVal k As Integer)
        Return
    End Sub 
End Class 

Public Class MemberInfo_GetCustomAttributes

    Public Shared Sub Main()
        ' Get the type of the class 'MyClass1'.
        Dim myType As Type = GetType(MyClass1)
        ' Get the members associated with the class 'MyClass1'.
        Dim myMethods As MethodInfo() = myType.GetMethods()

        ' For each method of the class 'MyClass1', display all the parameters
        ' to which MyAttribute or its derived types have been applied.
        For Each mi As MethodInfo In myMethods
            ' Get the parameters for the method.
            Dim myParameters As ParameterInfo() = mi.GetParameters()
            If myParameters.Length > 0 Then
                Console.WriteLine(vbCrLf & "The following parameters of {0} have MyAttribute or a derived type: ", mi)
                For Each pi As ParameterInfo In myParameters
                    If pi.IsDefined(GetType(MyAttribute), False) Then
                        Console.WriteLine("Parameter {0}, name = {1}, type = {2}", _
                            pi.Position, pi.Name, pi.ParameterType)
                    End If
                Next
            End If
        Next
    End Sub 
End Class 

' This code example produces the following output:
'
'The following parameters of Void MyMethod(Int32, Int32, Int32) have MyAttribute or a derived type:
'Parameter 0, name = i, type = System.Int32
'Parameter 1, name = j, type = System.Int32
'
'The following parameters of Boolean Equals(System.Object) have MyAttribute or a derived type:
' </Snippet1>