
Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    
        '<Snippet99>
        Dim model As New MetaModel
        model.RegisterContext(GetType(AdventureWorksLTDataContext), _
           New ContextConfiguration() With {.ScaffoldAllTables = True})
        '</Snippet99>
        
   
End Sub

