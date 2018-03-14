'<Snippet4>
Imports System
Imports System.Reflection

Module DemoModule

    Public Class TestClass
        ' Assign the Obsolete attribute to a method.
        <Obsolete("This method is obsolete. Use Method2() instead.")> _
        Public Sub Method1()
        End Sub

        Public Sub Method2()
        End Sub
    End Class

    Sub Main()
        ' Get the class type to access its metadata.
        Dim clsType As Type = GetType(TestClass)
        ' Get the MethodInfo object for Method1.
        Dim mInfo As MethodInfo = clsType.GetMethod("Method1")
        ' See if the Obsolete attribute is defined for this method.
        Dim isDef As Boolean = Attribute.IsDefined(mInfo, _
            GetType(ObsoleteAttribute))
        Dim strDef As String
        If isDef = True Then
            strDef = "is"
        Else
            strDef = "is not"
        End If
        ' Display the results.
        Console.WriteLine("The Obsolete attribute {0} defined for " & _
            "method {1} of class {2}.", strDef, mInfo.Name, clsType.Name)
        ' If it's defined, display the attribute's message.
        If isDef = True Then
            Dim attr As Attribute = Attribute.GetCustomAttribute(mInfo, _
                GetType(ObsoleteAttribute))
            If Not attr Is Nothing And TypeOf attr Is ObsoleteAttribute Then
                Dim obsAttr As ObsoleteAttribute = _
                    CType(attr, ObsoleteAttribute)
                Console.WriteLine("The message is: ""{0}""", obsAttr.Message)
            Else
                Console.WriteLine("The message could not be retrieved.")
            End If
        End If
    End Sub
End Module

' Output:
' The Obsolete attribute is defined for method Method1 of class TestClass.
' The message is: "This method is obsolete. Use Method2() instead."
'</Snippet4>
