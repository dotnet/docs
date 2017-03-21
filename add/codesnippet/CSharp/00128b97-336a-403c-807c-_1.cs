            // Remove elements in mediaFiles1 that are also in mediaFiles2.
            Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...");
            Console.WriteLine("\tCount before: {0}", mediaFiles1.Count.ToString());
            mediaFiles1.ExceptWith(mediaFiles2);
            Console.WriteLine("\tCount after: {0}", mediaFiles1.Count.ToString());