'C:\_ricka08\code\DD\Walk\VB_DataType\DynamicData\FieldTemplates\Text.ascx.vb
' C:\sdtree\Orcas\Web.NET\System.ComponentModel.DataAnnotations2
'<snippet2>

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Xml.Linq
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

Partial Class TextField
    Inherits System.Web.DynamicData.FieldTemplateUserControl

    Private Function getNavUrl() As String
        Dim metadata = MetadataAttributes.OfType(Of DataTypeAttribute).FirstOrDefault()
        If (metadata Is Nothing) Then
            Return FieldValueString
        End If

        Dim url As String = FieldValueString

        Select Case metadata.DataType

            Case DataType.Url
                url = FieldValueString
                If (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Or _
                   url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) Then
                    Return url
                End If

                Return "http://" + FieldValueString

            Case DataType.EmailAddress
                Return "mailto:" + FieldValueString

            Case Else
                Throw New Exception("Unknow DataType")

        End Select

    End Function


    Protected Overrides Sub OnDataBinding(ByVal e As System.EventArgs)
        MyBase.OnDataBinding(e)

        If (String.IsNullOrEmpty(FieldValueString)) Then
            Return
        End If

        Dim metadata = MetadataAttributes.OfType(Of DataTypeAttribute).FirstOrDefault()

        If (metadata Is Nothing Or String.IsNullOrEmpty(FieldValueString)) Then
            Dim literal As New Literal()
            literal.Text = FieldValueString
            Controls.Add(literal)
            Return
        End If

        If (metadata.DataType = DataType.Url Or _
            metadata.DataType = DataType.EmailAddress) Then

            Dim hyperlink As New HyperLink
            hyperlink.Text = FieldValueString
            hyperlink.NavigateUrl = getNavUrl()
            hyperlink.Target = "_blank"
            Controls.Add(hyperlink)
            Return

        End If

        If (metadata.DataType = DataType.Custom And _
             String.Compare(metadata.CustomDataType, "BoldRed", True) = 0) Then
            Dim lbl As New Label()
            lbl.Text = FieldValueString
            lbl.Font.Bold = True
            lbl.ForeColor = System.Drawing.Color.Red
            Controls.Add(lbl)
        End If

    End Sub

End Class
'</snippet2>