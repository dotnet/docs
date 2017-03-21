      public override void Dispose()
      {
         try
         {
            Context.Response.Write("Disposing " + ToString());
            // Perform resource cleanup.
            myTextWriter.Close();
            myButton.Dispose();
         }
         catch(Exception myException)
         {
            Context.Response.Write("Exception occurred: "+myException.Message);
         }
      }