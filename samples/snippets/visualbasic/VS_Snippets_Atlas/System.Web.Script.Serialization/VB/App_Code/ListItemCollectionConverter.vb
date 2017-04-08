 ' <Snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Web.UI.WebControls
Imports System.Collections

Namespace System.Web.Script.Serialization.VB

    Public Class ListItemCollectionConverter
        Inherits JavaScriptConverter

        ' <Snippet3>
        Public Overrides ReadOnly Property SupportedTypes() As _
            System.Collections.Generic.IEnumerable(Of System.Type)
            Get
                ' Define the ListItemCollection as a supported type.
                Return New ReadOnlyCollection(Of Type)(New List(Of Type) _
                (New Type() {GetType(ListItemCollection)}))
            End Get
        End Property
        ' </Snippet3>

        Public Overrides Function Serialize(ByVal obj As Object, _
            ByVal serializer As JavaScriptSerializer) As _
            System.Collections.Generic.IDictionary(Of String, Object)

            Dim listType As ListItemCollection = CType(obj, ListItemCollection)

            If Not (listType Is Nothing) Then

                ' Create the representation.
                Dim result As New Dictionary(Of String, Object)

                Dim itemsList As New ArrayList()
                Dim item As ListItem
                For Each item In listType
                    ' Add each entry to the dictionary.
                    Dim listDict As New Dictionary(Of String, Object)
                    listDict.Add("Value", item.Value)
                    listDict.Add("Text", item.Text)
                    itemsList.Add(listDict)
                Next item
                result("List") = itemsList

                Return result
            End If
            Return New Dictionary(Of String, Object)
        End Function

        Public Overrides Function Deserialize(ByVal dictionary As _
            System.Collections.Generic.IDictionary(Of String, Object), _
            ByVal type As System.Type, ByVal serializer As JavaScriptSerializer) As Object

            If dictionary Is Nothing Then
                Throw New ArgumentNullException("dictionary")
            End If

            If type Is GetType(ListItemCollection) Then
                ' Create the instance to deserialize into.
                Dim list As New ListItemCollection()

                ' Deserialize the ListItemCollection's items.
                ' <Snippet5>
                Dim itemsList As ArrayList = CType(dictionary("List"), ArrayList)
                Dim i As Integer
                For i = 0 To itemsList.Count - 1
                    list.Add(serializer.ConvertToType(Of ListItem)(itemsList(i)))
                Next i
                ' </Snippet5>

                Return list
            End If

            Return Nothing

        End Function
    End Class
End Namespace
' </Snippet2>