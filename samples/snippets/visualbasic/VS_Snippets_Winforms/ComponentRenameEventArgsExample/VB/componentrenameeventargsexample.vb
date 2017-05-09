Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class ComponentRenameEventArgsExample

        Public Sub New()
        End Sub 'New

        '<Snippet1>
        ' This example method creates a ComponentRenameEventArgs using the specified arguments.
        ' Typically, this type of event args is created by a design mode subsystem.  
        Public Function CreateComponentRenameEventArgs(ByVal component As Object, ByVal oldName As String, ByVal newName As String) As ComponentRenameEventArgs
            Dim args As New ComponentRenameEventArgs(component, oldName, newName)

            ' The component that was renamed:          args.Component
            ' The previous name of the component:      args.OldName
            ' The new name of the component:           args.NewName            

            Return args
        End Function
        '</Snippet1>

    End Class 'ComponentRenameEventArgsExample 
End Namespace 'MiscCompModSamples