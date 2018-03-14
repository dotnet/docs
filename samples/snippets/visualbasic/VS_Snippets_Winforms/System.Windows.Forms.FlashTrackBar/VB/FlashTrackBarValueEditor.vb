' <snippet20>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Windows.Forms.ComponentModel
Imports System.Windows.Forms.Design

Namespace Microsoft.Samples.WinForms.VB.FlashTrackBar

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class FlashTrackBarValueEditor
        Inherits UITypeEditor

        Private edSvc As IWindowsFormsEditorService


        Overridable Protected Sub SetEditorProps(editingInstance As FlashTrackBar, editor As FlashTrackBar)
            editor.ShowValue = true
            editor.StartColor = Color.Navy
            editor.EndColor = Color.White
            editor.ForeColor = Color.White
            editor.Min = editingInstance.Min
            editor.Max = editingInstance.Max
        End Sub

        Overrides OverLoads Public Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As object) As Object

            If ((context IsNot Nothing) And (context.Instance IsNot Nothing) And (provider IsNot Nothing)) Then

                edSvc = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (edSvc IsNot Nothing) Then

                    Dim trackBar As FlashTrackBar = New FlashTrackBar()
                    AddHandler trackBar.ValueChanged, AddressOf Me.ValueChanged
                    SetEditorProps(CType(context.Instance, FlashTrackBar), TrackBar)

                    Dim asInt As Boolean = True

                    If (TypeOf value Is Integer) Then
                        trackBar.Value = CInt(value)
                    ElseIf (TypeOf value Is System.Byte) Then
                        asInt = False
                        trackBar.Value = CType(value, Byte)
                    End If

                    edSvc.DropDownControl(trackBar)

                    If (asInt) Then
                        value = trackBar.Value
                    Else
                        value = CType(trackBar.Value, Byte)
                    End If

                End If

            End If

            Return value

         End Function

        Overrides OverLoads Public Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
            If ((context IsNot Nothing) And (context.Instance IsNot Nothing)) Then
                Return UITypeEditorEditStyle.DropDown
            End If
            Return MyBase.GetEditStyle(context)
        End Function

        private Sub ValueChanged(sender As object, e As EventArgs)
            If (edSvc IsNot Nothing) Then
                edSvc.CloseDropDown()
            End If
        End Sub

    End Class

End Namespace
' </snippet20>