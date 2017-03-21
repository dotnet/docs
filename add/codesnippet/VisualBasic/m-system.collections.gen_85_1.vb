            ' Remove elements that have non-media extensions. See the 'isDoc' method.
            Console.WriteLine("Remove docs from the set...")
            Console.WriteLine(vbTab & "Count before: {0}", mediaFiles1.Count.ToString)
            mediaFiles1.RemoveWhere(AddressOf isDoc)
            Console.WriteLine(vbTab & "Count after: {0}", mediaFiles1.Count.ToString)