' <snippet1>
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

        ' <snippet2>      
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
        ' </snippet2>        
    End Class
End Namespace
' </snippet1>

' <snippet3>
Namespace Examples.AspNet

    ' The SampleCheckBox class that uses the SampleCheckBoxDesigner class.
    <Designer(GetType( _
        Examples.AspNet.SampleCheckBoxDesigner))> _
    Public Class SampleCheckBox
        Inherits CheckBox
        ' To customize the CheckBox class, insert code here.
    End Class

End Namespace
' </snippet3>
