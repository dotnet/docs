    <DefaultEvent("CollectionChanged")> _ 
    Public Class MyCollection
        Inherits BaseCollection

        Public Event CollectionChanged (ByVal sender As Object, _
            ByVal e As CollectionChangeEventArgs)
        
        ' Insert additional code.
    End Class 'MyCollection