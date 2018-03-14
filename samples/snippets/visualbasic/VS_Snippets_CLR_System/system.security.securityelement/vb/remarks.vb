Imports System
Imports System.Security

Public Class SecurityElementTest
    Private Dim xmlRootElement As SecurityElement

    Public Sub New
        xmlRootElement = New SecurityElement("thetag", " ")
        xmlRootElement.AddAttribute("a", "123")
        xmlRootElement.AddAttribute("b", "456")
        xmlRootElement.AddAttribute("c", "789")

        xmlRootElement.AddChild(New SecurityElement("first", "text1"))
        xmlRootElement.AddChild(New SecurityElement("second", "text2"))
    End Sub

    ' <Snippet1>
    Public Function SearchForTextOfTag(ByVal tag As String) As String
        Dim element As SecurityElement = MyClass.SearchForChildByTag(tag)
        Return element.Text
    End Function
    ' </Snippet1>

    Private Function SearchForChildByTag(ByVal tag As String) As SecurityElement
        Return xmlRootElement.SearchForChildByTag(tag)
    End Function

    Public Shared Sub Main()
        Try
            Dim seTest As New SecurityElementTest

            Console.WriteLine("Found the text for <second>: " + seTest.SearchForTextOfTag("second"))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class
