' SimpleRadioButtonListDesigner.vb
' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls

Namespace Examples.VB.WebControls.Design

    ' Create the SimpleRadioButtonListDesigner, which provides
    ' design-time support for a custom list class.  
    Public Class SimpleRadioButtonListDesigner
        Inherits ListControlDesigner

        Private simpleRadioButtonList As SimpleRadioButtonList
        Private changedDataSource As Boolean

        ' <snippet2>        
        ' Create the markup to display the control on the design surface.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim designTimeHtml As String = String.Empty

            ' Create variables to access the control's
            ' item collection and back color. 
            Dim items As ListItemCollection = simpleRadioButtonList.Items
            Dim oldBackColor As Color = simpleRadioButtonList.BackColor

            ' Check the property values and render the markup
            ' on the design surface accordingly.
            Try
                If (Color.op_Equality(oldBackColor, Color.Empty)) Then
                    simpleRadioButtonList.BackColor = Color.Gainsboro
                End If

                If (changedDataSource) Then
                    items.Add( _
                        "Updated to a new data source: " & DataSource & ".")
                End If

                designTimeHtml = MyBase.GetDesignTimeHtml()

            Catch ex As Exception
                ' Catch any exceptions that occur.
                MyBase.GetErrorDesignTimeHtml(ex)

            Finally
                ' Set the properties back to their original state.
                simpleRadioButtonList.BackColor = oldBackColor
                items.Clear()
            End Try

            Return designTimeHtml
        End Function ' GetDesignTimeHtml
        ' </snippet2>

        ' <snippet3>
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a SimpleRadioButtonList can be created 
            ' in this designer.
            Debug.Assert( _
                TypeOf component Is SimpleRadioButtonList, _
                "An invalid SimpleRadioButtonList control was initialized.")

            simpleRadioButtonList = CType(component, SimpleRadioButtonList)
            MyBase.Initialize(component)
        End Sub ' Initialize
        ' </snippet3>   

        ' <snippet4>        
        ' If the data source changes, set a Boolean variable.
        Public Overrides Sub OnDataSourceChanged()
            changedDataSource = True
        End Sub ' OnDataSourceChanged
        ' </snippet4>
    End Class ' SimpleRadioButtonListDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
