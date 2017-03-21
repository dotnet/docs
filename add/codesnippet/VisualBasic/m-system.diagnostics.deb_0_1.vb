<DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(GetType(MyHashtable.HashtableDebugView))> _
Class MyHashtable
    Inherits Hashtable
    Private Const TestString As String = "This should not appear in the debug window."

    Friend Class HashtableDebugView
        Private hashtable As Hashtable
        Public Shared TestString As String = "This should appear in the debug window."

        Public Sub New(ByVal hashtable As Hashtable)
            Me.hashtable = hashtable
        End Sub 'New

        <DebuggerBrowsable(DebuggerBrowsableState.RootHidden)> _
        ReadOnly Property Keys as KeyValuePairs()
            Get
                Dim nkeys(hashtable.Count) as KeyValuePairs

                Dim i as Integer = 0
                For Each key As Object In hashtable.Keys
                    nkeys(i) = New KeyValuePairs(hashtable, key, hashtable(key))
                    i = i + 1
                Next
                Return nkeys
            End Get
        End Property

    End Class 'HashtableDebugView
End Class 'MyHashtable