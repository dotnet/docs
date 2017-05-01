Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class DesignerEventHandlerExample

        Public Sub New()
        End Sub

        '<Snippet1>
        Public Sub LinkDesignerEvent(ByVal eventService As IDesignerEventService)
            ' Registers an event handler for the DesignerCreated and DesignerDisposed events.
            AddHandler eventService.DesignerCreated, AddressOf Me.OnDesignerEvent
            AddHandler eventService.DesignerDisposed, AddressOf Me.OnDesignerEvent
        End Sub

        Private Sub OnDesignerEvent(ByVal sender As Object, ByVal e As DesignerEventArgs)
            ' Displays designer event information on the console.
            Console.WriteLine(("Name of the root component of the created or disposed designer: " + e.Designer.RootComponentClassName))
        End Sub
        '</Snippet1>

    End Class
End Namespace