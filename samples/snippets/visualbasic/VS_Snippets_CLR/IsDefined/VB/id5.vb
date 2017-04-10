'<Snippet5>
Imports System
Imports System.Reflection

Module DemoModule
    Public Class TestClass
        ' Assign a ParamArray attribute to the parameter using the keyword.
        Public Sub Method1(ByVal ParamArray args As String())
        End Sub
    End Class

    Sub Main()
        ' Get the class type to access its metadata.
        Dim clsType As Type = GetType(TestClass)
        ' Get the MethodInfo object for Method1.
        Dim mInfo As MethodInfo = clsType.GetMethod("Method1")
        ' Get the ParameterInfo array for the method parameters.
        Dim pInfo() As ParameterInfo = mInfo.GetParameters()
        If Not pInfo(0) Is Nothing Then
            ' See if the ParamArray attribute is defined.
            Dim isDef As Boolean = Attribute.IsDefined(pInfo(0), _
                                   GetType(ParamArrayAttribute))
            Dim strDef As String
            If isDef = True Then
                strDef = "is"
            Else
                strDef = "is not"
            End If
            ' Display the result.
            Console.WriteLine("The ParamArray attribute {0} defined " & _
                              "for parameter {1} of method {2}.", _
                              strDef, pInfo(0).Name, mInfo.Name)
        Else
            Console.WriteLine("Could not retrieve parameter information " & _
                              "for method {0}.", mInfo.Name)
        End If
    End Sub
End Module

' Output:
' The ParamArray attribute is defined for parameter args of method Method1.
'</Snippet5>
