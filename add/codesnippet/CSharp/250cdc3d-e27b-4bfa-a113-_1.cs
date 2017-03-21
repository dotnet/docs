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