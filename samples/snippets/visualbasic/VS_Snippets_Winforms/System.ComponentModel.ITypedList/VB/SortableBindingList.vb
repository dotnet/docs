' <snippet1>
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Windows.Forms

<Serializable()> _
Public Class SortableBindingList(Of Tkey)
    Inherits BindingList(Of Tkey)
    Implements ITypedList

    <NonSerialized()> _
    Private properties As PropertyDescriptorCollection

    Public Sub New()
        MyBase.New()

        ' Get the 'shape' of the list. 
        ' Only get the public properties marked with Browsable = true.
        Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(Tkey), New Attribute() {New BrowsableAttribute(True)})

        ' Sort the properties.
        properties = pdc.Sort()

    End Sub

    ' <snippet2>
#Region "ITypedList Implementation"

    ' <snippet3>
    Public Function GetItemProperties(ByVal listAccessors() As System.ComponentModel.PropertyDescriptor) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ITypedList.GetItemProperties

        Dim pdc As PropertyDescriptorCollection

        If (Not (listAccessors Is Nothing)) And (listAccessors.Length > 0) Then
            ' Return child list shape
            pdc = ListBindingHelper.GetListItemProperties(listAccessors(0).PropertyType)
        Else
            ' Return properties in sort order
            pdc = properties
        End If

        Return pdc

    End Function
    ' </snippet3>

    ' <snippet4>
    ' This method is only used in the design-time framework 
    ' and by the obsolete DataGrid control.
    Public Function GetListName( _
    ByVal listAccessors() As PropertyDescriptor) As String _
    Implements System.ComponentModel.ITypedList.GetListName

        Return GetType(Tkey).Name

    End Function
    ' </snippet4>

#End Region
    ' </snippet2>

End Class
' </snippet1>