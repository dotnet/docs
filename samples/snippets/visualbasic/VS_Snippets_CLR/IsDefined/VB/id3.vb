'<Snippet3>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Module DemoModule

    ' Assign a Guid attribute to a class.
    <Guid("BF235B41-52D1-46cc-9C55-046793DB363F")> _
    Public Class TestClass
    End Class

    Sub Main()
        ' Get the class type to access its metadata.
        Dim clsType As Type = GetType(TestClass)
        ' See if the Guid attribute is defined for the class.
        Dim isDef As Boolean = Attribute.IsDefined(clsType, _
            GetType(GuidAttribute))
        Dim strDef As String
        If isDef = True Then
            strDef = "is"
        Else
            strDef = "is not"
        End If
        ' Display the result.
        Console.WriteLine("The Guid attribute {0} defined for class {1}.", _
                          strDef, clsType.Name)
        ' If it's defined, display the GUID.
        If isDef = True Then
            Dim attr As Attribute = Attribute.GetCustomAttribute( _
                clsType, GetType(GuidAttribute))
            If Not attr Is Nothing And TypeOf attr Is GuidAttribute Then
                Dim guidAttr As GuidAttribute = CType(attr, GuidAttribute)
                Console.WriteLine("GUID: {" & guidAttr.Value & "}.")
            Else
                Console.WriteLine("Could not retrieve the Guid attribute.")
            End If
        End If
    End Sub
End Module

' Output:
' The Guid attribute is defined for class TestClass.
' GUID: {BF235B41-52D1-46cc-9C55-046793DB363F}.
'</Snippet3>
