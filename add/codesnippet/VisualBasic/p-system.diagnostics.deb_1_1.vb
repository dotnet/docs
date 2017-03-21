<DebuggerDisplay("{value}", Name := "{key}")>  _
Friend Class KeyValuePairs
    Private dictionary As IDictionary
    Private key As Object
    Private value As Object
    
    
    Public Sub New(ByVal dictionary As IDictionary, ByVal key As Object, ByVal value As Object) 
        Me.value = value
        Me.key = key
        Me.dictionary = dictionary

    End Sub 'New
End Class 'KeyValuePairs