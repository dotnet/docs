    public sealed class FileWriter : AsyncCodeActivity
    {
        public FileWriter()
            : base() 
        { 
        }
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            string tempFileName = Path.GetTempFileName();
            Console.WriteLine("Writing to file: " + tempFileName);

            FileStream file = File.Open(tempFileName, FileMode.Create);

            context.UserState = file;

            byte[] bytes = UnicodeEncoding.Unicode.GetBytes("123456789");
            return file.BeginWrite(bytes, 0, bytes.Length, callback, state);
        }
        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            FileStream file = (FileStream)context.UserState;
            
            try
            {
                file.EndWrite(result);
                file.Flush();
            }
            finally
            {
                file.Close();
            }
        }
    }