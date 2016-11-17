    public class EHClass
    {
        void ReadFile(int index)
        {
            // To run this code, substitute a valid path from your local machine
            string path = @"c:\users\public\test.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            char[] buffer = new char[10];
            try
            {
                file.ReadBlock(buffer, index, buffer.Length);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message);
            }
            
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
            // Do something with buffer...
        }

    }
    