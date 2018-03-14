Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class ComponentEventHandlerExample

        Public Sub New()
        End Sub

        '<Snippet1>
        Public Sub LinkComponentEvent(ByVal changeService As IComponentChangeService)
            ' Registers an event handler for the ComponentAdded,
            ' ComponentAdding, ComponentRemoved, and ComponentRemoving events.
            AddHandler changeService.ComponentAdded, AddressOf Me.OnComponentEvent
            AddHandler changeService.ComponentAdding, AddressOf Me.OnComponentEvent
            AddHandler changeService.ComponentRemoved, AddressOf Me.OnComponentEvent
            AddHandler changeService.ComponentRemoving, AddressOf Me.OnComponentEvent
        End Sub

        Private Sub OnComponentEvent(ByVal sender As Object, ByVal e As ComponentEventArgs)
            ' Displays changed component information on the console.            
            If (e.Component.Site IsNot Nothing) Then
                Console.WriteLine(("Name of the component related to the event: " + e.Component.Site.Name))
            End If
        End Sub
        '</Snippet1>

    End Class 'ComponentEventHandlerExample 
End Namespace 'MiscCompModSamples