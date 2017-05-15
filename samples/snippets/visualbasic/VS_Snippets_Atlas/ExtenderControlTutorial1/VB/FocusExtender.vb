'<Snippet1>
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

    '<Snippet12>
    <TargetControlType(GetType(Control))> _
    Public Class FocusExtender
        Inherits ExtenderControl
        '</Snippet12>

        Private _highlightCssClass As String
        Private _noHighlightCssClass As String

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

        '<Snippet4>
        Protected Overrides Function GetScriptReferences() As IEnumerable(Of ScriptReference)
            Dim reference As ScriptReference = New ScriptReference()
            reference.Path = ResolveClientUrl("FocusBehavior.js")

            Return New ScriptReference() {reference}
        End Function

        Protected Overrides Function GetScriptDescriptors(ByVal targetControl As Control) As IEnumerable(Of ScriptDescriptor)
            Dim descriptor As ScriptBehaviorDescriptor = New ScriptBehaviorDescriptor("Samples.FocusBehavior", targetControl.ClientID)
            descriptor.AddProperty("highlightCssClass", Me.HighlightCssClass)
            descriptor.AddProperty("nohighlightCssClass", Me.NoHighlightCssClass)

            Return New ScriptDescriptor() {descriptor}
        End Function
        '</Snippet4>
    End Class
End Namespace
'</Snippet1>
