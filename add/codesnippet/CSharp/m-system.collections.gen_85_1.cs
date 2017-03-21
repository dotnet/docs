            // Remove elements that have non-media extensions.
            // See the 'isDoc' method.
            Console.WriteLine("Remove docs from the set...");
            Console.WriteLine("\tCount before: {0}", mediaFiles1.Count.ToString());
            mediaFiles1.RemoveWhere(isDoc);
            Console.WriteLine("\tCount after: {0}", mediaFiles1.Count.ToString());