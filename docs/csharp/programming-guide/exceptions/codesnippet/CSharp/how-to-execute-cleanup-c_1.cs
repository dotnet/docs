        static void CodeWithoutCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("C:\\file.txt");

            file = fileInfo.OpenWrite();
            file.WriteByte(0xF);

            file.Close();
        }