            ' Create a set of the sets.
            Dim comparer As IEqualityComparer(Of SortedSet(Of String)) = _
                SortedSet(Of String).CreateSetComparer()
            Dim allMedia As HashSet(Of SortedSet(Of String)) = _
                    New HashSet(Of SortedSet(Of String))(comparer)
            allMedia.Add(mediaFiles1)
            allMedia.Add(mediaFiles2)