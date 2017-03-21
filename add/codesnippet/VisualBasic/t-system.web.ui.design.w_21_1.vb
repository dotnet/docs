Imports System
'Imports System.Design
Imports System.Drawing
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
'Imports Examples.AspNet

Namespace Examples.AspNet '.Design

    ' Create a class, named SampleCheckBoxDesigner, that overrides the
    ' GetDesignTimeHtml method to display the control on the design
    ' surface.

    Public Class SampleCheckBoxDesigner
        Inherits System.Web.UI.Design.WebControls.CheckBoxDesigner

        ' Override the GetDesignTimeHtml method to display a border on the 
        ' control if the BorderStyle property has not been set by the user.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim sampleCheckBox As SampleCheckBox = CType(Component, _
                SampleCheckBox)
            Dim designTimeHtml As String = Nothing

            ' Check the control's BorderStyle property.
            If (sampleCheckBox.BorderStyle = BorderStyle.NotSet) Then

                ' Save the current value of the BorderStyle property.
                Dim oldBorderStyle As BorderStyle = _
                    sampleCheckBox.BorderStyle

                ' Change the value of the BorderStyle property and 
                ' generate the design-time HTML.
                Try
                    sampleCheckBox.BorderStyle = BorderStyle.Groove
                    designTimeHtml = MyBase.GetDesignTimeHtml()

                    ' If an exception occurs, call the GetErrorDesignTimeHtml
                    ' method.
                Catch ex As Exception
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Restore the BorderStyle property to its original value.
                Finally
                    sampleCheckBox.BorderStyle = oldBorderStyle
                End Try

            Else
                designTimeHtml = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeHtml
        End Function
    End Class
End Namespace