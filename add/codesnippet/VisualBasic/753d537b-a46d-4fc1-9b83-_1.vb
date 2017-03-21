            ' Create a sorted set using the ByFileExtension comparer.
            Dim mediaFiles1 As SortedSet(Of String) = _
                New SortedSet(Of String)(New ByFileExtension)