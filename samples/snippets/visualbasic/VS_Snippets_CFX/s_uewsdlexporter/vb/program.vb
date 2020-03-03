'<Snippet0>
Imports System.ServiceModel
Imports System.ServiceModel.Description

Module Module1

    Sub Main()
        '<Snippet1>
        Dim exporter As New WsdlExporter()
        '</Snippet1>   
        '<Snippet2>
        exporter.PolicyVersion = PolicyVersion.Policy15
        '</Snippet2>

        '<Snippet3>
        Dim myServiceEndpoints() As ServiceEndpoint = New ServiceEndpoint(1) {}
        Dim myDescription As New ContractDescription("myContract")
        myServiceEndpoints(0) = New ServiceEndpoint(myDescription, New BasicHttpBinding(), New EndpointAddress("http://localhost/myservice"))
        myServiceEndpoints(1) = New ServiceEndpoint(myDescription, New BasicHttpBinding(), New EndpointAddress("http://localhost/myservice"))
        '</Snippet3>

        '<Snippet4>
        'Export all endpoints for each endpoint in collection.
        For Each endpoint As ServiceEndpoint In myServiceEndpoints
            exporter.ExportEndpoint(endpoint)
        Next
        '</Snippet4>

        '<Snippet5>
        'If there are no errors, get the documents.
        Dim metadataDocs As MetadataSet
        metadataDocs = Nothing

        If (exporter.Errors.Count = 0) Then
            metadataDocs = exporter.GetGeneratedMetadata()
        End If
        '</Snippet5>
    End Sub

End Module
' </Snippet0>
