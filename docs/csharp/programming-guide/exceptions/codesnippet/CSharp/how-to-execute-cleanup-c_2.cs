        static void CodeWithCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = null;

            try
            {
                fileInfo = new System.IO.FileInfo("C:\\file.txt");

                file = fileInfo.OpenWrite();
                file.WriteByte(0xF);
            }
            catch(System.UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }