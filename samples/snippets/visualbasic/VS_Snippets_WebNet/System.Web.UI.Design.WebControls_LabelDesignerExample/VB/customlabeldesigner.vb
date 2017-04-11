' CustomLabelDesigner.vb
' <snippet1>
Imports System
Imports System.Web
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' <snippet2>
    ' The SampleLabel is a copy of the Label.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.SampleLabelDesigner))> _
    Public Class SampleLabel
        Inherits Label
    End Class ' SampleLabel
    ' </snippet2>

    ' Override members of the LabelDesigner.
    Public Class SampleLabelDesigner
        Inherits LabelDesigner

        ' <snippet3>
        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the control more visible in the designer.  If the border 
            ' style is None or NotSet, change the border to a dashed line. 
            Dim sampleLabel As SampleLabel = CType(Component, SampleLabel)
            Dim designTimeMarkup As String = Nothing

            ' Check if the border style should be changed.
            If (sampleLabel.BorderStyle = BorderStyle.NotSet Or _
                sampleLabel.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = sampleLabel.BorderStyle

                Try
                    ' Set the design-time BorderStyle.
                    sampleLabel.BorderStyle = BorderStyle.Dashed

                    ' Call the base method to generate the markup.
                    designTimeMarkup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    ' If an exception occurs, generate an error message.
                    designTimeMarkup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the BorderStyle to its original setting.
                    sampleLabel.BorderStyle = oldBorderStyle
                End Try

            Else
                ' Call the base method to generate the markup.
                designTimeMarkup = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeMarkup
        End Function ' GetDesignTimeHtml
        ' </snippet3>      
    End Class ' SampleLabelDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>

