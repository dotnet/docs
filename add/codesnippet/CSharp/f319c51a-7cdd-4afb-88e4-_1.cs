            // Create a set of the sets.
            IEqualityComparer<SortedSet<string>> comparer =
                SortedSet<string>.CreateSetComparer();

            HashSet<SortedSet<string>> allMedia =
                new HashSet<SortedSet<string>>(comparer);
            allMedia.Add(mediaFiles1);
            allMedia.Add(mediaFiles2);