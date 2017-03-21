        private void getNewStreamReader() 
        {
            //Get a new StreamReader in ASCII format from a
            //file using a buffer and byte order mark detection
            StreamReader srAsciiFromFileFalse512 = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII, false, 512);
            //Get a new StreamReader in ASCII format from a
            //file with byte order mark detection = false
            StreamReader srAsciiFromFileFalse = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII, false);
            //Get a new StreamReader in ASCII format from a file 
            StreamReader srAsciiFromFile = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII);
            //Get a new StreamReader from a
            //file with byte order mark detection = false
            StreamReader srFromFileFalse = 
                new StreamReader("C:\\Temp\\Test.txt", false);
            //Get a new StreamReader from a file
            StreamReader srFromFile = 
                new StreamReader("C:\\Temp\\Test.txt");
            //Get a new StreamReader in ASCII format from a
            //FileStream with byte order mark detection = false and a buffer
            StreamReader srAsciiFromStreamFalse512 = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII, false, 512);
            //Get a new StreamReader in ASCII format from a
            //FileStream with byte order mark detection = false
            StreamReader srAsciiFromStreamFalse = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII, false);
            //Get a new StreamReader in ASCII format from a FileStream
            StreamReader srAsciiFromStream = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            //Get a new StreamReader from a
            //FileStream with byte order mark detection = false
            StreamReader srFromStreamFalse = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"), 
                false);
            //Get a new StreamReader from a FileStream
            StreamReader srFromStream = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"));
        }