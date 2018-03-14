Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class MyClass1
    
    ' <Snippet1>
    <DefaultEvent("CollectionChanged")> _ 
    Public Class MyCollection
        Inherits BaseCollection

        Public Event CollectionChanged (ByVal sender As Object, _
            ByVal e As CollectionChangeEventArgs)
        
        ' Insert additional code.
    End Class 'MyCollection
    ' </Snippet1>
    ' <Snippet2>
    Public Shared Function Main() As Integer
        ' Creates a new collection.
        Dim myNewCollection As New MyCollection()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewCollection)
        
        ' Prints the name of the default event by retrieving the
        ' DefaultEventAttribute from the AttributeCollection. 
        Dim myAttribute As DefaultEventAttribute = _
            CType(attributes(GetType(DefaultEventAttribute)), DefaultEventAttribute)
        Console.WriteLine(("The default event is: " & myAttribute.Name))
        Return 0
    End Function 'Main
    ' </Snippet2>
End Class 'MyClass1
