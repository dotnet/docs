Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

Namespace Samples.AspNet.VB
    ' Create a custom HtmlTextWriter class.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class HTW1
        Inherits HtmlTextWriter

        Public Sub New(ByVal writer As TextWriter)
            MyBase.New(writer)
        End Sub 'New



        Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
            MyBase.New(writer, tabString)
        End Sub 'New


        ' <snippet1>
        ' Override the RenderBeginTag method to check whether
        ' the tagKey parameter is set to a <label> element
        ' or a <font> element.   
        Public Overloads Overrides Sub RenderBeginTag(ByVal tagKey As HtmlTextWriterTag)
            ' <snippet2>
            ' If the tagKey parameter is set to a <label> element
            ' but a color attribute is not defined on the element,
            ' the AddStyleAttribute method adds a color attribute
            ' and sets it to red.
            If tagKey = HtmlTextWriterTag.Label Then
                If Not IsStyleAttributeDefined(HtmlTextWriterStyle.Color) Then
                    AddStyleAttribute(GetStyleKey("color"), "red")
                End If
            End If
            ' </snippet2>

            ' <snippet3>
            ' If the tagKey parameter is set to a <font> element
            ' but a size attribute is not defined on the element,
            ' the AddStyleAttribute method adds a size attribute
            ' and sets it to 30 point. 
            If tagKey = HtmlTextWriterTag.Font Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Size) Then
                    AddAttribute(GetAttributeKey("size"), "30pt")
                End If
            End If
            ' </snippet3>

            ' Call the base class's RenderBeginTag method
            ' to ensure that this custom MarkupTextWriter
            ' includes functionality for all other markup elements.
            MyBase.RenderBeginTag(tagKey)
        End Sub
        ' </snippet1>

        ' <snippet4>
        ' Override the FilterAttributes method to check whether 
        ' <label> and <anchor> elements contain specific attributes.   
        Protected Overrides Sub FilterAttributes()

            ' <snippet5>
            ' If the <label> element is rendered and a style
            ' attribute is not defined, add a style attribute 
            ' and set its value to blue.
            If TagKey = HtmlTextWriterTag.Label Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Style) Then
                    AddAttribute("style", EncodeAttributeValue("color:blue", True))
                    Write(NewLine)
                    Indent = 3
                    OutputTabs()
                End If
            End If
            ' </snippet5>
            ' <snippet6>
            ' If an <anchor> element is rendered and an href
            ' attribute has not been defined, call the AddAttribute
            ' method to add an href attribute
            ' and set it to http://www.cohowinery.com.
            ' Use the EncodeUrl method to convert any spaces to %20.
            If TagKey = HtmlTextWriterTag.A Then
                If Not IsAttributeDefined(HtmlTextWriterAttribute.Href) Then
                    AddAttribute("href", EncodeUrl("http://www.cohowinery.com"))
                End If
            End If
            ' </snippet6>

            ' Call the FilterAttributes method of the base class.
            MyBase.FilterAttributes()
        End Sub
        ' </snippet4>

        ' <snippet7>
        ' Override the OutputTabs method to set the tab to
        ' the number of spaces defined by the Indent variable.   
        Protected Overrides Sub OutputTabs()
            ' Output the DefaultTabString for the number
            ' of times specified in the Indent property.
            Dim i As Integer
            For i = 0 To Indent - 1
                Write(DefaultTabString)
            Next i
            MyBase.OutputTabs()
        End Sub
        ' </snippet7>
    End Class 'HTW1 
End Namespace