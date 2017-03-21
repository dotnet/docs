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