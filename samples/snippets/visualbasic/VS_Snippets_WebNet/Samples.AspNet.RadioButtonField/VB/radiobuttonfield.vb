' <Snippet1>
Imports System
Imports System.Collections.Specialized
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class RadioButtonField
        Inherits CheckBoxField

        Public Sub New()
        End Sub 'New

        ' Gets a default value for a basic design-time experience. Since
        ' it would look odd, even at design time, to have more than one
        ' radio button selected, make sure that none are selected.
        Protected Overrides Function GetDesignTimeValue() As Object
            Return False
        End Function

        ' <Snippet2>
        ' This method is called by the ExtractRowValues methods of
        ' GridView and DetailsView. Retrieve the current value of the 
        ' cell from the Checked state of the Radio button.
        Public Overrides Sub ExtractValuesFromCell( _
            ByVal dictionary As IOrderedDictionary, _
            ByVal cell As DataControlFieldCell, _
            ByVal rowState As DataControlRowState, _
            ByVal includeReadOnly As Boolean)
            ' Determine whether the cell contain a RadioButton 
            ' in its Controls collection.
            If cell.Controls.Count > 0 Then
                Dim radio As RadioButton = CType(cell.Controls(0), RadioButton)

                Dim checkedValue As Object = Nothing
                If radio Is Nothing Then
                    ' A RadioButton is expected, but a null is encountered.
                    ' Add error handling.
                    Throw New InvalidOperationException( _
                        "RadioButtonField could not extract control.")
                Else
                    checkedValue = radio.Checked
                End If


                ' Add the value of the Checked attribute of the
                ' RadioButton to the dictionary.
                If dictionary.Contains(DataField) Then
                    dictionary(DataField) = checkedValue
                Else
                    dictionary.Add(DataField, checkedValue)
                End If
            End If
        End Sub
        ' </Snippet2>
        ' <Snippet3>
        ' This method adds a RadioButton control and any other 
        ' content to the cell's Controls collection.
        Protected Overrides Sub InitializeDataCell( _
            ByVal cell As DataControlFieldCell, _
            ByVal rowState As DataControlRowState)

            Dim radio As New RadioButton()

            ' If the RadioButton is bound to a DataField, add
            ' the OnDataBindingField method event handler to the
            ' DataBinding event.
            If DataField.Length <> 0 Then
                AddHandler radio.DataBinding, AddressOf Me.OnDataBindField
            End If

            radio.Text = Me.Text

            ' Because the RadioButtonField is a BoundField, it only 
            ' displays data. Therefore, unless the row is in edit mode, 
            ' the RadioButton is displayed as disabled.
            radio.Enabled = False
            ' If the row is in edit mode, enable the button.
            If (rowState And DataControlRowState.Edit) <> 0 _
                OrElse (rowState And DataControlRowState.Insert) <> 0 Then
                radio.Enabled = True
            End If

            cell.Controls.Add(radio)
        End Sub
        ' </Snippet3>

    End Class

End Namespace
' </Snippet1>