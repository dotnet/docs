    ' Create an event collection.
    ' Add to it the created simulatedEvents.
    Public Shared Sub AddEvents() 
        events = _
        New System.Web.Management.WebBaseEventCollection(simulatedEvents)
    
    End Sub 'AddEvents
    
    