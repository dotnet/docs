    ' This method is only used in the design-time framework 
    ' and by the obsolete DataGrid control.
    Public Function GetListName( _
    ByVal listAccessors() As PropertyDescriptor) As String _
    Implements System.ComponentModel.ITypedList.GetListName

        Return GetType(Tkey).Name

    End Function