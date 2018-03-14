' <Snippet1>
' Create a class that derives from the
' ChtmlTextWriter class.
Imports System
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls.Adapters

Namespace AspNet.Samples.VB

    Public Class CustomChtmlTextWriter
        Inherits ChtmlTextWriter

        ' Create two constructors for the new
        ' text writer.
        Public Sub New(ByVal writer As TextWriter)
            MyClass.New(writer, DefaultTabString)
        End Sub

        Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
            MyBase.New(writer, tabString)
        End Sub

        ' <snippet2>
        ' Override the OnAttributeRender method to
        ' not render the bgcolor attribute, which is 
        ' not supported in CHTML.
        Protected Overrides Function OnAttributeRender(ByVal name As String, ByVal value As String, ByVal key As HtmlTextWriterAttribute) As Boolean
            If (String.Equals("bgcolor", name)) Then
                Return False
            End If

            ' Call the ChtmlTextWriter version of 
            ' the OnAttributeRender method.
            MyBase.OnAttributeRender(name, value, key)

        End Function
        ' </snippet2>
    End Class

    ' <snippet3>
    ' Derive from the WebControlAdapter class,
    ' provide a CreateCustomChtmlTextWriter
    ' method to attach the custom writer.
    Public Class ChtmlCustomPageAdapter
        Inherits WebControlAdapter

        Protected Friend Function CreateCustomChtmlTextWriter( _
         ByVal writer As TextWriter) As ChtmlTextWriter

            Return New CustomChtmlTextWriter(writer)

        End Function
    End Class
    ' </snippet3>
End Namespace
' </Snippet1>

