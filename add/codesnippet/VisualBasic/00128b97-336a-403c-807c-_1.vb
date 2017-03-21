            ' Remove elements in mediaFiles1 that are also in mediaFiles2.
            Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...")
            Console.WriteLine(vbTab & "Count before: {0}", _
                    mediaFiles1.Count.ToString)
            mediaFiles1.ExceptWith(mediaFiles2)
            Console.WriteLine(vbTab & "Count after: {0}", _
                    mediaFiles1.Count.ToString)