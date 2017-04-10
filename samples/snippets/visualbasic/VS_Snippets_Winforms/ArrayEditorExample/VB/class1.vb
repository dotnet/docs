Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design

Public Class ArrayEditorTestComponent
    Inherits Component

    '<Snippet1>
    <EditorAttribute(GetType(ArrayEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property componentArray() As Object()
        Get
            Return compArray
        End Get
        Set(ByVal Value As Object())
            compArray = Value
        End Set
    End Property
    Private compArray() As Object
    '</Snippet1>

    Public Sub New()
        compArray = New Component() {New Component, New Component, Me}
    End Sub

End Class