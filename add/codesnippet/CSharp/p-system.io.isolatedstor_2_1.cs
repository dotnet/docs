            StreamWriter writer = new StreamWriter(isoStream);
            // Update the data based on the new inputs.
            writer.WriteLine(this.NewsUrl);
            writer.WriteLine(this.SportsUrl);

            // Calculate the amount of space used to record this user's preferences.
            double d = isoFile.CurrentSize / isoFile.MaximumSize;
            Console.WriteLine("CurrentSize = " + isoFile.CurrentSize.ToString());
            Console.WriteLine("MaximumSize = " + isoFile.MaximumSize.ToString());