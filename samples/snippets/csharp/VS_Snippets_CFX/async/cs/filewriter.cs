//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.Activities;

namespace Microsoft.Samples.WorkflowModel
{
    // <Snippet0>
    public sealed class FileWriter : AsyncCodeActivity
    {
        public FileWriter()
            : base() 
        { 
        }
        // <Snippet1>
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            string tempFileName = Path.GetTempFileName();
            Console.WriteLine("Writing to file: " + tempFileName);

            FileStream file = File.Open(tempFileName, FileMode.Create);

            context.UserState = file;

            byte[] bytes = UnicodeEncoding.Unicode.GetBytes("123456789");
            return file.BeginWrite(bytes, 0, bytes.Length, callback, state);
        }
        // </Snippet1>
        // <Snippet2>
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
    // </Snippet2>
    // </Snippet0>
}
