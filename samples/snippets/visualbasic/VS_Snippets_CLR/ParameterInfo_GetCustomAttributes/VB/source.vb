' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define a custom attribute with one named parameter.
<AttributeUsage(AttributeTargets.Parameter)> Public Class MyAttribute
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

' Define a class which has a custom attribute associated with one of 
' the parameters of a method. 
Public Class MyClass1

    Public Sub MyMethod( _
            <MyAttribute("This is an example parameter attribute")> _
            ByVal i As Integer _
        )
        Return
    End Sub 
End Class 


Public Class MemberInfo_GetCustomAttributes

    Public Shared Sub Main()
        ' Get the type of the class 'MyClass1'.
        Dim myType As Type = GetType(MyClass1)
        ' Get the members associated with the class 'MyClass1'.
        Dim myMethods As MethodInfo() = myType.GetMethods()

        ' Display the attributes for each of the parameters of each method of the class 'MyClass1'.
        For i As Integer = 0 To myMethods.Length - 1
            ' Get the parameters for the method.
            Dim myParameters As ParameterInfo() = myMethods(i).GetParameters()

            If myParameters.Length > 0 Then
                Console.WriteLine(vbCrLf & "The parameters for the method {0} that have custom attributes are : ", myMethods(i))
                For j As Integer = 0 To myParameters.Length - 1
                    ' Get the attributes of type 'MyAttribute' for each parameter.
                    Dim myAttributes As Object() = myParameters(j).GetCustomAttributes(GetType(MyAttribute), False)

                    If myAttributes.Length > 0 Then
                        Console.WriteLine("Parameter {0}, name = {1}, type = {2} has attributes: ", _
                            myParameters(j).Position, myParameters(j).Name, myParameters(j).ParameterType)
                        For k As Integer = 0 To myAttributes.Length - 1
                            Console.WriteLine(vbTab & "{0}", myAttributes(k))
                        Next k
                    End If
                Next j
            End If
        Next i
    End Sub 
End Class 

' This code example produces the following output:
'
'The parameters for the method Void MyMethod(Int32) that have custom attributes are :
'Parameter 0, name = i, type = System.Int32 has attributes:
'        MyAttribute
'
'The parameters for the method Boolean Equals(System.Object) that have custom attributes are :
' </Snippet1>