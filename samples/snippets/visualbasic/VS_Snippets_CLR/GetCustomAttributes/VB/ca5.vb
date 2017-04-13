' <Snippet5>
Imports System
Imports System.Reflection
Imports System.ComponentModel

Module DemoModule
    Public Class AClass
        ' Add Description and ParamArray (with the keyword) attributes.
        Public Sub ParamArrayAndDesc( _
            <Description("This argument is a ParamArray")> _
            ByVal ParamArray args() As Integer)
        End Sub
    End Class

    Sub Main()
        ' Get the Class type to access its metadata.
        Dim clsType As Type = GetType(AClass)
        ' Get the type information for the method.
        Dim mInfo As MethodInfo = clsType.GetMethod("ParamArrayAndDesc")
        ' Get the Parameter information for the method.
        Dim pInfo() As ParameterInfo = mInfo.GetParameters()
        Dim attr As Attribute
        ' Iterate through each attribute of the parameter.
        For Each attr In Attribute.GetCustomAttributes(pInfo(0))
            ' Check for the ParamArray attribute.
            If TypeOf attr Is ParamArrayAttribute Then
                ' Convert the attribute to access its data.
                Dim paAttr As ParamArrayAttribute = _
                    CType(attr, ParamArrayAttribute)
                Console.WriteLine("Parameter {0} has the " + _
                    "ParamArray attribute.", pInfo(0).Name)
            ' Check for the Description attribute.
            ElseIf TypeOf attr Is DescriptionAttribute Then
                ' Convert the attribute to access its data.
                Dim descAttr As DescriptionAttribute = _
                    CType(attr, DescriptionAttribute)
                Console.WriteLine("Parameter {0} has a description " + _
                    "attribute. The description is:", pInfo(0).Name)
                Console.WriteLine(descAttr.Description)
            End If
        Next
    End Sub
End Module

' Output:
' Parameter args has a description attribute. The description is:
' This argument is a ParamArray
' Parameter args has the ParamArray attribute.
' </Snippet5>
