Class MainWindow 

    '<SnippetHandler>
    Private eventstr As New Text.StringBuilder()

    Private Sub HandleClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
        ' Get the element that handled the event.
        Dim fe As FrameworkElement = DirectCast(sender, FrameworkElement)
        eventstr.Append("Event handled by element named ")
        eventstr.Append(fe.Name)
        eventstr.Append(vbLf)

        ' Get the element that raised the event. 
        Dim fe2 As FrameworkElement = DirectCast(args.Source, FrameworkElement)
        eventstr.Append("Event originated from source element of type ")
        eventstr.Append(args.Source.[GetType]().ToString())
        eventstr.Append(" with Name ")
        eventstr.Append(fe2.Name)
        eventstr.Append(vbLf)

        ' Get the routing strategy.
        eventstr.Append("Event used routing strategy ")
        eventstr.Append(args.RoutedEvent.RoutingStrategy)
        eventstr.Append(vbLf)

        results.Text = eventstr.ToString()
    End Sub
    '</SnippetHandler>

End Class
