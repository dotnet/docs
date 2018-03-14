Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic

Namespace Samples.VB

    Public Class SampleTextBox
        Inherits TextBox
        Implements IScriptControl

        Private _highlightCssClass As String
        Private _noHighlightCssClass As String
        Private sm As ScriptManager

        Public Property HighlightCssClass() As String
            Get
                Return _highlightCssClass
            End Get
            Set(ByVal value As String)
                _highlightCssClass = value
            End Set
        End Property

        Public Property NoHighlightCssClass() As String
            Get
                Return _noHighlightCssClass
            End Get
            Set(ByVal value As String)
                _noHighlightCssClass = value
            End Set
        End Property

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not Me.DesignMode Then

                ' Test for ScriptManager and register if it exists
                sm = ScriptManager.GetCurrent(Page)

                If sm Is Nothing Then _
                    Throw New HttpException("A ScriptManager control must exist on the current page.")

                sm.RegisterScriptControl(Me)
            End If

            MyBase.OnPreRender(e)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            If Not Me.DesignMode Then _
              sm.RegisterScriptDescriptors(Me)

            MyBase.Render(writer)
        End Sub
' <Snippet14>
        Protected Overridable Function GetScriptReferences() As IEnumerable(Of ScriptReference)
            Dim reference As ScriptReference = New ScriptReference()
			reference.Assembly = "Samples"
			reference.Name = "Samples.SampleTextBox.js"

            Return New ScriptReference() {reference}
        End Function
' </Snippet14>
        Protected Overridable Function GetScriptDescriptors() As IEnumerable(Of ScriptDescriptor)
            Dim descriptor As ScriptControlDescriptor = New ScriptControlDescriptor("Samples.SampleTextBox", Me.ClientID)
            descriptor.AddProperty("highlightCssClass", Me.HighlightCssClass)
            descriptor.AddProperty("nohighlightCssClass", Me.NoHighlightCssClass)

            Return New ScriptDescriptor() {descriptor}
        End Function

        Function IScriptControlGetScriptReferences() As IEnumerable(Of ScriptReference) Implements IScriptControl.GetScriptReferences
            Return GetScriptReferences()
        End Function

        Function IScriptControlGetScriptDescriptors() As IEnumerable(Of ScriptDescriptor) Implements IScriptControl.GetScriptDescriptors
            Return GetScriptDescriptors()
        End Function
    End Class
End Namespace
