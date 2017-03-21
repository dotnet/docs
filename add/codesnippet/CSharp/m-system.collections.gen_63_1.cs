            // List all the avi files.
            SortedSet<string> aviFiles = mediaFiles1.GetViewBetween("avi", "avj");

            Console.WriteLine("AVI files:");
            foreach (string avi in aviFiles)
            {
                Console.WriteLine("\t{0}", avi);
            }