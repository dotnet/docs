' <Snippet3>
Imports System
Imports System.Linq
Imports System.Web.UI.WebControls
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

Partial Public Class TextField
    Inherits System.Web.DynamicData.FieldTemplateUserControl

    Protected Overloads Overrides Sub OnDataBinding(ByVal e As EventArgs)
        MyBase.OnDataBinding(e)
        Dim processed As Boolean = False
        Dim metadata As DataTypeAttribute = _
           MetadataAttributes.OfType(Of DataTypeAttribute)().FirstOrDefault()
        If metadata IsNot Nothing Then
            If metadata.DataType = DataType.EmailAddress Then
                If Not String.IsNullOrEmpty(FieldValueString) Then
                    processed = True
                    Dim hyperlink As New HyperLink()
                    hyperlink.Text = FieldValueString
                    hyperlink.NavigateUrl = "mailto:" + FieldValueString
                    Controls.Add(hyperlink)
                End If
            End If
        End If
        If Not processed Then
            Dim literal As New Literal()
            literal.Text = FieldValueString
            Controls.Add(literal)
        End If
    End Sub

End Class
' </Snippet3>
