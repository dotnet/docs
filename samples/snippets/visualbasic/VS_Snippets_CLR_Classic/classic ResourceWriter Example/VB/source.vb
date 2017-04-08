' <Snippet1>
Imports System
Imports System.Resources

Public Class WriteResources
    
    Public Shared Sub Main()
        
        ' Creates a resource writer.
        Dim writer As New ResourceWriter("myResources.resources")
        
        ' Adds resources to the resource writer.
        writer.AddResource("String 1", "First String")
        
        writer.AddResource("String 2", "Second String")
        
        writer.AddResource("String 3", "Third String")
        
        ' Writes the resources to the file or stream, and closes it.
        writer.Close()
    End Sub
End Class
' </Snippet1>