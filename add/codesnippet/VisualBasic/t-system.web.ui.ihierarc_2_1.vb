
    Public Class FileSystemHierarchicalEnumerable
        Inherits ArrayList
        Implements IHierarchicalEnumerable

        Public Sub New()
        End Sub


        Public Overridable Function GetHierarchyData( _
            ByVal enumeratedItem As Object) As IHierarchyData _
            Implements IHierarchicalEnumerable.GetHierarchyData

            Return CType(enumeratedItem, IHierarchyData)
        End Function

    End Class
