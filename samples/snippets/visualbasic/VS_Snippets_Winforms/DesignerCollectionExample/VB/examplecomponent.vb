Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class ExampleComponent
    Inherits Component

    Public Sub New()
        Dim designerhost1 As IDesignerHost = Nothing
        Dim designerhost2 As IDesignerHost = Nothing
        '<Snippet1>            
        ' Create a DesignerCollection using a constructor
        ' that accepts an array of IDesignerHost objects with
        ' which to initialize the collection.
        Dim collection As New DesignerCollection(New IDesignerHost() {designerhost1, designerhost2})
        '</Snippet1>
    End Sub

    Public Sub OutputDesignerCollectionInfo(ByVal collection As DesignerCollection)
        '<Snippet2>
        ' Get the number of elements in the collection.
        Dim count As Integer = collection.Count
        '</Snippet2>

        '<Snippet3>
        ' Access each IDesignerHost in the DesignerCollection using
        ' the collection's indexer property, and output the class name 
        ' of the root component associated with each IDesignerHost.            
        Dim i As Integer
        For i = 0 To collection.Count - 1
            Console.WriteLine(collection(i).RootComponentClassName)
        Next i
        '</Snippet3>
    End Sub

End Class