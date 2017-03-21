        ' This example method creates a DesignerEventArgs using the specified designer host.
        ' Typically, this type of event args is created by the IDesignerEventService.  
        Public Function CreateComponentEventArgs(ByVal host As IDesignerHost) As DesignerEventArgs

            Dim args As New DesignerEventArgs(host)

            ' The designer host of the created or disposed document:  args.Component

            Return args

        End Function