' CustomButton.vb
'
' <snippet1>
' Create a class that derives from ButtonDesigner
' and displays the custom SampleButton control
' on the design surface.
Imports System
Imports System.Web.UI.Design
Imports System.Drawing
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls

Namespace Examples.AspNet 

    
    Public Class SampleButtonDesigner
        Inherits ButtonDesigner

        ' Override the GetDesignTimeHtml method.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim sampleButton As SampleButton = CType(Component, SampleButton)
            Dim designTimeHtml As String = Nothing

            ' Check the control's BorderStyle property
            ' to conditionally render design-time HTML.
            If (sampleButton.BorderStyle = BorderStyle.NotSet) Then

                ' Create variables to hold current property settings.
                Dim oldBorderStyle As BorderStyle = sampleButton.BorderStyle
                Dim oldBorderWidth As Unit = sampleButton.BorderWidth
                Dim oldBorderColor As Color = sampleButton.BorderColor

                ' Set properties and the design-time HTML.
                Try
                    sampleButton.BorderStyle = BorderStyle.Dashed
                    sampleButton.BorderWidth = Unit.Pixel(3)
                    sampleButton.BorderColor = Color.Blue
                    designTimeHtml = MyBase.GetDesignTimeHtml()

                    ' If an exception occurs, call the GetErrorDesignTimeHtml
                    ' method.
                Catch ex As Exception
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Return properties to their original settings.
                Finally
                    sampleButton.BorderStyle = oldBorderStyle
                    sampleButton.BorderWidth = oldBorderWidth
                    sampleButton.BorderColor = oldBorderColor
                End Try

            Else
                designTimeHtml = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeHtml

        End Function

    End Class
End Namespace
' </snippet1>


Namespace Examples.AspNet
' <snippet2>
    <DesignerAttribute( _
        GetType(Examples.AspNet.SampleButtonDesigner))> _
    Public Class SampleButton
        Inherits Button
        ' Include code here for a custom 
        ' class that inherits from Button.        
    End Class
' </snippet2>
End Namespace
