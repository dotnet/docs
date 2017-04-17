Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamples

    Public Class ActiveDesignerEventHandlerExample

        Public Sub New()
        End Sub 'New

        '<Snippet1>
        Public Sub LinkActiveDesignerEvent(ByVal eventService As IDesignerEventService)
            ' Registers an event handler for the ActiveDesignerChanged event.
            AddHandler eventService.ActiveDesignerChanged, AddressOf Me.OnActiveDesignerEvent
        End Sub

        Private Sub OnActiveDesignerEvent(ByVal sender As Object, ByVal e As ActiveDesignerEventArgs)
            ' Displays changed designer information on the console.            
            If (e.NewDesigner.RootComponent.Site IsNot Nothing) Then
                Console.WriteLine(("Name of the component of the new active designer: " + e.NewDesigner.RootComponent.Site.Name))
            End If
            Console.WriteLine(("Type of the component of the new active designer: " + e.NewDesigner.RootComponentClassName))
            If (e.OldDesigner.RootComponent.Site IsNot Nothing) Then
                Console.WriteLine(("Name of the component of the previously active designer: " + e.OldDesigner.RootComponent.Site.Name))
            End If
            Console.WriteLine(("Type of the component of the previously active designer: " + e.OldDesigner.RootComponentClassName))
        End Sub
        '</Snippet1>

    End Class 'ActiveDesignerEventHandlerExample
End Namespace 'MiscCompModSamples