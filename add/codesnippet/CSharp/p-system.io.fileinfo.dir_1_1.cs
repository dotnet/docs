        string   fileName = @"C:\TMP\log.txt";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        Console.WriteLine("{0} has a directoryName of {1}",
            fileName, fileInfo.DirectoryName);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\TMP\log.txt has a directory name of C:\TMP
         */