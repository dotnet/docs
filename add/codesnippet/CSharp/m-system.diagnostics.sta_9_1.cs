      public void InternalMethod()
      {
         try
         {
            ClassLevel2 nestedClass = new ClassLevel2();
            nestedClass.Level2Method();
         }
         catch (Exception e)
         {
            Console.WriteLine(" InternalMethod exception handler");

            // Build a stack trace from one frame, skipping the
            // current frame and using the next frame.  By
            // default, file and line information are not displayed.
            StackTrace st = new StackTrace(new StackFrame(1));
            Console.WriteLine(" Stack trace for next level frame: {0}",
               st.ToString());
            Console.WriteLine(" Stack frame for next level: ");
            Console.WriteLine("   {0}", st.GetFrame(0).ToString());

            Console.WriteLine(" Line Number: {0}",
               st.GetFrame(0).GetFileLineNumber().ToString());

            Console.WriteLine();
            Console.WriteLine("   ... throwing exception to next level ...");
            Console.WriteLine("-------------------------------------------------\n");
            throw e;
         }
      }