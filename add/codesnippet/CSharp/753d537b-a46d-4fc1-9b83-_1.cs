            // Create a sorted set using the ByFileExtension comparer.
            SortedSet<string> mediaFiles1 =
                new SortedSet<string>(new ByFileExtension());