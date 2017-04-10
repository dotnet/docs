' <Snippet3>
Imports System
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Module DemoModule

    ' Set a GUID and ProgId attribute for this class.
    <Guid("BF235B41-52D1-46cc-9C55-046793DB363F"), _
     ProgId("CustAttrs3VB.ClassWithGuidAndProgId")> _
    Public Class ClassWithGuidAndProgId
    End Class

    Sub Main()
        ' Get the Class type to access its metadata.
        Dim clsType As Type = GetType(ClassWithGuidAndProgId)
        Dim attr As Attribute

        ' Iterate through all the attributes for the class.
        For Each attr In Attribute.GetCustomAttributes(clsType)
            ' Check for the Guid attribute.
            If TypeOf attr Is GuidAttribute Then
                ' Convert the attribute to access its data.
                Dim guidAttr As GuidAttribute = _
                    CType(attr, GuidAttribute)
                ' Display the GUID.
                Console.WriteLine("Class {0} has a GUID.", clsType.Name)
                Console.WriteLine("GUID: {" + Chr(34) + guidAttr.Value + _
                                    Chr(34) + "}.")

            ' Check for the ProgId attribute.
            ElseIf TypeOf attr Is ProgIdAttribute Then
                ' Convert the ProgId to access its data.
                Dim piAttr As ProgIdAttribute = _
                    CType(attr, ProgIdAttribute)
                ' Display the ProgId.
                Console.WriteLine("Class {0} has a ProgId.", clsType.Name)
                Console.WriteLine("ProgId: {0}.", piAttr.Value)
            End If
        Next
    End Sub
End Module

' Output:
' Class ClassWithGuidAndProgId has a ProgId.
' ProgId: CustAttrs3VB.ClassWithGuidAndProgId.
' Class ClassWithGuidAndProgId has a GUID.
' GUID: {"BF235B41-52D1-46cc-9C55-046793DB363F"}.
' </Snippet3>
