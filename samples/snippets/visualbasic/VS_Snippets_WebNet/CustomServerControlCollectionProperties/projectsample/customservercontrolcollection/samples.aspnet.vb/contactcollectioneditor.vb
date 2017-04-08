' ContactCollectionEditor.vb
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Reflection

Namespace Samples.AspNet.VB.Controls
    Public Class ContactCollectionEditor
        Inherits CollectionEditor

        Public Sub New(ByVal newType As Type)
            MyBase.new(newType)
        End Sub

        Protected Overrides Function CanSelectMultipleInstances() _
        As Boolean
            Return False
        End Function

        Protected Overrides Function CreateCollectionItemType() As Type
            Return GetType(Contact)
        End Function
    End Class
End Namespace
